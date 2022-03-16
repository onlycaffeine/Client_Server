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
    public class DuyetdutruController : Controller
    {
        // GET: Admin/Duyetdutru
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();

        [HasCredential(RoleID = "DUYET_DT")]
        public ActionResult Index(string searchString, string nguon, string a, string b)
        {
            var dao1 = new PhieulinhDao();
            var dao2 = new DonglinhDao();
            var dao3 = new VattuyteDao();

            var model1 = dao1.ListAllPaging1(searchString);
            var model2 = dao2.ListAllPagingWithSohd(nguon);
            var model3 = dao3.ListAllPaging(searchString);

            ModelCollection model = new ModelCollection();

            model.PhieulinhDTOs = model1;
            model.DonglinhDTOs = model2;
            model.VattuyteDTOs = model3;

            var nguons = from n in db.Phieulinhs where n.Matt == "tt001" select n;
            ViewBag.nguon = new SelectList(nguons, "Sophieulinh", "Sophieulinh");


            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Index0(string searchString)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index1(string searchString, string searchString3, string a, string b)
        {
            var dao1 = new PhieulinhDao();
            var dao3 = new VattuyteDao();
            var model1 = dao1.ListAllPaging3(searchString3);
            var model3 = dao3.ListAllPaging(searchString);
            ModelCollection model = new ModelCollection();
            model.PhieulinhDTOs = model1;
            model.VattuyteDTOs = model3;
            var nguons = from n in db.Phieulinhs where n.Matt == "tt001" select n;
            ViewBag.nguon = new SelectList(nguons, "Sophieulinh", "Sophieulinh");
            ViewBag.SearchString3 = searchString3;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
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
            //SetViewBag();
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
            //SetViewBag(pr.Mathuoc);
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
            //SetViewBag(pr.Mathuoc);
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edithd(string id)
        {
            var dao = new PhieulinhDao();
            var pr = dao.ViewDetail(id);
            //SetViewBaghd(pr.Madiemtiem, pr.Matt);
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
            //SetViewBaghd(pr.Madiemtiem, pr.Matt);
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

        [ActionName("MultiDelete")]
        [HttpPost]
        public ActionResult MultiDelete(IEnumerable<int> dsslhuy, string sophieu, int check)
        {
            //if (check != 5)
            //{
            //    ModelState.AddModelError("", "Duyệt không thành công");
            //    return RedirectToAction("Fail0", "Duyetdutru");
            //}

            var dao3 = new DonglinhDao();
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
                if ( arr[j] < 0)
                {
                    ModelState.AddModelError("", "Duyệt không thành công");
                    return RedirectToAction("Fail", "Duyetdutru");
                }
                j += 1;
            }
            j = 0;
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            foreach (var item in model3)
            {
                var lo = db.Donglinhs.Find(item.Madonglinh);
                lo.SLcapphat = arr[j];
                db.SaveChanges();
                j += 1;
            }

            new PhieulinhDao().Updateghichu(sophieu, session.UserID);
            db.SaveChanges();
            return View("~/Areas/Admin/Views/Duyetdutru/Success.cshtml");
        }

        public ActionResult Success()
        {
            return View("~/Areas/Admin/Views/Duyetdutru/Success.cshtml");
        }

        public ActionResult Fail()
        {
            return View("~/Areas/Admin/Views/Duyetdutru/Fail.cshtml");
        }

        public ActionResult Fail0()
        {
            return View("~/Areas/Admin/Views/Duyetdutru/Fail0.cshtml");
        }
    }

}
