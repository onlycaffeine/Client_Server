using Model1;
using Model1.Dao;
using Model1.DTO;
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
        public ActionResult Index(string searchString, string mathuoc = "")
        {
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];

            var dao1 = new PhieulinhDao();
            var dao2 = new DonglinhDao();
            var dao3 = new VattuyteDao();

            long sldonghoadon = dao1.Sldong() + 1;
            string mahoadonauto = "pl00" + sldonghoadon.ToString();
            if (sldonghoadon > 9)
            {
                mahoadonauto = "pl0" + sldonghoadon.ToString();
            }

            var model1 = dao1.ListAllPaging(searchString, session.Madiemtiem);
            var model2 = dao2.ListAllPaging(mathuoc);
            var model3 = dao3.ListAllPaging1();

            ModelCollection model = new ModelCollection();

            model.PhieulinhDTOs = model1;
            model.DonglinhDTOs = model2;
            model.Vattuytes = model3;

            var madts = from c in db.Diemtiems select c;
            var mathuocs = from p in db.Vattuytes select p;
            var matts = from q in db.Trangthais select q;

            ViewBag.madt = new SelectList(madts, "Madiemtiem", "Tendiemtiem");
            ViewBag.mathuoc = new SelectList(mathuocs, "Mavattu", "Tenvattu");
            ViewBag.matt = new SelectList(matts, "Matrangthai", "Tentrangthai");
            ViewBag.SearchString = searchString;
            ViewBag.mahoadonauto = mahoadonauto;
            return View(model);
        }

        [HasCredential(RoleID = "DUYET_DT")]
        public ActionResult Index1(string searchString, string madt = "", string matt = "")
        {
            var dao1 = new PhieulinhDao();
            var model = dao1.ListAllPaging1(searchString);//, madt);
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
            var model = dao1.ListAllPagingWithSohd(pr.Sophieulinh);
            return View(model);

        }

        [HttpPost]
        [ActionName("MultiDelete")]
        public ActionResult MultiDelete_Post(IEnumerable<int> dsslhuy, string sophieu, string manv)//, string ghichu
        {
            var dao1 = new Donglinh();
            var dao3 = new VattuyteDao();
            var model3 = dao3.ListAllPaging("");
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
                if ( arr[j] < 0)
                {
                    ModelState.AddModelError("", "Thêm phiếu dự trù không thành công");
                    return RedirectToAction("Fail", "Dutru");
                }
                j += 1;
            }
            if (k == 0)
            {
                return RedirectToAction("Fail0", "Dutru");
            }
            j = 0;
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var order = new Phieulinh();
            order.Sophieulinh = sophieu;
            order.Manhanvien = manv;
            order.Ngayyeucau = DateTime.Now;
            order.Madiemtiem = session.Madiemtiem;
            order.Matt = "tt001";
            order.Manhanvien = session.UserID;

            var id3 = new PhieulinhDao().Insert(order);

            foreach (var item in model3)
            {
                string madxhauto = "dl" + item.Mavattu.ToString().Substring(2) + sophieu.ToString().Substring(2);
                var dx = new Donglinh();
                dx.Madonglinh = madxhauto;
                dx.Sophieulinh = sophieu;
                dx.Mathuoc = item.Mavattu;
                dx.SLyeucau = arr[j];
                j += 1;
                var id = new DonglinhDao().Insert(dx);
            }

            //new Phieulinh().Deleteslxuat0(sophieu);
            //db.SaveChanges();
            return View("~/Areas/Admin/Views/Dutru/Success.cshtml");
        }

        public void SetViewBag(string selectedId = "")
        {
            var dao = new VattuyteDao();
            ViewBag.Mathuoc = new SelectList(dao.ListAll(), "Mavattu", "Tenvattu", selectedId);
        }

        public void SetViewBaghd(string selectedId = "", string selectedId1 = "")
        {
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var dao = new DiemtiemDao();
            var dao1 = new TrangthaiDao();
            ViewBag.Madiemtiem = new SelectList(dao.ListAll(), "Madiemtiem", "Tendiemtiem", selectedId);
            ViewBag.Matt = new SelectList(dao1.ListAll(), "Matrangthai", "Tentrangthai", selectedId1);
            //ViewBag.Madiemtiem = new SelectList(dao.ListAll(), "Madiemtiem", "Tendiemtiem", selectedId);
            //ViewBag.Matt = new SelectList(dao1.ListAll(), "Matrangthai", "Tentrangthai", selectedId1);
        }

        public ActionResult Success()
        {
            return View("~/Areas/Admin/Views/Dutru/Success.cshtml");
        }

        public ActionResult Fail()
        {
            return View("~/Areas/Admin/Views/Dutru/Fail.cshtml");
        }

        public ActionResult Fail0()
        {
            return View("~/Areas/Admin/Views/Dutru/Fail0.cshtml");
        }
    }
}