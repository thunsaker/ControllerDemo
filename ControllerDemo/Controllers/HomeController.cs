using System.Web.Mvc;

namespace ControllerDemo.Controllers {
    public class HomeController : Controller {
        // GET: /Home/
        public ActionResult Index() {
            return View();
        }
    }
}