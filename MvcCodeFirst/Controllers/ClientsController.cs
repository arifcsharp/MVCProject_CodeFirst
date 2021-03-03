using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using MvcCodeFirst.Context;
using MvcCodeFirst.Models;
using System.IO;

namespace MvcCodeFirst.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Create(long? id)
        {
            if (id == null)
            {
                ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "ID", "Name");
            }
            else
            {
                ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "ID", "Name", id);
            }
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Address,IssueDate,Amount,AccountTypeID")] Client client, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    // To save a image to a folder
                    string picture = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/AppFiles/Images/"), picture);
                    file.SaveAs(path);

                    // To store as byte[] in a Table of Database
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        client.Image = ms.GetBuffer();
                    }
                    db.Clients.Add(client);
                    await db.SaveChangesAsync();
                    TempData["id"] = client.AccountTypeID;
                    return RedirectToAction("Index", "AccountTypes");
                }
                else
                {
                    ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "ID", "Name", client.AccountTypeID);
                    return PartialView(client);
                }
            }
            ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "ID", "Name", client.AccountTypeID);
            return PartialView(client);
        }

        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "ID", "Name", client.AccountTypeID);
            return PartialView(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Address,Image,IssueDate,Amount,AccountTypeID")] Client client, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    // To save a image to a folder
                    string picture = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/AppFiles/Images/"), picture);
                    file.SaveAs(path);

                    // To store as byte[] in a Table of Database
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        client.Image = ms.GetBuffer();
                    }
                }
                db.Entry(client).State = EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["id"] = client.AccountTypeID;
                return RedirectToAction("Index", "AccountTypes");
            }
            ViewBag.AccountTypeID = new SelectList(db.AccountTypes, "ID", "Name", client.AccountTypeID);
            return PartialView(client);
        }

        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = await db.Clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return PartialView(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            Client client = await db.Clients.FindAsync(id);
            db.Clients.Remove(client);
            await db.SaveChangesAsync();
            TempData["id"] = client.AccountTypeID;
            return RedirectToAction("Index", "AccountTypes");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
