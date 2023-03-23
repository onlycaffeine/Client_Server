using Model1.DTO;
using Model1.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class PhieudangkyDao
    {
        CSDL_NangcaoDbContext db = null;
        public PhieudangkyDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public class FormattedDbEntityValidationException : Exception
        {
            public FormattedDbEntityValidationException(DbEntityValidationException innerException) :
                base(null, innerException)
            {
            }

            public override string Message
            {
                get
                {
                    var innerException = InnerException as DbEntityValidationException;
                    if (innerException != null)
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.AppendLine();
                        sb.AppendLine();
                        foreach (var eve in innerException.EntityValidationErrors)
                        {
                            sb.AppendLine(string.Format("- Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().FullName, eve.Entry.State));
                            foreach (var ve in eve.ValidationErrors)
                            {
                                sb.AppendLine(string.Format("-- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                    ve.PropertyName,
                                    eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                    ve.ErrorMessage));
                            }
                        }
                        sb.AppendLine();

                        return sb.ToString();
                    }

                    return base.Message;
                }
            }
        }

        //public class MyContext : DbContext
        //{
        //    // ...

        //    public override int SaveChanges()
        //    {
        //        try
        //        {
        //            return base.SaveChanges();
        //        }
        //        catch (DbEntityValidationException e)
        //        {
        //            var newException = new FormattedDbEntityValidationException(e);
        //            throw newException;
        //        }
        //    }
        //}


        public string Insert(Phieudangky entity)
        {

            db.Phieudangkies.Add(entity);
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var newException = new FormattedDbEntityValidationException(e);
                throw newException;
            }
            //db.SaveChanges();
            return entity.Sophieudangky;

        }



        public string InsertTS(Phieudky_Tiensu entity)
        {
            db.Phieudky_Tiensu.Add(entity);
            db.SaveChanges();
            return entity.Matiensu;
        }

        public long Sldong()
        {
            long a = db.Phieudangkies.LongCount();
            return a;
        }

        public string Maphuongdk(string ten)
        {
            var p = db.Phuongs.SingleOrDefault(x => x.Tenphuong == ten);
            return p.Maphuong;
        }

        public string Manhomdk(string ten)
        {
            var p = db.Nhomuutiens.SingleOrDefault(x => x.Tennhomuutien == ten);
            return p.Manhomuutien;
        }

        public string Mathuocdk(string ten)
        {
            //if (ten != "")
            //{
                var p = db.Vattuytes.SingleOrDefault(x => x.Tenvattu == ten);
                return p.Mavattu;
            //}
            //return ten;
        }

        public string Dstiensu(string maphieu)
        {
            string a = "";
            var model = from l in db.Tiensus
                        join k in db.Phieudky_Tiensu on l.Matiensu equals k.Matiensu
                        where k.Maphieudangky == maphieu && k.Matrangthai == "tt001"
                        select new { l.Ten, k.Trieuchung };
            foreach (var item in model)
            {
                a += item.Ten + "( "+ item.Trieuchung + " )  " ;
            }
            return a;
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
                         join c in db.Loes on b.Malo equals c.Malo
                         join d in db.Vattuytes on c.Mavattu equals d.Mavattu
                         join e in db.Diemtiems on b.Madiemtiem equals e.Madiemtiem
                         where (a.CCCD == cccd && a.SDT == sdt && a.Tennguoidan.Contains(ten))
                         select new PhieutiemViewModel
                         {
                             Phieutiem = a,
                             Chitietphhieutiem = b,
                             tenthuoc = d.Tenvattu,
                             tendiemtiem = e.Tendiemtiem
                         }).ToList();
            return model;
        }

        public IEnumerable<PhieudangkyDTO> ListAllPaging(string tt, string muidk, string nhomut, string vc1, string map, int page, int pageSize)
        {
            List<PhieudangkyDTO> listLinks = new List<PhieudangkyDTO>();

            var model = from l in db.Phieudangkies // lấy toàn bộ sp
                        join k in db.Tinhtrangphieudks on l.Matrangthai equals k.Matrangthai
                        join p in db.Vattuytes on l.Mathuoc1 equals p.Mavattu
                        join q in db.Nhomuutiens on l.Manhomuutien equals q.Manhomuutien
                        where l.Maphuong == map

                        select new
                        {
                            l.Sophieudangky,
                            l.Tennguoidan,
                            l.SDT,
                            l.SDTdangky,
                            l.SDTgiamho,
                            l.CCCD,
                            l.Ngaysinh,
                            l.Loaimui,
                            l.Matrangthai,
                            l.Gioitinh,
                            l.Email,
                            k.Tentranthai,
                            p.Tenvattu,
                            l.Tenthuoc1,
                            l.Hotendangky,
                            l.Hotengiamho,
                            l.Phanungtiem1,
                            l.Ngaytiem1,
                            l.Maphuong,
                            l.Tenphuong,
                            l.Manhomuutien,
                            l.Mathuoc1,
                            //q.Tennhomuutien,
                            l.Tennhomuutien,
                            l.Ngaymongmuon,
                            l.Buoimongmuon
                        };

            if (tt != "tatca" && !string.IsNullOrEmpty(tt))
            {
                model = model.Where(x => x.Matrangthai.Contains(tt) || x.Matrangthai.Contains(tt));
            }

            if (muidk != "tatca" && !string.IsNullOrEmpty(muidk))
            {
                model = model.Where(x => x.Loaimui.Contains(muidk) || x.Loaimui.Contains(muidk));
            }

            if (nhomut != "tatca" && !string.IsNullOrEmpty(nhomut))
            {
                model = model.Where(x => x.Manhomuutien.Contains(nhomut) || x.Manhomuutien.Contains(nhomut));
            }

            if (vc1 != "tatca" && !string.IsNullOrEmpty(vc1))
            {
                model = model.Where(x => x.Mathuoc1.Contains(vc1) || x.Mathuoc1.Contains(vc1));
            }

            foreach (var item in model)
            {
                PhieudangkyDTO temp = new PhieudangkyDTO();
                temp.Sophieudangky = item.Sophieudangky;
                temp.Tennguoidan = item.Tennguoidan;
                temp.SDT = item.SDT;
                temp.SDTdangky = item.SDTdangky;
                temp.SDTgiamho = item.SDTgiamho;
                temp.CCCD = item.CCCD;
                temp.Ngaysinh = item.Ngaysinh;
                temp.Loaimui = item.Loaimui;
                temp.Matrangthai = item.Matrangthai;
                temp.Gioitinh = item.Gioitinh;
                temp.Email = item.Email;
                temp.Tennhomuutien = item.Tennhomuutien;
                temp.Ngaymongmuon = item.Ngaymongmuon;
                temp.Buoimongmuon = item.Buoimongmuon;
                temp.Tenthuoc1 = item.Tenvattu;
                temp.Ngaytiem1 = item.Ngaytiem1;
                temp.Tentt = item.Tentranthai;
                temp.Phanungtiem1 = item.Phanungtiem1;
                temp.Dstiensu = Dstiensu(item.Sophieudangky);
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Ngaymongmuon).ToPagedList(page, pageSize);
        }

        public Phieudangky GetById(string sophieu)
        {
            return db.Phieudangkies.SingleOrDefault(x => x.Sophieudangky == sophieu);
        }

        public Phieudangky ViewDetail(string id)
        {
            return db.Phieudangkies.Find(id);
        }

        public bool Updatett(string id, string tt)
        {
            var pr = db.Phieudangkies.Find(id);
            pr.Matrangthai = tt;
            db.SaveChanges();
            return true;
        }

        public bool Delete(string id)
        {
            try
            {
                var user = db.Phieudangkies.Find(id);
                db.Phieudangkies.Remove(user);
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
