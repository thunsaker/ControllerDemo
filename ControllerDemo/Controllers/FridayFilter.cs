using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllerDemo.Controllers {
    public class FridayFilter : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday) {
                base.OnActionExecuting(filterContext);
            } else {
                filterContext.Result =
                    new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new {
                                    controller = "Monkey",
                                    action = "NotTheDay",
                                    name = "Friday"
                                }));
            }
        }
    }
}