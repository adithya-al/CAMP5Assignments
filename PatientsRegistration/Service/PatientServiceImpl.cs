using PatientsRegistration.Models;
using PatientsRegistration.Repository;


namespace PatientsRegistration.Service
{
    public class PatientServiceImpl : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        //DI
        public PatientServiceImpl(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
       
        public IEnumerable<Patients> GetAllPatients()
        {
            return _patientRepository.SelectAllPatients();
        }

        //Add Patient
        public void AddPatient(Patients patient)
        {
            _patientRepository.InsertPatient(patient);
        }

       public List<Membership>GetAllMembership()
        {
            return _patientRepository.SelectAllMembership().ToList();
        }

        public void EditAndUpdatePatient(Patients patients)
        {
            _patientRepository.UpdatePatient(patients);
        }

        public Patients GetPatientById(int? PatientId)
        {
            return _patientRepository.SelectPatientById(PatientId);
        }

    }
}

