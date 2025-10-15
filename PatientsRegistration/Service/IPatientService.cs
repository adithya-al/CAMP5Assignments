using PatientsRegistration.Models;

namespace PatientsRegistration.Service
{
    public interface IPatientService
    {
        //List of Patients
        IEnumerable<Patients> GetAllPatients();
        //List of Memberships
        List<Membership> GetAllMembership();

        //Add Patient
        void AddPatient(Patients patient);

        //Edit Patient
        void EditAndUpdatePatient(Patients patients);

        //Get Patient By Id
        Patients GetPatientById(int? PatientId);

    }
}

