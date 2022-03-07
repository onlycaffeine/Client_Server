using Model1.Dao;
using Model1.EF;
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
            //ViewBag.a = a;
            //ViewBag.b = b;
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

    }
}