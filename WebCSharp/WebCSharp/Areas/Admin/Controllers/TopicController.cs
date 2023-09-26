using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCSharp.Models;
using WebCSharp.Models.EntityFrameWork;

namespace WebCSharp.Areas.Admin.Controllers
{
    public class TopicController : Controller
    {
        // GET: Admin/Topic
        private ApplicationDbContext _dbConect = new ApplicationDbContext();
      

        public ActionResult Index()
        {
            var items = _dbConect.Topics.OrderBy(x=>x.Create_at).ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Topic model)
        {
            if (ModelState.IsValid)
            {
                model.Create_at = DateTime.Now;
                model.Update_at = DateTime.Now;
                model.Status = 1;
                model.Slug = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
                _dbConect.Topics.Add(model);
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = _dbConect.Topics.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Topic model)
        {
            if (ModelState.IsValid)
            {
                _dbConect.Topics.Attach(model);
                model.Update_at = DateTime.Now;
                model.Status = 1;

                model.Slug = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
                _dbConect.Entry(model).Property(x => x.Name).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Slug).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Parent_Id).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Metadesc).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Metakey).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Update_at).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Update_By).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Status).IsModified = true;
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _dbConect.Topics.Find(id);
            if (item != null)
            {
                _dbConect.Topics.Remove(item);
                _dbConect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult Show(int id)
        {
            var item = _dbConect.Topics.Find(id);
            return View(item);
        }
    }
}