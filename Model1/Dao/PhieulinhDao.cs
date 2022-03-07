using Model1.DTO;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class PhieulinhDao
    {
        CSDL_NangcaoDbContext db = null;
        public PhieulinhDao()
        {
            db = new CSDL_NangcaoDbContext();
        }
        public long Sldong()
        {
            long a = db.Phieulinhs.LongCount();
            return a;
        }

        public string GetMadt(string id)
        {
            var pl = db.Phieulinhs.Find(id);
            return pl.Madiemtiem;
        }

        public string Insert(Phieulinh order)
        {
            db.Phieulinhs.Add(order);
            db.SaveChanges();
            return order.Sophieulinh;
        }

        public string Insert1(string sophieu, string madt, string manv, DateTime ngayyc, string matt)
        {

            string connString = @"Data Source=.\sqlexpress;Initial Catalog=CSDL_Nangcao;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_Insert_Phieulinh";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add("@Sophieulinh", SqlDbType.VarChar).Value = sophieu;
                cmd.Parameters.Add("@Madiemtiem", SqlDbType.VarChar).Value = madt;
                cmd.Parameters.Add("@Manhanvien", SqlDbType.VarChar).Value = "";
                cmd.Parameters.Add("@Ngayyc", SqlDbType.DateTime).Value = ngayyc;
                cmd.Parameters.Add("@Matt", SqlDbType.VarChar).Value = "tt001";

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            db.SaveChanges();
            return sophieu;
        }

        public bool Update(Phieulinh entity)
        {
            try
            {
                var pr = db.Phieulinhs.Find(entity.Sophieulinh);
                pr.Sophieulinh = entity.Sophieulinh;
                pr.Ngayyeucau = entity.Ngayyeucau;
                pr.Madiemtiem = entity.Madiemtiem;
                pr.Manhanvien = entity.Manhanvien;
                pr.Matt = entity.Matt;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var pr = db.Phieulinhs.Find(id);

                var model = from l in db.Donglinhs where l.Sophieulinh == id select new { l.Madonglinh };
                foreach (var item in model)
                {
                    var pr1 = db.Donglinhs.Find(item.Madonglinh);
                    db.Donglinhs.Remove(pr1);
                }

                db.Phieulinhs.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Updateghichu(string sophieu, string manv2)
        {
            try
            {
                var pr = db.Phieulinhs.Find(sophieu);
                //pr.Ghichu = ghichu;
                pr.Matt = "tt002";
                //pr.Ngayyeucau = DateTime.Now;
                pr.Manhanvien = manv2;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }

        //public bool Deletephieulinh(string id)
        //{
        //    try
        //    {
        //        var pr = db.Phieulinhs.Find(id);

        //        var model = from l in db.Donglinhs where l.Sophieutiem == id select new { l.Machitietphieutiem };
        //        foreach (var item in model)
        //        {
        //            var pr1 = db.Loes.Find(item.Machitietphieutiem);
        //            db.Loes.Remove(pr1);
        //        }

        //        db.Phieulinhs.Remove(pr);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //}

        public Phieulinh ViewDetail(string id)
        {
            return db.Phieulinhs.Find(id);
        }

        public string ViewDetailTenDiemtiem(string id)
        {
            var pr = db.Phieulinhs.Find(id);
            string id1 = pr.Madiemtiem;
            var pr1 = db.Diemtiems.Find(id1);
            return pr1.Tendiemtiem;
        }

        public IEnumerable<PhieulinhDTO> ListAllPaging(string searchString, string Madt)
        {
            List<PhieulinhDTO> listLinks = new List<PhieulinhDTO>();

            var model = from l in db.Phieulinhs
                        join c in db.Diemtiems on l.Madiemtiem equals c.Madiemtiem
                        where  l.Madiemtiem == Madt //l.Matt == "tt001" || l.Matt == "tt03" &&
                        select new { l.Sophieulinh, l.Ngayyeucau, l.Manhanvien, l.Madiemtiem, c.Tendiemtiem, l.Matt };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Sophieulinh.Contains(searchString) || x.Sophieulinh.Contains(searchString));
            }

            foreach (var item in model)
            {
                PhieulinhDTO temp = new PhieulinhDTO();
                temp.Sophieulinh = item.Sophieulinh;
                temp.Ngayyeucau = item.Ngayyeucau;
                temp.Manhanvien = item.Manhanvien;
                temp.Madiemtiem = item.Madiemtiem;
                temp.Tendiemtiem = item.Tendiemtiem;
                temp.Matt = item.Matt;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Ngayyeucau);
        }

        public IEnumerable<PhieulinhDTO> ListAllPaging1(string searchString)//, string Madt)
        {
            List<PhieulinhDTO> listLinks = new List<PhieulinhDTO>();

            var model = from l in db.Phieulinhs
                        join c in db.Diemtiems on l.Madiemtiem equals c.Madiemtiem
                        join z in db.Phuongs on c.Maphuong equals z.Maphuong
                        join x in db.Quans on z.Maquan equals x.Maquan
                        join t in db.Thanhphoes on x.Mathanhpho equals t.Mathanhpho
                        join p in db.Trangthais on l.Matt equals p.Matrangthai
                        where p.Matrangthai == "tt001"
                        select new { l.Sophieulinh, l.Ngayyeucau, l.Manhanvien, l.Madiemtiem, c.Tendiemtiem, p.Tentrangthai, l.Matt, t.Tenthanhpho, x.Tenquan, z.Tenphuong };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Sophieulinh.Contains(searchString) || x.Sophieulinh.Contains(searchString));
            }

            foreach (var item in model)
            {
                PhieulinhDTO temp = new PhieulinhDTO();
                temp.Sophieulinh = item.Sophieulinh;
                temp.Ngayyeucau = item.Ngayyeucau;
                temp.Manhanvien = item.Manhanvien;
                temp.Madiemtiem = item.Madiemtiem;
                temp.Tendiemtiem = item.Tendiemtiem;
                temp.Tentt = item.Tentrangthai;
                temp.Matt = item.Matt;
                temp.Tenphuong = item.Tenphuong;
                temp.Tenquan = item.Tenquan;
                temp.Tenthanhpho = item.Tenthanhpho;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Madiemtiem);
        }

        public IEnumerable<PhieulinhDTO> ListAllPaging3(string searchString)//, string Madt)
        {
            List<PhieulinhDTO> listLinks = new List<PhieulinhDTO>();

            var model = from l in db.Phieulinhs
                        join c in db.Diemtiems on l.Madiemtiem equals c.Madiemtiem
                        join z in db.Phuongs on c.Maphuong equals z.Maphuong
                        join x in db.Quans on z.Maquan equals x.Maquan
                        join t in db.Thanhphoes on x.Mathanhpho equals t.Mathanhpho
                        join p in db.Trangthais on l.Matt equals p.Matrangthai
                        where p.Matrangthai == "tt001"
                        select new { l.Sophieulinh, l.Ngayyeucau, l.Manhanvien, l.Madiemtiem, c.Tendiemtiem, p.Tentrangthai, l.Matt, t.Tenthanhpho, x.Tenquan, z.Tenphuong };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Tendiemtiem.Contains(searchString.Substring(7)) || x.Tendiemtiem.Contains(searchString.Substring(7)));
            }

            foreach (var item in model)
            {
                PhieulinhDTO temp = new PhieulinhDTO();
                temp.Sophieulinh = item.Sophieulinh;
                temp.Ngayyeucau = item.Ngayyeucau;
                temp.Manhanvien = item.Manhanvien;
                temp.Madiemtiem = item.Madiemtiem;
                temp.Tendiemtiem = item.Tendiemtiem;
                temp.Tentt = item.Tentrangthai;
                temp.Matt = item.Matt;
                temp.Tenphuong = item.Tenphuong;
                temp.Tenquan = item.Tenquan;
                temp.Tenthanhpho = item.Tenthanhpho;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Madiemtiem);
        }
    }
}
