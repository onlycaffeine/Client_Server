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
            var model = dao.ListAllPaging(tt, muidk, nhomut, vc1, session.Maphuong, 1, 1000);

            var mattduyets = from n in db.Tinhtrangphieudks where n.Matrangthai != "" select n;
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


        [HttpPost]
        public ActionResult InsertPhieutiem(string sophieudk)
        {
            var order = new Phieutiem();

            var dao = new PhieutiemDao();

            long sldonghoadon = dao.Sldong() + 1;
            string mahoadonauto = "pt00" + sldonghoadon.ToString();
            if (sldonghoadon > 9 && sldonghoadon < 100)
            {
                mahoadonauto = "pt0" + sldonghoadon.ToString();
            }
            if (sldonghoadon > 99)
            {
                mahoadonauto = "pt" + sldonghoadon.ToString();
            }

            var pr = db.Phieudangkies.Find(sophieudk);

            bool exists_ = db.Phieutiems.Any(p => p.CCCD == pr.CCCD);
            if (exists_)
            {
                return View("~/Areas/Admin/Views/Phieutiem/Fail1.cshtml");
            }

            if (pr.Matrangthai != "tt004") // trang thai da tiem moi co the them vao phieu tiem
            {
                return View("~/Areas/Admin/Views/Phieutiem/Fail2.cshtml");
            }
            order.Sophieu = mahoadonauto;
            order.Tennguoidan = pr.Tennguoidan;
            order.CCCD = pr.CCCD;
            order.SDT = pr.SDT;
            order.Ngaysinh = (DateTime)pr.Ngaysinh;
            try
            {
                var id = new PhieutiemDao().Insert(order);
                pr.Matrangthai = "tt006";
                db.SaveChanges();
                return View("~/Areas/Admin/Views/Phieutiem/Success.cshtml");
            }
            catch (Exception ex)
            {
                return View("~/Areas/Admin/Views/Phieutiem/Fail.cshtml");
            }

        }
    }
}