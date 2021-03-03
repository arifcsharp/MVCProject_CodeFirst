using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using System.IO;
using MvcCodeFirst.Models;
using System.Data.Entity;

namespace MvcCodeFirst.Controllers
{
    public class AccountHolderController : Controller
    {
        // GET: HEmployee
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<AccountHolder> GetAllEmployee()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.AccountHolders.ToList<AccountHolder>();
            }

        }

        public ActionResult AddOrEdit(int id = 0)
        {
            AccountHolder emp = new AccountHolder();
            if (id != 0)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    emp = db.AccountHolders.Where(x => x.AccountHolderID == id).FirstOrDefault<AccountHolder>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(AccountHolder emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    if (emp.AccountHolderID == 0)
                    {
                        db.AccountHolders.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();

                    }
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Submitted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    AccountHolder emp = db.AccountHolders.Where(x => x.AccountHolderID == id).FirstOrDefault<AccountHolder>();
                    db.AccountHolders.Remove(emp);
                    db.SaveChanges();
                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}