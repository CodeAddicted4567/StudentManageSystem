using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMng.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name must be required"),StringLength(100),DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Marks must be required"), Range(0,300)]
        public int Marks { get; set; }
    }
}