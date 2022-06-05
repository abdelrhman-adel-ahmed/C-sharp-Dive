using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // IPHostEntry host = Dns.GetHostEntry("localhost");
            // UsingTcpClientDSL.UsingTcpClient();
            // UsingSocket.UsingSockets();

           // ttt();
           test();

        }
        private static void test()
        {

            EmailLog Obj = new EmailLog();
            Obj.Email = "abdelrahman.adel@nt-me.com";
            Obj.EmailText = "test";
            string ReceivingEmailAddress = "abdelrahman.adel@nt-me.com";
            int portNo = 587;
            string smtpServer = "outlook.office365.com";
            string userName = "result@alborgdx.com";
            string password = "Alborg@2020";

            string CustomerName = "Alborg@2020";
            bool sendingMsgWithSSL = true;

            MailMessage sendMessage = new MailMessage();

            string mailBody = "heeelp";//"Your activation code is :" + activationCode;
            sendMessage.Subject = "Activate your account";
            sendMessage.From = new MailAddress(userName, CustomerName);
            sendMessage.Body = mailBody;
            sendMessage.To.Add(ReceivingEmailAddress);
            SmtpClient smtpClient = new SmtpClient
            {
                Host= smtpServer,
                Port =587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(userName, password),
                DeliveryMethod=SmtpDeliveryMethod.Network
            };
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };

            smtpClient.Send(sendMessage);
            Obj.ExceptionText = "NA";
        }

        static void ttt()
        {
            EmailLog Obj = new EmailLog();
            Obj.Email = "abdelrahman.adel@nt-me.com";
            Obj.EmailText = "test";
            string ReceivingEmailAddress = "abdelrahman.adel@nt-me.com";
            int portNo = 587;
            string smtpServer = "outlook.office365.com";
            string userName = "result@alborgdx.com";
            string password = "Alborg@2020";

            string CustomerName = "Alborg@2020";
            bool sendingMsgWithSSL = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(userName, password);
            client.Port = 587; // 25 587
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(userName, CustomerName);
            mail.To.Add(new MailAddress(ReceivingEmailAddress));
            mail.Subject = "A special subject";
            mail.Body = "test";

            client.Send(mail);
        }

    }

    public class EmailLog
    {
        public int Id { get; set; }

        public string EmailText { get; set; }

        public string Email { get; set; }

        public string TimeStamp { get; set; }

        public string ExceptionText { get; set; }

        public string PatientNo { get; set; }

        public bool Success { get; set; }
    }
}
