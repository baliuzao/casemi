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
    public class PessoasController : Controller
    {
        private CasemiDesenvolvimentoEntities db = new CasemiDesenvolvimentoEntities();

        // GET: Pessoas
        public ActionResult Index()
        {
            var pessoas = db.Pessoas;
            return View(pessoas.ToList());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            Pessoas pessoas = new Pessoas();
            pessoas.Ativo = true;

            IEnumerable<SelectListItem> TipoPessoa = new List<SelectListItem>(){
                new SelectListItem() {Text="FISICA", Value="FISICA", Selected = string.Equals("FISICA", pessoas.TipoPessoa)},
                new SelectListItem() { Text="JURIDICA", Value="JURIDICA", Selected = string.Equals("JURICA", pessoas.TipoPessoa)}
            };

            ViewBag.TipoPessoa = TipoPessoa;

            return View(pessoas);
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoaID,TipoPessoa,Nome,Email,Observacao,Ativo,TipoPessoa")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                pessoas.PessoaID = Guid.NewGuid();
                db.Pessoas.Add(pessoas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            IEnumerable<SelectListItem> TipoPessoa = new List<SelectListItem>(){
                new SelectListItem() {Text="FISICA", Value="FISICA", Selected = string.Equals("FISICA", pessoas.TipoPessoa)},
                new SelectListItem() { Text="JURIDICA", Value="JURIDICA", Selected = string.Equals("JURICA", pessoas.TipoPessoa)}
            };

            ViewBag.TipoPessoa = TipoPessoa;

            return View(pessoas);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }

            IEnumerable<SelectListItem> TipoPessoa = new List<SelectListItem>(){
                new SelectListItem() {Text="FISICA", Value="FISICA", Selected = string.Equals("FISICA", pessoas.TipoPessoa)},
                new SelectListItem() { Text="JURIDICA", Value="JURIDICA", Selected = string.Equals("JURIDICA", pessoas.TipoPessoa)}
            };

            ViewBag.TipoPessoa = TipoPessoa;
            ViewBag.PessoaTipos = db.PessoaTipos.OrderBy(x => x.Nome).ToList();

            return View(pessoas);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaID,Nome,Email,Observacao,Ativo,TipoPessoa")] Pessoas pessoas)
        {
            IEnumerable<SelectListItem> TipoPessoa = new List<SelectListItem>(){
                new SelectListItem() {Text="FISICA", Value="FISICA", Selected = string.Equals("FISICA", pessoas.TipoPessoa)},
                new SelectListItem() { Text="JURIDICA", Value="JURIDICA", Selected = string.Equals("JURIDICA", pessoas.TipoPessoa)}
            };

            ViewBag.TipoPessoa = TipoPessoa;

            if (ModelState.IsValid)
            {
                db.Entry(pessoas).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Edit", new { id = pessoas.PessoaID});
            }

            
            return View(pessoas);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Pessoas pessoas = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // PessoaAssociado Get and Post
        //
        //
        public ActionResult PessoaAssociadoFormPartial(Guid pessoaID)
        {
            PessoaAssociado pessoaAssociado = db.PessoaAssociado.Find(pessoaID);

            if (pessoaAssociado == null)
            {
                pessoaAssociado = new PessoaAssociado();
                pessoaAssociado.PessoaID = pessoaID;
                pessoaAssociado.AssociadoDesde = DateTime.Now;
            }

            ViewBag.DepartamentoID = new SelectList(db.Departamentos.OrderBy(x => x.Nome).ToList(), "DepartamentoID", "Nome", pessoaAssociado.DepartamentoID);
            return PartialView("_PessoaAssociadoFormPartial", pessoaAssociado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PessoaAssociadoFormPartial([Bind(Include = "PessoaID,Matricula,DepartamentoID,Profissao,RendaMensal,LimiteDeCredito,AssociadoDesde,Aposentado,Afastado")] PessoaAssociado pessoaAssociado)
        {
            ViewBag.DepartamentoID = new SelectList(db.Departamentos.OrderBy(x => x.Nome).ToList(), "DepartamentoID", "Nome", pessoaAssociado.DepartamentoID);
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.PessoaAssociado.Where(x => x.PessoaID == pessoaAssociado.PessoaID).Count() == 0)
                    {
                        db.PessoaAssociado.Add(pessoaAssociado);
                        db.SaveChanges();
                        ModelState.AddModelError("Success", "Informações atualizadas!");
                    }
                    else
                    {
                        db.Entry(pessoaAssociado).State = EntityState.Modified;
                        db.SaveChanges();
                        ModelState.AddModelError("Success", "Informações atualizadas!");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "Preencha todas as informações necessárias!");
                }
                return PartialView("_PessoaAssociadoFormPartial", pessoaAssociado);
            }
            catch (Exception E)
            {
                ModelState.AddModelError("ErrorCustomized", "Error ao gravar! Preencha todas as informações necessárias corretamente!");
                ModelState.AddModelError("ErrorSystem", E.Message);
                return PartialView("_PessoaAssociadoFormPartial", pessoaAssociado);
            }
        }


        // PessoaFisica Get and Post
        //
        //
        public ActionResult PessoaFisicaFormPartial(Guid pessoaID)
        {
            PessoaFisica pessoaFisica = db.PessoaFisica.Find(pessoaID);

            if (pessoaFisica == null){
                pessoaFisica = new PessoaFisica();
                pessoaFisica.PessoaID = pessoaID;
            }

            IEnumerable<SelectListItem> Sexo = new List<SelectListItem>(){
                new SelectListItem() {Text="MASCULINO", Value="MASCULINO", Selected = string.Equals("MASCULINO", pessoaFisica.Sexo)},
                new SelectListItem() { Text="FEMININO", Value="FEMININO", Selected = string.Equals("FEMININO", pessoaFisica.Sexo)}
            };
            ViewBag.Sexo = Sexo;

            return PartialView("_PessoaFisicaFormPartial", pessoaFisica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PessoaFisicaFormPartial([Bind(Include = "PessoaID,CPF,Sexo,DataDeNascimento,Naturalidade,NomeDoPai,NomeDaMae")] PessoaFisica pessoaFisica)
        {
            IEnumerable<SelectListItem> Sexo = new List<SelectListItem>(){
                new SelectListItem() {Text="MASCULINO", Value="MASCULINO", Selected = string.Equals("MASCULINO", pessoaFisica.Sexo)},
                new SelectListItem() { Text="FEMININO", Value="FEMININO", Selected = string.Equals("FEMININO", pessoaFisica.Sexo)}
            };
            ViewBag.Sexo = Sexo;

            try
            {
                if (ModelState.IsValid)
                {
                    if (db.PessoaFisica.Where(x => x.PessoaID == pessoaFisica.PessoaID).Count() == 0)
                    {
                        db.PessoaFisica.Add(pessoaFisica);
                        db.SaveChanges();
                        ModelState.AddModelError("Success", "Informações atualizadas!");
                    }
                    else
                    {
                        db.Entry(pessoaFisica).State = EntityState.Modified;
                        db.SaveChanges();
                        ModelState.AddModelError("Success", "Informações atualizadas!");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error","Preencha todas as informações necessárias!");
                }
                return PartialView("_PessoaFisicaFormPartial", pessoaFisica);
            }
            catch (Exception E)
            {
                ModelState.AddModelError("ErrorCustomized", "Error ao gravar! Preencha todas as informações necessárias corretamente!");
                ModelState.AddModelError("ErrorSystem", E.Message);
                return PartialView("_PessoaFisicaFormPartial", pessoaFisica);
            }            
        }


        // PessoaJuridica Get and Post
        //
        //
        public ActionResult PessoaJuridicaFormPartial(Guid pessoaID)
        {
            PessoaJuridica pessoaJuridica = db.PessoaJuridica.Find(pessoaID);

            if (pessoaJuridica == null)
            {
                pessoaJuridica = new PessoaJuridica();
                pessoaJuridica.PessoaID = pessoaID;
            }

            return PartialView("_PessoaJuridicaFormPartial", pessoaJuridica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PessoaJuridicaFormPartial([Bind(Include = "PessoaID,CNPJ,InscricaoMunicipal,InscricaoEstadua")] PessoaJuridica pessoaJuridica)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.PessoaJuridica.Where(x => x.PessoaID == pessoaJuridica.PessoaID).Count() == 0)
                    {
                        db.PessoaJuridica.Add(pessoaJuridica);
                        db.SaveChanges();
                        ModelState.AddModelError("Success", "Informações atualizadas!");
                    }
                    else
                    {
                        db.Entry(pessoaJuridica).State = EntityState.Modified;
                        db.SaveChanges();
                        ModelState.AddModelError("Success", "Informações atualizadas!");
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "Preencha todas as informações necessárias!");
                }
                return PartialView("_PessoaJuridicaFormPartial", pessoaJuridica);
            }
            catch (Exception E)
            {
                ModelState.AddModelError("ErrorCustomized", "Error ao gravar! Preencha todas as informações necessárias corretamente!");
                ModelState.AddModelError("ErrorSystem", E.Message);
                return PartialView("_PessoaJuridicaFormPartial", pessoaJuridica);
            }
        }

        public ActionResult PerfilRelacionamentoPartial(Guid pessoaID)
        {
            var pessoaPessoaTipos = db.PessoasPessoaTipos.Where(x => x.PessoaID == pessoaID);
            ViewBag.PessoaTipos = db.PessoaTipos.OrderBy(x => x.Nome).ToList();
            ViewBag.PessoaID = pessoaID;

            return PartialView("_PerfilRelacionamentoPartial", pessoaPessoaTipos.ToList());
        }

        public ActionResult PerfilRelacionamentoAlteraPerfil(Guid pessoaID, Guid pessoaTipoID)
        {
            Pessoas pessoa = db.Pessoas.Find(pessoaID);
            if (pessoa == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (pessoaTipoID != null)
            {
                PessoasPessoaTipos pessoaPessoaTipo = db.PessoasPessoaTipos.Where(x => x.PessoaID == pessoaID && x.PessoaTipoID == pessoaTipoID).FirstOrDefault();

                if (pessoaPessoaTipo != null)
                {
                    db.PessoasPessoaTipos.Remove(pessoaPessoaTipo);
                    db.SaveChanges();
                }
                else
                {
                    pessoaPessoaTipo = new PessoasPessoaTipos();
                    pessoaPessoaTipo.PessoaPessoaTipoID = Guid.NewGuid();
                    pessoaPessoaTipo.PessoaID = pessoaID;
                    pessoaPessoaTipo.PessoaTipoID = pessoaTipoID;
                    db.PessoasPessoaTipos.Add(pessoaPessoaTipo);
                    db.SaveChanges();

                    if (db.PessoaTipos.Find(pessoaTipoID).Nome.ToUpper() == "ASSOCIADO")
                    {
                        if (db.PessoaAssociado.Where(x => x.PessoaID == pessoaID).Count() == 0)
                        {
                            PessoaAssociado pessoaAssociado = new PessoaAssociado();
                            pessoaAssociado.PessoaID = pessoaPessoaTipo.PessoaID;
                            pessoaAssociado.Matricula = (db.PessoasPessoaTipos.Where(x => x.PessoaTipos.Nome.ToUpper() == "ASSOCIADO").Count() + 1).ToString();
                            pessoaAssociado.AssociadoDesde = DateTime.Now.Date;

                            db.PessoaAssociado.Add(pessoaAssociado);
                            db.SaveChanges();
                            ModelState.AddModelError("Success", "Informações atualizadas!");
                        }
                        //else
                        //{
                        //    db.Entry(pessoaAssociado).State = EntityState.Modified;
                        //    db.SaveChanges();
                        //    ModelState.AddModelError("Success", "Informações atualizadas!");
                        //}
                    }

                }
            }

            //var pessoaPessoaTipos = db.PessoasPessoaTipos.Where(x => x.PessoaID == pessoaID);
            //ViewBag.PessoaTipos = db.PessoaTipos.OrderBy(x => x.Nome).ToList();
            //ViewBag.PessoaID = pessoaID;

            return RedirectToAction("Edit", new { id = pessoaID });
        }


        public ActionResult PessoaDependentesListaPartial(Guid pessoaID)
        {
            var pessoaDependentes = db.PessoaDependentes.Include(x => x.DependenteTipos).Where(x => x.PessoaID == pessoaID).OrderBy(x => x.Nome);
            ViewBag.PessoaID = pessoaID;
            return PartialView("_PessoaDependentesListaPartial", pessoaDependentes.ToList());
        }

        public ActionResult PessoaDependentesCreatePartial(Guid pessoaID)
        {
            PessoaDependentes pessoaDependentes = new PessoaDependentes();
            pessoaDependentes.PessoaDependenteID = Guid.NewGuid();
            pessoaDependentes.PessoaID = pessoaID;
            pessoaDependentes.DataDeNascimento = DateTime.Now.Date;
            pessoaDependentes.AssociadoDesde = DateTime.Now.Date;
            pessoaDependentes.Ativo = true;

            ViewBag.DependenteTipoID = new SelectList(db.DependenteTipos.OrderBy(x => x.Nome), "DependenteTipoID", "Nome", pessoaDependentes.DependenteTipoID);
            return PartialView("_PessoaDependentesCreatePartial", pessoaDependentes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PessoaDependentesCreatePartial([Bind(Include = "PessoaDependenteID,PessoaID,Nome,DataDeNascimento,DependenteTipoID,AssociadoDesde,Observacao,Ativo")] PessoaDependentes pessoaDependentes)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.PessoaDependentes.Add(pessoaDependentes);
                    db.SaveChanges();

                    string url = Url.Action("PessoaDependentesListaPartial", "Pessoas", new { pessoaID = pessoaDependentes.PessoaID });
                    return Json(new { success = true, url = url });
                }

                ModelState.AddModelError("Error", "Preencha todas as informações necessárias!");
                ViewBag.DependenteTipoID = new SelectList(db.DependenteTipos.OrderBy(x => x.Nome), "DependenteTipoID", "Nome", pessoaDependentes.DependenteTipoID);
                return PartialView("_PessoaDependentesCreatePartial", pessoaDependentes);
            }
            catch (Exception E)
            {
                ModelState.AddModelError("ErrorCustomized", "Error ao gravar! Preencha todas as informações necessárias corretamente!");
                ModelState.AddModelError("ErrorSystem", E.Message);
                ViewBag.DependenteTipoID = new SelectList(db.DependenteTipos.OrderBy(x => x.Nome), "DependenteTipoID", "Nome", pessoaDependentes.DependenteTipoID);
                return PartialView("_PessoaDependentesCreatePartial", pessoaDependentes);
            }
            
        }

        public ActionResult PessoaDependentesEditPartial(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaDependentes pessoaDependentes = db.PessoaDependentes.Find(id);
            if (pessoaDependentes == null)
            {
                return HttpNotFound();
            }

            ViewBag.DependenteTipoID = new SelectList(db.DependenteTipos.OrderBy(x => x.Nome), "DependenteTipoID", "Nome", pessoaDependentes.DependenteTipoID);
            return PartialView("_PessoaDependentesEditPartial", pessoaDependentes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PessoaDependentesEditPartial([Bind(Include = "PessoaDependenteID,PessoaID,Nome,DataDeNascimento,DependenteTipoID,AssociadoDesde,Observacao,Ativo")] PessoaDependentes pessoaDependentes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoaDependentes).State = EntityState.Modified;
                db.SaveChanges();
                string url = Url.Action("PessoaDependentesListaPartial", "Pessoas", new { pessoaID = pessoaDependentes.PessoaID });
                return Json(new { success = true, url = url });
            }
            ViewBag.DependenteTipoID = new SelectList(db.DependenteTipos.OrderBy(x => x.Nome), "DependenteTipoID", "Nome", pessoaDependentes.DependenteTipoID);
            return PartialView("_PessoaDependentesEditPartial", pessoaDependentes);
        }


        public ActionResult PessoaDependentesDeletePartial(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaDependentes pessoaDependentes = db.PessoaDependentes.Find(id);

            if (pessoaDependentes == null)
            {
                return HttpNotFound();
            }

            return PartialView("_PessoaDependentesDeletePartial", pessoaDependentes);
        }

        // POST: PessoaTelefones/Delete/5
        [HttpPost, ActionName("PessoaDependentesDeletePartial")]
        [ValidateAntiForgeryToken]
        public ActionResult PessoaDependentesDeleteConfirmed(Guid id)
        {
            PessoaDependentes pessoaDependentes = db.PessoaDependentes.Find(id);
            db.PessoaDependentes.Remove(pessoaDependentes);
            db.SaveChanges();

            string url = Url.Action("PessoaDependentesListaPartial", "Pessoas", new { pessoaID = pessoaDependentes.PessoaID });
            return Json(new { success = true, url = url });
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
