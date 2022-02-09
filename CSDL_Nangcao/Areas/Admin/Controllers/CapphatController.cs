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
    public class CapphatController : Controller
    {
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();

        [HasCredential(RoleID = "XUAT_CP")]
        public ActionResult Index(string searchString, string a = "", string b = "", string madt = "", string makho = "", string matt = "")
        {
            var dao1 = new PhieuxuatDao();
            var dao2 = new DongxuatDao();

            var model1 = dao1.ListAllPaging(searchString, a, b, madt, makho, matt);
            var model2 = dao2.ListAllPagingWithoutSohd(searchString);

            ModelCollection model = new ModelCollection();

            model.PhieuxuatDTOs = model1;
            model.Dongxuats = model2;

            var dts = from c in db.Diemtiems select c;
            var khoes = from k in db.Khoes select k;
            var tts = from u in db.Tinhtrangpxes select u;
            ViewBag.dt = new SelectList(dts, "Madiemtiem", "Tendiemtiem"); // danh sách diem tiem
            ViewBag.kho = new SelectList(khoes, "Makho", "Tenkho"); // danh sách kho
            ViewBag.tt = new SelectList(tts, "Matinhtrang", "Tentinhtrang"); // danh sách tt

            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HasCredential(RoleID = "NHAP_CP")]
        public ActionResult Index1(string searchString, string a = "", string b = "", string madt = "", string makho = "", string matt = "")
        {
            var dao1 = new PhieuxuatDao();
            var model1 = dao1.ListAllPaging(searchString, a, b, madt, makho, matt);

            var dts = from c in db.Diemtiems select c;
            var khoes = from k in db.Khoes select k;
            var tts = from u in db.Tinhtrangpxes select u;
            ViewBag.dt = new SelectList(dts, "Madiemtiem", "Tendiemtiem"); // danh sách diem tiem
            ViewBag.kho = new SelectList(khoes, "Makho", "Tenkho"); // danh sách kho
            ViewBag.tt = new SelectList(tts, "Matinhtrang", "Tentinhtrang"); // danh sách tt

            ViewBag.SearchString = searchString;
            return View(model1);
        }


        [HttpGet]
        public ActionResult Create()
        {
            //SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Dongxuat pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new DongxuatDao();
                string id = dao.Insert(pr);
                if (id != null)
                {
                    return RedirectToAction("Index", "Capphat");
                }

                else
                {
                    ModelState.AddModelError("", "Thêm sp thành công");
                }
            }
            //SetViewBag();
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new DongxuatDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Deletehd(string id)
        {
            new PhieuxuatDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new DongxuatDao();
            var pr = dao.ViewDetail(id);
            //SetViewBag(pr.Mathuoc);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edit(Dongxuat pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new DongxuatDao();
                var result = dao.Update(pr);
                if (result)
                {
                    ModelState.AddModelError("", "Update lô sản phẩm thành công");
                    return RedirectToAction("Index", "Capphat");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật lô sản phẩm không thành công");
                }
            }
            //SetViewBag(pr.Mathuoc);
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edithd(string id)
        {
            var dao = new PhieuxuatDao();
            var pr = dao.ViewDetail(id);
            SetViewBaghd( pr.Madiemtiem, pr.Makhoxuat, pr.Matinhtrang);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edithd(Phieuxuat pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhieuxuatDao();
                var result = dao.Update(pr);
                if (result)
                {
                    ModelState.AddModelError("", "Update phiếu xuất thành công");
                    return RedirectToAction("Index", "Capphat");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật phiếu xuất không thành công");
                }
            }
            SetViewBaghd(pr.Madiemtiem, pr.Makhoxuat, pr.Matinhtrang);
            return View("Index");
        }

        public ActionResult Detailhd(string id)
        {
            var dao = new PhieuxuatDao();
            var pr = dao.ViewDetail(id);

            var dao1 = new DongxuatDao();
            var model = dao1.ListAllPagingWithSohd(pr);
            return View(model);

        }

        [HttpGet]
        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Payment(string sophieu, string dt, string kho, string manv, DateTime ngayxuat, string tt)
        {
            var order = new Phieuxuat();
            order.Sophieuxuat = sophieu;
            order.Madiemtiem = dt;
            order.Manhanvien = manv;
            order.Makhoxuat = kho;
            order.Ngayxuat = ngayxuat;
            order.Matinhtrang = tt;
            try
            {
                var id3 = new PhieuxuatDao().Insert(order);
                var c = new DongxuatDao().Update1(ref id3);
                if (c == false)
                    return Redirect("/loi-thanh-toan");
            }
            catch (Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }

            return Redirect("/hoan-thanh");
        }

        //public void SetViewBag(string selectedId = "")
        //{
        //    var dao = new VattuyteDao();
        //    ViewBag.Mathuoc = new SelectList(dao.ListAll(), "Mavattu", "Tenvattu", selectedId);
        //}

        public void SetViewBaghd(string selectedId = "", string selectedId1 = "", string selectedId2 = "")
        {
            var dao = new DiemtiemDao();
            var dao1 = new KhoDao();
            var dao3 = new TinhtrangpxDao();
            ViewBag.Madiemtiem = new SelectList(dao.ListAll(), "Madiemtiem", "Tendiemtiem", selectedId); // danh sách diem tiem
            ViewBag.Makhoxuat = new SelectList(dao1.ListAll(), "Makho", "Tenkho", selectedId); // danh sách diem tiem
            ViewBag.Matinhtrang = new SelectList(dao3.ListAll(), "Matinhtrang", "Tentinhtrang", selectedId); // danh sách diem tiem
        }


        public ActionResult Success()
        {
            return View("~/Areas/Admin/Views/Nhaptuncc/Success.cshtml");
        }
    }
}