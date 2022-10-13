using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class UserController : Controller
    {
        UserManagementContext _context = new UserManagementContext();

        //GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Insert(TblUser model)
        {
            var data = _context.TblUser.Add(model);
            _context.SaveChanges();
            return Json("Sucessfully inserted", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(int id)
        {
            var data = _context.TblUser.Find(id);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(TblUser model)
        {
            var dbREsp = _context.TblUser.Update(model);
            _context.SaveChanges();
            return Json("Updated Scuessfully", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _context.TblUser.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(TblUser model)
        {
            var d = model.Id;
            var Id = _context.TblUser.Where(x => x.Id == d);
            var dbResp = _context.TblUser.Remove(model);
            _context.SaveChanges();
            return Json("Sucessfully deleted",JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DeleteFromMoadl(int id)
        {
            var data = _context.TblUser.Find(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }





    }
}