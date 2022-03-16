using Model1.DTO;
using Model1.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class DiemtiemDao
    {
        CSDL_NangcaoDbContext db = null;
        public DiemtiemDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public string Insert(Diemtiem entity)
        {
            db.Diemtiems.Add(entity);
            db.SaveChanges();
            return entity.Madiemtiem;
        }

        public bool Update(Diemtiem entity)
        {
            try
            {
                var user = db.Diemtiems.Find(entity.Madiemtiem);
                user.Tendiemtiem = entity.Tendiemtiem;
                user.Tennguoidungdau = entity.Tennguoidungdau;
                user.Diachi = entity.Diachi;
                user.Sobantiem = entity.Sobantiem;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

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

        public string Check(string id)
        {
            Diemtiem dt =  db.Diemtiems.Find(id);
            return dt.Madiemtiem;
        }

        public string Tendiemtiem(string id)
        {
            Diemtiem dt = db.Diemtiems.Find(id);
            return dt.Tendiemtiem;
        }

        public long Sldong()
        {
            long a = db.Diemtiems.LongCount();
            return a;
        }

        public bool ChangeStatus(string id)
        {
            var user = db.Diemtiems.Find(id);
            user.Trangthai = !user.Trangthai;
            db.SaveChanges();
            return user.Trangthai;
        }

        //public bool Update(Diemtiem entity)
        //{
        //    try
        //    {
        //        var user = db.Diemtiems.Find(entity.Madiemtiem);
        //        user.Tendiemtiem = entity.Tendiemtiem;
        //        user.Madiemtiem = entity.Madiemtiem;
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}

        //List<LoDTO> listLinks = new List<LoDTO>();

        //var model = from l in db.Loes // lấy toàn bộ sp
        //            join p in db.Chithidongbangs on l.Machithidongbang equals p.Machithidongbang
        //            join q in db.Chithinhietdoes on l.Machithinhietdo equals q.Machithinhietdo
        //            join k in db.Vattuytes on l.Mavattu equals k.Mavattu
        //            where l.Sohoadon == null
        //            select new
        //            {
        //                l.Malo,
        //                l.SLnhap,
        //            };

        //    foreach (var item in model)
        //    {
        //        LoDTO temp = new LoDTO();
        //temp.Malo = item.Malo;
        //        temp.SLnhap = item.SLnhap;
        //        temp.Dongia = item.Dongia;
        //    }

        //    return listLinks.OrderByDescending(x => x.HSD);

        public IEnumerable<DiemtiemDTO> ListAllPaging(string searchString, int page, int pageSize)
        {
            //IQueryable<Diemtiem> model = db.Diemtiems;
            List<DiemtiemDTO> listLinks = new List<DiemtiemDTO>();
            var model = from l in db.Diemtiems
                        join p in db.Phuongs on l.Maphuong equals p.Maphuong
                        join q in db.Quans on p.Maquan equals q.Maquan
                        join k in db.Thanhphoes on q.Mathanhpho equals k.Mathanhpho
                        where l.Trangthai == true
                        select new
                        {
                            l.Madiemtiem,
                            l.Tendiemtiem,
                            l.Tennguoidungdau,
                            l.Sobantiem,
                            l.Diachi,
                            p.Tenphuong,
                            q.Tenquan,
                            k.Tenthanhpho,
                            l.Trangthai
                        };
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Tendiemtiem.Contains(searchString.Substring(7)) || x.Tendiemtiem.Contains(searchString.Substring(7)) && x.Trangthai == true);
            }

            foreach (var item in model)
            {
                DiemtiemDTO temp = new DiemtiemDTO();
                temp.Madiemtiem = item.Madiemtiem;
                temp.Tendiemtiem = item.Tendiemtiem;
                temp.Tennguoidungdau = item.Tennguoidungdau;
                temp.Diachi = item.Diachi;
                temp.Sobantiem = item.Sobantiem;
                temp.Tenquan = item.Tenquan;
                temp.Tenthanhpho = item.Tenthanhpho;
                temp.Tenphuong = item.Tenphuong;
                temp.Trangthai = item.Trangthai;
                listLinks.Add(temp);
            }
            return listLinks.OrderByDescending(x => x.Madiemtiem).ToPagedList(page, pageSize);
        }

        public IEnumerable<DiemtiemDTO> ListAllPagingQl(string searchString, string maquyen, string map, string maq, string matp, int page, int pageSize)
        {
            //IQueryable<Diemtiem> model = db.Diemtiems;
            List<DiemtiemDTO> listLinks = new List<DiemtiemDTO>();
            var model = from l in db.Diemtiems
                        join p in db.Phuongs on l.Maphuong equals p.Maphuong
                        join q in db.Quans on p.Maquan equals q.Maquan
                        join k in db.Thanhphoes on q.Mathanhpho equals k.Mathanhpho
                        select new
                        {
                            l.Madiemtiem,
                            l.Tendiemtiem,
                            l.Tennguoidungdau,
                            l.Sobantiem,
                            l.Diachi,
                            p.Tenphuong,
                            q.Tenquan,
                            k.Tenthanhpho,
                            l.Maphuong,
                            l.Maquan,
                            l.Mathanhpho,
                            l.Trangthai
                        };
            if (maquyen == "w_account")
            {
                model = model.Where(x => x.Maphuong == map);
            }

            if (maquyen == "d_leader")
            {
                model = model.Where(x => x.Maquan == maq);
            }

            if (maquyen == "c_leader")
            {
                model = model.Where(x => x.Mathanhpho == matp);
            }

            //if (maquyen == "leader")
            //{
            //    model = model.Where(x => x.Manhom == "c_account" || x.Manhom == "c_leader");
            //}

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Tendiemtiem.Contains(searchString) || x.Tendiemtiem.Contains(searchString));
            }

            foreach (var item in model)
            {
                DiemtiemDTO temp = new DiemtiemDTO();
                temp.Madiemtiem = item.Madiemtiem;
                temp.Tendiemtiem = item.Tendiemtiem;
                temp.Tennguoidungdau = item.Tennguoidungdau;
                temp.Diachi = item.Diachi;
                temp.Sobantiem = item.Sobantiem;
                temp.Tenquan = item.Tenquan;
                temp.Tenthanhpho = item.Tenthanhpho;
                temp.Tenphuong = item.Tenphuong;
                temp.Trangthai = item.Trangthai;
                listLinks.Add(temp);
            }
            return listLinks.OrderByDescending(x => x.Madiemtiem).ToPagedList(page, pageSize);
        }

        public Diemtiem GetById(string userName)
        {
            return db.Diemtiems.SingleOrDefault(x => x.Madiemtiem == userName);
        }

        public Diemtiem ViewDetail(string id)
        {
            return db.Diemtiems.Find(id);
        }
       
        //public string Tendiemtiem(string id)
        //{
        //    var dt = db.Diemtiems.Find(id);
        //    return dt.Tendiemtiem;
        //}

        public bool Delete(string id)
        {
            try
            {
                var user = db.Diemtiems.Find(id);
                db.Diemtiems.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public int Sltiem(int ngaytiem)
        {
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=CSDL_Nangcao;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "show_sltiem";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add("@so", SqlDbType.VarChar).Value = ngaytiem;

                conn.Open();
                object sl = cmd.ExecuteScalar();
                int sl1 = Int32.Parse(sl.ToString());
                //string sl1 = sl.ToString();
                conn.Close();
                return sl1;
            }
            
        }

        public int Sltiem1(string matp)
        {
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=CSDL_Nangcao;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "show_sltiem1";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add("@matp", SqlDbType.VarChar).Value = matp;

                conn.Open();
                object sl = cmd.ExecuteScalar();
                int sl1 = Int32.Parse(sl.ToString());
                //string sl1 = sl.ToString();
                conn.Close();
                return sl1;
            }

        }

        public List<Diemtiem> ListAll()
        {
            return db.Diemtiems.Where(x => x.Tendiemtiem != "").OrderBy(x => x.Madiemtiem).ToList();
        }
    }
}
