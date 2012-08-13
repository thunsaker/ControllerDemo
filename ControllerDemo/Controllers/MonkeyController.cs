using System.Text;
using System.Web.Mvc;
using ControllerDemo.Models;

namespace ControllerDemo.Controllers {
    public class MonkeyController : Controller {
        #region ActionResult Examples

        // GET: /Monkey/
        /// <summary>Return Raw HTML</summary>
        public ActionResult Index() {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html><head><title>Testing</title></head>");
            sb.Append("<body>");
            sb.Append("<h1>Raw Html</h1>");
            sb.Append("<div class=\"main\">The Body of the Page<br /><br />");
            sb.Append("<a href=\"" + Url.Action("Index", "Home") + "\">Home</a>");
            sb.Append("</div></body></html>");
            return Content(sb.ToString(), "text/html");
        }

        // GET: /Monkey/Get/5
        /// <summary>Return Raw JSON</summary>
        public ActionResult Get(int id) {
            return Json(
                new {
                    Id = id,
                    Name = "George",
                    ScientificName = "Simia Curiosa",
                    Active = "true",
                    DateCreated = "1343404556"
                },
                JsonRequestBehavior.AllowGet);
        }

        // GET: /Monkey/Add
        public ActionResult Add() {
            return View("Add");
        }

        // POST: /Monkey/Add
        [HttpPost]
        public ActionResult Add(FormCollection collection) {
            try {
                // Create the Monkey, redirect user to home
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: /Monkey/Download
        /// <summary>Return an Image</summary>
        public FileResult Download() {
            string filename = Url.Content("~/Content/monkey.jpg");
            return File(filename, "image/jpeg", "DownloadedMonkey.jpg");
        }

        #endregion

        #region Filter Examples
        [FridayFilter]
        public ActionResult OnlyOnFriday() {
            return Content(MonkeyHtml.FridayHtml);
        }

        public ActionResult NotTheDay(string name) {
            return Content("<html><body>Not " + name + " like, I thought it was...</body></html>");
        }

        [TuesdayFilter]
        public ActionResult OnlyOnTuesday() {
            return Content("<html><body>Not the day I thought it was...</body></html>");
        }
        #endregion

        #region Unimplemented Actions

        // GET: /Monkey/Edit/5
        [Authorize]
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: /Monkey/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: /Monkey/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: /Monkey/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        #endregion
    }
}