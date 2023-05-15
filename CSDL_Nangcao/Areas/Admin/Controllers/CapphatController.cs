﻿using Model1;
using Model1.Dao;
using Model1.EF;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Interop.Word;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    //[Authorize]
    public class CapphatController : BaseController
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

        public ActionResult PartialView()
        {
            var dao2 = new DongxuatDao();
            var ls = dao2.ListAllPagingWithoutSohddto();
            return View(ls);
        }
        public ActionResult ExportPdf()
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            converter.Options.WebPageWidth = 1000;
            converter.Options.WebPageHeight = 1000;
            converter.Options.MarginLeft = 10;
            converter.Options.MarginRight = 10;
            converter.Options.MarginBottom = 20;
            converter.Options.MarginTop = 20;
            
            var dao2 = new DongxuatDao();
            var ls = dao2.ListAllPagingWithoutSohddto();
            var lss = db.Dongxuats.ToList();

            var htmlPdf = base.RenderPartialToString("~/Areas/Admin/Views/Capphat/PartialView.cshtml", ls, ControllerContext);

            // create a new pdf document converting an html string
            PdfDocument doc = converter.ConvertHtmlString(htmlPdf);

            string filename = string.Format("{0}.pdf", DateTime.Now.Ticks);
            string pathfile = string.Format("{0}/{1}", Server.MapPath("~/Resource/Pdf"), filename);

            // save pdf document
            doc.Save(pathfile);

            // close pdf document
            doc.Close();

            return Json(filename, JsonRequestBehavior.AllowGet);
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
            ViewBag.id = id;
            return View(model);

        }

        [HttpPost]
        public FileResult ExporttoW(string id)
        {

            var dao = new PhieuxuatDao();
            var pr = dao.ViewDetail(id);

            var dao1 = new DongxuatDao();
            var model = dao1.ListAllPagingWithSohd(pr);
            // Đường dẫn đến file word gốc
            string filePath = @"D:\TemplatePhieucapphat";

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
            string b = pr.Sophieuxuat.ToString();
            wordDoc.Content.Find.Execute(FindText: "<Ngày nhập>", ReplaceWith: "Ngày Nhập: " + a);
            wordDoc.Content.Find.Execute(FindText: "<Số hợp đồng>", ReplaceWith: "Số phiếu cấp phát: " + b);
            // Get reference to the first table in the document
            Table table = wordDoc.Tables[1];
            // Create a new row object and add it to the table
            int i = 1;
            foreach (var item in model)
            {
                Row newRow = table.Rows.Add();

                // Set the values of each cell in the new row
                //newRow.Cells[1].Range.Text = item.Sohoadon;
                newRow.Cells[1].Range.Text = i.ToString();
                newRow.Cells[2].Range.Text = item.Tenthuoc.ToString();
                newRow.Cells[3].Range.Text = item.Malo.ToString();
                newRow.Cells[4].Range.Text = item.HSD.ToString("d/M/yyyy");
                newRow.Cells[5].Range.Text = item.SLxuat.ToString();
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