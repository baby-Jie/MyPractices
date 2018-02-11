using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using LogLibrary;
using System.Threading;

namespace SocketServer.ViewModels
{
    class MainWindowViewModel: NotificationObject
    {

        public MainWindowViewModel()
        {
            OpenCommand = new DelegateCommand(OpenSocket, CanOpenSocket);
            CloseSocketCommand = new DelegateCommand(CloseSocket);



            ServerIp = Dns.GetHostAddresses(Dns.GetHostName()).Where((ipaddress) => { return ipaddress.AddressFamily == AddressFamily.InterNetwork; }).First().ToString();
            ServerPort = 3000;
        }

        private string serverIp;
        public string ServerIp
        {
            get { return serverIp; }
            set
            {
                serverIp = value;
                this.RaisePropertyChanged("ServerIp");
            }
        }


        private int serverPort;
        public int ServerPort
        {
            get { return serverPort; }
            set
            {
                serverPort = value;
                this.RaisePropertyChanged("ServerPort");
            }
        }

        DelegateCommand openCmd;

        public DelegateCommand OpenCommand
        {
            get { return openCmd; }
            set
            {
                openCmd = value;
                this.RaisePropertyChanged("OpenCommand");
            }
        }




        private DelegateCommand closeSocketCommand;
        public DelegateCommand CloseSocketCommand
        {
            get { return closeSocketCommand; }
            set
            {
                closeSocketCommand = value;
                this.RaisePropertyChanged("CloseSocketCommand");
            }
        }


        Socket serverSock;


        private bool isSocketOpened;
        public bool IsSocketOpened
        {
            get { return isSocketOpened; }
            set
            {
                isSocketOpened = value;
                this.RaisePropertyChanged("IsSocketOpened");
            }
        }



        private string rcvMsg;
        public string RcvMessage
        {
            get { return rcvMsg; }
            set
            {
                rcvMsg = value;
                this.RaisePropertyChanged("RcvMessage");
            }
        }



        void OpenSocket()
        {
            try
            {
                serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ServerIp), ServerPort);
                serverSock.Bind(ip);
                serverSock.Listen(10);
                IsSocketOpened = true;
                AppendMessage($"Open Socket Successfully! Ip:{ServerIp}, Port:{ServerPort}");
                StartListen();
            }
            catch (Exception ex)
            {
                //LogWriter.Instance.ActionLogger.Error(ex.Message);
                IsSocketOpened = false;
                AppendMessage($"Open Socket Failed! Ip:{ServerIp}, Port:{ServerPort}");
            }
           
        }


        void CloseSocket()
        {
            try
            {
                //serverSock.Shutdown(SocketShutdown.Both);
                //Thread.Sleep(10);
                serverSock.Close();
                AppendMessage($"Close Socket Successfully! Ip:{ServerIp}, Port:{ServerPort}");
                IsSocketOpened = false;
            }
            catch (Exception ex)
            {
                AppendMessage($"Close Socket Failed! Ip:{ServerIp}, Port:{ServerPort}");
                LogHelper.Log("Close Socket Failed! msg:{0} pos:{1}", ex.Message, ex.StackTrace);
            }
        }


        bool CanOpenSocket()
        {
            return !IsSocketOpened;
        }

        void AppendMessage(string message)
        {
            RcvMessage += message + "\n";
        }

        async void StartListen()
        {
            await Task.Run(()=> 
            {
                while (IsSocketOpened)
                {
                    try
                    {
                        //判断是否被释放
                       
                        Socket clientSock = serverSock.Accept();
                        AppendMessage($"client {clientSock.RemoteEndPoint}  Message:Connected");
                        byte[] buffer = new byte[1024];
                        bool isEndSocket = false;
                        while (!isEndSocket)
                        {
                            int rcvLen = clientSock.Receive(buffer);
                            if (0 != rcvLen)
                            {
                                string message = Encoding.ASCII.GetString(buffer, 0, rcvLen);
                                AppendMessage($"client {clientSock.RemoteEndPoint}  Message:{message}");
                            }
                            else
                            {
                                isEndSocket = true;
                                AppendMessage($"client {clientSock.RemoteEndPoint}  Message:Disconnect");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Log("Accept err:" + ex.Message);
                        LogHelper.Log("pos:" + ex.StackTrace);
                    }
                }
               
            });
           
        }

    }


    
}
