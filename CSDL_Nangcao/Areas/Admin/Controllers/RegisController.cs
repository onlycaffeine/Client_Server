using Model1.Dao;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    public class RegisController : Controller
    {
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();
        // GET: Admin/Regis
        public ActionResult Index()
        {
            //return View();
            var dao = new PhieudangkyDao();
            var model = dao.ListAllPaging("",1,10);

            var nguons = from n in db.Vattuytes where n.Maloaivattu == "lvt001" select n;
            ViewBag.nguon = new SelectList(nguons, "Mavattu", "Tenvattu");
            //ViewBag.SearchString = searchString;
            return View(model);
        }


        [HttpGet]
        public ActionResult Create()
        {
            //SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Phieudangky pr)
        {
            if (ModelState.IsValid)
            {
                var dao = new PhieudangkyDao();
                string id = dao.Insert(pr);
                if (id != null)
                {
                    return RedirectToAction("Index", "Regis");
                }

                else
                {
                    ModelState.AddModelError("", "Thêm thành công");
                }
            }
            return View("Index");
        }
    }
}