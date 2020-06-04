using MyBlog.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        DbMyBlogEntities db = new DbMyBlogEntities();
        public List<SelectListItem> makeTagList()
        {
            List<SelectListItem> dropdownItems = (from item in db.tbl_tag.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = item.name,
                                                      Value = item.id.ToString()
                                                  }
                                                 ).ToList();
            return dropdownItems;
        }
        public List<SelectListItem> makeUserList()
        {
            List<SelectListItem> dropdownItems = (from item in db.tbl_user.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = item.username,
                                                      Value = item.id.ToString()
                                                  }
                                                 ).ToList();
            return dropdownItems;
        }

        // GET: Post
        public ActionResult Index()
        {
            var values = db.tbl_post.ToList();
            return View(values);
        }
        public ActionResult DeletePost(int id)
        {
            var post = db.tbl_post.Find(id);
            db.tbl_post.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddPost()
        {
            ViewBag.dropdownItemsTag = makeTagList();
            ViewBag.dropdownItemsUser = makeUserList();
            return View();
        }
        [HttpPost]
        public ActionResult AddPost(tbl_post post)
        {
            var tags = db.tbl_tag.Where(m => m.id == post.tbl_tag.id).FirstOrDefault();
            var users = db.tbl_user.Where(m => m.id == post.tbl_user.id).FirstOrDefault();
            post.tbl_tag = tags;
            post.tbl_user = users;
            post.create_time = DateTime.Now;
            db.tbl_post.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringPostForUpdate(int id)
        {
            ViewBag.dropdownItemsTag = makeTagList();
            ViewBag.dropdownItemsUser = makeUserList();
            return View(db.tbl_post.Find(id));
        }
        public ActionResult UpdatePost(tbl_post p)
        {
            var reelPost = db.tbl_post.Find(p.id);
            var tags = db.tbl_tag.Where(m => m.id == p.tbl_tag.id).FirstOrDefault();
            var users = db.tbl_user.Where(m => m.id == p.tbl_user.id).FirstOrDefault();
            reelPost.tbl_user = users;
            reelPost.tbl_tag = tags;
            reelPost.title = p.title;
            reelPost.blog_content = p.blog_content;
            reelPost.update_time = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}