using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class UsersController : Controller
    {
        private ContactManagerContext db = new ContactManagerContext();

        [AllowAnonymous]
        // GET: Users
        public async Task<ActionResult> ContactList()
           {
               return View(await db.Users.ToListAsync());
           }

          [AllowAnonymous]
           // GET: Users/Details/5
           public async Task<ActionResult> Details(int? id)
           {
               if (id == null)
               {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               }
               User user = await db.Users.FindAsync(id);
               if (user == null)
               {
                   return HttpNotFound();
               }
               return View(user);
           }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Surname,Email,Password,CategoryType,PhoneNumber,BirthDate")] User user)
        {
            if (ModelState.IsValid)
            {

                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("ContactList");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Surname,Email,Password,CategoryType,PhoneNumber,BirthDate")] User user)
        {
            bool isValidEmail = db.Users.Any(x => x.Email != user.Email);

            if (isValidEmail && ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("ContactList");
            }
            ModelState.AddModelError("", "Email is already in use");
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (id != 1)
            {
                User user = await db.Users.FindAsync(id);
                db.Users.Remove(user);
                await db.SaveChangesAsync();
                return RedirectToAction("ContactList");
            } else
            {
                return RedirectToAction("ContactList");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
