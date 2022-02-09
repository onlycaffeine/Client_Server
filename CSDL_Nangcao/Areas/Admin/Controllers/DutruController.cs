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
    public class DutruController : Controller
    {
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();

        [HasCredential(RoleID = "DUTRU")]
        public ActionResult Index(string searchString, string madt = "", string mathuoc = "", string matt = "")
        {
            var dao1 = new PhieulinhDao();
            var dao2 = new DonglinhDao();

            var model1 = dao1.ListAllPaging(searchString, madt);
            var model2 = dao2.ListAllPaging(mathuoc);

            ModelCollection model = new ModelCollection();

            model.PhieulinhDTOs = model1;
            model.DonglinhDTOs = model2;

            var madts = from c in db.Diemtiems select c;
            var mathuocs = from p in db.Vattuytes select p;
            var matts = from q in db.Trangthais select q;

            ViewBag.madt = new SelectList(madts, "Madiemtiem", "Tendiemtiem"); // danh sách diem tiem
            ViewBag.mathuoc = new SelectList(mathuocs, "Mavattu", "Tenvattu"); // danh sách thuoc
            ViewBag.matt = new SelectList(matts, "Matrangthai", "Tentrangthai"); // danh sách thuoc
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HasCredential(RoleID = "DUYET_DT")]
        public ActionResult Index1(string searchString, string madt = "", string matt = "")
        {
            var dao1 = new PhieulinhDao();
            var model = dao1.ListAllPaging1(searchString, madt);
            var madts = from c in db.Diemtiems select c;
            var matts = from q in db.Trangthais select q;
            ViewBag.madt = new SelectList(madts, "Madiemtiem", "Tendiemtiem"); // danh sách diem tiem
            ViewBag.matt = new SelectList(matts, "Matrangthai", "Tentrangthai"); // danh sách thuoc
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // create dong linh
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Donglinh pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new DonglinhDao();
                string id = dao.Insert(pr);
                if (id != null)
                {
                    return RedirectToAction("Index", "Dutru");
                }

                else
                {
                    ModelState.AddModelError("", "Thêm sp thành công");
                }
            }
            SetViewBag();
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(string ma)
        {
            new DonglinhDao().Delete(ma);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Deletehd(string id)
        {
            new PhieulinhDao().Delete(id);
            return RedirectToAction("Index");
        }

        // edit dong linh
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new DonglinhDao();
            var pr = dao.ViewDetail(id);
            SetViewBag(pr.Mathuoc);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edit(Donglinh pr) /// hoac la DTO 
        {
            if (ModelState.IsValid)
            {
                var dao = new DonglinhDao();
                var result = dao.Update(pr);
                if (result)
                {
                    //SetAlert("Sửa thành công", "success");
                    ModelState.AddModelError("", "Update sản phẩm thành công");
                    return RedirectToAction("Index", "Dutru");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sản phẩm không thành công");
                }
            }
            SetViewBag(pr.Mathuoc);
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edithd(string id)
        {
            var dao = new PhieulinhDao();
            var pr = dao.ViewDetail(id);
            SetViewBaghd(pr.Madiemtiem, pr.Matt);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edithd(Phieulinh pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhieulinhDao();
                var result = dao.Update(pr);
                if (result)
                {
                    //SetAlert("Sửa user thành công", "success");
                    ModelState.AddModelError("", "Update phiếu lĩnh thành công");
                    return RedirectToAction("Index", "Dutru");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật phiếu lĩnh không thành công");
                }
            }
            SetViewBaghd(pr.Madiemtiem, pr.Matt);
            return View("Index");
        }

        public ActionResult Detailhd(string id)
        {
            var dao = new PhieulinhDao();
            var pr = dao.ViewDetail(id);

            var dao1 = new DonglinhDao();
            var model = dao1.ListAllPagingWithSohd(pr);
            return View(model);

        }

        [HttpGet]
        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Payment(string sophieu, string madt, string manv, DateTime ngayyc, string matt)
        {
            //try
            //{
                var id1 = new PhieulinhDao().Insert1(sophieu, madt, manv, ngayyc, matt);
                //if (id1 == null)
                //    return Redirect("/loi-thanh-toan");
            //}
            //catch (Exception ex)
            //{
            //    return Redirect("/loi-thanh-toan");
            //}

            return Redirect("/hoan-thanh");
        }

        public void SetViewBag(string selectedId = "")
        {
            var dao = new VattuyteDao();
            ViewBag.Mathuoc = new SelectList(dao.ListAll(), "Mavattu", "Tenvattu", selectedId);
        }

        public void SetViewBaghd(string selectedId = "", string selectedId1 = "")
        {
            var dao = new DiemtiemDao();
            var dao1 = new TrangthaiDao();
            ViewBag.Madiemtiem = new SelectList(dao.ListAll(), "Madiemtiem", "Tendiemtiem", selectedId); // danh sách diem tiem
            ViewBag.Matt = new SelectList(dao1.ListAll(), "Matrangthai", "Tentrangthai", selectedId1); // danh sách diem tiem
        }


        public ActionResult Success()
        {
            return View("~/Areas/Admin/Views/Nhaptuncc/Success.cshtml");
        }
    }
}