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
        public ActionResult Index(string searchString, string a = "", string b = "", string madt = "", string sophieu = "")
        {
            var dao1 = new PhieuxuatDao();
            var dao2 = new DongxuatDao();
            var dao3 = new LoDao();
            var dao4 = new PhieulinhDao();

            long sldonghoadon = dao1.Sldong() + 1;
            string mahoadonauto = "px00" + sldonghoadon.ToString();
            if (sldonghoadon > 9)
            {
                mahoadonauto = "px0" + sldonghoadon.ToString();
            }

            var model1 = dao1.ListAllPaging(searchString, a, b);
            var model2 = dao2.ListAllPagingWithoutSohd(searchString);

            ModelCollection model = new ModelCollection();

            model.PhieuxuatDTOs = model1;
            model.Dongxuats = model2;

            var nguons = from n in db.Phieulinhs where n.Matt == "tt002" select n;
            ViewBag.nguon = new SelectList(nguons, "Sophieulinh", "Sophieulinh");
            ViewBag.mahoadonauto = mahoadonauto;
            ViewBag.SearchString = searchString;

            //var pr = dao4.ViewDetail(sophieu);

            return View(model);
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

        [HttpGet]
        public ActionResult CreateCT(string nguon)
        {
            nguon = Request["nguon"];
            var loes = from l in db.Loes where l.SLnhap > 0 && l.Sohoadon != null select l;
            //var tenthuocs = from m in db.Vattuytes select m;

            var dao1 = new PhieulinhDao();
            var dao2 = new LoDao();
            var dao3 = new DongxuatDao();
            var dao4 = new DonglinhDao();

            var model2 = dao2.ListAllPaging1("", "");
            var model3 = dao3.ListAllPagingWithoutSohd("");
            var model4 = dao4.ListAllPagingWithSohd(nguon);

            ModelCollection model = new ModelCollection();

            model.DonglinhDTOs = model4;
            model.LoDTOs = model2;
            model.Dongxuats = model3;

            long sldonglo = dao3.Sldong() + 1;
            string maloauto = "dx00" + sldonglo.ToString();
            if (sldonglo > 9)
            {
                maloauto = "dx0" + sldonglo.ToString();
            }

            string pr = dao1.ViewDetailTenDiemtiem(nguon);
            Session["sophieudutru"] = nguon;
            Session["tendiemtiem"] = pr;
            var nguons = from n in db.Phieulinhs where n.Matt == "tt002" select n;
            ViewBag.nguon = new SelectList(nguons, "Sophieulinh", "Sophieulinh");
            ViewBag.maloauto = maloauto;
            ViewBag.malo = new SelectList(loes, "Malo", "Malo");
            //ViewBag.tenthuoc = new SelectList(tenthuocs, "Mavattu", "Tenvattu");
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateCT(string madx, string malo, int slxuat, Dongxuat order)
        {
            order.Malo = malo;
            order.SLxuat = slxuat;
            order.Madongxuat = madx;

            var nguons = from n in db.Phieulinhs where n.Matt == "tt002" select n;
            ViewBag.nguon = new SelectList(nguons, "Sophieulinh", "Sophieulinh");

            //try
            //{
                var id3 = new DongxuatDao().Insert(order);
            //}
            //catch (Exception ex)
            //{
            //    return Redirect("/loi-thanh-toan");
            //}

            return RedirectToAction("Index", "Capphat");
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
                    ModelState.AddModelError("", "Update lô xuất thành công");
                    return RedirectToAction("Index", "Capphat");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật lô sản phẩm không thành công");
                }
            }
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

        //[HttpGet]
        //public ActionResult Payment()
        //{
        //    return View();
        //}

        [ActionName("MultiDelete")]
        [HttpPost]
        public ActionResult MultiDelete(string sophieux, string sophieudutru)
        {
            var dao = new PhieulinhDao();
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var order = new Phieuxuat();
            order.Sophieuxuat = sophieux;
            order.Ngayxuat = DateTime.Now;
            order.Manhanvien = session.UserID;
            order.Matinhtrang = "tt001";
            order.Madiemtiem = dao.GetMadt(sophieudutru);
            //var pr = new PhieulinhDao().ViewDetail(sophieudutru);
            //pr.Matt = "tt003";
            //db.SaveChanges();
                //var ccc = new PhieulinhDao().Updatettvanchuyen(sophieudutru);
                var cc = new PhieuxuatDao().Insert(order);
                var c = new DongxuatDao().Update1(ref cc);
                //var d = new LoDao().Updatexuat(ref cc);
            //if (c == false)
            //    return Redirect("/loi-thanh-toan");
            new PhieulinhDao().Updateghichu1(sophieudutru);
            db.SaveChanges();

            return View("~/Areas/Admin/Views/Capphat/Success.cshtml");
        }

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
            return View("~/Areas/Admin/Views/Capphat/Success.cshtml");
        }

        public ActionResult Fail()
        {
            return View("~/Areas/Admin/Views/Capphat/Fail.cshtml");
        }

        public ActionResult Fail0()
        {
            return View("~/Areas/Admin/Views/Capphat/Fail0.cshtml");
        }
    }
}