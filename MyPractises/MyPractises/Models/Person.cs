using MyPractises.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyPractises.Models
{
    public class Person: NotifyBase
    {
        public string Name { get; set; }

        public int Id { get; set; }


        //[XmlIgnore] 加上此特性  xml序列化时会忽略此元素
        //public int filedTest; //共有的字段是可以序列化的

      //  private int privateTest; 私有的不可序列化
    }
}
