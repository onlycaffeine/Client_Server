using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model1.DTO;
using Model1.EF;

namespace Model1.Dao
{
    public class UserDao
    {
        CSDL_NangcaoDbContext db = null;
        public UserDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public bool Checktk(string tk) // trung -> true
        {
            var model = from a in db.Nhanviens where a.Taikhoan == tk select new { a.Manhanvien };
            if (model.LongCount() > 0)
                return true;
            return false;
        }

        public string Maphuongdk(string ten)
        {
            if (ten.Length > 7)
            {
                var p = db.Phuongs.SingleOrDefault(x => x.Tenphuong == ten.Substring(7));
                return p.Maphuong;
            }

            else
            {
                return ten;
            }
        }

        public string Maquandk(string ten)
        {
            if (ten.Length > 7)
            {
                var p = db.Quans.SingleOrDefault(x => x.Tenquan == ten.Substring(5));
                return p.Maquan;
            }

            else
            {
                return ten;
            }
        }

        public string Matpdk(string ten)
        {
            if (ten.Length > 7)
            {
                var p = db.Thanhphoes.SingleOrDefault(x => x.Tenthanhpho == ten.Substring(10));
                return p.Mathanhpho;
            }
            else
            {
                return ten;
            }
        }

        public string Madtdk(string ten)
        {
            if (ten[0] == 'd' && ten[1] == 't')
            {
                return ten;
            }
            else
            {
                var p = db.Diemtiems.SingleOrDefault(x => x.Tendiemtiem == ten);
                return p.Madiemtiem;
            }

        }

        public long Sldong()
        {
            long a = db.Nhanviens.LongCount();
            return a;
        }

        public string Insert(Nhanvien entity)
        {
            db.Nhanviens.Add(entity);
            db.SaveChanges();
            return entity.Manhanvien;
        }
        public string InsertForFacebook(Nhanvien entity)
        {
            var user = db.Nhanviens.SingleOrDefault(x => x.Taikhoan == entity.Taikhoan);
            if (user == null)
            {
                db.Nhanviens.Add(entity);
                db.SaveChanges();
                return entity.Manhanvien;
            }
            else
            {
                return user.Manhanvien;
            }

        }
        public bool Update(Nhanvien entity)
        {
            try
            {
                var user = db.Nhanviens.Find(entity.Manhanvien);
                user.Tennhanvien = entity.Tennhanvien;
                if (!string.IsNullOrEmpty(entity.Matkhau))
                {
                    user.Matkhau = entity.Matkhau;
                }
                user.SDT = entity.SDT;
                //user.Manhom = entity.Manhom;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<NhanvienDTO> ListAllPaging(string searchString, string maquyen, string madt, string map, string maq, string matp, int page, int pageSize)
        {
            List<NhanvienDTO> listLinks = new List<NhanvienDTO>();
            var model = from a in db.Nhanviens
                        join b in db.Nhomnhanviens on a.Manhom equals b.Manhomnv
                        select new
                        {
                            a.Manhanvien,
                            a.Tennhanvien,
                            a.Taikhoan,
                            a.Ngaysinh,
                            a.SDT,
                            b.Tennhomnv,
                            a.Trangthai,
                            a.Manhom,
                            a.Matkhau,
                            a.Madiemtiem,
                            a.Maphuong,
                            a.Maquan,
                            a.Mathanhpho
                        };
            if (maquyen == "w_account")
            {
                model = model.Where(x => x.Manhom == "cadres" && x.Maphuong == map);
            }

            if (maquyen == "d_leader")
            {
                model = model.Where(x => x.Manhom == "cadres" || x.Manhom == "w_account" && x.Maquan == maq);
            }

            if (maquyen == "c_leader")
            {
                model = model.Where(x => x.Manhom == "d_account" || x.Manhom == "d_leader" && x.Mathanhpho == matp);
            }

            //if (maquyen == "leader")
            //{
            //    model = model.Where(x => x.Manhom == "c_account" || x.Manhom == "c_leader");
            //}

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Tennhanvien.Contains(searchString) || x.Tennhanvien.Contains(searchString));
            }
            foreach (var item in model)
            {
                NhanvienDTO temp = new NhanvienDTO();
                temp.Manhanvien = item.Manhanvien;
                temp.Tennhanvien = item.Tennhanvien;
                temp.Taikhoan = item.Taikhoan;
                temp.Ngaysinh = item.Ngaysinh;
                temp.SDT = item.SDT;
                temp.Tennhom = item.Tennhomnv;
                temp.Madiemtiem = item.Madiemtiem;
                temp.Matkhau = item.Matkhau;
                temp.Trangthai = item.Trangthai;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Manhanvien);


            //IQueryable<Nhanvien> model = db.Nhanviens;
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    model = model.Where(x => x.Tennhanvien.Contains(searchString) || x.Tennhanvien.Contains(searchString));
            //}

            //return model.OrderByDescending(x => x.Chucvu);//.ToPagedList(page, pageSize);
        }

        public Nhanvien GetById(string userName)
        {
            return db.Nhanviens.SingleOrDefault(x => x.Taikhoan == userName);
        }
        public Nhanvien ViewDetail(string id)
        {
            return db.Nhanviens.Find(id);
        }
        public List<string> GetListCredential(string userName)
        {
            var user = db.Nhanviens.Single(x => x.Taikhoan == userName);
            var data = (from a in db.Nhomnv_Quyen
                        join b in db.Nhomnhanviens on a.Manhomnv equals b.Manhomnv
                        join c in db.Quyens on a.Maquyen equals c.Maquyen
                        where b.Manhomnv == user.Manhom
                        select new
                        {
                            RoleID = a.Maquyen,
                            UserGroupID = a.Manhomnv
                        }).AsEnumerable().Select(x => new Nhomnv_Quyen()
                        {
                            Maquyen = x.RoleID,
                            Manhomnv = x.UserGroupID
                        });
            return data.Select(x => x.Maquyen).ToList();

        }

        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.Nhanviens.SingleOrDefault(x => x.Taikhoan == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.Manhom == CommonConstants.ADMIN_GROUP)
                    {
                        if (result.Trangthai == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Matkhau == passWord)
                                return 1;
                            else
                                return 1;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Trangthai == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Matkhau.Trim() == passWord)
                            return 1;
                        else
                            return -2;
                    }
                }
            }

        }

        public bool ChangeStatus(string id)
        {
            var user = db.Nhanviens.Find(id);
            user.Trangthai = !user.Trangthai;
            db.SaveChanges();
            return user.Trangthai;
        }
        public bool Delete(string id)
        {
            try
            {
                var user = db.Nhanviens.Find(id);
                db.Nhanviens.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool CheckUserName(string userName)
        {
            return db.Nhanviens.Count(x => x.Taikhoan == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Nhanviens.Count(x => x.Email == email) > 0;
        }
    }
}
