using System.Diagnostics;
using System.Web;
using System.Web.Mvc;

namespace StudentMng.Filters
{
    public class CustomAuth : AuthorizeAttribute
    {
        public string Role { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.Session["User"];//Check if user is logged in
            var role = httpContext.Session["Role"]?.ToString();//Get user role from session

            if (user == null)
                return false;//Access denied

            if (!string.IsNullOrEmpty(Role))
                return role == Role && role != null;//Access granted if role matches and have values

            return true;//Access granted
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            Debug.WriteLine("Unauthorized Access Attempted.");
            filterContext.Result = new RedirectResult("/Account/Login");//Redirect to login page
        }
    }
}