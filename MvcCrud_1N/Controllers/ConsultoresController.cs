using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcCrud_1N.Models;

namespace MvcCrud_1N.Controllers
{
    public class ConsultoresController : Controller
    {
        private LojaContext db = new LojaContext();

        // GET: Consultores
        public ActionResult Index()
        {
            return View(db.Consultores.ToList());
        }

        [HttpPost]
        public ActionResult Index(string texto)
        {
            return View(db.Consultores.Where(c => c.Nome.Contains(texto)));
        }

        // GET: Consultores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultores consultores = db.Consultores.Find(id);
            if (consultores == null)
            {
                return HttpNotFound();
            }
            return View(consultores);
        }

        // GET: Consultores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consultores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Consultores consultores)
        {

            if (ModelState.IsValid)
            {
                db.Consultores.Add(consultores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consultores);
        }

        // GET: Consultores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultores consultores = db.Consultores.Find(id);
            if (consultores == null)
            {
                return HttpNotFound();
            }
            return View(consultores);
        }

        // POST: Consultores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Consultores consultores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consultores);
        }

        // GET: Consultores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultores consultores = db.Consultores.Find(id);
            if (consultores == null)
            {
                return HttpNotFound();
            }
            return View(consultores);
        }

        // POST: Consultores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultores consultores = db.Consultores.Find(id);
            db.Consultores.Remove(consultores);
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
