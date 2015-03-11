using System;

using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Casemi.Models;
using PagedList;

namespace Casemi.Controllers
{
    [Authorize]
    public class ServicosController : Controller
    {
        private CasemiDesenvolvimentoEntities db = new CasemiDesenvolvimentoEntities();

        // GET: Servicos
        public ActionResult Index(string searchString, string currentFilter, int? page)
        {
            var servicos = db.Servicos.AsQueryable();

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                servicos = servicos.Where(
                        x => x.Nome.Contains(searchString)
                );
            }
            else
            {
                searchString = currentFilter;
            }



            int pageSize = 25;
            int pageNumber = (page ?? 1);


            return View(servicos.OrderBy(x => x.Nome).ToPagedList(pageNumber, pageSize));
        }

        // GET: Servicos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicos servicos = db.Servicos.Find(id);
            if (servicos == null)
            {
                return HttpNotFound();
            }
            return View(servicos);
        }

        // GET: Servicos/Create
        public ActionResult Create()
        {
            Servicos servicos = new Servicos();
            return View(servicos);
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServicoID,Nome,DescontoParaAssociados")] Servicos servicos)
        {
            if (ModelState.IsValid)
            {
                servicos.ServicoID = Guid.NewGuid();
                db.Servicos.Add(servicos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicos);
        }

        // GET: Servicos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicos servicos = db.Servicos.Find(id);
            if (servicos == null)
            {
                return HttpNotFound();
            }

            return View(servicos);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServicoID,Nome,DescontoParaAssociados")] Servicos servicos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicos);
        }

        // GET: Servicos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicos servicos = db.Servicos.Find(id);
            if (servicos == null)
            {
                return HttpNotFound();
            }
            return View(servicos);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Servicos servicos = db.Servicos.Find(id);
            db.Servicos.Remove(servicos);
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