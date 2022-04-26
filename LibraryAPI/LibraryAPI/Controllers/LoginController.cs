using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using LibraryAPI.Exceptions;
namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public List<Admin> getAll()
        {
            return (new libraryContext()).Admins.ToList();
        }
        [HttpPost]
        [Route("Check")]
        public Admin Check(LogInModel LoginData)
        {
            var context = new libraryContext();
            try { var Admin= context.Admins.FirstOrDefault(a => a.Email == LoginData.Email && a.Password == LoginData.Password); return Admin;
            } catch (Exception) { return null; }
        }
        [HttpPost]
        [Route("add_admin")]
        public bool AddAdmin(Admin _Admin)
        {
            var context = new libraryContext();
            try
            {
                context.Admins.Add(_Admin);
                context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [Route("dismiss_admin")]
        public bool DismissAdmin(int AdminId)
        {
            var context = new libraryContext();
            try
            {
                Admin _Admin = context.Admins.Find(AdminId);
                if (_Admin is null)
                    throw new AdminNotFoundException("Admin Not Found");
                context.Admins.Remove(_Admin);
                context.SaveChangesAsync();
                return true;
            }
            catch (AdminNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
