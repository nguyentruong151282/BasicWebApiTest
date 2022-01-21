using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiTutorial.Models
{
    public class CourseModel
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseLocation { get; set; }
        public Nullable<int> TeacherID { get; set; }
    }
}