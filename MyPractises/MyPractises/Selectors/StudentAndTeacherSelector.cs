using MyPractises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyPractises.Selectors
{
    class StudentAndTeacherSelector:StyleSelector
    {
        public Style StudentStyle { get; set; }

        public Style TeacherStyle { get; set; }

        public  override Style SelectStyle(object item, DependencyObject container)
        {
            try
            {
                if (item is Student)
                    return StudentStyle;
                else
                    return TeacherStyle;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
