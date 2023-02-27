
using NT.SharedKernel.SSNCore;
using OracleWebResult.Enums;
using OracleWebResult.Shared.Entities;
using OracleWebResult.SqlHelper;


int counter = 1000000;
string connectionstring = "DATA SOURCE=nat-sqldev.privatelink.database.windows.net;Database=webresultv.4_stage;PERSIST SECURITY INFO=True;USER ID=Nat_AdminDev;password=SQL_P@ssw0rd;Max Pool Size=700";
for (int i = 0; i < counter; i++)
{
    UserToken userToken = new UserToken
    {
        UserId = 2,
        IssuerIpAddress = "0.0.0.0",
        SessionId = Guid.NewGuid().ToString(),
        Token = "ABC",
        UserTypeId = UserType.Payer,
        BrowserId = "Test",
        ClientLoginTime = DateTime.Now,
        CreatedDate = DateTime.Now
    };
    SetLoginTime(userToken, 2);
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
        sqlManager.OpenConnection();
        new UserTokensOperations().InsertUserToken(sqlManager, userToken, "NationalTe");
    }
}


static void SetLoginTime(UserToken userToken, double ClientUtcOffset)
{
    DateTime ClientLoginTime = DateTime.UtcNow.AddHours(ClientUtcOffset);
    DateTime ClientLoginRoundedTime = new DateTime(ClientLoginTime.Year, ClientLoginTime.Month, ClientLoginTime.Day, ClientLoginTime.Hour, 0, 0);
    if (ClientLoginTime.Minute > 0 || ClientLoginTime.Second > 0)
        ClientLoginRoundedTime = ClientLoginRoundedTime.AddHours(1);
    userToken.ClientLoginTime = ClientLoginRoundedTime;

}
