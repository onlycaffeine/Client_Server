using Model1.Dao;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    public class ChitietphieutiemController : Controller
    {
        // GET: Admin/Chitietphieutiem
        public ActionResult Index()
        {
            var dao = new ChitietphieutiemDao();
            var model = dao.ListAllPaging();

            //ViewBag.SearchString = searchString;
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            //SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Chitietphhieutiem pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChitietphieutiemDao();
                string id = dao.Insert(pr);
                if (id != null)
                {
                    return RedirectToAction("Index", "Phieutiem");
                }

                else
                {
                    ModelState.AddModelError("", "Thêm chi tiết phiếu tiêm thành công");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new LoDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new ChitietphieutiemDao();
            var pr = dao.ViewDetail(id);
            //SetViewBag(pr.CategoryID);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edit(Chitietphhieutiem pr)
        {
            var dao = new ChitietphieutiemDao();
            var result = dao.Update(pr);
            if (result)
            {
                ModelState.AddModelError("", "Update chi tiết phiếu tiêm thành công");
                return RedirectToAction("Index", "Phieutiem");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật chi tiết phiếu tiêm không thành công");

            }

            ////SetViewBag(pr.CategoryID);
            return RedirectToAction("Index", "Phieutiem");
        }
    }
}