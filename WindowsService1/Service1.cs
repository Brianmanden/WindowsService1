using System;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {

        public Service1()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStart123.txt");
            Listen();
        }

        protected override void OnStop()
        {
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "OnStop.txt");
        }

        private void Listen()
        {
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "ListenStarted.txt");
            /*
            int port = 49152;

            var listener = new TcpListener(IPAddress.Parse(LocalIPAddress()), port);
            listener.Start();
            */
        }

        private string LocalIPAddress()
        {
            string localIP = String.Empty;
            try
            {
                IPHostEntry host;
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }
                Console.WriteLine("--->" + localIP);
                return localIP;
            }
            catch (Exception ex)
            {
                //LogWriter.WriteExceptionLog(ex.ToString());
                Console.WriteLine(ex.ToString());
            }

            return localIP;
        }
    }
}
