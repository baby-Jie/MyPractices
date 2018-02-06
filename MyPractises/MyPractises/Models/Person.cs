using MyPractises.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractises.Models
{
    public class Person: NotifyBase
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }
}
