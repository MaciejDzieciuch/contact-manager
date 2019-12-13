using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactManager.Models;
using System.Web.Security;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            using (var context = new ContactManager.Models.ContactManagerContext())
            {
                bool isValid = context.Users.Any(x => x.Name == model.Name && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, false);
                    return RedirectToAction("ContactList", "Users");
                }
                ModelState.AddModelError("", "Invalid username and password");
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    }
}