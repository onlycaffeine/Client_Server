using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSDL_Nangcao.Areas.Admin.Code
{
    public class SessionHelper
    {
        public static void SetSession(UserSession sessions)
        {
            HttpContext.Current.Session["loginSession"] = sessions;
        }

        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["loginSession"];
            if (session == null)
                return null;
            else
            {
                return session as UserSession;
            }
        }
    }
}