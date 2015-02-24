using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Casemi.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace OrdemServicoWeb.Controllers
{

    [Authorize]
    public class OrdemServicoController : Controller
    {
        private CasemiDesenvolvimentoEntities db = new CasemiDesenvolvimentoEntities();

        // GET: OrdemServico
        public ActionResult Index(string searchString)
        {
            var ordensServico = db.OrdensServico.Include(o => o.Pessoas);

            if (!string.IsNullOrEmpty(searchString))
            {
                ordensServico = ordensServico.Where(
                        x => x.Codigo.Contains(searchString) ||
                        x.Pessoas.Nome.ToUpper().Contains(searchString.ToUpper())
                );
            }

            return View(ordensServico.OrderByDescending(x => x.AberturaDataHora).ToList());
        }

        [AllowAnonymous]
        // GET: OrdemServico/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdensServico ordensServico = db.OrdensServico.Find(id);
            if (ordensServico == null)
            {
                return HttpNotFound();
            }
            return View(ordensServico);
        }


        public ActionResult DetailsPDF(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdensServico ordensServico = db.OrdensServico.Find(id);
            if (ordensServico == null)
            {
                return HttpNotFound();
            }
            return new Rotativa.ActionAsPdf("Details", new { id = id }) { FileName = "OrdemServico_" + ordensServico.Codigo.ToString() + ".pdf" };
        }

        // GET: OrdemServFinico/Create
        public ActionResult Create()
        {
            OrdemServicoCreate ordemServicoCreate = new OrdemServicoCreate();
            return View(ordemServicoCreate);
        }

        // POST: OrdemServico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrdemServicoID,AberturaDataHora,AberturaUsuarioID,FornecedorID,FornecedorNome,AssociadoID,AssociadoNome,ServicoID,ServicoNome,Valor,Observacao")] OrdemServicoCreate ordemServicoCreate)
        {
            ordemServicoCreate.OrdemServicoID = Guid.NewGuid();
            ordemServicoCreate.AberturaDataHora = DateTime.Now;
            ordemServicoCreate.AberturaUsuarioID = Guid.Parse(User.Identity.GetUserId().ToString());
            ordemServicoCreate.Encerrada = false;
            ordemServicoCreate.Codigo =
                System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString("d2") + "-" +
                (db.OrdensServico.Count() + 1).ToString("d7");


            if (ModelState.IsValid)
            {
                OrdensServico ordemServico = new OrdensServico();
                ordemServico.OrdemServicoID = ordemServicoCreate.OrdemServicoID;
                ordemServico.Codigo = ordemServicoCreate.Codigo;
                ordemServico.AberturaDataHora = ordemServicoCreate.AberturaDataHora;
                ordemServico.AberturaUsuarioID = ordemServicoCreate.AberturaUsuarioID;
                ordemServico.FornecedorID = ordemServicoCreate.FornecedorID;
                ordemServico.AssociadoID = ordemServicoCreate.AssociadoID;
                ordemServico.ServicoID = ordemServicoCreate.ServicoID;
                ordemServico.Valor = ordemServicoCreate.Valor;
                ordemServico.Observacao = ordemServicoCreate.Observacao;
                ordemServico.Encerrada = ordemServicoCreate.Encerrada;

                db.OrdensServico.Add(ordemServico);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = ordemServico.OrdemServicoID });
            }
            return View(ordemServicoCreate);
        }




        // GET: OrdemServico/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdensServico ordensServico = db.OrdensServico.Find(id);
            if (ordensServico == null)
            {
                return HttpNotFound();
            }

            return View(ordensServico);
        }

        // POST: OrdemServico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrdemServicoID,EmpresaID,Codigo,PessoaID,ClienteNome,Descricao,Combustivel,Cor,PrevisaoDeEntregaData,PrevisaoDeEntregaHora,Observacao,Placa,Marca,Modelo,Ano,KM,AberturaDataHora,OrdemServicoStatusID")] OrdensServico ordensServico)
        {

            if (ModelState.IsValid)
            {

                db.Entry(ordensServico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.PessoaID = new SelectList(db.Pessoas, "PessoaID", "Nome", ordensServico.PessoaID);
            //ViewBag.OrdemServicoStatusID = new SelectList(db.OrdemServicoStatus.OrderBy(x => x.Ordem), "OrdemServicoStatusID", "Nome", ordensServicoCreate.OrdemServicoStatusID);
            //ViewBag.OrdemServicoID = ordensServico.OrdemServicoID;
            return View(ordensServico);
        }



        // GET: OrdemServico/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdensServico ordensServico = db.OrdensServico.Find(id);
            if (ordensServico == null)
            {
                return HttpNotFound();
            }
            return View(ordensServico);
        }

        // POST: OrdemServico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            OrdensServico ordensServico = db.OrdensServico.Find(id);
            db.OrdensServico.Remove(ordensServico);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public JsonResult AutoCompleteAssociado(string term)
        {
            Pessoas[] matching = string.IsNullOrWhiteSpace(term) ?
            db.Pessoas.ToArray() :
            db.Pessoas.Where(p => p.Nome.ToUpper().Contains(term.ToUpper())).OrderBy(p => p.Nome).ToArray();

            return Json(matching.Select(m => new
            {
                id = m.PessoaID,
                value = m.Nome,
                label = m.Nome.ToString()
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutoCompleteFornecedor(string term)
        {
            Pessoas[] matching = string.IsNullOrWhiteSpace(term) ?
            db.Pessoas.ToArray() :
            db.Pessoas.Where(p => p.Nome.ToUpper().Contains(term.ToUpper())).OrderBy(p => p.Nome).ToArray();

            return Json(matching.Select(m => new
            {
                id = m.PessoaID,
                value = m.Nome,
                label = m.Nome.ToString()
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AutoCompleteServico(string term)
        {
            Servicos[] matching = string.IsNullOrWhiteSpace(term) ?
            db.Servicos.ToArray() :
            db.Servicos.Where(p => p.Nome.ToUpper().Contains(term.ToUpper())).OrderBy(p => p.Nome).ToArray();

            return Json(matching.Select(m => new
            {
                id = m.ServicoID,
                value = m.Nome,
                label = m.Nome.ToString()
            }), JsonRequestBehavior.AllowGet);
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
