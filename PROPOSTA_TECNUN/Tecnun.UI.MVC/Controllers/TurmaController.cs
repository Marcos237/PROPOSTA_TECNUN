using System;
using System.Web.Mvc;
using Tecnun.Applications.Interfaces;
using Tecnun.Applications.Model;

namespace Tecnun.UI.MVC.Controllers
{
    public class TurmaController : Controller
    {
        // GET: Turma
        public const int PageSize = 5;

        private static Guid Turmaid;
        private static PagedViewModel<AlunoViewModel> _paged = new PagedViewModel<AlunoViewModel>();

        private readonly ITurmaAppService _turmaappservice;
        private readonly IProfessorAppService _professorAppService;
        private readonly IAlunoAppService _alunoappservice;

        public TurmaController(ITurmaAppService turmaappservice,  IProfessorAppService professorappservice, IAlunoAppService alunoappservice)
        {
            _turmaappservice = turmaappservice;
            _professorAppService = professorappservice;
            _alunoappservice = alunoappservice;
        }

        public ActionResult ListarTurma(string buscar, int pageNumber = 1)
        {
            var paged = _turmaappservice.ObterTodasTurmas(buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;
            ViewBag.Count = paged.Count;

            return View(paged.List);
        }

        public ActionResult AdicionarTurma()
        {
            return PartialView("_AdicionarTurmas");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarTurma(TurmaViewModel model)
        {
            if (ModelState.IsValid)
            {
                _turmaappservice.AdicionarTurma(model);

                if (!model.ValidationResult.IsValid)
                {
                    foreach (var erro in model.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return PartialView("_AdicionarTurmas", model);
                }

                string url = Url.Action("ListarTurma", "Turma", new { });
                return Json(new { success = true, url = url });
            }

            return PartialView("_AdicionarTurmas", model);
        }

        public ActionResult AtualizarTurma(Guid id)
        {
            var model = _turmaappservice.BuscarTurmaPorId(id);

            ViewBag.TurmaId = model.TurmaId;
            ViewBag._ProfessorId = model.ProfessorId;
            ViewBag.Periodo = model.PeriodoTurma;

            var nome = _professorAppService.BuscarProfessorPorId(model.ProfessorId);
            ViewBag.Nome = nome.Nome;
            return PartialView("_AtualizarTurmas", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarTurma(TurmaViewModel model)
        {
            if (ModelState.IsValid)
            {
                _turmaappservice.AtualizarTurma(model);
                string url = Url.Action("ListarTurma", "Turma", new { });
                return Json(new { success = true, url = url });
            }
            return PartialView("_AtualizarTurmas", model);
        }


        public ActionResult BuscarPeriodoTurma()
        {
            var retorno = _turmaappservice.BuscarPeridoTurma();

            return Json(new { retorno }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuscaTodosProfessores()
        {
            var retorno = _professorAppService.BuscarTodosProfessores();

            return Json(new { retorno }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BuscarTodosAlunos(Guid id, string buscar, int pageNumber = 1)
        {

            var paged = _alunoappservice.ObterTodosAlunos(buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;
            ViewBag.Count = paged.Count;

            _paged = paged;
            ViewBag.TurmaId = id;
            Turmaid = id;

            return PartialView("_BuscarAlunos", paged.List);
        }

        public ActionResult AdicionarAlunoTurma(Guid? id)
        {
            var model = new AlunoTurmaVieModel();

                model.AlunoId = id.Value;
                model.TurmaId = Turmaid;

                _turmaappservice.AdicionarAlunoTurma(model);

            if (!model.ValidationResult.IsValid)
            {
                foreach (var erro in model.ValidationResult.Erros)
                {
                   ModelState.AddModelError(string.Empty, erro.Message);
                }

                return RedirectToAction("ListarTurma", _paged.List);
            }

            return RedirectToAction("ListarTurma", _paged.List);
        }

        public ActionResult BuscarAlunoMatriculados(string buscar, int pageNumber = 1)
        {

            var paged = _turmaappservice.BuscarAlunoTurma(buscar, PageSize, pageNumber);
            ViewBag.TotalCount = Math.Ceiling((double)paged.Count / PageSize);
            ViewBag.PageNumber = pageNumber;
            ViewBag.SearchData = buscar;
            ViewBag.Count = paged.Count;

            return View("BuscarAlunoMatriculados", paged.List);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _turmaappservice.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
