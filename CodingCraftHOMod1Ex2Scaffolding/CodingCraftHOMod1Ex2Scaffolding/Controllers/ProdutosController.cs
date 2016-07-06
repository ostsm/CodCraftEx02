using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CodingCraftHOMod1Ex2Scaffolding.Models;

namespace CodingCraftHOMod1Ex2Scaffolding.Controllers
{
    public class ProdutosController : Controller
    {
        private CodingCraftHOMod1Ex2ScaffoldingContext context = new CodingCraftHOMod1Ex2ScaffoldingContext();

        //
        // GET: /Produtoes/

        public ViewResult Index()
        {
            return View(context.Produtos.ToList());
        }

        //
        // GET: /Produtoes/Details/5

        public ViewResult Details(long id)
        {
            Produto produto = context.Produtos.Single(x => x.ProdutoId == id);
            return View(produto);
        }

        //
        // GET: /Produtoes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Produtoes/Create

        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(produto);
        }
        
        //
        // GET: /Produtoes/Edit/5
 
        public ActionResult Edit(long id)
        {
            Produto produto = context.Produtos.Single(x => x.ProdutoId == id);
            return View(produto);
        }

        //
        // POST: /Produtoes/Edit/5

        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                context.Entry(produto).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        //
        // GET: /Produtoes/Delete/5
 
        public ActionResult Delete(long id)
        {
            Produto produto = context.Produtos.Single(x => x.ProdutoId == id);
            return View(produto);
        }

        //
        // POST: /Produtoes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Produto produto = context.Produtos.Single(x => x.ProdutoId == id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}