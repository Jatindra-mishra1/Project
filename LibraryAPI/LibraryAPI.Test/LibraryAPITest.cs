using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryAPI.Controllers;
using LibraryAPI.Models;
using System;

namespace LibraryAPI.Test
{
    [TestClass]
    public class LibraryAPITest
    {
        [TestInitialize]
        public void SetUp()
        {
            LoginService = new LoginController();
            UserService = new UserController();
        }
        LoginController LoginService;
        UserController UserService;
        LogInModel LoginModel;
        [TestMethod]
        public void LoginTest()
        {

            var Result = LoginService.Check(new LogInModel() { Email = null, Password = null });
            Assert.AreEqual(Result, null);
        }
        [TestMethod]
        public void AddAdminTest()
        {
            var Result = LoginService.AddAdmin(new Admin() { Id = -1, Name = null, Email = null, Address = null, Password = null, Phone = null, UserName = null });
            Assert.IsNull(Result);
            Result = LoginService.AddAdmin(null);
            Assert.IsNull(Result);
        }
        [TestMethod]
        public void DismissAdminTest()
        {
            var Result = LoginService.DismissAdmin(-1);
            Assert.AreEqual(Result, false);
        }
        [TestMethod]
        public void CheckRandomUser()
        {
            var Result1 = UserService.AddStudent(null);
            Assert.IsNull(Result1);
            var Result2 = UserService.AddTeacher(null);
            Assert.IsNull(Result2);
        }
        [TestMethod]
        public void DeleteNullUser()
        {
            var Result1 = UserService.DeleteStudent(-1);
            Assert.AreEqual(Result1,false);
            var Result2 = UserService.DeleteTeacher(-1);
            Assert.AreEqual(Result2,false);
        }
        [TestMethod]
        public void CheckExistance()
        {
            var res = UserService.StudentExist(113);
            Assert.AreEqual(res,true);
        }

        [TestCleanup]
        public void CleanUp()
        {
        }
    }
}
