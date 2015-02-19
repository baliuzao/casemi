using System;

using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Casemi.Models;

namespace Casemi.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private CasemiDesenvolvimentoEntities db = new CasemiDesenvolvimentoEntities();

        // GET: Produtos
        public ActionResult Index(string searchString)
        {
            IQueryable<Produtos> produtos = db.Produtos;

            if (!string.IsNullOrEmpty(searchString))
            {
                produtos = produtos.Where(
                        x => x.Nome.Contains(searchString)
                );
            }

            return View(produtos.OrderBy(x => x.Nome).ToList());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            Produtos produtos = new Produtos();
            
            produtos.PrecoDeCompra = 0;
            produtos.PrecoDeVenda = 0;
            produtos.EstoqueQuantidadeAtual = 0;
            produtos.EstoqueQuantidadeMinima = 0;
            produtos.EstoqueQuantidadeMaxima = 0;
            
            ViewBag.ProdutoGrupoID = new SelectList(db.ProdutoGrupos.OrderBy(x => x.Nome), "ProdutoGrupoID", "Nome", produtos.ProdutoGrupoID);
            ViewBag.VendaUnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(x => x.Nome), "UnidadeDeMedidaID", "Nome", produtos.VendaUnidadeDeMedidaID);
            ViewBag.CompraUnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(x => x.Nome), "UnidadeDeMedidaID", "Nome", produtos.CompraUnidadeDeMedidaID);
            return View(produtos);
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoID,CodigoDeBarras,CodigoInterno,Nome,CompraUnidadeDeMedidaID,VendaUnidadeDeMedidaID,PrecoDeCompra,PrecoDeVenda,EstoqueLocal,EstoqueQuantidadeAtual,EstoqueQuantidadeMinima,EstoqueQuantidadeMaxima,ProdutoGrupoID")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                produtos.ProdutoID = Guid.NewGuid();
                db.Produtos.Add(produtos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoGrupoID = new SelectList(db.ProdutoGrupos.OrderBy(x => x.Nome), "ProdutoGrupoID", "Nome", produtos.ProdutoGrupoID);
            ViewBag.VendaUnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(x => x.Nome), "UnidadeDeMedidaID", "Nome", produtos.VendaUnidadeDeMedidaID);
            ViewBag.CompraUnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(x => x.Nome), "UnidadeDeMedidaID", "Nome", produtos.CompraUnidadeDeMedidaID);
            return View(produtos);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProdutoGrupoID = new SelectList(db.ProdutoGrupos.OrderBy(x => x.Nome), "ProdutoGrupoID", "Nome", produtos.ProdutoGrupoID);
            ViewBag.VendaUnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(x => x.Nome), "UnidadeDeMedidaID", "Nome", produtos.VendaUnidadeDeMedidaID);
            ViewBag.CompraUnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(x => x.Nome), "UnidadeDeMedidaID", "Nome", produtos.CompraUnidadeDeMedidaID);
            return View(produtos);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoID,CodigoDeBarras,CodigoInterno,Nome,CompraUnidadeDeMedidaID,VendaUnidadeDeMedidaID,PrecoDeCompra,PrecoDeVenda,EstoqueLocal,EstoqueQuantidadeAtual,EstoqueQuantidadeMinima,EstoqueQuantidadeMaxima,ProdutoGrupoID")] Produtos produtos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { searchString = produtos.Nome });
            }

            ViewBag.ProdutoGrupoID = new SelectList(db.ProdutoGrupos.OrderBy(x => x.Nome), "ProdutoGrupoID", "Nome", produtos.ProdutoGrupoID);
            ViewBag.VendaUnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(x => x.Nome), "UnidadeDeMedidaID", "Nome", produtos.VendaUnidadeDeMedidaID);
            ViewBag.CompraUnidadeDeMedidaID = new SelectList(db.UnidadesDeMedida.OrderBy(x => x.Nome), "UnidadeDeMedidaID", "Nome", produtos.CompraUnidadeDeMedidaID);
            return View(produtos);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produtos produtos = db.Produtos.Find(id);
            if (produtos == null)
            {
                return HttpNotFound();
            }
            return View(produtos);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Produtos produtos = db.Produtos.Find(id);
            db.Produtos.Remove(produtos);
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