using Model1.DTO;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class UsergroupDao
    {

        CSDL_NangcaoDbContext db = null;
        public UsergroupDao()
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



        public IEnumerable<Nhomnhanvien> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Nhomnhanvien> model = db.Nhomnhanviens;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Tennhomnv.Contains(searchString) || x.Tennhomnv.Contains(searchString));
            }

            return model.OrderByDescending(x => x.Manhomnv);//.ToPagedList(page, pageSize);
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
