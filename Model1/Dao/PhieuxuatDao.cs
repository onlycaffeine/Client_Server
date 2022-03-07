using Model1.DTO;
using Model1.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class PhieuxuatDao
    {
        CSDL_NangcaoDbContext db = null;
        public PhieuxuatDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public long Sldong()
        {
            long a = db.Phieuxuats.LongCount();
            return a;
        }

        public string Insert(Phieuxuat order)
        {
            db.Phieuxuats.Add(order);
            db.SaveChanges();
            return order.Sophieuxuat;
        }

        public bool Update(Phieuxuat entity)
        {
            try
            {
                var pr = db.Phieuxuats.Find(entity.Sophieuxuat);
                pr.Sophieuxuat = entity.Sophieuxuat;
                pr.Ngayxuat = entity.Ngayxuat;
                pr.Makhoxuat = entity.Makhoxuat;
                pr.Khonhan = entity.Khonhan;
                pr.Khoxuat = entity.Khoxuat;
                pr.Manhanvien = entity.Manhanvien;
                pr.Madiemtiem = entity.Madiemtiem;
                pr.Tongtien = entity.Tongtien;
                pr.Matinhtrang = entity.Matinhtrang;
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
                var pr = db.Phieuxuats.Find(id);

                var model = from l in db.Dongxuats where l.Sophieuxuat == id select new { l.Madongxuat };
                foreach (var item in model)
                {
                    var pr1 = db.Dongxuats.Find(item.Madongxuat);
                    db.Dongxuats.Remove(pr1);
                }

                db.Phieuxuats.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Updateghichu(string sophieu, string ghichu, string manv2)
        {
            try
            {
                var pr = db.Phieuxuats.Find(sophieu);
                pr.Ghichu = ghichu;
                pr.Matinhtrang = "tt002";
                pr.Ngaynhap = DateTime.Now;
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

        public Phieuxuat ViewDetail(string id)
        {
            return db.Phieuxuats.Find(id);
        }

        public IEnumerable<PhieuxuatDTO> ListAllPaging(string searchString, string a, string b)// tinh trang da duyet
        {
            List<PhieuxuatDTO> listLinks = new List<PhieuxuatDTO>();

            var model = from l in db.Phieuxuats // lấy toàn bộ sp
                        join c in db.Diemtiems on l.Madiemtiem equals c.Madiemtiem
                        //join k in db.Khoes on l.Makhoxuat equals k.Makho
                        join p in db.Tinhtrangpxes on l.Matinhtrang equals p.Matinhtrang
                        select new { l.Sophieuxuat, l.Ngayxuat, l.Makhoxuat, c.Tendiemtiem, l.Madiemtiem, l.Manhanvien, l.Tongtien, l.Khonhan, p.Tentinhtrang, l.Matinhtrang, l.Ngaynhap };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Sophieuxuat.Contains(searchString) || x.Sophieuxuat.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(b))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                DateTime createdate2 = Convert.ToDateTime(b);
                model = model.Where(x => x.Ngayxuat >= createdate1 && x.Ngayxuat <= createdate2);
            }

            if (!string.IsNullOrEmpty(a))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                model = model.Where(x => x.Ngayxuat >= createdate1);
            }

            if (!string.IsNullOrEmpty(b))
            {
                DateTime createdate2 = Convert.ToDateTime(b);
                model = model.Where(x => x.Ngayxuat <= createdate2);
            }

            foreach (var item in model)
            {
                PhieuxuatDTO temp = new PhieuxuatDTO();
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Madiemtiem = item.Madiemtiem;
                temp.Tendiemtiem = item.Tendiemtiem;
                temp.Makhoxuat = item.Makhoxuat;
                //temp.Khoxuat = item.Tenkho;
                temp.Khonhan = item.Khonhan;
                temp.Manhanvien = item.Manhanvien;
                temp.Tongtien = item.Tongtien;
                temp.Ngayxuat = item.Ngayxuat;
                temp.Ngaynhap = item.Ngaynhap;
                temp.Tentt = item.Tentinhtrang;
                temp.Matrangthai = item.Matinhtrang;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Ngayxuat);
        }


        public IEnumerable<PhieuxuatDTO> ListAllPaging1(string searchString, string a, string b, string madt)// tinh trang da duyet
        {
            List<PhieuxuatDTO> listLinks = new List<PhieuxuatDTO>();

            var model = from l in db.Phieuxuats // lấy toàn bộ sp
                        join c in db.Diemtiems on l.Madiemtiem equals c.Madiemtiem
                        //join k in db.Khoes on l.Makhoxuat equals k.Makho
                        join p in db.Tinhtrangpxes on l.Matinhtrang equals p.Matinhtrang
                        where l.Madiemtiem == madt && l.Matinhtrang == "tt002"
                        select new { l.Sophieuxuat, l.Ngayxuat, l.Makhoxuat,  c.Tendiemtiem, l.Madiemtiem, l.Manhanvien, l.Tongtien, l.Khonhan, p.Tentinhtrang, l.Matinhtrang, l.Ngaynhap };

            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Sophieuxuat.Contains(searchString) || x.Sophieuxuat.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(a) && !string.IsNullOrEmpty(b))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                DateTime createdate2 = Convert.ToDateTime(b);
                model = model.Where(x => x.Ngaynhap >= createdate1 && x.Ngaynhap <= createdate2);
            }

            if (!string.IsNullOrEmpty(a))
            {
                DateTime createdate1 = Convert.ToDateTime(a);
                model = model.Where(x => x.Ngaynhap >= createdate1);
            }

            if (!string.IsNullOrEmpty(b))
            {
                DateTime createdate2 = Convert.ToDateTime(b);
                model = model.Where(x => x.Ngaynhap <= createdate2);
            }

            foreach (var item in model)
            {
                PhieuxuatDTO temp = new PhieuxuatDTO();
                temp.Sophieuxuat = item.Sophieuxuat;
                temp.Madiemtiem = item.Madiemtiem;
                temp.Tendiemtiem = item.Tendiemtiem;
                temp.Makhoxuat = item.Makhoxuat;
                //temp.Khoxuat = item.Tenkho;
                temp.Khonhan = item.Khonhan;
                temp.Manhanvien = item.Manhanvien;
                temp.Tongtien = item.Tongtien;
                temp.Ngayxuat = item.Ngayxuat;
                temp.Ngaynhap = item.Ngaynhap;
                temp.Tentt = item.Tentinhtrang;
                temp.Matrangthai = item.Matinhtrang;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Ngayxuat);
        }
    }
}
