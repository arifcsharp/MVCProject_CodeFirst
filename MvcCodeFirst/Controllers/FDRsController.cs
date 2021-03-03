using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcCodeFirst.Models;

namespace MvcCodeFirst.Controllers
{
    public class FDRsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<BCustomer> OrderAndCustomerList = db.BCustomers.ToList();
            return View(OrderAndCustomerList);
        }


        public ActionResult DeleteCustomer(Guid? id)
        {
            BCustomer bcustomer = db.BCustomers.Find(id);
            db.BCustomers.Remove(bcustomer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteOrder(Guid? id)
        {
            FDR fdr = db.FDRs.Find(id);
            db.FDRs.Remove(fdr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SaveOrder(string name, String address, FDR[] fdr)
        {
            string result = "Error! FDR Account Is Not Complete!";
            if (name != null && address != null && fdr != null)
            {
                var bcutomerId = Guid.NewGuid();
                BCustomer model = new BCustomer();
                model.BCustomerID = bcutomerId;
                model.Name = name;
                model.Address = address;
                model.OpeningDate = DateTime.Now;
                db.BCustomers.Add(model);

                foreach (var item in fdr)
                {
                    var fdrId = Guid.NewGuid();
                    FDR O = new FDR();
                    O.FDRID = fdrId;
                    O.AccountName = item.AccountName;
                    O.Quantity = item.Quantity;
                    O.Value = item.Value;
                    O.TotalAmount = item.TotalAmount;
                    O.BCustomerID = bcutomerId;
                    db.FDRs.Add(O);
                }
                db.SaveChanges();
                result = "Success! FDR Account Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}