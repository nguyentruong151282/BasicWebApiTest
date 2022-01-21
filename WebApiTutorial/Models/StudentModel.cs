using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTutorial.Models
{
    public class StudentModel
    {

        public int StudentID { get; set; }

        public string Adress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public Nullable<int> FK_CourseID { get; set; }
    }
}