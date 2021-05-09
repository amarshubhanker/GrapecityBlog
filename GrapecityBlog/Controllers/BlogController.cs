using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrapecityBlog.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            try
            {
                GrapecityBlogEntities gc = new GrapecityBlogEntities();

                var allBlogs = gc.blogs.ToList();

                return View(allBlogs);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Blog/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                GrapecityBlogEntities gc = new GrapecityBlogEntities();
                var blog = gc.blogs.Find(id);

                return View(blog);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(blog bg)
        {
            try
            {
                // TODO: Add insert logic here
                GrapecityBlogEntities gc = new GrapecityBlogEntities();
                gc.blogs.Add(bg);
                gc.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                GrapecityBlogEntities gc = new GrapecityBlogEntities();
                var editBlog = gc.blogs.Find(id);

                return View(editBlog);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, blog bg)
        {
            try
            {
                // TODO: Add update logic here

                GrapecityBlogEntities gc = new GrapecityBlogEntities();
                var removingval = gc.blogs.Find(id);
                gc.blogs.Remove(removingval);
                gc.blogs.Add(bg);
                gc.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {

            try
            {
                GrapecityBlogEntities gc = new GrapecityBlogEntities();
                var deleteBlog = gc.blogs.Find(id);

                return View(deleteBlog);
            }
            catch
            {
                return View();
            }
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, blog bg)
        {
            try
            {
                GrapecityBlogEntities gc = new GrapecityBlogEntities();
                var removingval = gc.blogs.Find(id);
                gc.blogs.Remove(removingval);
                gc.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
