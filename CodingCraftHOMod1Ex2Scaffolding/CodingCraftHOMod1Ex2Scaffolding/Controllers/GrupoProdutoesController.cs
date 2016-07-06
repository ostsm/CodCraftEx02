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
    public class GrupoProdutoesController : Controller
    {
        private CodingCraftHOMod1Ex2ScaffoldingContext db = new CodingCraftHOMod1Ex2ScaffoldingContext();

        // GET: GrupoProdutoes
        public async Task<ActionResult> Index()
        {
            return View(await db.GrupoProdutos.ToListAsync());
        }

        // GET: GrupoProdutoes/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoProduto grupoProduto = await db.GrupoProdutos.FindAsync(id);
            if (grupoProduto == null)
            {
                return HttpNotFound();
            }
            return View(grupoProduto);
        }

        // GET: GrupoProdutoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoProdutoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GrupoProdutoId,NomeGrupoProduto")] GrupoProduto grupoProduto)
        {
            if (ModelState.IsValid)
            {
                db.GrupoProdutos.Add(grupoProduto);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(grupoProduto);
        }

        // GET: GrupoProdutoes/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoProduto grupoProduto = await db.GrupoProdutos.FindAsync(id);
            if (grupoProduto == null)
            {
                return HttpNotFound();
            }
            return View(grupoProduto);
        }

        // POST: GrupoProdutoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GrupoProdutoId,NomeGrupoProduto")] GrupoProduto grupoProduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoProduto).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(grupoProduto);
        }

        // GET: GrupoProdutoes/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoProduto grupoProduto = await db.GrupoProdutos.FindAsync(id);
            if (grupoProduto == null)
            {
                return HttpNotFound();
            }
            return View(grupoProduto);
        }

        // POST: GrupoProdutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            GrupoProduto grupoProduto = await db.GrupoProdutos.FindAsync(id);
            db.GrupoProdutos.Remove(grupoProduto);
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
