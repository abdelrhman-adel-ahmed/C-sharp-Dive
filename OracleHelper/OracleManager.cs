using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace OracleHelper
{
    public enum DatabaseConnection
    {
        ConnectionString = 0,
        LogConnectionString = 1,
        LDMDevelopment = 2,
        WebResult = 3
    }
    public class OracleManager : IDisposable
    {
        public delegate string PrepareConnectionStringDelegate(string connectionString);
        public static PrepareConnectionStringDelegate PrepareConnectionStringEvent = null;

        // This flag to disable session parallel query if needed as ALA (LDM) case
        public static bool IsDisableSessionParallelQuery = false;

        private Hashtable returnedParameters;
        private OracleCommand command;
        private OracleConnection connection;
        private DataSet dataSet;
        private DataTable dataTable;
        private OracleDataAdapter adapter;
        private OracleTransaction transaction;
        private CommandParameterCollection parameterCollection;

        private IDBMetaDataLinker dBMetaDataLinker;

        private Action<DataTable> onGetDataTableAction;
        private Action<DataSet> onGetDataSetAction;

        public CommandParameterCollection CommandParameters
        {
            get
            {
                return this.parameterCollection;
            }
        }


        public Hashtable ReturnedParameters
        {
            get
            {
                if (returnedParameters == null)
                {
                    returnedParameters = new Hashtable();
                }

                return returnedParameters;
            }
        }

        #region Constructors

        public OracleManager(string connectionString)
        {
            IntializeInstances(connectionString);
        }

        public OracleManager(DatabaseConnection databaseConnection)
        {
            string connectionString;

            switch (databaseConnection)
            {
                case DatabaseConnection.LogConnectionString:
                    connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LogConnectionString"].ConnectionString; ;
                    break;
                case DatabaseConnection.WebResult:
                    connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["WebResultConnectionString"].ConnectionString; ;
                    break;
                case DatabaseConnection.ConnectionString:
                default:
                    connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    break;
            }

            IntializeInstances(connectionString);
        }

        public OracleManager()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            IntializeInstances(connectionString);
        }

        #endregion

        public void CheckNull(object obj)
        {
            if (obj != null)
            {
                Type CurrentT = obj.GetType();
                System.Reflection.PropertyInfo[] pros = CurrentT.GetProperties();
                foreach (System.Reflection.PropertyInfo pro in pros)
                {
                    object[] atts = pro.GetCustomAttributes(typeof(NotNullableAttribute), false);
                    if (atts.Length > 0 && pro.GetValue(obj, null) == null)
                    {
                        throw new InvalidOperationException(string.Format("Value of this Property {0} in class {1} can't be Null", pro.Name, obj.GetType().Name));
                    }
                }
            }
        }

        public void CloseConnection()
        {
            try
            {
                connection.Close();
                //connection.Dispose();                
            }
            catch (Exception exception)
            {
                DataAccessHandler.Handle(exception, this.GetType().Name, MethodInfo.GetCurrentMethod().Name, "Connection Error", null, ErrorType.Critical);
                throw;
            }
        }

        public void CommitTransactionalConnection()
        {
            try
            {
                transaction.Commit();
                CloseConnection();
            }
            catch (Exception exception)
            {
                DataAccessHandler.Handle(exception, this.GetType().Name, MethodInfo.GetCurrentMethod().Name, "Connection Error", null, ErrorType.Critical);
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int ExcuteNonQuery(string commandText, CommandType commandType)
        {
            ReturnedParameters.Clear();

            this.FillCommandParam(commandText, commandType);

            int returnedValue = command.ExecuteNonQuery();

            FillRetrunParams();

            this.command.Parameters.Clear();

            return returnedValue;
        }

        public OracleDataReader ExcuteReader(string commandText, CommandType commandType)
        {
            ReturnedParameters.Clear();

            FillCommandParam(commandText, commandType);

            OracleDataReader read = command.ExecuteReader();

            FillRetrunParams();

            this.command.Parameters.Clear();

            return read;
        }

        public object ExcuteScaler(string commandText, CommandType commandType)
        {
            ReturnedParameters.Clear();

            FillCommandParam(commandText, commandType);

            object result = command.ExecuteScalar();

            FillRetrunParams();

            command.Parameters.Clear();

            return result;
        }

        public DataSet GetDataSet(string commandText, CommandType commandType)
        {

            ReturnedParameters.Clear();

            FillCommandParam(commandText, commandType);

            adapter.SelectCommand = this.command;
            dataSet.Clear();
            dataSet.Tables.Clear();
            adapter.Fill(dataSet);
            FillRetrunParams();
            command.Parameters.Clear();

            // onAction
            if (onGetDataSetAction != null)
            {
                onGetDataSetAction(dataSet);
            }

            return dataSet;
        }

        public DataTable getDataTable(string commandText, CommandType commandType)
        {
            this.ReturnedParameters.Clear();

            this.FillCommandParam(commandText, commandType);

            this.dataTable = new DataTable();

            this.adapter.SelectCommand = this.command;

            this.adapter.Fill(dataTable);

            FillRetrunParams();

            this.command.Parameters.Clear();

            // onAction
            if (onGetDataTableAction != null)
            {
                onGetDataTableAction(dataTable);
            }

            return dataTable;
        }

        public bool IsLiveConnection()
        {
            bool status = true;

            try
            {
                if (connection != null)
                {
                    if (connection.State != ConnectionState.Closed)
                    {
                        status = true;
                    }
                    else
                    {
                        status = false;
                    }
                }

                return status;
            }
            catch (Exception exception)
            {
                DataAccessHandler.Handle(exception, this.GetType().Name, MethodInfo.GetCurrentMethod().Name, "Connection Error", null, ErrorType.Critical);
                throw;
            }
        }

        public IDbConnection Connection
        {
            get
            {
                return connection;
            }
        }

        public OracleConnection OpenConnection()
        {
            try
            {
                command.CommandTimeout = 10000000;

                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                CheckSessionParallelQueryToBeDisabledOrNot();

                return connection;
            }
            catch (Exception exception)
            {
                DataAccessHandler.Handle(exception, this.GetType().Name, MethodInfo.GetCurrentMethod().Name, "Connection Error", null, Enums.ErrorType.Critical);
                throw;
            }
        }


        public void OpenTransactionalConnection()
        {
            OpenTransactionalConnection(IsolationLevel);
        }

        public void OpenTransactionalConnection(System.Data.IsolationLevel isolationLevel)
        {
            try
            {
                this.OpenConnection();
                this.transaction = this.connection.BeginTransaction(isolationLevel);
                this.command.Transaction = transaction;

                CheckSessionParallelQueryToBeDisabledOrNot();
            }
            catch (Exception exception)
            {
                DataAccessHandler.Handle(exception, this.GetType().Name, MethodInfo.GetCurrentMethod().Name, "Connection Error", null, ErrorType.Critical);
                throw;
            }
        }

        public void RollbackTransactionalConnection()
        {
            try
            {
                this.transaction.Rollback();
                CloseConnection();
                // this.transaction.Dispose();
            }
            catch (Exception exception)
            {
                DataAccessHandler.Handle(exception, this.GetType().Name, MethodInfo.GetCurrentMethod().Name, "Connection Error", null, ErrorType.Critical);
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dataTable != null)
                {
                    dataTable.Dispose();
                    dataTable = null;
                }

                if (adapter != null)
                {
                    adapter.Dispose();
                    adapter = null;
                }


                if (dataSet != null)
                {
                    dataSet.Dispose();
                    dataSet = null;
                }

                if (connection != null)
                {
                    connection.Dispose();
                    connection = null;
                }

                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }

                if (transaction != null)
                {
                    transaction.Dispose();
                    transaction = null;
                }

                returnedParameters = null;
            }

        }

        private void IntializeInstances(string connectionString)
        {
            if (PrepareConnectionStringEvent != null)
            {
                connectionString = PrepareConnectionStringEvent(connectionString);

            }
            connection = new OracleConnection(connectionString);
            command = new OracleCommand();
            this.parameterCollection = new CommandParameterCollection(command.Parameters);
            command.CommandTimeout = 70;
            command.Connection = connection;
            dataSet = new DataSet();
            dataTable = new DataTable();
            adapter = new OracleDataAdapter();

            dBMetaDataLinker = IocContainer.ResolveAssembly<IDBMetaDataLinker>();
        }

        /// <summary>
        /// Ranme paramters to be equal to oracle param names in case the same code used by sql server version. and handle implict ref cursor mapping.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        private void FillCommandParam(string commandText, CommandType commandType)
        {
            command.CommandText = GetPlSqlCommand(commandText);
            command.CommandType = commandType;
            command.BindByName = true;

            FillParameters();
            if (commandType == CommandType.StoredProcedure)
            {
                FillRefCursorParams(commandText);
            }
        }

        private string GetPlSqlCommand(string commandText)
        {
            return commandText.Replace("=@", "=:v_").Replace("= @", "= :v_").Replace("<>@", "<>:v_").Replace("<> @", "<> :v_");
            //return commandText.Replace("=@", "=v_").Replace("= @", "= v_");
        }

        private void FillParameters()
        {
            foreach (OracleParameter oracleParameter in this.CommandParameters)
            {
                oracleParameter.ParameterName = GetOracleParamName(oracleParameter);

                if (oracleParameter.OracleDbType == OracleDbType.Varchar2)
                {
                    oracleParameter.OracleDbType = OracleDbType.NVarchar2;
                }
            }
        }

        private static string GetOracleParamName(OracleParameter oracleParameter)
        {
            return oracleParameter.ParameterName.Replace("@", "v_");
        }

        private void FillRetrunParams()
        {
            foreach (OracleParameter parameter in CommandParameters)
            {
                if (parameter.Direction == System.Data.ParameterDirection.Output || parameter.Direction == System.Data.ParameterDirection.InputOutput || parameter.Direction == System.Data.ParameterDirection.ReturnValue)
                {
                    ReturnedParameters.Add(parameter.ParameterName.Replace("v_", "@"), parameter.Value);
                }
            }
        }

        private void FillRefCursorParams(string spName)
        {
            if (dBMetaDataLinker != null)
            {
                List<SPParamInfo> additionalParameters = dBMetaDataLinker.GetAdditionalParameters();

                if (additionalParameters != null && additionalParameters.Count > 0)
                {
                    foreach (var param in additionalParameters.Where(sp => sp.SPName.ToLower() == spName.ToLower() &&
                               this.command.Parameters.Cast<OracleParameter>().Any(x => x.ParameterName.Trim().ToLower() == sp.ProceduresParam.ParameterName?.Trim()?.ToLower()) == false))
                    {
                        this.command.Parameters.Add(param.ProceduresParam);
                    }
                }
            }
        }

        public bool CheckAvailability(string highAvailabilityServers)
        {
            try
            {
                string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString" + highAvailabilityServers];
                //string LogConnectionString = System.Configuration.ConfigurationManager.AppSettings["LogConnectionString" + highAvailabilityServers.ToString()];
                //string WebResultConnectionString = System.Configuration.ConfigurationManager.AppSettings["WebResultConnectionString" + highAvailabilityServers.ToString()];
                //string BBMConnStr = System.Configuration.ConfigurationManager.AppSettings["BBMConnStr" + highAvailabilityServers.ToString()];

                connectionString += connectionString.EndsWith(";") ? "Connection Timeout=30;" : ";Connection Timeout=30;";
                IntializeInstances(connectionString);
                OpenConnection();
                CloseConnection();

                //LogConnectionString += LogConnectionString.EndsWith(";") ? "Connection Timeout=30;" : ";Connection Timeout=30;";
                //IntializeInstances(LogConnectionString);
                //OpenConnection();
                //CloseConnection();

                //WebResultConnectionString += WebResultConnectionString.EndsWith(";") ? "Connection Timeout=30;" : ";Connection Timeout=30;";
                //IntializeInstances(WebResultConnectionString);
                //OpenConnection();
                //CloseConnection();

                //BBMConnStr += BBMConnStr.EndsWith(";") ? "Connection Timeout=30;" : ";Connection Timeout=30;";
                //IntializeInstances(BBMConnStr);
                //OpenConnection();
                //CloseConnection();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SetOnGetDataTableAction(Action<DataTable> _onGetDataTableAction)
        {
            onGetDataTableAction = _onGetDataTableAction;
        }

        public void SetOnGetDataSetAction(Action<DataSet> onGetDataSetAction)
        {
            this.onGetDataSetAction = onGetDataSetAction;
        }

        private void CheckSessionParallelQueryToBeDisabledOrNot()
        {
            if (IsDisableSessionParallelQuery)
            {
                using (OracleCommand cmd = new OracleCommand("alter session disable parallel query", this.connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
