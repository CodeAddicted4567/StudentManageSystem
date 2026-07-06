using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMng.Models
{
    public class StudentVM
    {
        public List<Student> Students { get; set; }
        public string SearchName { get; set; }
       //For showing the list of students in the view
        public string SortByNames { get; set; }
    }
}