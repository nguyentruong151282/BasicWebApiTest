//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiTutorial
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public int StudentID { get; set; }
        public string Adress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> FK_CourseID { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
