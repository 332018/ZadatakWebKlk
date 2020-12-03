using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDataLayer.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string BrojIndeksa { get; set; }
        public decimal Ocena { get; set; }
    }
}
