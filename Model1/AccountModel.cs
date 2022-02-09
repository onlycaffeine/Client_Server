using Model1.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model1
{
    public class AccountModel
    {
        private CSDL_NangcaoDbContext context = null;
        public AccountModel()
        {
            context = new CSDL_NangcaoDbContext();
        }

        public bool Login(string username, string password)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Taikhoan", username),
                new SqlParameter("@Matkhau", password),
            };

            var res = context.Database.SqlQuery<bool>("Sp_Account_Login @Taikhoan, @Matkhau", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
