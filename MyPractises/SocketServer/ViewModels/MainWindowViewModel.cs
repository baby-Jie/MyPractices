using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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

        void OpenSocket()
        {
            try
            {
                serverSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ip = new IPEndPoint(IPAddress.Parse(ServerIp), ServerPort);
                serverSock.Bind(ip);
                serverSock.Listen(10);
                IsSocketOpened = true;
            }
            catch (Exception ex)
            {
                //LogWriter.Instance.ActionLogger.Error(ex.Message);
                IsSocketOpened = false;
            }
           
        }


        void CloseSocket()
        {
            try
            {
                serverSock.Close();
            }
            catch (Exception)
            {

                
            }
            IsSocketOpened = false;
        }


        bool CanOpenSocket()
        {
            return !IsSocketOpened;
        }

    }
}
