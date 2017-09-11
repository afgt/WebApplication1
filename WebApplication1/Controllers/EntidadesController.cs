using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EntidadesController : Controller
    {
        private KnowledgeBaseDbContext db = new KnowledgeBaseDbContext();

        // GET: Entidades
        public ActionResult Index()
        {
            return View(db.Entidades.ToList());
        }

        // GET: Entidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidade entidade = db.Entidades.Find(id);
            if (entidade == null)
            {
                return HttpNotFound();
            }
            return View(entidade);
        }

        //test de github
        // GET: Entidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entidades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntidadeId,Nome,Nif")] Entidade entidade)
        {
            if (ModelState.IsValid)
            {
                db.Entidades.Add(entidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entidade);
        }

        // GET: Entidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidade entidade = db.Entidades.Find(id);
            if (entidade == null)
            {
                return HttpNotFound();
            }
            return View(entidade);
        }

        // POST: Entidades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntidadeId,Nome,Nif")] Entidade entidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entidade);
        }

        // GET: Entidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entidade entidade = db.Entidades.Find(id);
            if (entidade == null)
            {
                return HttpNotFound();
            }
            return View(entidade);
        }

        // POST: Entidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entidade entidade = db.Entidades.Find(id);
            db.Entidades.Remove(entidade);
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
