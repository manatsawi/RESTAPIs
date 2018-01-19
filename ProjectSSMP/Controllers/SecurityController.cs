using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectSSMP.Models;
using ProjectSSMP.Models.Security;

namespace ProjectSSMP.Controllers
{
    public class SecurityController : Controller
    {
        private readonly sspmContext _context;

        public SecurityController(sspmContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //public async Task<IActionResult> Login(LgoinInputModel inputModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    if (!validateuser(inputModel.Username, inputModel.Password))
        //    {
        //        ModelState.AddModelError("","");
        //        return View();
        //    }
        //    //List<Claim> claims = new List<Claim>
        //    //{

        //    //}
            
        //}
        private bool validateuser(string user , string pass)
        {
            var userid = (from u in _context.UserSspm where u.Username.Equals(user) select u).FirstOrDefault();
            if (userid == null)
                return false;
            if(userid.Password != pass)
            {
                return false;
            }
            return true;
        }


    }
}