using Model1.Dao;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    public class RegisController : Controller
    {
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();
        // GET: Admin/Regis
        public ActionResult Index(string tt, string muidk, string nhomut, string vc1)
        {
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            //Session["madt"] = session.Maphuong;

            var dao = new PhieudangkyDao();
            var model = dao.ListAllPaging(tt, muidk, nhomut, vc1,session.Maphuong,1,10);

            var mattduyets = from n in db.Tinhtrangphieudks where n.Matrangthai != "tt004" select n;
            ViewBag.mattduyet = new SelectList(mattduyets, "Matrangthai", "Tentranthai");
            ViewBag.tt = tt;
            ViewBag.muidk = muidk;
            ViewBag.nhomut = nhomut;
            ViewBag.vc1 = vc1;
            if (tt != null && muidk != null && nhomut != null & vc1 != null)
            {
                TempData["tt"] = tt;
                TempData["muidk"] = muidk;
                TempData["nhomut"] = nhomut;
                TempData["vc1"] = vc1;
            }
            return View(model);
        }

        public ActionResult Index1(string tt, string muidk, string nhomut, string vc1)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Update()
        {
            //SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Update(string sophieudk, string trangthaichitiet)
        {
            //if (ModelState.IsValid)
            //{
            var pr = new PhieudangkyDao();
                //pr.Matrangthai = trangthaichitiet;
                //db.SaveChanges();
            bool ok = pr.Updatett(sophieudk, trangthaichitiet);
            //string id = dao.Insert(pr);
            //if (pr.Tentt != null)
            //{
            //    return RedirectToAction("Index", "Regis");
            //}

            //else
            //{
            //    ModelState.AddModelError("", "update thành công");
            //}
            //}
            return RedirectToAction("Index", "Regis");
        }
    }
}