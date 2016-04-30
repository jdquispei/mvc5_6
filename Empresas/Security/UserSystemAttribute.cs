using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Empresas.Security
{
    public class UserSystemAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authroized = base.AuthorizeCore(httpContext);
            if (!authroized)
            {
                return false;
            }

            var AuthAccount = httpContext.Session["AuthAccount"];
            if (AuthAccount == null)
            {
                return false;
            }

            return true;
        }
    }
}