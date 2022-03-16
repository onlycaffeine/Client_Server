using Model1.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {

            long sllohethan = new LoDao().sllohethan();
            long sllosaphethan = new LoDao().sllosaphethan();
            long slduyet = new PhieuxuatDao().Slduyet();
            long slpx = new PhieuxuatDao().Sldongchuanhap();
            long sltl = new TralaiDao().Sldongchuanhap();
            ViewBag.sllohethan = sllohethan;
            ViewBag.sllosaphethan = sllosaphethan;
            ViewBag.slduyet = slduyet;
            ViewBag.slpx = slpx;
            ViewBag.sltl = sltl;

            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            ViewBag.Maquyen = session.Maquyen;
            return View();
        }

        public ActionResult TopMenu()
        {
            return PartialView();
        }
    }
}