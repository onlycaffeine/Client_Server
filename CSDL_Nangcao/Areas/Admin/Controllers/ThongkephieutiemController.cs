using Model1.Dao;
using Model1.EF;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;


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
            ViewBag.a = a;
            ViewBag.b = b;
            if (a != null && b != null && khuvuc != null)
            {
                TempData["a"] = a;
                TempData["b"] = b;
                TempData["khuvuc"] = khuvuc;
            }

            return View(model);
        }

        //public File()

        [HttpPost]
        public FileResult Export(string a, string b, string khuvuc = "")
        {
            var dao = new ThongkephieutiemDao();

            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var emplist = dao.ListAllPagingQG(session.Matp, session.Maquan, session.Maphuong, a, b, khuvuc, session.Maquyen);

            DateTime myDatea = DateTime.Parse(a);
            DateTime myDateb = DateTime.Parse(b);
            string start = myDatea.ToString("dd-MM-yyyy");
            string end = myDateb.ToString("dd-MM-yyyy");

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            string tentinhthanhpho = new DiemtiemDao().Tenthanhpho(session.Matp);
            string tenquanhuyen = new DiemtiemDao().Tenquan(session.Maquan);
            string tenphuongxa = new DiemtiemDao().Tenphuong(session.Maphuong);
            //ViewBag.tongslasta1 = tongslasta1;

            if (session.Maquyen == "n_account" || session.Maquyen == "admin")
            {
                ws.Cells["B7"].Value = "Tỉnh/thành phố: ";
                ws.Cells["H7"].Value = "Xã gửi lên huyện trước ngày 05 tháng sau";
                ws.Cells["B8"].Value = "Huyện/Quận/Thị xã: ";
                ws.Cells["H8"].Value = "Huyện/quận gửi lên Tỉnh trước ngày 10 tháng sau";
                ws.Cells["B9"].Value = "Phường/xã: ";
            }
            else if (session.Maquyen == "c_account")
            {
                ws.Cells["B7"].Value = "Tỉnh/thành phố: " + tentinhthanhpho;
                ws.Cells["H7"].Value = "Xã gửi lên huyện trước ngày 05 tháng sau";
                ws.Cells["B8"].Value = "Huyện/Quận/Thị xã: " ;
                ws.Cells["H8"].Value = "Huyện/quận gửi lên Tỉnh trước ngày 10 tháng sau";
                ws.Cells["B9"].Value = "Phường/xã: " ;
            }
            else if (session.Maquyen == "d_account")
            {
                ws.Cells["B7"].Value = "Tỉnh/thành phố: " + tentinhthanhpho;
                ws.Cells["H7"].Value = "Xã gửi lên huyện trước ngày 05 tháng sau";
                ws.Cells["B8"].Value = "Huyện/Quận/Thị xã: " + tenquanhuyen;
                ws.Cells["H8"].Value = "Huyện/quận gửi lên Tỉnh trước ngày 10 tháng sau";
                ws.Cells["B9"].Value = "Phường/xã: ";
            }
            else if (session.Maquyen == "w_account")
            {
                ws.Cells["B7"].Value = "Tỉnh/thành phố: " + tentinhthanhpho;
                ws.Cells["H7"].Value = "Xã gửi lên huyện trước ngày 05 tháng sau";
                ws.Cells["B8"].Value = "Huyện/Quận/Thị xã: " + tenquanhuyen;
                ws.Cells["H8"].Value = "Huyện/quận gửi lên Tỉnh trước ngày 10 tháng sau";
                ws.Cells["B9"].Value = "Phường/xã: " + tenphuongxa;
            }

            ws.Cells["C3"].Value = "Mẫu 03/13-TCMR";
            ws.Cells["C3"].Value = "BỘ Y TẾ";
            ws.Cells["C3"].Style.Font.Bold = true;
            //ws.Cells["D3"].Value = khuvuc;
            //ws.Cells["E3"].Value = ViewBag.khuvuc;
            ws.Cells["G4"].Value = "KẾT QUẢ TIÊM CHỦNG COVID-19 TRONG NĂM";
            ws.Cells["G4"].Style.Font.Size = 16;
            ws.Cells["G4"].Style.Font.Bold = true;
            ws.Cells["H5"].Value = "         Thời gian: " + start + " đến " + end;
            
            //if(khuvuc != "")
            
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

            int rowStart = 14;
            int cnt = 1;
            int tongslastra1 = 0; int tongslastra2 = 0; int tongslastra3 = 0; int tongslpfizer1 = 0;int tongslpfizer2 = 0; int tongslpfizer3 = 0; int tongslverocell1 = 0;int tongslverocell2 = 0;
            int tongslverocell3 = 0; int tongsl3mui = 0;int tongslnhe = 0;int tongslnang = 0;
            foreach (var item in emplist)
            {
                ws.Cells[string.Format("B{0}", rowStart)].Value = cnt;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Madiemtiem;
                ws.Cells[string.Format("C{0}", rowStart + 1)].Value = "Tổng";
                tongslastra1 += item.SLastra1;
                tongslastra2 += item.SLastra2;
                tongslastra3 += item.SLastra3;
                tongslpfizer1 += item.SLpfi1;
                tongslpfizer2 += item.SLpfi2;
                tongslpfizer3 += item.SLpfi3;
                tongslverocell1 += item.SLvero1;
                tongslverocell2 += item.SLvero2;
                tongslverocell3 += item.SLvero3;
                tongsl3mui += item.SLtiem;
                tongslnhe += item.SLtcnhe;
                tongslnang += item.SLtcnang;
                ws.Cells[string.Format("D{0}", rowStart + 1)].Value = tongslastra1;
                ws.Cells[string.Format("E{0}", rowStart + 1)].Value = tongslastra2;
                ws.Cells[string.Format("F{0}", rowStart + 1)].Value = tongslastra3;
                ws.Cells[string.Format("G{0}", rowStart + 1)].Value = tongslpfizer1;
                ws.Cells[string.Format("H{0}", rowStart + 1)].Value = tongslpfizer2;
                ws.Cells[string.Format("I{0}", rowStart + 1)].Value = tongslpfizer3;
                ws.Cells[string.Format("J{0}", rowStart + 1)].Value = tongslverocell1;
                ws.Cells[string.Format("K{0}", rowStart + 1)].Value = tongslverocell2;
                ws.Cells[string.Format("L{0}", rowStart + 1)].Value = tongslverocell3;
                ws.Cells[string.Format("M{0}", rowStart + 1)].Value = tongsl3mui;
                ws.Cells[string.Format("N{0}", rowStart + 1)].Value = tongslnhe;
                ws.Cells[string.Format("O{0}", rowStart + 1)].Value = tongslnang;
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
            ws.Cells[string.Format("C{0}", rowStart + cnt + 1)].Value = "Người lập báo cáo";
            ws.Cells[string.Format("C{0}", rowStart + cnt + 2)].Value = "(Ký, ghi rõ họ tên)";
            ws.Cells[string.Format("C{0}", rowStart + cnt + 2)].Style.Font.Italic = true;

            ws.Cells[string.Format("O{0}", rowStart + cnt + 0)].Value = "Ngày      Tháng      Năm";
            ws.Cells[string.Format("O{0}", rowStart + cnt + 1)].Value = "Thủ trưởng";
            ws.Cells[string.Format("O{0}", rowStart + cnt + 1)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[string.Format("O{0}", rowStart + cnt + 2)].Value = "(Ký, ghi rõ họ tên)";
            ws.Cells[string.Format("O{0}", rowStart + cnt + 2)].Style.Font.Italic = true;
            //ws.Cells["D17"].Value = tongslastra1;

            ws.Column(13).BestFit = true;
            ws.Cells[11, 2, rowStart, 15].AutoFitColumns();
            Border border = ws.Cells[11, 2, rowStart, 15].Style.Border;
            border.Bottom.Style = border.Top.Style = border.Left.Style = border.Right.Style = ExcelBorderStyle.Thin;
            ws.Column(13).Width = 17;
            ws.Column(15).Width = 14;

            return File(pck.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
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

            if (a != null && b != null)
            {
                TempData["a"] = a;
                TempData["b"] = b;
            }

            if (passtp == "thanhpho")
                return View(model2);
            return View("SaiPass");
        }

        public ActionResult SaiPass()
        {
            return View("~/Areas/Admin/Views/Thongkephieutiem/SaiPass.cshtml");
        }

    }
}