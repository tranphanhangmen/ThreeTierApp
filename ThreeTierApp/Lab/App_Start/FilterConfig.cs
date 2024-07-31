using Lab.Models;
using System.Web;
using System.Web.Mvc;

namespace Lab
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new AuthorizeDemo());
        }
    }

    public class AuthorizeDemo : FilterAttribute, IAuthorizationFilter
    {
        private readonly string _roles;

        public AuthorizeDemo()
        {

        }
        public AuthorizeDemo(string Roles)
        {
            _roles = Roles.ToLower();
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var login = filterContext.HttpContext.Session["login"] as LoginModel;

            if (_roles == null)
            {
                return;
            }

            if (login == null && _roles != null)
            {
                filterContext.Result = new RedirectResult("/accounts/login");
            }

            if (login != null && _roles.IndexOf(login.Role.ToLower()) == -1)
            {
                filterContext.Result = new RedirectResult("/home/error");
            }
        }
    }
}
