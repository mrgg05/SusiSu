using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SusiSu.Models;

namespace SusiSu.Controllers
{
    public class SiparisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Siparis
        public ActionResult Index()
        {
            return View(db.Siparis.ToList());
        }

        // GET: Siparis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // GET: Siparis/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SiparisOlustur(Siparis s,SiparisDetay sd,Su su)
        {

                Siparis sip = new Siparis();
                SiparisDetay sipdetay = new SiparisDetay();



            var userid= User.Identity.GetUserId();

            var userbilgi = (from a in db.User
                             where a.Id == userid
                             select a).FirstOrDefault();

               

                sip.User = userbilgi;
                sip.SiparisTarihi =s.SiparisTarihi;
            db.Siparis.Add(sip);
            db.SaveChanges();

            int sonsip = db.Siparis.OrderByDescending(x => x.SiparisID).FirstOrDefault().SiparisID;
            int suid = db.Su.Where(x => x.Tur == su.Tur && x.Boy == su.Boy).FirstOrDefault().SuID;

            sipdetay.Adet = sd.Adet;
            sipdetay.SiparisID = sonsip;
            sipdetay.Fiyat = sd.Fiyat;
            sipdetay.SuID = suid; 
            db.SiparisDetay.Add(sipdetay);
            db.SaveChanges();


            return RedirectToAction("Index");

        }

        public ActionResult SiparisOlustur()
        {
            return View();
        }

        // POST: Siparis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SiparisTarihi")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Siparis.Add(siparis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(siparis);
        }

        // GET: Siparis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // POST: Siparis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SiparisTarihi")] Siparis siparis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(siparis);
        }

        // GET: Siparis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Siparis siparis = db.Siparis.Find(id);
            if (siparis == null)
            {
                return HttpNotFound();
            }
            return View(siparis);
        }

        // POST: Siparis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Siparis siparis = db.Siparis.Find(id);
            db.Siparis.Remove(siparis);
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
