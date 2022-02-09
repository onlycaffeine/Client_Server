using CSDL_Nangcao.Common;
using Model1.Dao;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        [HasCredential(RoleID = "QLY_ND")]

        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            ViewBag.SearchString = searchString;

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
            return View(user);
        }

        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Create(Nhanvien user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();

                var encryptedMd5Pas = Encryptor.MD5Hash(user.Matkhau);
                user.Matkhau = encryptedMd5Pas;

                string id = dao.Insert(user);
                if (id != "")
                {
                    //SetAlert("Thêm user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user không thành công");
                }
            }
            return View("Index");
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
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}