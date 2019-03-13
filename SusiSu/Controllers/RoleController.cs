using Microsoft.AspNet.Identity.EntityFramework;
using SusiSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SusiSu.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext db;


        public RoleController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Role
        public ActionResult Index()
        {
            var roles = db.Roles.ToList();

            return View(roles);
        }


        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            db.Roles.Add(Role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


       
        public ActionResult RoleAta()
        {
            ViewBag.Name = new SelectList(db.Roles.ToList(), "Name", "Name");
            return View();
        }

    }
}