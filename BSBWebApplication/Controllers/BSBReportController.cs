using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSBWebApplication.Controllers
{
    public class BSBReportController : Controller
    {
        // GET: BSBReport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GridViewerPage()
        {
            return View();
        }

        public ActionResult ReportViewerPage()
        {
            return View();
        }

        BSBWebApplication.Models.BSBDatabaseEntities db = new BSBWebApplication.Models.BSBDatabaseEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.ParSys;
            return PartialView("_GridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] BSBWebApplication.Models.ParSy item)
        {
            var model = db.ParSys;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] BSBWebApplication.Models.ParSy item)
        {
            var model = db.ParSys;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.PAR_ID == item.PAR_ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 PAR_ID)
        {
            var model = db.ParSys;
            if (PAR_ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.PAR_ID == PAR_ID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model.ToList());
        }
    }
}