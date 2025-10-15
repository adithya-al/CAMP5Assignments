using Microsoft.AspNetCore.Mvc;
using PatientsRegistration.Service;
using PatientsRegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PatientsRegistration.Controllers
{
    public class PatientController: Controller
    {
        private readonly IPatientService _patientService;

        //DI
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        
        public IActionResult List()
        {
            //List All Patients
            List<Patients> patients = _patientService.GetAllPatients().ToList();
            return View(patients);
        }
        #region 2 Get - Displlay for Insert
        public IActionResult Create()
        {
            
            ViewBag.Memberships = _patientService.GetAllMembership();
            return View();
        }
        #endregion

        #region 2.POST --- Inserting new Record (Create)
        [HttpPost]
        public IActionResult Create([Bind] Patients patients)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _patientService.AddPatient(patients);
                }
                return RedirectToAction("List");
            }
            catch
            {
                return View(patients);
            }
           
        }

        #endregion
        #region GET - Display for Update 
        [HttpGet]
        public IActionResult Edit(int PatientId)
        {
            ViewBag.Memberships = _patientService.GetAllMembership();
            Patients patients = _patientService.GetPatientById(PatientId);
            return View(patients);
        }

        #endregion
        #region Update an Patient

        [HttpPost]
        public IActionResult Edit([Bind] int PatientId, Patients patients)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _patientService.EditAndUpdatePatient(patients);
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

