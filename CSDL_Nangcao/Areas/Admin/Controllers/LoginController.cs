using CSDL_Nangcao.Models;
using Model1;
using Model1.Dao;
using CSDL_Nangcao.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSDL_Nangcao.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        //[HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                //var result = dao.Login(model.UserName, model.Password); //Encryptor.MD5Hash(model.Password)
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password.Trim()));
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.Taikhoan;
                    userSession.UserID = user.Manhanvien;
                    userSession.GroupID = user.Manhom;
                    userSession.Madiemtiem = user.Madiemtiem; // them o day
                    userSession.Maphuong = user.Maphuong; // them o day
                    userSession.Maquan = user.Maquan; // them o day
                    userSession.Matp = user.Mathanhpho; // them o day
                    userSession.Maquyen = user.Manhom; // them o day
                    var listCredentials = dao.GetListCredential(model.UserName);

                    Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Quyền truy cập bị từ chối.");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng.");
                }
            }
            return View("Login");
        }

    }
}