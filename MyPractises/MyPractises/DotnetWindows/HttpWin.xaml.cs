using MyPractises.Comman;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
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

namespace MyPractises.DotnetWindows
{
    /// <summary>
    /// Interaction logic for HttpWin.xaml
    /// </summary>
    public partial class HttpWin : Window
    {
        public HttpWin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = tbUrl.Text;
            MyWebclient client = new MyWebclient();
            client.TimeOut = 2000;
            client.DownloadFile(url, "testdownload.jpg");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string url = tbUrl.Text + "?md5str=" + GetFileMd5("1.jpg");
            string ret = UpLoadFile("1.jpg", url);
         //   tbShowmsg.Text = url;
            tbShowmsg.AppendText(ret);
        }

        private void UploadFileByWebClient()
        {
            string url = tbUrl.Text;
            MyWebclient client = new MyWebclient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.TimeOut = 4000;
            byte[] ret = client.UploadFile(new Uri(url), "Post", "1.jpg");
            string str = Encoding.ASCII.GetString(ret);
            tbShowmsg.Text = str;
        }


        public string UpLoadFile(string filePath, string url)
        {
            string responseData = String.Empty;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            byte[] buffur = new byte[fileStream.Length];
            fileStream.Read(buffur, 0, (int)fileStream.Length);

            req.Method = "POST";
              req.ContentType = "text/plain";
           // req.ContentType = "application/x-www-form-urlencoded";
            req.ContentLength = fileStream.Length;

            //string timeStamp = DateTime.Now.ToString("YYYY-MM-DD HH:mm:ss");
            //string userName = "*****";
            //string passWord = "*****";
            //string uniqueKey = "*****";
          //  string userkey = Md5Helper.GetMD5String(userName + passWord + uniqueKey + timeStamp);
        //    req.Headers.Add("userName", userName);
        //    req.Headers.Add("channelId", "*****");
        //    req.Headers.Add("timestamp", timeStamp);
        ////    req.Headers.Add("userKey", userkey);
        //    req.Headers.Add("model", "getPolicyZip");
        //    req.Headers.Add("policyConstraint", "{}");

            Stream reqStream = req.GetRequestStream();
            reqStream.Write(buffur, 0, buffur.Length);
            reqStream.Close();

            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312")))
                {
                    responseData = reader.ReadToEnd().ToString();
                }
                return responseData;
            }
        }


        private string GetFileMd5(string filePath)
        {
            StringBuilder strMd5 = new StringBuilder();
            MD5 md5 = MD5.Create();
            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] outMd5 = md5.ComputeHash(fs);
                for (int i = 0; i < outMd5.Length; i++)
                {
                    strMd5.Append(outMd5[i].ToString("X2"));
                }
            }

            return strMd5.ToString();
        }
    }
}
