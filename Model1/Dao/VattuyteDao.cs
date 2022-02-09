using Model1.EF;
using Model1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1.Dao
{
    public class VattuyteDao
    {
        CSDL_NangcaoDbContext db = null;
        public VattuyteDao()
        {
            db = new CSDL_NangcaoDbContext();
        }

        public List<Vattuyte> ListAll()
        {
            return db.Vattuytes.Where(x => x.Tenvattu != "").OrderBy(x => x.Mavattu).ToList();
        }

        public List<Vattuyte> ListNewProduct(int top)// thieu truong create date
        {
            return db.Vattuytes.OrderByDescending(x => x.Loaivattuyte).Take(top).ToList();
        }
        public List<string> ListName(string keyword)
        {
            return db.Vattuytes.Where(x => x.Tenvattu.Contains(keyword)).Select(x => x.Tenvattu).ToList();
        }
        public IEnumerable<Vattuyte> ListAllPaging(string searchString, int page, int pageSize, int minp, int maxp)
        {
            List<Vattuyte> listLinks = new List<Vattuyte>();

            //var model = from l in db.Products // lấy toàn bộ sp
            //            join c in db.ProductCategories on l.CategoryID equals c.CategoryID
            //            select new { l.ProductID, l.ProductName, l.Price, l.Description, l.CategoryID, c.Name, l.ProductCode, l.ProductImage, l.Quantity };

            var model = from l in db.Vattuytes // lấy toàn bộ sp
                        select new { l.Mavattu, l.Tenvattu};

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    model = model.Where(x => x.ProductName.Contains(searchString) || x.ProductName.Contains(searchString));
            //}

            //if (CategoryID != 0)
            //{
            //    model = model.Where(x => x.CategoryID == CategoryID);
            //}

            //if (minp != 0 && maxp != 0)
            //{
            //    model = model.Where(x => x.Price > minp && x.Price < maxp);
            //}

            //if (minp != 0)
            //{
            //    model = model.Where(x => x.Price > minp);
            //}

            //if (maxp != 0)
            //{
            //    model = model.Where(x => x.Price < maxp);
            //}

            foreach (var item in model)
            {
                Vattuyte temp = new Vattuyte();
                //temp.Mavattu = item.Mavattu;
                temp.Tenvattu = item.Tenvattu;
                listLinks.Add(temp);
            }

            return listLinks.OrderByDescending(x => x.Maloaivattu);
            //return listLinks.OrderByDescending(x => x.Maloaivattu).ToPagedList(page, pageSize);
        }

        //public IEnumerable<Vattuyte> ListAllPaging2(string searchString, int page, int pageSize)
        //{
        //    List<Vattuyte> listLinks = new List<Vattuyte>();

        //    var model = from l in db.Vattuytes // lấy toàn bộ sp
        //                join c in db.ProductCategories on l.CategoryID equals c.CategoryID
        //                select new { l.ProductID, l.ProductName, l.Price, l.Description, l.CategoryID, l.Quantity };

        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(x => x.ProductName.Contains(searchString) || x.ProductName.Contains(searchString));
        //    }

        //    foreach (var item in model)
        //    {
        //        Product temp = new Product();
        //        temp.CategoryID = item.CategoryID;
        //        temp.Description = item.Description;
        //        temp.ProductID = item.ProductID;
        //        temp.ProductName = item.ProductName;
        //        temp.Price = item.Price;
        //        temp.Quantity = item.Quantity;
        //        listLinks.Add(temp);
        //    }

        //    return listLinks.OrderByDescending(x => x.Price).ToPagedList(page, pageSize);
        //}

        /// <summary>
        /// Get list product by category
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        /// 


        //public List<ProductViewModel> ListByCategoryId(long categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        //{
        //    totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
        //    var model = (from a in db.Products
        //                 join b in db.ProductCategories
        //                 on a.CategoryID equals b.CategoryID
        //                 where a.CategoryID == categoryID
        //                 select new
        //                 {
        //                     CateMetaTitle = b.MetaTitle,
        //                     CateName = b.Name,
        //                     CreatedDate = a.CreatedDate,
        //                     ID = a.ProductID,
        //                     Images = a.ProductImage,
        //                     Name = a.ProductName,
        //                     MetaTitle = a.MetaTitle,
        //                     Price = a.Price
        //                 }).AsEnumerable().Select(x => new ProductViewModel()
        //                 {
        //                     CateMetaTitle = x.MetaTitle,
        //                     CateName = x.Name,
        //                     CreatedDate = x.CreatedDate,
        //                     ID = x.ID,
        //                     Images = x.Images,
        //                     Name = x.Name,
        //                     MetaTitle = x.MetaTitle,
        //                     Price = x.Price
        //                 });
        //    model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    return model.ToList();
        //}
        //public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        //{
        //    totalRecord = db.Products.Where(x => x.ProductName == keyword).Count();
        //    var model = (from a in db.Products
        //                 join b in db.ProductCategories
        //                 on a.CategoryID equals b.CategoryID
        //                 where a.ProductName.Contains(keyword)
        //                 select new
        //                 {
        //                     CateMetaTitle = b.MetaTitle,
        //                     CateName = b.Name,
        //                     CreatedDate = a.CreatedDate,
        //                     ID = a.ProductID,
        //                     Images = a.ProductImage,
        //                     Name = a.ProductName,
        //                     MetaTitle = a.MetaTitle,
        //                     Price = a.Price
        //                 }).AsEnumerable().Select(x => new ProductViewModel()
        //                 {
        //                     CateMetaTitle = x.MetaTitle,
        //                     CateName = x.Name,
        //                     CreatedDate = x.CreatedDate,
        //                     ID = x.ID,
        //                     Images = x.Images,
        //                     Name = x.Name,
        //                     MetaTitle = x.MetaTitle,
        //                     Price = x.Price
        //                 });
        //    model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    return model.ToList();
        //}


        /// <summary>
        /// List feature product
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        /// 

        //public List<Vattuyte> ListFeatureProduct(int top)
        //{
        //    return db.Vattuytes.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        //}
        //public List<Vattuyte> ListRelatedProducts(long productId)
        //{
        //    var product = db.Vattuytes.Find(productId);
        //    return db.Vattuytes.Where(x => x.ProductID != productId && x.CategoryID == product.CategoryID).ToList();
        //}

        //public void UpdateImages(long productId, string images)
        //{
        //    var product = db.Vattuytes.Find(productId);
        //    product.MoreImages = images;
        //    db.SaveChanges();
        //}

        public Vattuyte ViewDetail(string id)
        {
            return db.Vattuytes.Find(id);
        }

        public string Insert(Vattuyte entity)
        {
            db.Vattuytes.Add(entity);
            db.SaveChanges();
            return entity.Mavattu;
        }

        public bool Update(Vattuyte entity)
        {
            try
            {
                var pr = db.Vattuytes.Find(entity.Mavattu);
                pr.Tenvattu = entity.Tenvattu;
                ///
                ///
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                var pr = db.Vattuytes.Find(id);
                db.Vattuytes.Remove(pr);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public string GetIDByMaxMaLoai()
        {
            var products = db.Vattuytes.OrderByDescending(x => x.Maloaivattu).First();
            return db.Vattuytes.SingleOrDefault(x => x.Maloaivattu == products.Maloaivattu).Mavattu;
        }
    }
}
