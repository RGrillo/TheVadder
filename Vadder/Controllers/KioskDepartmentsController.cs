using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vadder.Models;

namespace Vadder.Controllers
{
    public class KioskDepartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KioskDepartments
        public ActionResult Index()
        {
            return View(db.KioskDepartments.ToList());
        }

        // GET: KioskDepartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KioskDepartment kioskDepartment = db.KioskDepartments.Find(id);
            if (kioskDepartment == null)
            {
                return HttpNotFound();
            }
            return View(kioskDepartment);
        }

        // GET: KioskDepartments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KioskDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(KioskDepartment model)
        {
            if (ModelState.IsValid)
            {
                KioskDepartment kioskDepartment = new KioskDepartment()
                {
                    KdName = model.KdName,
                    KdCreateUTC = DateTime.Now,
                    KioskId = 1000, //Colocar o numero quando timer usando no futuro tirando do DB
                    KdCreateBy = User.Identity.GetUserId(),

                    //KdCreateBy colocar quando estiver logado e pegar do nome do usuario

                };

                db.KioskDepartments.Add(kioskDepartment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: KioskDepartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KioskDepartment kioskDepartment = db.KioskDepartments.Find(id);
            if (kioskDepartment == null)
            {
                return HttpNotFound();
            }
            return View(kioskDepartment);
        }

        // POST: KioskDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, KioskDepartment model)
        {
            if (ModelState.IsValid)
            {

                var kioskDepartment = db.KioskDepartments.SingleOrDefault(c => c.KdId == id);
                kioskDepartment.KdName = model.KdName;
                kioskDepartment.KdCreateUTC = model.KdCreateUTC;
                kioskDepartment.KioskId = model.KioskId; //Colocar o numero quando timer usando no futuro tirando do DB
                kioskDepartment.KdCreateBy = model.KdCreateBy;
                kioskDepartment.KdModifyUTC = DateTime.Now;
                kioskDepartment.KdModifyBy = User.Identity.GetUserId();


                //db.Entry(kioskDepartment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: KioskDepartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KioskDepartment kioskDepartment = db.KioskDepartments.Find(id);
            if (kioskDepartment == null)
            {
                return HttpNotFound();
            }
            return View(kioskDepartment);
        }

        // POST: KioskDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KioskDepartment kioskDepartment = db.KioskDepartments.Find(id);
            db.KioskDepartments.Remove(kioskDepartment);
            db.SaveChanges();
            return RedirectToAction("Index");
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
