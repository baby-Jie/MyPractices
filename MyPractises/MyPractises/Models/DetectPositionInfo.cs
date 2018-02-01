using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractises.Models
{
    public class DetectPositionInfo:INotifyPropertyChanged
    {
        public string Name { get; set; }

        public string Ip { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string name)
        {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
