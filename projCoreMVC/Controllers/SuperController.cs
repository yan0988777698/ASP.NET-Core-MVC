using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using projCoreMVC.Models;

namespace projCoreMVC.Controllers
{
    public class SuperController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (!HttpContext.Session.Keys.Contains(CDictionary.SessionKey_Login_Member))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Login",
                }));
            }
        }
    }
}
