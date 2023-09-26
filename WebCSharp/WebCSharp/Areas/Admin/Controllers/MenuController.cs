using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCSharp.Models;
using WebCSharp.Models.EntityFrameWork;


namespace WebCSharp.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext _dbConect = new ApplicationDbContext();
        // GET: Admin/Menu

        public ActionResult Index()
        {
            var items = _dbConect.Menus.ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Menu model )
        {
            if (ModelState.IsValid)
            {
                model.Create_at = DateTime.Now;
                model.Update_at = DateTime.Now;
                model.Status = 1;
                model.Type = model.Name;
                model.Link = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
                _dbConect.Menus.Add(model);
                _dbConect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = _dbConect.Menus.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu model)
        {
            if (ModelState.IsValid)
            {
                _dbConect.Menus.Attach(model);
                model.Update_at = DateTime.Now;
                model.Status = 1;
                model.Type = model.Name;
                model.Link = WebCSharp.Models.Commons.Filter.FilterChar(model.Name);
                _dbConect.Entry(model).Property(x=>x.Name).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Link).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Position).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Parent_Id).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Table_Id).IsModified = true;
                _dbConect.Entry(model).Property(x => x.Type).IsModified = true;
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
            var item = _dbConect.Menus.Find(id);
            if (item != null)
            {
                _dbConect.Menus.Remove(item);
                _dbConect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult Show(int id)
        {
            var item = _dbConect.Menus.Find(id);
            return View(item);
        }
    }
    

}