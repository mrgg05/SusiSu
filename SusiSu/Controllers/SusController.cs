using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SusiSu.Helpers;
using SusiSu.Models;

namespace SusiSu.Controllers
{
    public class SusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sus
        public ActionResult Index()
        {
            return View(db.Su.ToList());
        }

        public ActionResult Listele()
        {
            ViewBag.BoyEnum = new SelectList(Enum.GetValues(typeof(Enums.Enums.Boy)), Enums.Enums.Boy.buyuk);

            var result = (from a in db.Su
                          group a by new { a.Tur, a.Boy,a.Fiyat,a.SuID} into grp
                          select new ListeleViewModel
                          { SuID=grp.Key.SuID,
                              Fiyat=grp.Key.Fiyat,
                              Tur = grp.Key.Tur,
                              Boy = grp.Key.Boy,
                              StokMiktari = grp.Sum(t => t.StokMiktari)
                          }).ToList();


           

            return View(result);


            
        }

        // GET: Sus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Su su = db.Su.Find(id);
            if (su == null)
            {
                return HttpNotFound();
            }
            return View(su);
        }

        [Authorize(Roles ="bayi")]
        // GET: Sus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "bayi")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StokMiktari,Tur,Boy,Fiyat,UretimTarihi,SonKullanmaTarihi,EklenmeTarihi")] Su su)
        {
            if (ModelState.IsValid)
            {
                db.Su.Add(su);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(su);
        }

        // GET: Sus/Edit/5
        [Authorize(Roles = "bayi")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Su su = db.Su.Find(id);
            if (su == null)
            {
                return HttpNotFound();
            }
            return View(su);
        }

        // POST: Sus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "bayi")]
        public ActionResult Edit([Bind(Include = "ID,StokMiktari,Tur,Boy,Fiyat,UretimTarihi,SonKullanmaTarihi")] Su su)
        {
            if (ModelState.IsValid)
            {
                db.Entry(su).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(su);
        }

        // GET: Sus/Delete/5
        [Authorize(Roles = "bayi")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Su su = db.Su.Find(id);
            if (su == null)
            {
                return HttpNotFound();
            }
            return View(su);
        }

        // POST: Sus/Delete/5
        [Authorize(Roles = "bayi")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Su su = db.Su.Find(id);
            db.Su.Remove(su);
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
