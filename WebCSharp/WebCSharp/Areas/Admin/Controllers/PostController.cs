using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCSharp.Models.EntityFrameWork;
using WebCSharp.Models;

namespace WebCSharp.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        // GET: Admin/Post
        private ApplicationDbContext _dbConect = new ApplicationDbContext();


        public ActionResult Index()
        {
            var items = _dbConect.Posts.OrderBy(x => x.Create_at).ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Post model)
        {
            if (ModelState.IsValid)
            {
                model.Create_at = DateTime.Now;
                model.Update_at = DateTime.Now;
                model.Status = 1;
                model.Slug = WebCSharp.Models.Commons.Filter.FilterChar(model.Title);
               
                _dbConect.Posts.Add(model);
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //public ActionResult Edit(int id)
        //{
        //    var item = _dbConect.Topics.Find(id);
        //    return View(item);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Topic model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _dbConect.Topics.Attach(model);
        //        model.Update_at = DateTime.Now;
        //        model.Status = 1;

        //        model.Slug = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
        //        _dbConect.Entry(model).Property(x => x.Name).IsModified = true;
        //        _dbConect.Entry(model).Property(x => x.Slug).IsModified = true;
        //        _dbConect.Entry(model).Property(x => x.Parent_Id).IsModified = true;
        //        _dbConect.Entry(model).Property(x => x.Metadesc).IsModified = true;
        //        _dbConect.Entry(model).Property(x => x.Metakey).IsModified = true;
        //        _dbConect.Entry(model).Property(x => x.Update_at).IsModified = true;
        //        _dbConect.Entry(model).Property(x => x.Update_By).IsModified = true;
        //        _dbConect.Entry(model).Property(x => x.Status).IsModified = true;
        //        _dbConect.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(model);
        //}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConect.Posts.Find(id);
            if (item != null)
            {
                _dbConect.Posts.Remove(item);
                _dbConect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult Show(int id)
        {
            var item = _dbConect.Posts.Find(id);
            return View(item);
        }
    }
}