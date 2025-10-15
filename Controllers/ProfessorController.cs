using Microsoft.AspNetCore.Mvc;
using ProfessorList.Models;
using ProfessorList.Service;

namespace ProfessorList.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorService _professorService;

        //DI
        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }
        public IActionResult List()
        {
            //List All professor
            List<Professor> professors = _professorService.GetAllProfessors().ToList();
            return View(professors);
        }

        #region 2 Get - Displlay for Insert
        public IActionResult Create()
        {

            ViewBag.Departments = _professorService.GetAllDepartments();
            return View();
        }
        #endregion

        #region 2.POST --- Inserting new Record (Create)
        [HttpPost]
        public IActionResult Create([Bind] Professor professor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _professorService.AddProfessor(professor);
                }
                return RedirectToAction("List");
            }
            catch
            {
                return View(professor);
            }

        }

        #endregion

        #region GET - Display for Update 
        [HttpGet]
        public IActionResult Edit(int ProfessorId)
        {
            ViewBag.Departments = _professorService.GetAllDepartments();
            Professor professor = _professorService.GetProfessorById(ProfessorId);
            return View(professor);
        }
        #endregion

        #region  --Updating an Professor --2 Update

        [HttpPost]
        public IActionResult Edit([Bind] int ProfessorId, Professor professor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _professorService.EditAndUpdateProfessor(professor);
                }
                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        #endregion

    }
}





