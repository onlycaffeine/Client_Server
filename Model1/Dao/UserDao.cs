using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
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
                user.Chucvu = entity.Chucvu;
                user.Manhom = entity.Manhom;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<Nhanvien> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Nhanvien> model = db.Nhanviens;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Tennhanvien.Contains(searchString) || x.Tennhanvien.Contains(searchString));
            }

            return model.OrderByDescending(x => x.Chucvu);//.ToPagedList(page, pageSize);
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
                    if (result.Manhom == CommonConstants.ADMIN_GROUP )
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
                        if (result.Matkhau == passWord)
                            return 1;
                        else
                            return 1;
                    }
                }
            }

            }

            public bool? ChangeStatus(long id)
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
