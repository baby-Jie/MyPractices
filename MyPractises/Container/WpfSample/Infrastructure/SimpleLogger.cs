using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample.Infrastructure
{
    class SimpleLogger : ILogger
    {
        public ObservableCollection<string> LogList { get; set; }


        public SimpleLogger()
        {
            LogList = new ObservableCollection<string>();
        }

        public void ClearList()
        {
            LogList.Clear();
        }

        public void ToConsole(string text)
        {
            var log = $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {text}";
            Console.WriteLine(log);
            LogList.Add(log);
        }
    }
}
