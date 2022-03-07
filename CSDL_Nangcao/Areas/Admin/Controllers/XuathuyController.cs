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
    public class XuathuyController : Controller
    {
        // GET: Admin/Xuathuy
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();
        [HasCredential(RoleID = "XUAT_HUY")]
        public ActionResult Index(string searchString, string a = "", string b = "")
        {
            var dao1 = new PhieuxuathuyDao();
            var dao3 = new LoDao();

            long sldonghoadon = dao1.Sldong() + 1;
            string mahoadonauto = "pxh00" + sldonghoadon.ToString();
            if (sldonghoadon > 9)
            {
                mahoadonauto = "pxh0" + sldonghoadon.ToString();
            }

            var model1 = dao1.ListAllPaging(searchString, a, b);
            var model3 = dao3.ListAllPagingDxh();

            ModelCollection model = new ModelCollection();

            model.Phieuxuathuys = model1;
            model.LoDTOs = model3;

            var dts = from c in db.Diemtiems select c;

            ViewBag.mahoadonauto = mahoadonauto;
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new DongxuathuyDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HasCredential(RoleID = "QLY_ND")]
        [HttpDelete]
        public ActionResult Deletehd(string id)
        {
            new PhieuxuathuyDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new DongxuathuyDao();
            var pr = dao.ViewDetail(id);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edit(Dongxuathuy pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new DongxuathuyDao();
                var result = dao.Update(pr);
                if (result)
                {
                    ModelState.AddModelError("", "Update dòng xuất hủy thành công");
                    return RedirectToAction("Index", "Xuathuy");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edithd(string id)
        {
            var dao = new PhieuxuathuyDao();
            var pr = dao.ViewDetail(id);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edithd(Phieuxuathuy pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhieuxuathuyDao();
                var result = dao.Update(pr);
                if (result)
                {
                    ModelState.AddModelError("", "Update phiếu xuất hủy thành công");
                    return RedirectToAction("Index", "Xuathuy");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật phiếu xuất huỷ không thành công");
                }
            }
            return View("Index");
        }

        public ActionResult Detailhd(string id)
        {
            var dao = new PhieuxuathuyDao();
            var pr = dao.ViewDetail(id);

            var dao1 = new DongxuathuyDao();
            var model = dao1.ListAllPagingWithSohd(pr);
            return View(model);

        }

        [HttpPost]
        [ActionName("MultiDelete")]
        public ActionResult MultiDelete_Post(IEnumerable<int> dsslhuy, string sophieu, string manv,  string ghichu)
        {
            var dao1 = new DongxuathuyDao();
            var dao3 = new LoDao();
            var model3 = dao3.ListAllPagingDxh(); // ko phai ko co dxh
            int[] arr = new int[100];
            int i = 0, j = 0, k = 0;

            foreach (var item in dsslhuy)
            {
                arr[i] = item;
                k += arr[i];
                i += 1;
            }

            foreach (var item in model3)
            {
                if (arr[j] > item.SLnhap || arr[j] < 0)
                {
                    ModelState.AddModelError("", "Thêm phiếu xuất hủy không thành công");
                    return RedirectToAction("Fail", "Xuathuy");
                }
                j += 1;
            }
            if (k==0)
            {
                return RedirectToAction("Fail0", "Xuathuy");
            }
            j = 0;
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var order = new Phieuxuathuy();
            order.Sophieuxuat = sophieu;
            order.Manhanvien = manv;
            order.Ngayxuat = DateTime.Now;
            order.Ghichu = ghichu;
            order.Manhanvien = session.UserID;

            var id3 = new PhieuxuathuyDao().Insert(order);

            foreach (var item in model3)
            {
                string madxhauto = "dxh" + item.Malo.ToString().Substring(2) + sophieu.ToString().Substring(3);
                var dx = new Dongxuathuy();
                dx.Madongxuathuy = madxhauto;
                dx.Maphieuxuathuy = sophieu;
                dx.Malo = item.Malo;
                dx.Slxuat = arr[j];
                j += 1;
                var id = new DongxuathuyDao().Insert(dx);
            }

            new PhieuxuathuyDao().Deleteslxuat0(sophieu);
            db.SaveChanges();
            return View("~/Areas/Admin/Views/Xuathuy/Succcess.cshtml");
        }

        public ActionResult Success()
        {
            return View("~/Areas/Admin/Views/Xuathuy/Succcess.cshtml");
        }

        public ActionResult Fail()
        {
            return View("~/Areas/Admin/Views/Xuathuy/Fail.cshtml");
        }

        public ActionResult Fail0()
        {
            return View("~/Areas/Admin/Views/Xuathuy/Fail0.cshtml");
        }
    }
}