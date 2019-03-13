using SusiSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SusiSu.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        ApplicationDbContext db = new ApplicationDbContext();
        public PartialViewResult Partial()
        {
          


            return PartialView("Partial");
        }

        //[HttpPost]
        //public ActionResult Partial(SiparisViewModel sipvm)
        //{
        //    Siparis s = new Siparis();
        //    s.SiparisTarihi = sipvm.SiparisTarihi;

        //    Su su = db.Su.Find(sipvm.Boy,);
            
        //    SiparisDetay sd = new SiparisDetay();
        //    sd.Adet = sipvm.Adet;


        //    db.Siparis.Add()

        //    return View("Siparis/SiparisOlustur");
        //}

    }
}