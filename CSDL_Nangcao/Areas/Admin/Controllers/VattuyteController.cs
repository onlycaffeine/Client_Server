using Model1.Dao;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    public class VattuyteController : Controller
    {
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();
        // GET: Admin/User
        [HasCredential(RoleID = "QLY_ND")]

        public ActionResult Index(string searchString1, int page = 1, int pageSize = 10)
        {
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var dao = new VattuyteDao();
            var model = dao.ListAllPagingql();
            var lvts = from k in db.Loaivattuytes select k;
            var nsxs = from k in db.Nhasanxuats select k;
            ViewBag.lvt = new SelectList(lvts, "Maloaivattu", "Tenloaivattu");
            ViewBag.nsx = new SelectList(nsxs, "Mansx", "Tennsx");
            ViewBag.SearchString1 = searchString1;
            return View(model);
        }
        [HttpGet]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Create()
        {
            return View();
        }

        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Edit(string id)
        {
            var user = new VattuyteDao().ViewDetail(id);
            string tennhom = "", tennsx = "";
            if (user.Maloaivattu != "")
            {
                tennhom = db.Loaivattuytes.Find(user.Maloaivattu).Tenloaivattu;
            }

            if (user.Mansx != "")
            {
                tennsx = db.Nhasanxuats.Find(user.Mansx).Tennsx;
            }
            ViewBag.Malvt = tennhom;
            ViewBag.Mansx = tennsx;
            return View(user);
        }


        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Create(string tennv, string lvt, string nsx)
        {
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var dao = new VattuyteDao();

            long sldonglo = dao.Sldong() + 1;
            string maloauto = "vt00" + sldonglo.ToString();
            if (sldonglo > 9)
            {
                maloauto = "vt0" + sldonglo.ToString();
            }

            var emp = new Vattuyte();
            emp.Mavattu = maloauto;
            emp.Tenvattu = tennv;
            emp.Maloaivattu = lvt;
            emp.Mansx = nsx;
            emp.Trangthai = true;
            //order.Manhanvien = session.UserID;

            try
            {
                var id = new VattuyteDao().Insert(emp);
            }
            catch (Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }

            return View("~/Areas/Admin/Views/Vattuyte/Success.cshtml");
        }

        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Edit(Vattuyte user)
        {
            if (ModelState.IsValid)
            {
                var dao = new VattuyteDao();
                var result = dao.Update(user);
                if (result)
                {
                    //SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "Vattuyte");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Không thành công");
                }
            }
            return View("Index");
        }
        //[HttpDelete]
        //[HasCredential(RoleID = "QLY_ND")]
        //public ActionResult Delete(string id)
        //{
        //    new VattuyteDao().Delete(id);

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        public JsonResult ChangeStatus(string id)
        {
            var result = new VattuyteDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }


        public ActionResult Success()
        {
            return View("~/Areas/Admin/Views/Vattuyte/Success.cshtml");
        }

        public ActionResult Fail1()
        {
            return View("~/Areas/Admin/Views/Vattuyte/Fail1.cshtml");
        }

        public ActionResult Fail0()
        {
            return View("~/Areas/Admin/Views/Vattuyte/Fail0.cshtml");
        }

        public ActionResult Fail()
        {
            return View("~/Areas/Admin/Views/Vattuyte/Fail.cshtml");
        }
    }
}