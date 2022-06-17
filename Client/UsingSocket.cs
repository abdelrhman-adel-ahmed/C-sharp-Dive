using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Client
{
    class UsingSocket
    {
        public static void UsingSockets()
        {
            Socket clinetSocket = ConnectToServer();
            SendData(clinetSocket);
        }

        static Socket ConnectToServer()
        {
            Socket clinetSocket;
            connection:
            try
            {
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3333);
                clinetSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //clinetSocket.Bind(new IPEndPoint(IPAddress.Any, 6666));
                clinetSocket.Connect(endpoint);
                Console.WriteLine($"Socket Connceted To Ip and Port {clinetSocket.RemoteEndPoint}");
                Console.WriteLine($"Socket Connceted using Ip and Port {clinetSocket.LocalEndPoint}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"excption happend {ex.Message}");
                goto connection;
            }
            return clinetSocket;
        }

        static void SendData(Socket clinetSocket)
        {
            sendData:
            try
            {
                bool connect = true;

                while (connect)
                {
                    Console.WriteLine("write message to send ...");
                    while (true)
                    {
                        string message = Console.ReadLine();
                        //1025 byte message , that will got trimed on the server side and the only specified buffer size 1024 will got recived
                        message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaas";
                        message = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaas";
                        if (message.ToLower() == "close")
                            connect = false;
                        byte[] MessageAsBytes = Encoding.ASCII.GetBytes(message);
                        int byteSentCount = clinetSocket.Send(MessageAsBytes);
                        Console.WriteLine($"num of bytes that got send by the client {byteSentCount}");
                    }
                    byte[] bytes = new byte[1024];
                    int byteRecvCount = clinetSocket.Receive(bytes);
                    string responseMessage = Encoding.UTF8.GetString(bytes, 0, byteRecvCount);
                    Console.WriteLine($"Message that got recv from server : {responseMessage}");
                }
                //clinetSocket.Shutdown(SocketShutdown.Both);
                clinetSocket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"excption happend {ex}");
                clinetSocket = ConnectToServer();
                goto sendData;
            }

        }

    }
}