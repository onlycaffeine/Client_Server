using Model1;
using Model1.Dao;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Controllers
{
    public class HomeController : Controller
    {
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Result(string cccd, string sdt, string ten)
        {
            var dao = new PhieutiemDao();
            var model = dao.Tracuu(cccd, sdt, ten);
            return View(model);
        }

        public ActionResult Index(string searchString, int page = 1, int pageSize = 4)
        {
            var dao = new DiemtiemDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            //string Str1 = searchString.Substring(7);
            ViewBag.SearchString = searchString;/*.Substring(7);*/
            return View(model);
        }
    }
}