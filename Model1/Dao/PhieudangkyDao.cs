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
    public class PhieudangkyDao
    {
        CSDL_NangcaoDbContext db = null;
        public PhieudangkyDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public string Insert(Phieudangky entity)
        {
            db.Phieudangkies.Add(entity);
            db.SaveChanges();
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
            var p = db.Vattuytes.SingleOrDefault(x => x.Tenvattu == ten);
            return p.Mavattu;
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

        public IEnumerable<PhieudangkyDTO> ListAllPaging(string searchString, int page, int pageSize)
        {
            List<PhieudangkyDTO> listLinks = new List<PhieudangkyDTO>();

            var model = from l in db.Phieudangkies // lấy toàn bộ sp
                        join k in db.Tinhtrangphieudks on l.Matrangthai equals k.Matrangthai
                        join p in db.Vattuytes on l.Mathuoc1 equals p.Mavattu
                        join q in db.Nhomuutiens on l.Manhomuutien equals q.Manhomuutien
                        //where l.SLnhap != 0
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
                            //p.Tenvattu,
                            l.Tenthuoc1,
                            l.Hotendangky,
                            l.Hotengiamho,
                            l.Phanungtiem1,
                            l.Ngaytiem1,
                            l.Maphuong,
                            l.Tenphuong,
                            l.Manhomuutien,
                            //q.Tennhomuutien,
                            l.Tennhomuutien,
                            l.Ngaymongmuon,
                            l.Buoimongmuon
                        };

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
                temp.Tenthuoc1 = item.Tenthuoc1;
                listLinks.Add(temp);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.CCCD.Contains(searchString) || x.CCCD.Contains(searchString));
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
