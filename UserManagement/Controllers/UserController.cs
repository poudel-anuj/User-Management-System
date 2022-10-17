using PagedList;
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
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageIndex = 1;
            var p = page == null ? 1 : page;

            var data = _context.TblUser.ToList().OrderByDescending(x => x.Id).ToPagedList(page ?? 1, 3);
            //var data = _context.TblUser.ToList();
            //if (page>0)
            //    page=page;
            //else
            //{
            //    page = 1; //set page to default
            //}
            //int limit = 5; //display 5 products per page
            //int start = (int)(page -1) * limit;
            //int totalProduct = data.Count();
            //ViewBag.toalProduct = totalProduct;
            //ViewBag.currentPage = page;
            //int numberPage = (totalProduct / limit);
            //ViewBag.numberPage = numberPage;
            //var dataProduct = data.OrderByDescending(s => s.Id).Skip(start).Take(limit);
            ViewBag.pageNum = page;

            return View(data);
        }

        [HttpPost]
        public ActionResult Insert(TblUser model)
        {
            var data = _context.TblUser.Add(model);
            _context.SaveChanges();
            return Json("Sucessfully inserted", JsonRequestBehavior.AllowGet);
            //return RedirectToAction("GetAll");
        }

        public JsonResult GetById(int id)
        {
            var data = _context.TblUser.Find(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(TblUser model)
        {
            var dbREsp = _context.TblUser.Update(model);
            _context.SaveChanges();
            return Json("Updated Scuessfully", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetAll(int page)
        {
            var data = _context.TblUser.ToList().OrderByDescending(p => p.Id).ToPagedList(page, 3);
            //page = data.Count();
            if (data.Count == 0)
            {

                page = page - 1;
                if (page >= 1)
                {

                data = _context.TblUser.ToList().ToPagedList(page, 3);
                }
                //page = data.Count();


            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(TblUser model,int page)
        {
            var d = model.Id;
            var Id = _context.TblUser.Where(x => x.Id == d);
            var dbResp = _context.TblUser.Remove(model);
            _context.SaveChanges();
            var datas = _context.TblUser.ToList().ToPagedList(page, 3);
            //page = data.Count();
            //if (datas.Count == 0)
            //{

            //    page = page - 1;
            //    if (page >= 1)
            //    {

            //        datas = _context.TblUser.ToList().ToPagedList(page, 3);
            //    }
            //    //page = data.Count();


            //}
            return Json(datas, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult DeleteFromMoadl(int id)
        {
            var data = _context.TblUser.Find(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }





    }
}