using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WMPLib;

//Ø File //操作文件,静态类，对文件整体操作。拷贝、删除、剪切等。

//Ø FileInfo//文件类，用来描述一个文件对象。获取指定目录下的所有文件时，返回一个FileInfo数组。

//Ø Directory 操作目录（文件夹），静态类。

//Ø DirectoryInfo //文件夹的一个“类”，用来描述一个文件夹对象（获取指定目录下的所有目录时返回一个DirectoryInfo数组。）

//Ø Path//对文件或目录的路径进行操作（很方便）【字符串】

//Ø Stream 文件流，抽象类。

//Ø FileStream//文件流,MemoryStream(内存流),NetworkStream(网络流)

//Ø StreamReader //快速读取文本文件

//Ø StreamWriter//快速写入文本文件

//Ø GZipStream

//    1、Path.GetFileName()获取“C:\test\”会返回null。

//2、获取当前exe文件执行的路径：

//Ø Assembly.GetExecutingAssembly().Location;

//Ø Application.StartupPath.

//不要用：Directory.GetCurrentDirectory(); 获取应用程序的当前工作目录。因为这个可能会变，通过使用OpenFileDialog或者手动设置Directory.SetCurrentDirectory().

//      Using作用：

//1、 引用命名空间；

//2、 为命名空间或者类型起别名；

//3、 调用Dispose（）方法。

//  文件流操作

//1、创建文件流 FileStream fs=new FileStream（）；

//2、创建缓冲区 byte[] bytes = new byte[]();

//3、读或者写 fs.Read()或者fs.Write();

//    FileStream的Position属性为当前文件指针位置，每写一次就要移动一下Position以备下次写到后面的位置。

//  文件编码

//Unicode编码的前两个字节相同；

//UTF-8编码的前三个字节相同。

//StreamReader读取文件的方式是采用逐行读取的。

//读取结束的的两种方式：

//1）判断是否读取到流的末尾 read.EndOdStream方式判断

//2）判断读取的行是否为null：(line= read.ReadLine())!=null

//File.OpenRead()可以返回只读的FileStream.


namespace MyPractises.DotnetWindows
{
    /// <summary>
    /// Interaction logic for FileIOWin.xaml
    /// </summary>
    public partial class FileIOWin : Window
    {
        public FileIOWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListAllFiles(new DirectoryInfo(System.Environment.CurrentDirectory));
        }
        public  void ListAllFiles(FileSystemInfo info)
        {
            if (null == info) return;
            if (!info.Exists) return;//如果这个文件不存在
            DirectoryInfo dir = info as DirectoryInfo;
            //如果不是目录
            if (null == dir)
            {
                return;
            }
            FileSystemInfo[] files = dir.GetFileSystemInfos();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo test = files[i] as FileInfo;
                //如果是文件
                if (null != test)
                {
                    // Console.WriteLine(test.FullName + '\t' + test.Length);
                    tbShowFiles.AppendText(test.Name + '\t' + test.Length + '\n');
                }
                else
                {
                    ListAllFiles(files[i]);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            tbShowFiles.Text = filePath;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "img|*.jpg|all|*.*";
            bool? ret = dialog.ShowDialog();
            if (true == ret)
            {
                tbShowFiles.Text = dialog.FileName;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            FileInfo fileinfo = new FileInfo("BehaviorLibrary.dll");


            FileVersionInfo info = FileVersionInfo.GetVersionInfo("BehaviorLibrary.dll");

            tbShowFiles.Text = info.FileVersion;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var player = new WindowsMediaPlayer();
            var clip = player.newMedia("1.mp4");
            tbShowFiles.Text = clip.duration.ToString();
        }
    }
}



