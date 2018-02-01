using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractises.Models
{
    public class Student:IComparable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Score { get; set; }

        public int CompareTo(object obj)
        {
            if (null == obj)
                return 1;
            Student other = obj as Student;
            if (Math.Abs(Score - other.Score) < 0.001)
                return 0;
            else if (Score > other.Score)
                return 1;
            else
                return -1;
        }
    }
}
