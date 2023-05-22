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

        public ActionResult Index(string searchString1, int page = 1, int pageSize = 10)
        {
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var dao = new UserDao();

            var model = dao.ListAllPaging(searchString1, session.Maquyen, session.Madiemtiem, session.Maphuong, session.Maquan, session.Matp, page, pageSize);
            var nhomnvs = from k in db.Nhomnhanviens select k;
            var nhomnvws = from j in db.Nhomnhanviens where j.Manhomnv == "cadres" select j;
            var nhomnvds = from x in db.Nhomnhanviens where x.Manhomnv == "w_account" select x;
            var nhomnvcs = from y in db.Nhomnhanviens where y.Manhomnv == "d_account" || y.Manhomnv == "d_leader" select y;
            var dts = from l in db.Diemtiems where l.Maphuong == session.Maphuong select l;

            ViewBag.SearchString1 = searchString1;
            ViewBag.nhomnv = new SelectList(nhomnvs, "Manhomnv", "Tennhomnv");
            ViewBag.nhomnvw = new SelectList(nhomnvws, "Manhomnv", "Tennhomnv");
            ViewBag.nhomnvd = new SelectList(nhomnvds, "Manhomnv", "Tennhomnv");
            ViewBag.nhomnvc = new SelectList(nhomnvcs, "Manhomnv", "Tennhomnv");
            ViewBag.dt = new SelectList(dts, "Madiemtiem", "Tendiemtiem");
            ViewBag.Maquyen = session.Maquyen;
            ViewBag.Mathanhpho = session.Matp;
            ViewBag.Maquan = session.Maquan;
            ViewBag.Maphuong = session.Maphuong;
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

        [HttpGet]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Detail(string id)
        {
            //var nhomnvs = from k in db.Nhomnhanviens select k;
            //ViewBag.Manhom = new SelectList(nhomnvs, "Manhomnv", "Tennhomnv");
            //var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var user = new UserDao().ViewDetail(id);
            string tennhom = "", tentp = "", tenq = "", tenp = "", tendt = "";
            if (user.Manhom != "")
            {
                tennhom = db.Nhomnhanviens.Find(user.Manhom).Tennhomnv;
            }

            if (user.Mathanhpho != "")
            {
                tentp = db.Thanhphoes.Find(user.Mathanhpho).Tenthanhpho;
            }

            if (user.Maquan != "")
            {
                tenq = db.Quans.Find(user.Maquan).Tenquan;
            }

            if (user.Maphuong != "")
            {
                tenp = db.Phuongs.Find(user.Maphuong).Tenphuong;
            }

            if (user.Madiemtiem != "")
            {
                tendt = db.Diemtiems.Find(user.Madiemtiem).Tendiemtiem;
            }

            if(user.Manhom == "storage" || user.Manhom == "leader" || user.Manhom == "admin" || user.Manhom == "n_account")
            {
                tentp = "Không có dữ liệu"; tenq = "Không có dữ liệu"; tenp = "Không có dữ liệu"; tendt = "Không có dữ liệu";
            }

            if (user.Manhom == "c_account" || user.Manhom == "c_leader")
            {
                tenq = "Không có dữ liệu"; tenp = "Không có dữ liệu"; tendt = "Không có dữ liệu";
            }

            if (user.Manhom == "d_account" || user.Manhom == "d_leader")
            {
                tenp = "Không có dữ liệu"; tendt = "Không có dữ liệu";
            }

            if (user.Manhom == "w_account" )
            {
                tendt = "Không có dữ liệu";
            }

            ViewBag.Manhom = tennhom;
            ViewBag.Matp = tentp;
            ViewBag.Maq = tenq;
            ViewBag.Map = tenp;
            ViewBag.Madt = tendt;
            ViewBag.Maquyen = user.Manhom;
            return View(user);
        }

        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Create(string tennv, DateTime ngaynhap, string sdt, string nhomnv, string nhomnvw, string nhomnvd,
            string nhomnvc, bool trangthai, string tk, string mk, string tp, string q, string p, string dt)
        {
            var session = (UserLogin)Session[CSDL_Nangcao.Common.CommonConstants.USER_SESSION];
            var dao = new UserDao();
            string maphuong = dao.Maphuongdk(p);
            string maquan = dao.Maquandk(q);
            string matp = dao.Matpdk(tp);
            string madt = "";
            if (dt != null)
            {
                madt = dao.Madtdk(dt);
            }
            
            long sldonglo = dao.Sldong() + 1;
            string maloauto = "nv00" + sldonglo.ToString();
            if (sldonglo > 9)
            {
                maloauto = "nv0" + sldonglo.ToString();
            }

            if (dao.Checktk(tk))
            {
                return RedirectToAction("Fail", "User");
            }

            if (session.Maquyen == "d_leader" && maquan != session.Maquan)
            {
                return RedirectToAction("Fail0", "User");
            }

            if (session.Maquyen == "d_leader" && maphuong == "")
            {
                return RedirectToAction("Fail1", "User");
            }

            if (session.Maquyen == "c_leader" && matp != session.Matp)
            {
                return RedirectToAction("Fail0", "User");
            }

            if (session.Maquyen == "c_leader" && maquan == "")
            {
                return RedirectToAction("Fail1", "User");
            }

            string nhom = "";
            if (session.Maquyen == "w_account")
            {
                nhom = nhomnvw;
            }

            else if (session.Maquyen == "d_leader")
            {
                nhom = nhomnvd;
            }

            else if (session.Maquyen == "c_leader")
            {
                nhom = nhomnvc;
            }

            else if (session.Maquyen != "c_leader" && session.Maquyen != "d_leader")
            {
                nhom = nhomnv;
            }

            var emp = new Nhanvien();
            emp.Manhanvien = maloauto;
            emp.Tennhanvien = tennv;
            emp.Ngaysinh = ngaynhap;
            emp.SDT = sdt;
            emp.Manhom = nhom;
            emp.Trangthai = trangthai;
            emp.Taikhoan = tk;
            emp.Matkhau = Encryptor.MD5Hash(mk);
            emp.Mathanhpho = matp;
            emp.Maquan = maquan;
            emp.Maphuong = maphuong;
            emp.Madiemtiem = madt;
            //order.Manhanvien = session.UserID;

            try
            {
                var id = new UserDao().Insert(emp);
            }
            catch (Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }

            return View("~/Areas/Admin/Views/User/Success.cshtml");
        }

        [HttpPost]
        [HasCredential(RoleID = "QLY_ND")]
        public ActionResult Edit(Nhanvien user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                //if (!string.IsNullOrEmpty(user.Matkhau))
                //{
                //    var encryptedMd5Pas = Encryptor.MD5Hash(user.Matkhau);
                //    user.Matkhau = encryptedMd5Pas;
                //}


                var result = dao.Update(user);
                if (result)
                {
                    //SetAlert("Sửa user thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật user Không có dữ liệu thành công");
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
            int i = 0, j = 0;

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


        public ActionResult Success()
        {
            return View("~/Areas/Admin/Views/User/Success.cshtml");
        }

        public ActionResult Fail1()
        {
            return View("~/Areas/Admin/Views/User/Fail1.cshtml");
        }

        public ActionResult Fail0()
        {
            return View("~/Areas/Admin/Views/User/Fail0.cshtml");
        }

        public ActionResult Fail()
        {
            return View("~/Areas/Admin/Views/User/Fail.cshtml");
        }
    }
}