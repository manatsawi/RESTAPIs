using System;
using System.Collections.Generic;
using System.Linq;
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
        //public async Task<IActionResult> Login (LgoinInputModel inputModel)
        //{
        //    return View();
        //}
        private bool validateuser(string user , string pass)
        {
           // var user = (from )
            return true;
        }


    }
}