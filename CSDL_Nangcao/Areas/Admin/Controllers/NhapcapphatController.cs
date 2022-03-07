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
    public class NhapcapphatController : Controller
    {
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();

        [HasCredential(RoleID = "NHAP_CP")]
        public ActionResult Index(string searchString, string nguon, string a, string b)
        {

            var dao1 = new PhieuxuatDao();
            var dao2 = new DongxuatDao();
            var dao3 = new DiemtiemDao();

            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            string madt = session.Madiemtiem;
            string tendt = dao3.Tendiemtiem(madt);

            var model1 = dao1.ListAllPaging1(searchString, a, b, madt);
            var model2 = dao2.ListAllPaging(nguon);

            ModelCollection model = new ModelCollection();

            model.PhieuxuatDTOs = model1;
            model.Dongxuats = model2;

            var nguons = from n in db.Phieuxuats where n.Matinhtrang == "tt001" && n.Madiemtiem == madt select n;
            var mavattus = from z in db.Vattuytes select z;
            ViewBag.nguon = new SelectList(nguons, "Sophieuxuat", "Sophieuxuat"); // danh sách nguon
            //ViewBag.mavattu = new SelectList(mavattus, "Mavattu", "Tenvattu");

            ViewBag.SearchString = searchString;
            ViewBag.tendt = tendt;
            return View(model);
        }
        public ActionResult Index1(string searchString, string a, string b)
        {
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            string madt = session.Madiemtiem;
            var dao1 = new PhieuxuatDao();
            var model1 = dao1.ListAllPaging1(searchString, a, b, madt);
            ViewBag.SearchString1 = searchString;
            return View(model1);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string malo, string mavattu, string machithidongbang, string machithinhietdo, int slnhap, int dongia, int solieu, DateTime nsx, DateTime hsd)
        {
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
            try
            {
                var id = new LoDao().Insert(lo);
            }
            catch (Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }
            return RedirectToAction("Index", "Nhaptuncc");
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

        // edit lo
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new DongxuatDao();
            var pr = dao.ViewDetail(id);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edit(Dongxuat pr) /// hoac la DTO 
        {
            if (ModelState.IsValid)
            {
                var dao = new DongxuatDao();
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
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edithd(string id)
        {
            var dao = new PhieuxuatDao();
            var pr = dao.ViewDetail(id);
            SetViewBaghd(pr.Madiemtiem, pr.Makhoxuat, pr.Matinhtrang);
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
                    ModelState.AddModelError("", "Update phiếu nhập cấp phát thành công");
                    return RedirectToAction("Index", "Nhapcapphat");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật phiếu nhập cấp phát không thành công");
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

        [ActionName("MultiDelete")]
        [HttpPost]
        public ActionResult Payment(IEnumerable<int> dsslhuy, string sophieu, string ghichu, int check)
        {
            if(check != 5)
            {
                ModelState.AddModelError("", "Thêm phiếu nhập không thành công");
                return RedirectToAction("Fail0", "Nhapcapphat");
            }

            var dao3 = new DongxuatDao();
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
                    return RedirectToAction("Fail", "Nhapcapphat");
                }
                j += 1;
            }
            j = 0;
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            foreach (var item in model3)
            {
                var lo = db.Dongxuats.Find(item.Madongxuat);
                lo.SLnhap = arr[j];
                db.SaveChanges();
                //item.SLnhap = arr[j];
                j += 1;
            }

            new PhieuxuatDao().Updateghichu(sophieu, ghichu, session.UserID);
            db.SaveChanges();
            return View("~/Areas/Admin/Views/Nhapcapphat/Success.cshtml");
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
            return View("~/Areas/Admin/Views/Nhaptralai/Success.cshtml");
        }

        public ActionResult Fail()
        {
            return View("~/Areas/Admin/Views/Nhaptralai/Fail.cshtml");
        }

        public ActionResult Fail0()
        {
            return View("~/Areas/Admin/Views/Nhaptralai/Fail0.cshtml");
        }
    }

}
