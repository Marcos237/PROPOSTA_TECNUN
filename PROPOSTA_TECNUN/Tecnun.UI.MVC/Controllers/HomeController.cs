using System;
using System.Net;
using System.Web.Mvc;
using Tecnun.Applications.Interfaces;
using Tecnun.Applications.Model;

namespace Tecnun.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        public const int PageSize = 5;

        private readonly IAlunoAppService _alunoappservice;

        public HomeController(IAlunoAppService alunoappservice)
        {
            _alunoappservice = alunoappservice;
        }

        public ActionResult Index(string buscar, int pageNumber = 1)
        {
            var paged = _alunoappservice.ObterTodosAlunos(buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;
            ViewBag.Count = paged.Count;

            return View(paged.List);
        }

        public ActionResult AdicionarAluno()
        {
            return PartialView("_AdicionarAlunos");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarAluno(AlunoViewModel model)
        {
            if (ModelState.IsValid)
            {
                _alunoappservice.AdicionarAluno(model);

                if (!model.ValidationResult.IsValid)
                {
                    foreach (var erro in model.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return PartialView("_AdicionarAlunos", model);
                }

                string url = Url.Action("Index", "Home", new { });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarAlunos", model);
        }

        public ActionResult AtualizarAluno(Guid id)
        {
            var model = _alunoappservice.BuscarAlunoPorId(id);
            ViewBag.AlunoId = model.AlunoId;
            ViewBag.CPF = model.CPF;
            return PartialView("_AtualizarAluno", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarAluno(AlunoViewModel model)
        {
            if (ModelState.IsValid)
            {
                _alunoappservice.AtualizarAluno(model);
                string url = Url.Action("Index", "Home", new { });
                return Json(new { success = true, url = url });
            }
            return PartialView("_AtualizarAluno", model);
        }

        [HttpGet]
        public ActionResult DeletarAluno(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (_alunoappservice == null)
                return HttpNotFound();

            var aluno = _alunoappservice.BuscarAlunoPorId(id.Value);

            return PartialView("_ExcluirAluno", aluno);
        }

        [HttpPost, ActionName("DeletarAluno")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarAlunoConfirmacao(Guid id)
        {
            var aluno = _alunoappservice.BuscarAlunoPorId(id);
            _alunoappservice.DeletarAluno(id);

            string url = Url.Action("Index", "Home");
            return Json(new { success = true, url = url });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _alunoappservice.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}