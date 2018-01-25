using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3Assignment.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            string[] files = System.IO.Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath("~/TextFiles"));
            for(int i = 0; i < files.Length; i++)
            {
                files[i] = System.IO.Path.GetFileNameWithoutExtension(files[i]);
            }
            ViewBag.files = files;
            return View();
        }

        [Route("Display/{id?}"), ActionName("Display")]
        public ActionResult Contents(string id)
        {
            if (id != null)
            {
                try
                {
                    string text = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/TextFiles/" + id + ".txt"));
                    ViewBag.itemToShow = text;
                }
                catch(Exception E)
                {
                    ViewBag.itemToShow = "No Such File";
                }
            } else
            {
                ViewBag.itemToShow = "No Such File";
            }
            return View();
        }
    }
}