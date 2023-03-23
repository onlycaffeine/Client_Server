using Model1.Dao;
using Model1.EF;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    public class ThongkephieutiemController : Controller
    {
        // GET: Admin/Thongkephieutiem
        public ActionResult Index1(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new DiemtiemDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HasCredential(RoleID = "W_TKE_TIEM")]
        public ActionResult Index(string a, string b, string khuvuc = "")
        {
            var dao = new ThongkephieutiemDao();

            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            //var model = dao.ListAllPagingQG(matp, maquan, map, a, b, khuvuc, maquyen);
            var model = dao.ListAllPagingQG(session.Matp, session.Maquan, session.Maphuong, a, b, khuvuc, session.Maquyen);
            //Session["maquyen"] = session.Maquyen;
            ViewBag.Maquyen = session.Maquyen;
            ViewBag.khuvuc = khuvuc;

            return View(model);
        }

        [HttpGet]
        public ActionResult Edithd(string id, string a, string b, string passdt)
        {
            var dao = new DiemtiemDao();
            var pr = dao.ViewDetail(id);

            var dao1 = new ThongkephieutiemDao();
            var model = dao1.ListAllPagingWithMadt(pr, a, b);

            string check = dao.Check(id);
            if (passdt == check)
                return View(model);
            return View("SaiPass");
        }

        [HasCredential(RoleID = "D_TKE_TIEM")]
        [HttpGet]
        public ActionResult Thongkequan(string maquan, string a, string b, string passquan)
        {
            var dao = new QuanDao();

            var dao1 = new ThongkephieutiemDao();
            var model2 = dao1.ListAllPagingWithMaquan(maquan, a, b);
            string check = dao.Check(maquan);
            if (passquan == check)
                return View(model2);
            return View("SaiPass");
        }

        [HasCredential(RoleID = "C_TKE_TIEM")]
        [HttpGet]
        public ActionResult Thongkethanhpho(string a, string b, string passtp)
        {
            var dao1 = new ThongkephieutiemDao();
            var model2 = dao1.ListAllPaging(a, b);

            if (passtp == "thanhpho")
                return View(model2);
            return View("SaiPass");
        }

        public ActionResult SaiPass()
        {
            return View("~/Areas/Admin/Views/Thongkephieutiem/SaiPass.cshtml");
        }

        public void ExportToExcel(string a, string b, string khuvuc = "")
        {

            //var dao = new ThongkephieutiemDao();
            //var emplist = dao.ListAll1();

            var dao = new ThongkephieutiemDao();

            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            //var model = dao.ListAllPagingQG(matp, maquan, map, a, b, khuvuc, maquyen);
            //string a = "4-4-2012";
            //string b = "4-4-2023";
            var emplist = dao.ListAllPagingQG(session.Matp, session.Maquan, session.Maphuong, a, b, khuvuc, session.Maquyen);

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["C3"].Value = "BỘ Y TẾ";
            ws.Cells["G4"].Value = "KẾT QUẢ TIÊM CHỦNG COVID-19 TRONG NĂM";
            ws.Cells["G4"].Style.Font.Size = 16;
            ws.Cells["G4"].Style.Font.Bold = true;

            ws.Cells["I5"].Value = "Tháng   /";
            ws.Cells["B7"].Value = "Tỉnh/thành phố:";
            ws.Cells["H7"].Value = "Xã gửi lên huyện trước ngày 05 tháng sau";
            ws.Cells["B8"].Value = "Huyện/Quận/Thị xã:";
            ws.Cells["H8"].Value = "Huyện/quận gửi lên Tỉnh trước ngày 10 tháng sau";
            ws.Cells["B9"].Value = "Phường/xã:";
            ws.Cells["H9"].Value = "Tỉnh gửi TCMRQG trước ngày 15 tháng sau";

            ws.Cells["B11"].Value = "TT";
            ws.Cells["B11"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["C11"].Value = "Địa phương";
            ws.Cells["D11"].Value = "Miễn dịch cơ bản";
            ws.Cells["D11"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[11, 4, 11, 12].Merge = true;
            ws.Cells["M11"].Value = "Số người đủ 3 mũi";
            ws.Cells["N11"].Value = "Số ca pưst";
            ws.Cells["N11"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[11, 14, 11, 15].Merge = true;

            ws.Cells["D12"].Value = "Astrazenaca";
            ws.Cells["D12"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["G12"].Value = "Pfizer";
            ws.Cells["G12"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["J12"].Value = "VeroCell";
            ws.Cells["J12"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["N12"].Value = "Nhẹ";
            ws.Cells["N12"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["O12"].Value = "Nghiêm trọng";

            ws.Cells["D13"].Value = "1";
            ws.Cells["E13"].Value = "2";
            ws.Cells["F13"].Value = "3";
            ws.Cells["G13"].Value = "1";
            ws.Cells["H13"].Value = "2";
            ws.Cells["I13"].Value = "3";
            ws.Cells["J13"].Value = "1";
            ws.Cells["K13"].Value = "2";
            ws.Cells["L13"].Value = "3";
            ws.Cells["D13"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["E13"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["F13"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["G13"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["H13"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["I13"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["J13"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["K13"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["L13"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            ws.Cells[12, 4, 12, 6].Merge = true;
            ws.Cells[12, 7, 12, 9].Merge = true;
            ws.Cells[12, 10, 12, 12].Merge = true;

            ws.Cells[11, 2, 13, 2].Merge = true;
            ws.Cells[11, 3, 13, 3].Merge = true;
            ws.Cells[11, 13, 13, 13].Merge = true;
            ws.Cells[12, 14, 13, 14].Merge = true;
            ws.Cells[12, 15, 13, 15].Merge = true;


            //ws.Cells["A3"].Value = "Date";
            //ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            int rowStart = 14;
            int cnt = 1;
            foreach (var item in emplist)
            {
                ws.Cells[string.Format("B{0}", rowStart)].Value = cnt;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Madiemtiem;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.SLastra1;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.SLastra2;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.SLastra3;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.SLpfi1;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.SLpfi2;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.SLpfi3;
                ws.Cells[string.Format("J{0}", rowStart)].Value = item.SLvero1;
                ws.Cells[string.Format("K{0}", rowStart)].Value = item.SLvero2;
                ws.Cells[string.Format("L{0}", rowStart)].Value = item.SLvero3;
                ws.Cells[string.Format("M{0}", rowStart)].Value = item.SLtiem;
                ws.Cells[string.Format("N{0}", rowStart)].Value = item.SLtcnhe;
                ws.Cells[string.Format("O{0}", rowStart)].Value = item.SLtcnang;
                rowStart++;
                cnt++;
            }

            ws.Column(3).BestFit = true;
            ws.Cells[11, 2, rowStart, 15].AutoFitColumns();
            Border border = ws.Cells[11, 2, rowStart, 15].Style.Border;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

        }
    }
}