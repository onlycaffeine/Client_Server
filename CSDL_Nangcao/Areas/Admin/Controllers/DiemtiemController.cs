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
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();
        // GET: Admin/User
        [HasCredential(RoleID = "QLY_ND")]

        public ActionResult Index(string searchString1, int page = 1, int pageSize = 10)
        {
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var dao = new DiemtiemDao();

            var model = dao.ListAllPagingQl(searchString1, session.Maquyen, session.Maphuong, session.Maquan, session.Matp, page, pageSize);


            ViewBag.SearchString1 = searchString1;

            ViewBag.Maquyen = session.Maquyen;
            ViewBag.Mathanhpho = session.Matp;
            ViewBag.Maquan = session.Maquan;
            ViewBag.Maphuong = session.Maphuong;
            string[] arr = new string[5];
            ViewBag.arr = arr;

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
            var user = new DiemtiemDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Create(string ndd, string tendt, int sbt, bool trangthai, string diachi, string tp, string q, string p)
        {
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var dao = new DiemtiemDao();
            string maphuong = dao.Maphuongdk(p);
            string maquan = dao.Maquandk(q);
            string matp = dao.Matpdk(tp);

            long sldonglo = dao.Sldong() + 1;
            string maloauto = "dt00" + sldonglo.ToString();
            if (sldonglo > 9)
            {
                maloauto = "dt0" + sldonglo.ToString();
            }

            if (session.Maquyen == "d_leader" && maquan != session.Maquan)
            {
                return RedirectToAction("Fail0", "Diemtiem");
            }

            if (session.Maquyen == "d_leader" && maphuong == "")
            {
                return RedirectToAction("Fail1", "Diemtiem");
            }

            if (session.Maquyen == "c_leader" && matp != session.Matp)
            {
                return RedirectToAction("Fail0", "Diemtiem");
            }

            if (session.Maquyen == "c_leader" && maquan == "")
            {
                return RedirectToAction("Fail1", "Diemtiem");
            }

            var emp = new Diemtiem();
            emp.Madiemtiem = maloauto;
            emp.Tendiemtiem = tendt;
            emp.Trangthai = trangthai;
            emp.Sobantiem = sbt;
            emp.Tennguoidungdau = ndd;
            //emp.Mathanhpho = matp;
            emp.Maquan = maquan;
            emp.Maphuong = maphuong;
            emp.Diachi = diachi;
            emp.Mathanhpho = matp;
            //order.Manhanvien = session.UserID;

            try
            {
                var id = new DiemtiemDao().Insert(emp);
            }
            catch (Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }

            return View("~/Areas/Admin/Views/Diemtiem/Success.cshtml");
        }

        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Edit(Diemtiem user)
        {
            if (ModelState.IsValid)
            {
                var dao = new DiemtiemDao();

                var result = dao.Update(user);
                if (result)
                {
                    //SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "Diemtiem");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật Không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Delete(string id)
        {
            new DiemtiemDao().Delete(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        public JsonResult ChangeStatus(string id)
        {
            var result = new DiemtiemDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }

        public ActionResult Success()
        {
            return View("~/Areas/Admin/Views/Diemtiem/Success.cshtml");
        }

        public ActionResult Fail1()
        {
            return View("~/Areas/Admin/Views/Diemtiem/Fail1.cshtml");
        }

        public ActionResult Fail0()
        {
            return View("~/Areas/Admin/Views/Diemtiem/Fail0.cshtml");
        }

    }
}