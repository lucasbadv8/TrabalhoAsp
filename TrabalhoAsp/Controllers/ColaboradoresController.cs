using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TrabalhoAsp.Models;
using TrabalhoAsp.Models.Contexto;

namespace TrabalhoAsp.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly TrabalhoAspContext db = new TrabalhoAspContext();
        public ActionResult Index()
        {
            return View(db.Colaboradores.ToList());
        }
        public ActionResult Detalhes(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "Id,Nome,Sobrenome,Titulo,Cidade,Estado")] Colaboradores colaboradores)
        {
            if (!ModelState.IsValid) return View(colaboradores);
            db.Colaboradores.Add(colaboradores);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Alterar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar([Bind(Include = "Id,Nome,Sobrenome,Titulo,Cidade,Estado")] Colaboradores colaboradores)
        {
            if (!ModelState.IsValid) return View(colaboradores);
            db.Entry(colaboradores).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Excluir(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var colaboradores = db.Colaboradores.Find(id);
            if (colaboradores == null)
            {
                return HttpNotFound();
            }
            return View(colaboradores);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var colaboradores = db.Colaboradores.Find(id);
            db.Colaboradores.Remove(colaboradores);
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
