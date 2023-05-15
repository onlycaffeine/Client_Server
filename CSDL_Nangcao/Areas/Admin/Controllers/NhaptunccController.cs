using Model1;
using Model1.Dao;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Microsoft.Office.Interop.Word;
using DocumentFormat.OpenXml.Bibliography;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    public class NhaptunccController : Controller
    {
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();

        [HasCredential(RoleID = "NHAP_NCC")]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10, string a = "", string b = "", string mancc = "",
                string manguon = "", string makho = "", string mactdb = "", string mactnd = "")
        {
            var dao1 = new HoadonnhapDao();
            var dao2 = new LoDao();

            long sldonglo = dao2.Sldong() + 1;
            string maloauto = "lo00" + sldonglo.ToString();
            if (sldonglo > 9)
            {
                maloauto = "lo0" + sldonglo.ToString();
            }

            long sldonghoadon = dao1.Sldong() + 1;
            string mahoadonauto = "hd00" + sldonghoadon.ToString();
            if (sldonghoadon > 9)
            {
                mahoadonauto = "hd0" + sldonghoadon.ToString();
            }

            var model1 = dao1.ListAllPaging(searchString, page, pageSize, a, b, mancc, manguon, makho);
            var model2 = dao2.ListAllPaging(mactdb, mactnd);

            ModelCollection model = new ModelCollection();

            model.HoadonnhapDTOs = model1;
            model.LoDTOs = model2;

            var nccs = from c in db.Nhacungcaps select c;
            var khoes = from k in db.Khoes select k;
            var nguons = from n in db.Nguons select n;

            var ctdbs = from p in db.Chithidongbangs select p;
            var ctnds = from q in db.Chithinhietdoes select q;
            var mavattus = from z in db.Vattuytes where z.Trangthai == true select z;

            ViewBag.ncc = new SelectList(nccs, "Mancc", "Tencc"); // danh sách ncc
            ViewBag.nguon = new SelectList(nguons, "Manguon", "Tennguon"); // danh sách nguon
            ViewBag.kho = new SelectList(khoes, "Makho", "Tenkho"); // danh sách kho

            ViewBag.Mahithidongbang = new SelectList(ctdbs, "Machithidongbang", "Tenchithidongbang");
            ViewBag.Machithinhietdo = new SelectList(ctnds, "Machithinhietdo", "Tenchithinhietdo");
            ViewBag.mavattu = new SelectList(mavattus, "Mavattu", "Tenvattu");

            ViewBag.maloauto = maloauto;
            ViewBag.mahoadonauto = mahoadonauto;
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // create lo
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();

            return View();
        }

        [HttpPost]

        public ActionResult Create(string malo, string mavattu, string machithidongbang, string machithinhietdo, int slnhap, int dongia, int solieu, DateTime nsx, DateTime hsd)
        {
            //if (ModelState.IsValid)
            //{
            //    if (nsx == Convert.ToDateTime("08/13/2000") || hsd == Convert.ToDateTime("08/13/2000"))
            //    {
            //        return RedirectToAction("Fail1", "Nhaptuncc");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "Cập nhật lô sản phẩm không thành công");
            //    }
            //}

            //else
            //    return RedirectToAction("Fail1", "Nhaptuncc");

            if (nsx > hsd)
            {
                return RedirectToAction("Fail1", "Nhaptuncc");
            }

            if (slnhap < 0 || dongia < 0 || solieu < 0)
            {
                return RedirectToAction("Fail", "Nhaptuncc");
            }
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
            SetViewBag();
            return RedirectToAction("Index", "Nhaptuncc");
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            new LoDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Deletehd(string id)
        {
            new HoadonnhapDao().Delete(id);
            return RedirectToAction("Index");
        }

        // edit lo
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var dao = new LoDao();
            var pr = dao.ViewDetail(id);
            SetViewBag(pr.Machithidongbang, pr.Machithinhietdo);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edit(Lo pr) /// hoac la DTO 
        {
            if (ModelState.IsValid)
            {
                var dao = new LoDao();
                var result = dao.Update(pr);
                if (result)
                {
                    //SetAlert("Sửa thành công", "success");
                    ModelState.AddModelError("", "Update lô sản phẩm thành công");
                    return RedirectToAction("Index", "Nhaptuncc");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật lô sản phẩm không thành công");
                }
            }
            SetViewBag(pr.Machithidongbang, pr.Machithinhietdo);
            return View("Index");
        }

        [HttpGet]
        public ActionResult Edithd(string id)
        {
            var dao = new HoadonnhapDao();
            var pr = dao.ViewDetail(id);
            SetViewBaghd(pr.Mancc, pr.Manguon, pr.Makhonhap);
            return View(pr);
        }

        [HttpPost]
        public ActionResult Edithd(Hoadonnhap pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new HoadonnhapDao();
                var result = dao.Update(pr);
                if (result)
                {
                    //SetAlert("Sửa user thành công", "success");
                    ModelState.AddModelError("", "Update hóa đơn nhập thành công");
                    return RedirectToAction("Index", "Nhaptuncc");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật hóa đơn nhập không thành công");
                }
            }
            SetViewBaghd(pr.Mancc, pr.Manguon, pr.Makhonhap);
            return View("Index");
        }

        public ActionResult Detailhd(string id)
        {
            var dao = new HoadonnhapDao();
            var pr = dao.ViewDetail(id);

            var dao1 = new LoDao();
            var model = dao1.ListAllPagingWithSohd(pr);
            ViewBag.id = id;
            return View(model);
        }

        [HttpPost]
        public FileResult ExporttoW(string id)
        {

            var dao = new HoadonnhapDao();
            var pr = dao.ViewDetail(id);

            var dao1 = new LoDao();
            var model = dao1.ListAllPagingWithSohd(pr);
            // Đường dẫn đến file word gốc
            string filePath = @"D:\TemplateHoadonnhap";

            // Tạo đối tượng Word.Application
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = false;
            wordApp.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone;
            // Mở file Word
            Microsoft.Office.Interop.Word.Document wordDoc = wordApp.Documents.Open(filePath);
            wordApp.Visible = true;
            wordApp.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsAll;
            // Thực hiện các thao tác chỉnh sửa file Word ở đây
            // Ví dụ: thay thế nội dung "old text" bằng "new text"
            string a = pr.Ngaynhap.ToString("d/M/yyyy");
            string b = pr.Sohoadon.ToString();
            wordDoc.Content.Find.Execute(FindText: "<Ngày nhập>", ReplaceWith: "Ngày Nhập: " + a);
            wordDoc.Content.Find.Execute(FindText: "<Số hợp đồng>", ReplaceWith: "Số hóa đơn: " + b);
            // Get reference to the first table in the document
            Table table = wordDoc.Tables[1];
            // Create a new row object and add it to the table
            int i = 1;
            foreach (var item in model)
            {
                Row newRow = table.Rows.Add();

                // Set the values of each cell in the new row
                //newRow.Cells[1].Range.Text = item.Sohoadon;
                newRow.Cells[1].Range.Text = item.Malo;
                newRow.Cells[2].Range.Text = item.Solieutrenmotcai.ToString();
                newRow.Cells[3].Range.Text = item.SLnhap.ToString();
                newRow.Cells[4].Range.Text = item.Dongia.ToString();
                newRow.Cells[5].Range.Text = (item.SLnhap * item.Dongia).ToString();
                i++;
            }

            // Save the changes to the document
            // Lưu file Word với tên "new_a.docx"
            string newFilePath = @"D:\Grid1.docx";
            object fileName = newFilePath;
            object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatXMLDocument;
            wordDoc.SaveAs(ref fileName, ref fileFormat);

            // Đóng file Word và đối tượng Word.Application
            wordDoc.Close();
            wordApp.Quit();

            // Trả về file mới vừa chỉnh sửa
            byte[] fileBytes = System.IO.File.ReadAllBytes(newFilePath);
            string fileName1 = "Grid1.docx";
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName1);
        }

        [HttpGet]
        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Payment(string maphieu, string ncc, string nguon, string kho)
        {
            var dao1 = new LoDao();
            var model = dao1.ListAllPagingCheckHd();
            if (model.Count() > 0)
            {
                var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
                var order = new Hoadonnhap();
                order.Sohoadon = maphieu;
                order.Mancc = ncc;
                order.Manguon = nguon;
                order.Makhonhap = kho;
                order.Ngaynhap = DateTime.Now;
                order.Manhanvien = session.UserID;

                try
                {
                    var id = new HoadonnhapDao().Insert(order);
                    var c = new LoDao().Update1(ref id);
                    if (c == false)
                        return Redirect("/loi-thanh-toan");
                }
                catch (Exception ex)
                {
                    return Redirect("/loi-thanh-toan");
                }

                return View("~/Areas/Admin/Views/Nhaptuncc/Success.cshtml");
            }
            else

                return View("~/Areas/Admin/Views/Nhaptuncc/Fail0.cshtml");
        }

        public void SetViewBag(string selectedId1 = "", string selectedId2 = "")
        {
            var dao1 = new ChithidongbangDao();
            var dao2 = new ChithinhietdoDao();

            ViewBag.Machithidongbang = new SelectList(dao1.ListAll(), "Machithidongbang", "Tenchithidongbang", selectedId1);
            ViewBag.Machithinhietdo = new SelectList(dao2.ListAll(), "Machithinhietdo", "Tenchithinhietdo", selectedId2);
        }

        public void SetViewBaghd(string selectedId1 = "", string selectedId2 = "", string selectedId3 = "")
        {

            var dao1 = new NhacungcapDao();
            var dao2 = new NguonDao();
            var dao3 = new KhoDao();

            ViewBag.Mancc = new SelectList(dao1.ListAll(), "Mancc", "Tencc", selectedId1); // danh sách ncc
            ViewBag.Manguon = new SelectList(dao2.ListAll(), "Manguon", "Tennguon", selectedId2); // danh sách nguon
            ViewBag.Makhonhap = new SelectList(dao3.ListAll(), "Makho", "Tenkho", selectedId3); // danh sách kho
        }


        public ActionResult Success()
        {
            return View("~/Areas/Admin/Views/Nhaptuncc/Success.cshtml");
        }

        public ActionResult Fail()
        {
            return View("~/Areas/Admin/Views/Nhaptuncc/Fail.cshtml");
        }

        public ActionResult Fail0()
        {
            return View("~/Areas/Admin/Views/Nhaptuncc/Fail0.cshtml");
        }

        public ActionResult Fail1()
        {
            return View("~/Areas/Admin/Views/Nhaptuncc/Fail1.cshtml");
        }
    }
}