using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CollegeCRUD_ADO_.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string MiddleName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime DOB { get; set; }

        public int GenderID { get; set; }

        public bool isActive { get; set; }
        public bool isDeleted { get; set; }

        //public Gender Genders { get; set; }
      public List<Gender> genders { get; set; }
    }
}