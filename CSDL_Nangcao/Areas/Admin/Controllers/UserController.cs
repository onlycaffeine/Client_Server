using CSDL_Nangcao.Common;
using Model1.Dao;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        CSDL_NangcaoDbContext db = new CSDL_NangcaoDbContext();
        // GET: Admin/User
        [HasCredential(RoleID = "QLY_ND")]

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            var nhomnvs = from k in db.Nhomnhanviens select k;

            ViewBag.SearchString = searchString;
            ViewBag.nhomnv = new SelectList(nhomnvs, "Manhomnv", "Tennhomnv");
            string[] arr = new string[5];
            ViewBag.arr = arr;

            return View(model);
        }
        [HttpGet]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Create()
        {
            return View();
        }

        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Edit(string id)
        {
            var user = new UserDao().ViewDetail(id);
            var nhomnvs = from k in db.Nhomnhanviens select k;
            ViewBag.Manhom = new SelectList(nhomnvs, "Manhomnv", "Tennhomnv");
            return View(user);
        }

        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        //public ActionResult Create(Nhanvien user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new UserDao();

        //        var encryptedMd5Pas = Encryptor.MD5Hash(user.Matkhau);
        //        user.Matkhau = encryptedMd5Pas;

        //        string id = dao.Insert(user);
        //        if (id != "")
        //        {
        //            //SetAlert("Thêm user thành công", "success");
        //            return RedirectToAction("Index", "User");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Thêm user không thành công");
        //        }
        //    }
        //    return View("Index");
        //}
        public ActionResult Create(string maphieu, string tennv, DateTime ngaynhap, string sdt, string nhomnv, bool trangthai )
        {
            //var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var emp = new Nhanvien();
            emp.Manhanvien = maphieu;
            emp.Tennhanvien = tennv;
            emp.Ngaysinh = ngaynhap;
            emp.SDT = sdt;
            emp.Manhom = nhomnv;
            emp.Trangthai = trangthai;
            //order.Ngaynhap = ngaynhap;
            //order.Manhanvien = session.UserID;

            try
            {
                var id = new UserDao().Insert(emp);
            }
            catch (Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }

            //return Redirect("/hoan-thanh");
            //return View("~/Areas/Admin/Views/Nhaptuncc/Success.cshtml");
            return RedirectToAction("Index", "User");
        }

        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Edit(Nhanvien user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (!string.IsNullOrEmpty(user.Matkhau))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.Matkhau);
                    user.Matkhau = encryptedMd5Pas;
                }


                var result = dao.Update(user);
                if (result)
                {
                    //SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user không thành công");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Delete(string id)
        {
            new UserDao().Delete(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        public JsonResult ChangeStatus(string id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }


        public async Task<ActionResult> CreateMany()
        {
            List<Nhanvien> forums = new List<Nhanvien>();
            for (int i = 0; i < 5; i++)
            {
                forums.Add(new Nhanvien());
            }
            return View(forums);
        }
        [HttpPost]
        public async Task<ActionResult> CreateMany(List<Nhanvien> forums)
        {
            return View(forums);
        }

        //[HttpPost]
        //public ActionResult Delete(IEnumerable<string> employeeIdsToDelete)
        //{
        //    db.Nhanviens.Where(x => employeeIdsToDelete.Contains(x.Manhanvien)).ToList().ForEach(db.Nhanviens.Remove());
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [ActionName("MultiDelete")]
        public ActionResult MultiDelete_Post(IEnumerable<string> employeeIdsToDelete)
        {

            //(from nv in db.Nhanviens
            // where employeeIdsToDelete.Contains(nv.Manhanvien.ToString())
            // select nv).ToList().ForEach(x => db.Nhanviens.Remove(x));

            //List<Nhanvien> xnv =
            //(from nv in db.Nhanviens
            // where employeeIdsToDelete.Contains(nv.Manhanvien.ToString())
            // select nv).ToList();

            string[] arr = new string[5];
            int i = 0, j=0;

            foreach (var item in employeeIdsToDelete)
            {
                arr[i] = item;
                i += 1;
            }

            foreach (var item in employeeIdsToDelete)
            {
                var emp = new Lo();
                //var emp = db.Loes.Find();
                emp.Malo = item;
                emp.Dangdonggoi = arr[j];
                j += 1;
                var id = new LoDao().Insert(emp);
            }

            db.SaveChanges();
            //List<Dongxuathuy> xnv =
            //(from nv in db.Dongxuathuys
            // where nv.Slxuat == 0
            // select nv).ToList();

            //foreach (var item in xnv)
            //{
            //    var emp = new Lo();
            //    emp.Malo = item.Malo;
            //    emp.SLnhap = 0;
            //    var id = new LoDao().Insert(emp);
            //}

            //db.SaveChanges();


            //try
            //{
            //    var id = new UserDao().Insert(emp);
            //}
            //catch (Exception ex)
            //{
            //    return Redirect("/loi-thanh-toan");
            //}


            return RedirectToAction("Index");
            //return View(db.Nhanviens.ToList());
            //return Redirect("/hoan-thanh");
        }

    }
}