using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
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
                context.Students.Add(user);
                context.SaveChangesAsync();
                Console.WriteLine("Failed!");
                return user;
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
            context.Teachers.Add(user);
            context.SaveChangesAsync();
            return user;
        }
        [HttpDelete]
        [Route("delete_student")]
        public bool DeleteStudent(string Email)
        {
            Console.WriteLine("Deleting!");
            var context = new libraryContext();
            var student = context.Students.Find(Email);
            try
            {
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        [HttpDelete]
        [Route("delete_teacher")]
        public bool DeleteTeacher(string Email)
        {
            Console.WriteLine("Deleting!");
            var context = new libraryContext();
            var teacher = context.Teachers.Find(Email);
            try
            {
                if (teacher != null)
                {
                    context.Teachers.Remove(teacher); ;
                    context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
