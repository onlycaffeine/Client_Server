using Model1.DTO;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PagedList;

namespace Model1.Dao
{
    public class PhieutiemDao
    {
        CSDL_NangcaoDbContext db = null;
        public PhieutiemDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public string Insert(Phieutiem entity)
        {
            db.Phieutiems.Add(entity);
            db.SaveChanges();
            return entity.Sophieu;
        }

        public string Insert1(string loaimui, string madt, string malo, DateTime ngaytiem, string loaitc, string trieuchung,string mactpt, string sophieutiem, string ghichu)
        {

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=CSDL_Nangcao;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Capnhatphieutiem";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Ngaytiem", SqlDbType.VarChar).Value = ngaytiem;
                cmd.Parameters.Add("@Loaimui", SqlDbType.VarChar).Value = loaimui;
                cmd.Parameters.Add("@Madiemtiem", SqlDbType.VarChar).Value = madt;
                cmd.Parameters.Add("@Ngaytiem", SqlDbType.DateTime).Value = ngaytiem;
                cmd.Parameters.Add("@trieuchung", SqlDbType.VarChar).Value = trieuchung;
                cmd.Parameters.Add("@sophieutiem", SqlDbType.VarChar).Value = sophieutiem;
                cmd.Parameters.Add("@loaitc", SqlDbType.VarChar).Value = loaitc;
                cmd.Parameters.Add("@Malo", SqlDbType.VarChar).Value = malo;
                cmd.Parameters.Add("@Machitietphieutiem", SqlDbType.VarChar).Value = mactpt;
                cmd.Parameters.Add("@ghichu", SqlDbType.VarChar).Value = ghichu;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            db.SaveChanges();
            return sophieutiem;
        }

        public bool Update(Phieutiem entity)
        {
            try
            {
                var user = db.Phieutiems.Find(entity.Sophieu);
                user.Tennguoidan = entity.Tennguoidan;
                user.CCCD = entity.CCCD;
                user.SDT = entity.SDT;
                user.Ngaysinh = entity.Ngaysinh;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public IEnumerable<PhieutiemViewModel> Tracuu(string cccd, string sdt, string ten)
        {
            var model = (from a in db.Phieutiems
                        join b in db.Chitietphhieutiems on a.Sophieu equals b.Sophieutiem
                        where (a.CCCD == cccd && a.SDT == sdt && a.Tennguoidan.Contains(ten))
                        select new PhieutiemViewModel
                        {
                            Phieutiem = a,
                            Chitietphhieutiem = b
                        }).ToList();
            return model;
        }
    

        public IEnumerable<ChitietphieutiemDTO> ListCTPT(string cccd, string sdt, string ten)
        {
            List<ChitietphieutiemDTO> listLinks = new List<ChitietphieutiemDTO>();
            var model = from a in db.Phieutiems
                         join b in db.Chitietphhieutiems on a.Sophieu equals b.Sophieutiem
                         where (a.CCCD == cccd && a.SDT == sdt && a.Tennguoidan.Contains(ten))
                         select new { a.Tennguoidan, a.Ngaysinh, b.Loaimui, b.Ngaytiem, b.Tenthuoc };
            foreach (var item in model)
            {
                ChitietphieutiemDTO temp = new ChitietphieutiemDTO();
                temp.Tennguoidan = item.Tennguoidan;
                temp.Ngaysinh = item.Ngaysinh;
                temp.Loaimui = item.Loaimui;
                temp.Ngaytiem = item.Ngaytiem;
                temp.Tenthuoc = item.Tenthuoc;
                listLinks.Add(temp);
            }

            return listLinks.OrderBy(x => x.Ngaytiem);
        }

        public IEnumerable<Phieutiem> ListAllPaging(string searchString, int page, int pageSize)
        {

            IQueryable<Phieutiem> model = db.Phieutiems;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.CCCD.Contains(searchString) || x.CCCD.Contains(searchString));
            }

            return model.OrderByDescending(x => x.Sophieu).ToPagedList(page, pageSize);
        }

        public Phieutiem GetById(string sophieu)
        {
            return db.Phieutiems.SingleOrDefault(x => x.Sophieu == sophieu);
        }

        public Phieutiem ViewDetail(string id)
        {
            return db.Phieutiems.Find(id);
        }

        public bool Delete(string id)
        {
            try
            {
                var user = db.Phieutiems.Find(id);
                db.Phieutiems.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
