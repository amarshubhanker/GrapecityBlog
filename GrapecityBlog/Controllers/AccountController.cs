using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GrapecityBlog.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        // GET: Login
        [HttpPost]
        public ActionResult Login(user user)
        {

            try
            {
                GrapecityBlogEntities gc = new GrapecityBlogEntities();
                bool isValid = gc.users.Any(x => x.Email == user.Email && x.Password == user.Password );

                if (isValid) {

                    var loggedinUser = gc.users.First(u => u.Email == user.Email);
                    FormsAuthentication.SetAuthCookie(loggedinUser.Email, false);

                    return RedirectToAction("Index", "Blog");

                }
                else
                {

                    ModelState.AddModelError("", "Invalid UserName and Password Combination");
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("Index", "Blog");
            }
        }

        [HttpGet]
        public ActionResult Signup()
        {
            return View();
        }

        // GET: Login
        [HttpPost]
        public ActionResult Signup(user user)
        {
            try { 
                GrapecityBlogEntities gc = new GrapecityBlogEntities();
                bool isPresent = gc.users.Any(x => x.Email == user.Email);

                if (!isPresent)
                {
                    gc.users.Add(user);

                    gc.SaveChanges();

                    return RedirectToAction("Login");

                    //
                }
                else {

                    ViewBag.message = "Email Address Already Present";
                    return View();
                }
            }
            catch
            {
                return RedirectToAction("Index", "Blog");
            }
        }

        // GET: Account/Edit/5
        [HttpGet]
        [Authorize]
        public ActionResult EditProfile(string email)
        {
            try
            {
                GrapecityBlogEntities gc = new GrapecityBlogEntities();
                var editBlog = gc.users.First(u => u.Email == email);

                return View(editBlog);
            }
            catch
            {
                return RedirectToAction("Index", "Blog");
            }
        }

        // POST: Account/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult EditProfile(int id, user user)
        {
            try
            {
                // TODO: Add update logic here

                GrapecityBlogEntities gc = new GrapecityBlogEntities();
                var removingval = gc.users.Find(id);
                gc.users.Remove(removingval);
                gc.users.Add(user);
                gc.SaveChanges();

                return RedirectToAction("Index","Blog");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }

    }
}