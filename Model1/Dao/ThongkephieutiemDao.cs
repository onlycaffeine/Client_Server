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
    public class ThongkephieutiemDao
    {
        CSDL_NangcaoDbContext db = null;
        public ThongkephieutiemDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public string Insert(Phieuthongke entity)
        {
            db.Phieuthongkes.Add(entity);
            db.SaveChanges();
            return entity.Sophieu;
        }

        public bool Update(Phieuthongke entity)
        {
            try
            {
                var user = db.Phieuthongkes.Find(entity.Sophieu);
                user.SLtiem = entity.SLtiem;
                //user.Sltrieuchung = entity.Sltrieuchung;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public bool Update1(ref string a)
        {
            try
            {
                var model = from l in db.Loes where l.Sohoadon == null select new { l.Malo };
                foreach (var item in model)
                {
                    var pr = db.Loes.Find(item.Malo);
                    pr.Sohoadon = a;

                }
                db.SaveChanges();
            }

            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public IEnumerable<ThongkephieutiemQuanDTO> ListAllPaging(string a, string b)
        {
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=CSDL_Nangcao;Integrated Security=True";
            List<ThongkephieutiemQuanDTO> listLinks = new List<ThongkephieutiemQuanDTO>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                DateTime createdate2 = Convert.ToDateTime(b);

                string query = @"Select * from [dbo].[ThongKeTongSl_TP1](@a, @b)";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlParameter param2 = new SqlParameter();
                SqlParameter param3 = new SqlParameter();

                param2.ParameterName = "@a";
                param2.Value = createdate1;

                param3.ParameterName = "@b";
                param3.Value = createdate2;

                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ThongkephieutiemQuanDTO temp = new ThongkephieutiemQuanDTO();
                        temp.Madiemtiem = dr.GetString(0);
                        temp.SLastra1 = dr.GetInt32(1);
                        temp.SLastra2 = dr.GetInt32(2);
                        temp.SLastra3 = dr.GetInt32(3);
                        temp.SLpfi1 = dr.GetInt32(4);
                        temp.SLpfi2 = dr.GetInt32(5);
                        temp.SLpfi3 = dr.GetInt32(6);
                        temp.SLvero1 = dr.GetInt32(7);
                        temp.SLvero2 = dr.GetInt32(8);
                        temp.SLvero3 = dr.GetInt32(9);
                        temp.SLtiem = dr.GetInt32(10);
                        temp.SLtcnhe = dr.GetInt32(11);
                        temp.SLtcnang = dr.GetInt32(12);
                        listLinks.Add(temp);
                    }
                }
                dr.Close();
                conn.Close();
            }
            return listLinks.OrderBy(x => x.Madiemtiem);
        }

        public IEnumerable<ThongkephieutiemQuanDTO> ListAllPagingWithMaquan(string maquan, string a, string b)
        {
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=CSDL_Nangcao;Integrated Security=True";
            List<ThongkephieutiemQuanDTO> listLinks = new List<ThongkephieutiemQuanDTO>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                DateTime createdate2 = Convert.ToDateTime(b);

                string query = @"Select * from [dbo].[ThongKeTongSl_Quan1](@maquan, @a, @b)";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlParameter param1 = new SqlParameter();
                SqlParameter param2 = new SqlParameter();
                SqlParameter param3 = new SqlParameter();

                param1.ParameterName = "@maquan";
                param1.Value = maquan;

                param2.ParameterName = "@a";
                param2.Value = createdate1;

                param3.ParameterName = "@b";
                param3.Value = createdate2;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);


                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ThongkephieutiemQuanDTO temp = new ThongkephieutiemQuanDTO();
                        temp.Madiemtiem = dr.GetString(0);
                        temp.SLastra1 = dr.GetInt32(1);
                        temp.SLastra2 = dr.GetInt32(2);
                        temp.SLastra3 = dr.GetInt32(3);
                        temp.SLpfi1 = dr.GetInt32(4);
                        temp.SLpfi2 = dr.GetInt32(5);
                        temp.SLpfi3 = dr.GetInt32(6);
                        temp.SLvero1 = dr.GetInt32(7);
                        temp.SLvero2 = dr.GetInt32(8);
                        temp.SLvero3 = dr.GetInt32(9);
                        temp.SLtiem = dr.GetInt32(10);
                        temp.SLtcnhe = dr.GetInt32(11);
                        temp.SLtcnang = dr.GetInt32(12);
                        listLinks.Add(temp);
                    }
                }
                dr.Close();
                conn.Close();
            }
            return listLinks.OrderByDescending(x => x.Madiemtiem);
        }

        public IEnumerable<ThongkephieutiemQuanDTO> ListAllPagingWithMadt(Diemtiem dt, string a, string b)
        {
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=CSDL_Nangcao;Integrated Security=True";
            List<ThongkephieutiemQuanDTO> listLinks = new List<ThongkephieutiemQuanDTO>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                DateTime createdate2 = Convert.ToDateTime(b);

                string query = @"Select * from [dbo].[ThongKeTongSl_MaDT1](@iddt, @a, @b)";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlParameter param1 = new SqlParameter();
                SqlParameter param2 = new SqlParameter();
                SqlParameter param3 = new SqlParameter();

                param1.ParameterName = "@iddt";
                param1.Value = dt.Madiemtiem;

                param2.ParameterName = "@a";
                param2.Value = createdate1;

                param3.ParameterName = "@b";
                param3.Value = createdate2;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);


                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ThongkephieutiemQuanDTO temp = new ThongkephieutiemQuanDTO();
                        temp.Madiemtiem = dr.GetString(0);
                        temp.SLastra1 = dr.GetInt32(1);
                        temp.SLastra2 = dr.GetInt32(2);
                        temp.SLastra3 = dr.GetInt32(3);
                        temp.SLpfi1 = dr.GetInt32(4);
                        temp.SLpfi2 = dr.GetInt32(5);
                        temp.SLpfi3 = dr.GetInt32(6);
                        temp.SLvero1 = dr.GetInt32(7);
                        temp.SLvero2 = dr.GetInt32(8);
                        temp.SLvero3 = dr.GetInt32(9);
                        temp.SLtiem = dr.GetInt32(10);
                        temp.SLtcnhe = dr.GetInt32(11);
                        temp.SLtcnang = dr.GetInt32(12);
                        listLinks.Add(temp);
                    }
                }
                dr.Close();
                conn.Close();
            }
            return listLinks.OrderBy(x => x.Madiemtiem);
        }

        public IEnumerable<ThongkephieutiemQuanDTO> ListAllPagingQG(string matp, string maquan, string map, string a, string b, string khuvuc, string maquyen)
        {
            string connString = @"Data Source=.\sqlexpress;Initial Catalog=CSDL_Nangcao;Integrated Security=True";
            List<ThongkephieutiemQuanDTO> listLinks = new List<ThongkephieutiemQuanDTO>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                //"4-4-2022"

                DateTime createdate1= new DateTime();
                DateTime createdate2 = new DateTime();

                if (a == null || b == null)
                {
                    createdate1 = Convert.ToDateTime("4-4-2012");
                    createdate2 = Convert.ToDateTime("4-4-2022");
                }

                else
                {
                    createdate1 = Convert.ToDateTime(a);
                    createdate2 = Convert.ToDateTime(b);
                }

                //DateTime createdate1 = a;
                //DateTime createdate2 = b;

                string query = @"Select * from [dbo].[ThongKeTongSl_QG](@MATP, @MAQuan, @MAPhuong, @a, @b, @case, @maquyen)";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlParameter param1 = new SqlParameter();
                SqlParameter param2 = new SqlParameter();
                SqlParameter param3 = new SqlParameter();
                SqlParameter param4 = new SqlParameter();
                SqlParameter param5 = new SqlParameter();
                SqlParameter param6 = new SqlParameter();
                SqlParameter param7 = new SqlParameter();

                param1.ParameterName = "@MATP";
                param1.Value = matp;

                param2.ParameterName = "@MAQuan";
                param2.Value = maquan;

                param3.ParameterName = "@MAPhuong";
                param3.Value = map;

                param4.ParameterName = "@a";
                param4.Value = createdate1;

                param5.ParameterName = "@b";
                param5.Value = createdate2;

                param6.ParameterName = "@case";
                param6.Value = khuvuc;

                param7.ParameterName = "@maquyen";
                param7.Value = maquyen;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);
                cmd.Parameters.Add(param6);
                cmd.Parameters.Add(param7);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ThongkephieutiemQuanDTO temp = new ThongkephieutiemQuanDTO();
                        temp.Madiemtiem = dr.GetString(0);
                        temp.SLastra1 = dr.GetInt32(1);
                        temp.SLastra2 = dr.GetInt32(2);
                        temp.SLastra3 = dr.GetInt32(3);
                        temp.SLpfi1 = dr.GetInt32(4);
                        temp.SLpfi2 = dr.GetInt32(5);
                        temp.SLpfi3 = dr.GetInt32(6);
                        temp.SLvero1 = dr.GetInt32(7);
                        temp.SLvero2 = dr.GetInt32(8);
                        temp.SLvero3 = dr.GetInt32(9);
                        temp.SLtiem = dr.GetInt32(10);
                        temp.SLtcnhe = dr.GetInt32(11);
                        temp.SLtcnang = dr.GetInt32(12);
                        listLinks.Add(temp);
                    }
                }
                dr.Close();
                conn.Close();
            }
            return listLinks.OrderByDescending(x => x.Madiemtiem);
        }

        public Phieuthongke GetById(string sophieu)
        {
            return db.Phieuthongkes.SingleOrDefault(x => x.Sophieu == sophieu);
        }
        public Phieuthongke ViewDetail(string id)
        {
            return db.Phieuthongkes.Find(id);
        }

        public bool Delete(string id)
        {
            try
            {
                var user = db.Phieuthongkes.Find(id);
                db.Phieuthongkes.Remove(user);
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
