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
    class PersonDataTemplate : DataTemplateSelector
    {
        public DataTemplate StuTemp { get; set; }
        public DataTemplate TechTemp { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            try
            {
                if (item is Student)
                    return StuTemp;
                else
                    return TechTemp;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
