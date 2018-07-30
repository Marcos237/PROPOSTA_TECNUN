using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tecnun.Applications.Interfaces;
using Tecnun.Applications.Model;

namespace Tecnun.UI.MVC.Controllers
{
    public class ProfessorController : Controller
    {
        // GET: Professor
        public const int PageSize = 5;

        private readonly IProfessorAppService _professorappservice;

        public ProfessorController(IProfessorAppService professorappservice)
        {
            _professorappservice = professorappservice;
        }

        public ActionResult ListarProfessores(string buscar, int pageNumber = 1)
        {
            var paged = _professorappservice.ObterTodosProfessores(buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;
            ViewBag.Count = paged.Count;

            return View(paged.List);
        }

        public ActionResult AdicionarProfessor()
        {
            return PartialView("_AdicionarProfessores");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarProfessor(ProfessorViewModel model)
        {
            if (ModelState.IsValid)
            {
                _professorappservice.AdicionarProfessor(model);

                if (!model.ValidationResult.IsValid)
                {
                    foreach (var erro in model.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return PartialView("_AdicionarProfessores", model);
                }

                string url = Url.Action("ListarProfessores", "Professor", new { });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarProfessores", model);
        }

        public ActionResult AtualizarProfessor(Guid id)
        {
            var model = _professorappservice.BuscarProfessorPorId(id);
            ViewBag.ProfessorId = model.ProfessorId;
            ViewBag.CPF = model.CPF;
            return PartialView("_AtualizarProfessores", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarProfessor(ProfessorViewModel model)
        {
            if (ModelState.IsValid)
            {
                _professorappservice.AtualizarProfessor(model);
                string url = Url.Action("ListarProfessores", "Professor", new { });
                return Json(new { success = true, url = url });
            }
            return PartialView("_AtualizarProfessores", model);
        }

        [HttpGet]
        public ActionResult DeletarProfessor(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (_professorappservice == null)
                return HttpNotFound();

            var professsor = _professorappservice.BuscarProfessorPorId(id.Value);

            return PartialView("_ExcluirProfessores", professsor);
        }

        [HttpPost, ActionName("DeletarProfessor")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarProfessorConfirmacao(Guid id)
        {
            var aluno = _professorappservice.BuscarProfessorPorId(id);
            _professorappservice.DeletarProfessor(id);

            string url = Url.Action("ListarProfessores", "Professor", new { });
            return Json(new { success = true, url = url });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _professorappservice.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
