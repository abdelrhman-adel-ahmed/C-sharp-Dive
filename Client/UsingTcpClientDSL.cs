using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    class UsingTcpClientDSL
    {
        public static void UsingTcpClient()
        {
            TcpClient tcpClient = ConnectToServer();
            SendData(tcpClient);

            tcpClient.Close();
        }
        static TcpClient ConnectToServer()
        {
            TcpClient tcpClient = null;
            connection:
            try
            {
                Console.WriteLine("Conntect to Server ....");
                tcpClient = new TcpClient("127.0.0.1", 4000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"excption happend {ex.Message}");
                goto connection;
            }
            return tcpClient;
        }

        static void SendData(TcpClient tcpClient)
        {
            sendData:
            try
            {
                bool connect = true;

                NetworkStream stream = tcpClient.GetStream();
                StreamReader streamReader = new StreamReader(stream);
                while (connect)
                {
                    Console.WriteLine("write message to send ...");
                    string message = Console.ReadLine();
                    if (message.ToLower() == "close")
                        connect = false;
                    byte[] messageAsBytes = Encoding.ASCII.GetBytes(message);
                    int byteCount = messageAsBytes.Length;
                    stream.Write(messageAsBytes, 0, byteCount);
                    Console.WriteLine("Sending data To server ....");
                    string response = streamReader.ReadLine();
                    Console.WriteLine($"response data from server : {response}");
                }
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"excption happend {ex}");
                tcpClient = ConnectToServer();
                goto sendData;
            }

        }
    }
}
