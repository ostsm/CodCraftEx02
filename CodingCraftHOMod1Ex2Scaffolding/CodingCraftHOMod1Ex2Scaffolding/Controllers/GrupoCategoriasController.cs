using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodingCraftHOMod1Ex2Scaffolding.Models;

namespace CodingCraftHOMod1Ex2Scaffolding.Controllers
{
    public class GrupoCategoriasController : Controller
    {
        private CodingCraftHOMod1Ex2ScaffoldingContext db = new CodingCraftHOMod1Ex2ScaffoldingContext();

        // GET: GrupoCategorias
        public async Task<ActionResult> Index()
        {
            return View(await db.GrupoCategorias.ToListAsync());
        }

        // GET: GrupoCategorias/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoCategoria grupoCategoria = await db.GrupoCategorias.FindAsync(id);
            if (grupoCategoria == null)
            {
                return HttpNotFound();
            }
            return View(grupoCategoria);
        }

        // GET: GrupoCategorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoCategorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GrupoCategoriaId,NomeGrupoCategoria")] GrupoCategoria grupoCategoria)
        {
            if (ModelState.IsValid)
            {
                db.GrupoCategorias.Add(grupoCategoria);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(grupoCategoria);
        }

        // GET: GrupoCategorias/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoCategoria grupoCategoria = await db.GrupoCategorias.FindAsync(id);
            if (grupoCategoria == null)
            {
                return HttpNotFound();
            }
            return View(grupoCategoria);
        }

        // POST: GrupoCategorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GrupoCategoriaId,NomeGrupoCategoria")] GrupoCategoria grupoCategoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoCategoria).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(grupoCategoria);
        }

        // GET: GrupoCategorias/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoCategoria grupoCategoria = await db.GrupoCategorias.FindAsync(id);
            if (grupoCategoria == null)
            {
                return HttpNotFound();
            }
            return View(grupoCategoria);
        }

        // POST: GrupoCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            GrupoCategoria grupoCategoria = await db.GrupoCategorias.FindAsync(id);
            db.GrupoCategorias.Remove(grupoCategoria);
            await db.SaveChangesAsync();
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
