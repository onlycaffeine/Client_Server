using Model1.Dao;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    public class DiemtiemController : Controller
    {
        // GET: Admin/Diemtiem
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DiemtiemDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(string id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(Diemtiem user)
        {
            if (ModelState.IsValid)
            {
                var dao = new DiemtiemDao();
                string id = dao.Insert(user);
                if (id != "")
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(Diemtiem user)
        {
            if (ModelState.IsValid)
            {
                var dao = new DiemtiemDao();
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new DiemtiemDao().Delete(id);

            return RedirectToAction("Index");
        }

    }
}