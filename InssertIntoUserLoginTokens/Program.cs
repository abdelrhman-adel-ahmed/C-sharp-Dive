
using NT.SharedKernel.SSNCore;
using OracleWebResult.Enums;
using OracleWebResult.Shared.Entities;
using OracleWebResult.SqlHelper;
int counter = 1000000;
string connectionstring = "DATA SOURCE=192.168.92.150;Database=OraclewebresultV.4;PERSIST SECURITY INFO=True;USER ID=sa;password=P@$$w0rd;Max Pool Size=700";
for (int i = 0; i < counter; i++)
{
    UserToken userToken = new UserToken
    {
        SessionId = Guid.NewGuid().ToString(),
        Token = "ABC",
        UserTypeId = UserType.Payer,
        BrowserId = "Test"
    };
    if (i >= 30000)
    {
        userToken.UserTypeId = UserType.Patient;
    }
    else if (i >= 100000)
    {
        userToken.UserTypeId = UserType.Lab;
    }
    else if (i >= 200000)
    {
        userToken.UserTypeId = UserType.AccNum;
    }
    else if (i >= 300000)
    {
        userToken.UserTypeId = UserType.BranchManager;
    }
    else if (i >= 300000)
    {
        userToken.UserTypeId = UserType.BranchManager;
    }
    using (SqlManager sqlManager = new SqlManager(connectionstring))
    {
        Task.Run(() => new UserTokensOperations().InsertUserToken(sqlManager, userToken, "NationalTe"));
    }

}
