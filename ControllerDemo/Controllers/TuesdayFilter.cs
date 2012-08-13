using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControllerDemo.Controllers {
    public class TuesdayFilter : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday) {
                base.OnActionExecuting(filterContext);
            } else {
                filterContext.Result =
                    new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new {
                                    controller = "Monkey",
                                    action = "NotTheDay",
                                    name = "Tuesday"
                                }));
            }
        }
    }
}