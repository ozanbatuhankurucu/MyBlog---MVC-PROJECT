using MyBlog.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class TagController : Controller
    {
        DbMyBlogEntities db = new DbMyBlogEntities();
        // GET: Tag
        public ActionResult Index()
        {

            var values = db.tbl_tag.ToList();
            return View(values);
        }
        public ActionResult DeleteTag(int id)
        {
            var tag = db.tbl_tag.Find(id);
            db.tbl_tag.Remove(tag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddTag()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult AddTag(tbl_tag tag)
        {
            db.tbl_tag.Add(tag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringTagForUpdate(int id)
        {
            return View(db.tbl_tag.Find(id));
        }
        public ActionResult UpdateTag(tbl_tag t)
        {
            var tag = db.tbl_tag.Find(t.id);
            tag.name = t.name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}