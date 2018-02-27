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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SendPost();
        }

        void SendPost()
        {
            string url = tbUrl.Text;
            Stream sr;
            CallHttpPostTypeOfApplication(url, string.Empty, out sr);
            string str = GetStrFromStream(sr);
            tbShowmsg.Text = str;
        }


        public static int CallHttpPostTypeOfApplication(string url, string data, out Stream sr, string user = "", string pwd = "")
        {
            int ret = 0;
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            Stream reqStream = null;
            sr = null;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "POST";
            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pwd))
            {
                req.Credentials = GetCredentialCache(url, user, pwd);
                req.Headers.Add("Authorization", GetAuthorization(user, pwd));
            }
            req.ReadWriteTimeout = 5000;
            req.Timeout = 5000;
            req.Accept = "*/*";
            req.ContentType = "application/json";
            req.ContentLength = buffer.Length;

            try
            {
                reqStream = req.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();

                WebResponse wr = req.GetResponse();
                sr = wr.GetResponseStream();
            }
            catch (Exception ex)
            {
                if (reqStream != null)
                {
                    reqStream.Close();
                    reqStream.Dispose();
                    reqStream = null;
                }
              //  LogWriter.Instance.ActionLogger.Error("Failed to post request.", ex);
                ret = -1;
            }

            return ret;
        }

        public static string GetStrFromStream(Stream stream)
        {
            if (null == stream)
                return null;
            string content = null;
            using (StreamReader sr = new StreamReader(stream))
            {
                content = sr.ReadToEnd();
                content = content.Trim();
            }

            return content;
        }


        #region # 生成 Http Basic 访问凭证 #

        private static CredentialCache GetCredentialCache(string uri, string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            CredentialCache credCache = new CredentialCache();
            credCache.Add(new Uri(uri), "Basic", new NetworkCredential(username, password));

            return credCache;
        }

        private static string GetAuthorization(string username, string password)
        {
            string authorization = string.Format("{0}:{1}", username, password);

            return "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(authorization));
        }

        #endregion
    }
}
