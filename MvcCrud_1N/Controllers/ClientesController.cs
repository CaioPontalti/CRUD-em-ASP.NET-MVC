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
    public class ClientesController : Controller
    {
        private LojaContext db = new LojaContext();

        // GET: Clientes
        public ActionResult Index()
        {
            var clietes = db.Clietes.Include(c => c.Consultores);
            return View(clietes.ToList());
        }

        [HttpPost]
        public ActionResult Index(string texto)
        {
            var clietes = db.Clietes.Where(c => c.Nome.Contains(texto));
            return View(clietes.ToList());
        }


        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clietes.Include(c => c.Consultores) //Join com a tabela de Consultores
                                          .Include(c => c.Telefones) //Join com a tabela de telefones
                                          .FirstOrDefault(c => c.Id == id); // Buscando pelo Id
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.IdConsultor = new SelectList(db.Consultores, "Id", "Nome");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,IdConsultor,Telefones")] Clientes clientes)
        {
                if (ModelState.IsValid)
            {
                db.Clietes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdConsultor = new SelectList(db.Consultores, "Id", "Nome", clientes.IdConsultor);
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clietes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdConsultor = new SelectList(db.Consultores, "Id", "Nome", clientes.IdConsultor);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,IdConsultor,Telefones")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdConsultor = new SelectList(db.Consultores, "Id", "Nome", clientes.IdConsultor);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clietes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clietes.Find(id);
            db.Clietes.Remove(clientes);
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
