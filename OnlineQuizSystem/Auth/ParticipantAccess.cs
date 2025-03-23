using OnlineQuizSystem.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace OnlineQuizSystem.Auth
{
    public class ParticipantAccess : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (User)httpContext.Session["user"];
            if (user == null || user.Role == 2)
            {
                return true;
            }
            return false;
        }
    }
}