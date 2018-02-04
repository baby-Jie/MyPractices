using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractises.Models
{
    [Serializable]
    public class Student:Person ,IComparable, IEnumerable
    {
        public double Score { get; set; }

        public double[] Scores = new double[] { 12,23,34};

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


        //一个类型只要实现了IEnumerable接口，就说这个类型可以被遍历

        //因为实现该接口后，就会有一个叫做GetEnumerator()的方法，而该方法就可以返回一个

        //真正用来遍历数据的“工具对象”
        public IEnumerator GetEnumerator()
        {
            return new StudentNumerator(Scores);
        }

        public override string ToString()
        {
            return Name + ":" + Score;
        }
    }

    public class StudentNumerator : IEnumerator
    {
        double[] scores;
        int index = -1;
        public StudentNumerator(double[] scores)
        {
            this.scores = scores;
        }
        public object Current
        {
            get
            {
                if (scores.Length > 0)
                {
                    if (index >= 0 && index < scores.Length)
                    {
                        return scores[index];
                    }
                    else
                        throw new IndexOutOfRangeException("index out of range ");
                }
                else
                {
                    throw new Exception("没有参数");
                }
            }
        }

        public bool MoveNext()
        {
            if (index >= scores.Length - 1) return false;
            else { index++; return true; }
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
