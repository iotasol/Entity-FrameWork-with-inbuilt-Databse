/*
 * IOTASOL Pvt. Ltd.
 * Date: 26-02-2015
 * Summary : Controller to work with simple CRUD operation
 */
using System;
using System.Web.Mvc;
using EntityFramworkDbDemo.Web.DataModels.Models;

namespace EntityFramworkDbDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Display main page of this application
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// To insert new department in database
        /// </summary>
        /// <param name="model">model representing department</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(DepartmentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                model.CreateDepartment();
                ModelState.Clear();
                return View();
            }
            catch (InvalidOperationException ex)
            {
                ViewBag.Error = ex.Message;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View(model);
        }
        /// <summary>
        /// To render partial view with DepartmentTable
        /// </summary>
        /// <returns></returns>
        public ActionResult DepartmentList()
        {
            var departList = new DepartmentViewModel().GetDepartments();
            return PartialView("_DepartmentList", departList);
        }
        /// <summary>
        /// To update exiting department
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateDepartment(DepartmentViewModel model)
        {
            try
            {
                model.Update();
                return Json(new {StatusCode = 2, Status = "Successfully updated."});
            }
            catch (Exception ex)
            {
                return Json(new {StatusCode = 4, Status = ex.Message});
            }
        }
        /// <summary>
        /// get a single department by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetSingle(int id)
        {
            var singleDept = new DepartmentViewModel().GetSingle(id);
            return Json(singleDept, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// delete a department with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DeleteDept(int id)
        {
            new DepartmentViewModel().Delete(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}