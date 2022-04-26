using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using LibraryAPI.Models;
using LibraryAPI.Exceptions;
namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("students")]
        public IEnumerable<Student> GetStudents()
        {
            return (new libraryContext()).Students.ToList();
        }
        [HttpGet]
        [Route("teachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            return (new libraryContext()).Teachers.ToList();
        }
        [HttpPost]
        [Route("add_student")]
        public Student AddStudent(Student user)
        {
            Console.WriteLine("Adding!");
            var context = new libraryContext();
            try
            {
                if (user != null) {
                    context.Students.Add(user);
                    context.SaveChangesAsync();
                    Console.WriteLine("Failed!");
                    return user;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpPost]
        [Route("add_teacher")]
        public Teacher AddTeacher(Teacher user)
        {
            Console.WriteLine("Adding!");
            var context = new libraryContext();
            try
            {
                if (user != null) {
                    context.Teachers.Add(user);
                    context.SaveChangesAsync();
                    return user;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        [HttpDelete]
        [Route("delete_student")]
        public bool DeleteStudent(int studentId)
        {
            Console.WriteLine("Deleting!");
            var context = new libraryContext();
            var student = context.Students.Find(studentId);
            try
            {
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChangesAsync();
                    return true;
                }
                throw new StudentNotFoundException("Student Not Found");
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        [HttpDelete]
        [Route("delete_teacher")]
        public bool DeleteTeacher(int teacherId)
        {
            Console.WriteLine("Deleting!");
            var context = new libraryContext();
            var teacher = context.Teachers.Find(teacherId);
            try
            {
                if (teacher != null)
                {
                    context.Teachers.Remove(teacher); ;
                    context.SaveChangesAsync();
                    return true;
                }
                throw new TeacherNotFoundException("Teacher Not Found");
            }
            catch (TeacherNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPut]
        [Route("update_student")]
        public Student UpdateStudent(int StudentId, [FromBody] Student student)
        {
            Console.WriteLine("Updating!!");
            var context = new libraryContext();
            try
            {
                if (student != null)
                {
                    Student Matched=context.Students.Where(s=>s.StudentId==StudentId).FirstOrDefault();
                    Matched.StudentName = student.StudentName;
                    Matched.Email = student.Email;
                    Matched.Password = student.Password;
                    Matched.UserName = student.UserName;
                    Matched.Phone = student.Phone;
                    Matched.Address = student.Address;
                    context.SaveChangesAsync();
                    return student;
                }
                throw new StudentNotFoundException("Student Not Found");
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpPut]
        [Route("update_teacher")]
        public Teacher UpdateTeacher(int TeacherId, [FromBody] Teacher teacher)
        {
            Console.WriteLine("Updating!!");
            var context = new libraryContext();
            try
            {
                if (teacher != null)
                {
                    Teacher Matched = context.Teachers.Where(s => s.TeacherId == TeacherId).FirstOrDefault();
                    Matched.TeacherName = teacher.TeacherName;
                    Matched.Email = teacher.Email;
                    Matched.Password = teacher.Password;
                    Matched.UserName = teacher.UserName;
                    Matched.Phone = teacher.Phone;
                    Matched.Address = teacher.Address;
                    context.SaveChangesAsync();
                    return teacher;
                }
                throw new TeacherNotFoundException("Teacher Not Found");
            }
            catch (TeacherNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [HttpGet]
        [Route("student_exists")]
        public bool StudentExist(int Id)
        {
            var context = new libraryContext();
                if (context.Students.FirstOrDefault(s=>s.StudentId==Id) != null)
                    return true;
                else return false;
        }
        [HttpGet]
        [Route("teacher_exists")]
        public bool TeacherExist(int Id)
        {
            var context = new libraryContext();
            if (context.Teachers.FirstOrDefault(s=>s.TeacherId==Id)!= null)
                return true;
            else return false;
        }
    }
}
