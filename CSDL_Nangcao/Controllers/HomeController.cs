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
            int[] sltiems = new int[31];
            var dao = new DiemtiemDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);

            for (int i = 1; i < 31; i++)
            {
                sltiems[i - 1] = dao.Sltiem(i);
            }

            ViewBag.SearchString = searchString;
            ViewBag.sltiem = sltiems;
            return View(model);
        }

        [HttpGet]
        public ActionResult Regis()
        {
            var dao = new TiensuDao();
            var model = dao.ListAllPaging();
            return View(model);
        }

        [HttpPost]
        public ActionResult Regis(string sophieutiem, string tennd, string cccd, string sdt)//, DateTime ngaysinh
        {
            var order = new Phieudangky();
            order.Sophieudangky = "test1";
            order.Ngaysinh = DateTime.Now;
            order.Ngaymongmuon = DateTime.Now;
            //order.Tennguoidan = tennd;
            //order.CCCD = cccd;
            //order.SDT = sdt;
            //order.Ngaysinh = ngaysinh;

            try
            {
                var id = new PhieudangkyDao().Insert(order);
                //return Redirect("/hoan-thanh");
                return RedirectToAction("Index", "Phieudangky");
                //return Content("Hello World");

            }
            catch (Exception ex)
            {
                return Redirect("/loi-nhap");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string loaimui, string hotendk, string sdtdk, string fullname, DateTime? dateof, string gender, string phonenumber,
            string email, string identity, string insurance, string job, string jobadd, string add, string tenphuong, string dantoc, string nuoc, string uutien,
            string input_name_guardian,string input_relation, string input_phone_guardian, DateTime? ngaymm, string buoimm, DateTime? ngaytiem1, string tenvc1, string malo1,
            string diemtiem1, string phanung, IEnumerable<string> dsslhuy, IEnumerable<int> checkts)
        {
            string[] arr = new string[15];
            string[] arr1 = new string[15];
            int m = 1, n = 1;

            foreach (var item in dsslhuy)
            {
                
                arr[m] = item;
                m += 1;
            }

            foreach (var item in checkts)
            {
                if(item == 0)
                    arr1[n] = "tt001";
                else
                    arr1[n] = "tt002";
                n += 1;
            }

            var dao2 = new PhieudangkyDao();

            long sldonglo = dao2.Sldong() + 1;
            string maloauto = "pdk00" + sldonglo.ToString();
            if (sldonglo > 9)
            {
                maloauto = "pdk0" + sldonglo.ToString();
            }

            //if (ngaytiem1 == null)
            //{
            //    this.ModelState.AddModelError("birthdate", "You must supply a birthdate.");
            //}

            string maphuong = dao2.Maphuongdk(tenphuong);
            string mathuocdk = dao2.Mathuocdk(tenvc1);
            string manhomdk = dao2.Manhomdk(uutien);

            var order = new Phieudangky();
            order.Sophieudangky = maloauto;
            order.Loaimui = loaimui;
            order.Hotendangky = hotendk;
            order.SDTdangky = sdtdk;
            order.Tennguoidan = fullname;
            order.Ngaysinh = dateof;
            order.Gioitinh = gender;
            order.SDT = phonenumber;
            order.Email = email;
            order.CCCD = identity;
            order.Bhyt = insurance;
            order.Nghenghiep = job;
            order.Donvicongtac = jobadd;
            order.Diachi = add;
            order.Maphuong = maphuong; //
            order.Tenphuong = tenphuong;
            order.Dantoc = dantoc;
            order.Quoctich = nuoc;
            order.Manhomuutien = manhomdk;//
            order.Tennhomuutien = uutien;
            order.Hotengiamho = input_name_guardian;
            order.Quanhegiamho = input_relation;
            order.SDTgiamho = input_phone_guardian;
            order.Ngaymongmuon = ngaymm;
            order.Buoimongmuon = buoimm;
            order.Ngaytiem1 = ngaytiem1;
            order.Mathuoc1 = mathuocdk;//
            order.Tenthuoc1 = tenvc1;
            order.Malo1 = malo1;
            order.Diadiemtiem1 = diemtiem1;
            order.Phanungtiem1 = phanung;
            order.Matrangthai = "tt001";


            var id = new PhieudangkyDao().Insert(order);

            for (int i = 1; i < 10; i++)
            {
                string mats = "ts00" + i.ToString();
                var orderi = new Phieudky_Tiensu();
                orderi.Maphieudangky = maloauto;
                orderi.Matiensu = mats;
                orderi.Trieuchung = arr[i];
                orderi.Matrangthai = arr1[i];
                var idi = new PhieudangkyDao().InsertTS(orderi);
            }

            for (int j = 10; j < 13; j++)
            {
                string mats = "ts0" + j.ToString();
                var orderj = new Phieudky_Tiensu();
                orderj.Maphieudangky = maloauto;
                orderj.Matiensu = mats;
                orderj.Trieuchung = arr[j];
                orderj.Matrangthai = arr1[j];
                var idi = new PhieudangkyDao().InsertTS(orderj);
            }

            //try
            //{

            return RedirectToAction("Index", "Home");
            //}
            //catch (Exception ex)
            //{
            //    return Redirect("/loi-nhap");
            //}
        }
    }
}