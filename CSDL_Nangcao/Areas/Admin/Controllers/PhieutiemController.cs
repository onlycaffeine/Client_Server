using Model1;
using Model1.Dao;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{

    public class PhieutiemController : Controller
    {
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();
        // GET: Admin/Phieutiem
        [HasCredential(RoleID = "NHAP_TTT")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            //var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            //Session["madt"] = session.Madiemtiem;

            var dao = new PhieutiemDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            long sldonghoadon = dao.Sldong() + 1;
            string mahoadonauto = "pt00" + sldonghoadon.ToString();
            if (sldonghoadon > 9)
            {
                mahoadonauto = "pt0" + sldonghoadon.ToString();
            }

            ViewBag.SearchString = searchString;
            ViewBag.mahoadonauto = mahoadonauto;
            return View(model);
        }

        [HttpGet]
        public ActionResult CreateCT(string id)
        {
            var dao = new ChitietphieutiemDao();
            long sldonghoadon = dao.Sldong() + 1;
            string mahoadonauto = "ctpt00" + sldonghoadon.ToString();
            if (sldonghoadon > 9)
            {
                mahoadonauto = "ctpt0" + sldonghoadon.ToString();
            }

            //var dao = new PhieutiemDao();
            //var pr = dao.ViewDetail(id);
            Session["sophieutiem"] = id;
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            Session["madt"] = session.Madiemtiem;
            //SetViewBaghd(pr.Mancc, pr.Manguon, pr.Makhonhap);
            //return View(id);

            var ctdbs = from p in db.Vattuytes where p.Maloaivattu == "lvt001" select p;
            var lms = from l in db.Loaimuis select l;
            ViewBag.Mathuoc = new SelectList(ctdbs, "Mavattu", "Tenvattu");
            ViewBag.Loaimui = new SelectList(lms, "Maloaimui", "Ten");
            ViewBag.mahoadonauto = mahoadonauto;
            return View();
        }

        [HttpPost]
        public ActionResult CreateCT(Chitietphhieutiem pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new ChitietphieutiemDao();
                int loaimuitruoc = Int32.Parse(pr.Loaimui);
                if (pr.Loaimui != "1" && (pr.Ngaytiem - dao.ngaytiemtruoc(pr.Sophieutiem, loaimuitruoc)).TotalDays < 60)
                {
                    return RedirectToAction("Fail0", "Phieutiem");
                }
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string sophieutiem, string tennd, string cccd, string sdt, DateTime ngaysinh)
        {
            var order = new Phieutiem();
            order.Sophieu = sophieutiem;
            order.Tennguoidan = tennd;
            order.CCCD = cccd;
            order.SDT = sdt;
            order.Ngaysinh = ngaysinh;

            try
            {
                var id = new PhieutiemDao().Insert(order);
                return View("~/Areas/Admin/Views/Phieutiem/Success.cshtml");
            }
            catch (Exception ex)
            {
                return Redirect("/loi-nhap");
            }
        }

        [HttpGet]
        public ActionResult Edithd(string id)
        {
            var dao = new PhieutiemDao();
            var pr = dao.ViewDetail(id);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edithd(Phieutiem pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhieutiemDao();
                var result = dao.Update(pr);
                if (result)
                {
                    ModelState.AddModelError("", "Update phiếu tiêm thành công");
                    return RedirectToAction("Index", "Phieutiem");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật phiếu tiêm không thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Detailpn(string id)
        {
            var dao = new PhieutiemDao();
            var pr = dao.ViewDetail(id);
            Session["sophieutiem"] = pr.Sophieu;

            var dao1 = new ChitietphieutiemDao();
            var model = dao1.ListAllPagingWithSopn(pr);
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new PhieutiemDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult DeleteCT(string id)
        {
            new ChitietphieutiemDao().Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Success()
        {
            return View("~/Areas/Admin/Views/Phieutiem/Success.cshtml");
        }

        public ActionResult Fail0()
        {
            return View("~/Areas/Admin/Views/Phieutiem/Fail0.cshtml");
        }
    }
}