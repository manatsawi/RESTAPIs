using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectSSMP.Models;
using ProjectSSMP.Models.UserManagement;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectSSMP.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly sspmContext _context;

        public UserManagementController(sspmContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(AddUserInputModel inputModel)
        {
            try
            {
                //var loggedInUser = HttpContext.User;
                //var loggedInUserName = loggedInUser.Identity.Name;

                UserSspm ord = new UserSspm
                {
                    UserId = "999999",
                    Username = inputModel.Username,
                    Password = inputModel.Password,
                    Firstname = inputModel.Firstname,
                    Lastname = inputModel.Lastname,
                    //JobResponsible = inputModel.JobResponsible,
                    UserCreateBy = "Test",
                    UserCreateDate = DateTime.Now,



                };

                // Add the new object to the Orders collection.
                _context.UserSspm.Add(ord);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");



            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return View();
            }
        }
    }
}
