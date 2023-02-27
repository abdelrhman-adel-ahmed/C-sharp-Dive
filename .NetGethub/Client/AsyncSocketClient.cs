using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class AsyncSocketClient
    {
        internal static AsyncSocketClient Instance { get; } = new AsyncSocketClient();

        readonly static string MsgTail = ((char)28).ToString() + ((char)13).ToString();

        internal void Start()
        {
            try
            {
                HL7MessageDataModel hL7MessageDataModel = new HL7MessageDataModel
                {
                    IpAddress = "127.0.0.1",
                    Port = 3333,
                    Message = "hello"
                };
                // Send message to TCP
                SendMessageByTcp(hL7MessageDataModel);
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }

        private void SendMessageByTcp(HL7MessageDataModel hL7MessageDataModel)
        {


            string acknowledgement = SendMessageBySocket(hL7MessageDataModel);

        }

        private string SendMessageBySocket(HL7MessageDataModel hL7MessageDataModel)
        {
            byte[] receivedByteBuffer = new byte[32767000];
            Socket socket = null;
            try
            {

                socket = ConnectSocket(hL7MessageDataModel.IpAddress, hL7MessageDataModel.Port, hL7MessageDataModel.SendReceiveTimeout);
                if (socket == null)
                {
                    throw new InvalidOperationException($"Socket connection is not valid for {hL7MessageDataModel.IpAddress}:{hL7MessageDataModel.Port}");
                }
                if (!hL7MessageDataModel.Message.EndsWith(MsgTail))
                {
                    hL7MessageDataModel.Message = hL7MessageDataModel.Message + MsgTail;
                }

                byte[] msg = Encoding.GetEncoding("utf-8").GetBytes(hL7MessageDataModel.Message);


                socket.Send(msg, msg.Length, 0);


                int receivedByteLength = socket.Receive(receivedByteBuffer);

                if (receivedByteLength > 0)
                {
                    string acknowledgement = Encoding.GetEncoding("utf-8").GetString(receivedByteBuffer, 0, receivedByteLength);


                    return acknowledgement;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                CloseSocket(socket);
                receivedByteBuffer = null;
            }
            return null;
        }

        private Socket ConnectSocket(string ipAddress, int port, int receiveTimeoutInMilliseconds)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                ReceiveTimeout = (receiveTimeoutInMilliseconds > 0 ? receiveTimeoutInMilliseconds : 180) * 1000
            };


            IPEndPoint clientEndpoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

            socket.Connect(clientEndpoint);

            if (socket.Connected)
            {
                return socket;
            }

            return null;
        }


        private void CloseSocket(Socket socket)
        {
            Task.Factory.StartNew(() =>
            {
                if (socket == null)
                {
                    return;
                }
                try
                {
                    socket.Shutdown(SocketShutdown.Both);
                }
                catch { }
                try
                {
                    socket.Disconnect(true);
                }
                catch { }
                try
                {
                    socket.Dispose();
                }
                catch { }
                try
                {
                    socket = null;
                }
                catch { }
            });
        }

    }

    class HL7MessageDataModel
    {
        public string Message { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public string AlternateIp { get; set; }
        public int AlternatePort { get; set; }
        public int TryCount { get; set; }
        public int SendReceiveTimeout { get; set; }
    }
}
  