using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectSSMP.Models;

namespace ProjectSSMP.Controllers.api
{
    
    [Produces("application/json")]
    [Route("api/Authentication/Authen")]
    public class AuthenticationController : Controller
    {
        private readonly sspmContext _context;

        public AuthenticationController(sspmContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult Authen(string user, string pass)
        {
            string membercode = string.Empty;
            if (!Validateuser(user, pass))
            {
                return Json(new { success = false, msg = "ไม่สามารถดึงข้อมูลได้ กรุณาทำรายการใหม่" });

            }
            return Json(new { success = true, group = "Admin",msg = "user : " + user + " pass : " + pass });

        }
        private bool Validateuser(string username, string password)
        {
            var user = (from a in _context.UserSspm where a.Username.Equals(username) select a).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            if (user.Password != password)
            {
                return false;
            }
            return true;
        }
    }
}