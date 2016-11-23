using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wangjianlong.functionality.Web.Common;

namespace Wangjianlong.functionality.Web.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            var file = HttpContext.Request.Files[0];
            var saveFile = FileManager.Upload(file);
            return Json(saveFile, JsonRequestBehavior.AllowGet);
        }
    }
}