using MvcCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCodeFirst.Controllers
{
    public class CustomerAjaxController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerAjaxController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(_context.Customers.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Customer user)
        {
            _context.Customers.Add(user);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(_context.Customers.FirstOrDefault(x => x.CustomerID == ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Customer user)
        {
            var data = _context.Customers.FirstOrDefault(x => x.CustomerID == user.CustomerID);
            if (data != null)
            {
                data.Name = user.Name;
                data.DOB = user.DOB;
                data.District = user.District;
                data.Country = user.Country;
                
                _context.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = _context.Customers.FirstOrDefault(x => x.CustomerID == ID);
            _context.Customers.Remove(data);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}