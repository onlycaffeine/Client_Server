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
    public class NhaptralaiController : Controller
    {
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();

        [HasCredential(RoleID = "NHAP_NCC")]
        public ActionResult Index(string searchString, string nguon , string a, string b)
        {
            var dao1 = new TralaiDao();
            var dao2 = new DongtralaiDao();

            var model1 = dao1.ListAllPaging1(searchString, a, b);
            var model2 = dao2.ListAllPaging(nguon);

            ModelCollection model = new ModelCollection();

            model.Phieuxuattralais = model1;
            model.DongxuattralaiDTOs = model2;

            var nguons = from n in db.Phieuxuattralais where n.Matinhtrang == "tt001" select n;
            var mavattus = from z in db.Vattuytes select z;
            
            ViewBag.nguon = new SelectList(nguons, "Sophieuxuat", "Sophieuxuat");
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Index1(string searchString, string a, string b)
        {
            var dao1 = new TralaiDao();
            var model1 = dao1.ListAllPaging1(searchString, a, b);
            ViewBag.SearchString = searchString;
            return View(model1);
        }

        // create dong nhap tra lai
        [HttpGet]
        public ActionResult Create()
        {
            //SetViewBag();

            return View();
        }

        [HttpPost]
        //public ActionResult Create(Lo pr)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new LoDao();
        //        string id = dao.Insert(pr);
        //        if (id != null)
        //        {
        //            return RedirectToAction("Index", "Nhaptuncc");
        //        }

        //        else
        //        {
        //            ModelState.AddModelError("", "Thêm sp thành công");
        //        }
        //    }
        //    SetViewBag();
        //    return View("Index");
        //}

        public ActionResult Create(string malo, string mavattu, string machithidongbang, string machithinhietdo, int slnhap, int dongia, int solieu, DateTime nsx, DateTime hsd)
        {
            //var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var lo = new Lo();
            lo.Malo = malo;
            lo.Mavattu = mavattu;
            lo.Machithidongbang = machithidongbang;
            lo.Machithinhietdo = machithinhietdo;
            lo.SLnhap = slnhap;
            lo.Dongia = dongia;
            lo.Solieutrenmotcai = solieu;
            lo.NSX = nsx;
            lo.HSD = hsd;
            //order.Ngaynhap = ngaynhap;
            //order.Manhanvien = session.UserID;

            try
            {
                var id = new LoDao().Insert(lo);
            }
            catch (Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }
            //SetViewBag();
            return RedirectToAction("Index", "Nhaptuncc");
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new DongtralaiDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Deletehd(string id)
        {
            new TralaiDao().Delete(id);
            return RedirectToAction("Index");
        }

        // edit lo
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new DongtralaiDao();
            var pr = dao.ViewDetail(id);
            //SetViewBag(pr.Machithidongbang, pr.Machithinhietdo);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edit(Dongxuattralai pr) /// hoac la DTO 
        {
            if (ModelState.IsValid)
            {
                var dao = new DongtralaiDao();
                var result = dao.Update(pr);
                if (result)
                {
                    //SetAlert("Sửa thành công", "success");
                    ModelState.AddModelError("", "Update lô sản phẩm thành công");
                    return RedirectToAction("Index", "Nhaptralai");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật lô sản phẩm không thành công");
                }
            }
            //SetViewBag(pr.Machithidongbang, pr.Machithinhietdo);
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edithd(string id)
        {
            var dao = new TralaiDao();
            var pr = dao.ViewDetail(id);
            SetViewBaghd(pr.Madiemtiem, pr.Matinhtrang);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edithd(Phieuxuattralai pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new TralaiDao();
                var result = dao.Update(pr);
                if (result)
                {
                    //SetAlert("Sửa user thành công", "success");
                    ModelState.AddModelError("", "Update phiếu nhập trả lại thành công");
                    return RedirectToAction("Index", "Nhaptralai");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật phiếu nhập trả lại không thành công");
                }
            }
            SetViewBaghd(pr.Madiemtiem, pr.Matinhtrang);
            return View("Index");
        }

        public ActionResult Detailhd(string id)
        {
            var dao = new TralaiDao();
            var pr = dao.ViewDetail(id);

            var dao1 = new DongtralaiDao();
            var model = dao1.ListAllPagingWithSohd(pr);
            return View(model);

        }

        [ActionName("MultiDelete")]
        [HttpPost]
        public ActionResult Payment(IEnumerable<int> dsslhuy, string sophieu, string ghichu)
        {
            var dao3 = new DongtralaiDao();
            var model3 = dao3.ListAllPaging(sophieu);
            int[] arr = new int[100];
            int j = 0, i = 0, k = 0;

            foreach (var item in dsslhuy)
            {
                arr[i] = item;
                k += arr[i];
                i += 1;
            }

            foreach (var item in model3)
            {
                if (arr[j] > item.SLxuat || arr[j] < 0)
                {
                    ModelState.AddModelError("", "Thêm phiếu nhập không thành công");
                    return RedirectToAction("Fail", "Nhaptralai");
                }
                j += 1;
            }
            j = 0;
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            foreach (var item in model3)
            {
                var lo = db.Dongxuattralais.Find(item.Madongxuattralai);
                lo.SLnhap = arr[j];
                db.SaveChanges();
                //item.SLnhap = arr[j];
                j += 1;
            }

            new TralaiDao().Updateghichu(sophieu, ghichu, session.UserID);
            db.SaveChanges();
            return View("~/Areas/Admin/Views/Nhaptralai/Success.cshtml");
        }

        public void SetViewBaghd(string selectedId = "", string selectedId1 = "")
        {
            var dao = new DiemtiemDao();
            var dao1 = new TinhtrangxuattralaiDao();
            ViewBag.Madiemtiem = new SelectList(dao.ListAll(), "Madiemtiem", "Tendiemtiem", selectedId);
            ViewBag.Matinhtrang = new SelectList(dao1.ListAll(), "Matrangthai", "Tentrangthai", selectedId1);
        }

        public ActionResult Success()
        {
            return View("~/Areas/Admin/Views/Nhaptralai/Success.cshtml");
        }

        public ActionResult Fail()
        {
            return View("~/Areas/Admin/Views/Nhaptralai/Fail.cshtml");
        }
    }

}
