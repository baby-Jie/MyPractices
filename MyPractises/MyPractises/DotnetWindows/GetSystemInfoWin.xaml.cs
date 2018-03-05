using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyPractises.DotnetWindows
{
    /// <summary>
    /// Interaction logic for GetSystemInfoWin.xaml
    /// </summary>
    public partial class GetSystemInfoWin : Window
    {
        public GetSystemInfoWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowCpuuseageAsync();
        }

        #region CpuUseage

        private async void ShowCpuuseageAsync()
        {
          //  double f = await GetCpuUsageByCounterAsync();
            double f = await GetCpuuseageByWmiAsync();
            double d = Math.Round(f, 2);
            MessageBox.Show(d.ToString());
        }

        public async Task<float> GetCpuUsageByCounterAsync()
        {
            float a = 0;
            try
            {
                await Task.Run((Action)(() =>
                {
                    var cpuCounter = new PerformanceCounter
                    {
                        CategoryName = "Processor",
                        CounterName = "% Processor Time",
                        InstanceName = "_Total"
                    };
                    a = cpuCounter.NextValue();
                    Thread.Sleep(1000);
                    a = cpuCounter.NextValue();
                }));
            }
            catch (InvalidOperationException ex)
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.UseShellExecute = false;
                info.CreateNoWindow = true;
                info.FileName = "lodctr";
                info.Arguments = "/r";

                Process.Start(info);

            }
           
            
            
            return a;
        }

        private async Task<double> GetCpuuseageByWmiAsync()
        {
            double a = 0;
            await Task.Run((Action)(() =>
            {
                ObjectQuery wmicpus = new ObjectQuery("select * from Win32_Processor");
                ManagementObjectSearcher cpus = new ManagementObjectSearcher(wmicpus);
                foreach (var cpu in cpus.Get())
                {
                    string id = cpu["DeviceId"].ToString();
                    a = double.Parse(cpu["LoadPercentage"].ToString());
                }

            }));
            return a;
        }

        #endregion

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Assembly assm = Assembly.GetExecutingAssembly();
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(assm.Location);
            string versionStr = string.Format("{0}:{1}", info.ProductMajorPart, info.ProductMinorPart);
            MessageBox.Show(versionStr);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string filename = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            FileVersionInfo myFileVersion = FileVersionInfo.GetVersionInfo(path + "//" + filename + ".exe");
            MessageBox.Show(myFileVersion.FileVersion);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            MEMORY_INFO MemInfo = new MEMORY_INFO();
            GlobalMemoryStatus(ref MemInfo);
            MessageBox.Show(MemInfo.dwMemoryLoad.ToString());
        }

        [DllImport("kernel32")]
        public static extern void GlobalMemoryStatus(ref MEMORY_INFO meminfo);


        /// <summary>
        /// 测试磁盘信息
        /// </summary>
         void TestDriveInfo()
        {
            DriveInfo[] allDirves = DriveInfo.GetDrives();
            //检索计算机上的所有逻辑驱动器名称
            foreach (DriveInfo item in allDirves)
            {
                //Fixed 硬盘
                //Removable 可移动存储设备，如软盘驱动器或USB闪存驱动器。
             //   Console.Write(item.Name + "---" + item.DriveType);
                string msg = item.Name + "---" + item.DriveType;
                if (item.IsReady)
                {
                    double percent = item.TotalFreeSpace*100.0 / item.TotalSize;
                    percent = 100 - percent;
                    msg += ", 百分比：" + percent.ToString("f2") + "\n";
                   // msg += ",容量：" + item.TotalSize + "，可用空间大小：" + item.TotalFreeSpace + "\n";
                    tbShowMessage.AppendText(msg);
                   // Console.Write(",容量：" + item.TotalSize + "，可用空间大小：" + item.TotalFreeSpace);
                }
                else
                {
                  //  Console.Write("没有就绪");
                }
               // Console.WriteLine();
            }
        }

     

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TestDriveInfo();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ShowCpuuseageAsync();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (null != netSpeedTimer)
                return;
            netSpeedTimer = new System.Timers.Timer(1000);
            netSpeedTimer.AutoReset = true;
            netSpeedTimer.Elapsed += NetSpeedTimer_Elapsed;
            netSpeedTimer.Enabled = true;
            netSpeedTimer.Start();
        }

        private void NetSpeedTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            NetworkInterface[] inters = NetworkInterface.GetAllNetworkInterfaces();
            NetworkInterface inter = inters[0];
            long beginSentBytes = inter.GetIPv4Statistics().BytesSent;
            long beginRcvBytes = inter.GetIPv4Statistics().BytesReceived;
            DateTime begindate = DateTime.Now;
            Thread.Sleep(1000);
            long endSentBytes = inter.GetIPv4Statistics().BytesSent;
            long endRcvBytes = inter.GetIPv4Statistics().BytesReceived;
            DateTime enddate = DateTime.Now;
            double totalSeconds = (enddate - begindate).TotalSeconds;
            long sendBytes = endSentBytes - beginSentBytes;
            long receiveBytes = endRcvBytes - beginRcvBytes;

            double sendSpeed = sendBytes / (totalSeconds * 1024);
            sendSpeed = Math.Round(sendSpeed, 2);
            double receiveSpeed = receiveBytes / (totalSeconds * 1024);
            receiveSpeed = Math.Round(receiveSpeed, 2);
            this.Dispatcher.BeginInvoke((Action)(()=>
            {
                tbDownloadSpeed.Text = receiveSpeed.ToString();
                tbUploadSpeed.Text = sendSpeed.ToString();
            }));

        }

        System.Timers.Timer netSpeedTimer;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MEMORY_INFO
    {
        public uint dwLength;
        public uint dwMemoryLoad;
        public uint dwTotalPhys;
        public uint dwAvailPhys;
        public uint dwTotalPageFile;
        public uint dwAvailPageFile;
        public uint dwTotalVirtual;
        public uint dwAvailVirtual;
    }
}
