using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTutorial.Models;

namespace WebApiTutorial.Controllers
{
    public class StudentController : ApiController
    {
        public IHttpActionResult GetAllStudents()
        {
            IList<StudentModel> students = null;

            using (var ctx = new WinformwithWebAPIEntities())
            {
                students = ctx.Students.Select(s => new StudentModel()
                {
                    StudentID = s.StudentID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Adress = s.Adress,
                    FK_CourseID = s.FK_CourseID
                }).ToList<StudentModel>();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        public IHttpActionResult GetAllStudentsByLastName(string LastName)
        {
            IList<StudentModel> students = null;

            using (var ctx = new WinformwithWebAPIEntities())
            {
                students = ctx.Students.Where(x => x.LastName == LastName).Select(s => new StudentModel()
                {
                    StudentID = s.StudentID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Adress = s.Adress,
                    FK_CourseID = s.FK_CourseID
                }).ToList<StudentModel>();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        public IHttpActionResult GetAllStudentsByFirstName(string FirstName)
        {
            IList<StudentModel> students = null;

            using (var ctx = new WinformwithWebAPIEntities())
            {
                students = ctx.Students.Where(x => x.FirstName == FirstName).Select(s => new StudentModel()
                {
                    StudentID = s.StudentID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Adress = s.Adress,
                    FK_CourseID = s.FK_CourseID
                }).ToList<StudentModel>();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        public IHttpActionResult GetAllStudentsByID(int StudentID)
        {
            IList<StudentModel> students = null;

            using (var ctx = new WinformwithWebAPIEntities())
            {
                students = ctx.Students.Where(x => x.StudentID == StudentID).Select(s => new StudentModel()
                {
                    StudentID = s.StudentID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Adress = s.Adress,
                    FK_CourseID = s.FK_CourseID
                }).ToList<StudentModel>();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        public IHttpActionResult PostNewStudent(StudentModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new WinformwithWebAPIEntities())
            {
                ctx.Students.Add(new Student()
                {
                    StudentID = student.StudentID,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Adress = student.Adress,
                    FK_CourseID = student.FK_CourseID
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        public IHttpActionResult PutStudent(StudentModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new WinformwithWebAPIEntities())
            {
                var existingStudent = ctx.Students.Where(s => s.StudentID == student.StudentID)
                                                        .FirstOrDefault<Student>();

                if (existingStudent != null)
                {
                    existingStudent.FirstName = student.FirstName;
                    existingStudent.LastName = student.LastName;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult DeleteStudent(int StudentID)
        {
            if (StudentID <= 0)
                return BadRequest("Not a valid student id");

            using (var ctx = new WinformwithWebAPIEntities())
            {
                var student = ctx.Students
                    .Where(s => s.StudentID == StudentID)
                    .FirstOrDefault();
                if(student == null)
                {
                    return NotFound();
                }
                ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }

    }
}
