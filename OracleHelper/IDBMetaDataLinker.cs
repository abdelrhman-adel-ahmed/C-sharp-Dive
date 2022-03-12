using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;

namespace OracleHelper
{
    public class SPParamInfo
    {
        public string SPName { get; set; }

        public OracleParameter ProceduresParam { get; set; }
    }

    public interface IDBMetaDataLinker
    {
        List<SPParamInfo> GetAdditionalParameters();
    }
}