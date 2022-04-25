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
            return context.Admins.FirstOrDefault(a=>a.Email==LoginData.Email && a.Password==LoginData.Password);
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
                    context.Admins.Remove(context.Admins.Find(AdminId));
                    context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

    }
}
