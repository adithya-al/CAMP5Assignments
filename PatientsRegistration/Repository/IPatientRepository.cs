using PatientsRegistration.Models;

namespace PatientsRegistration.Repository
{
    public interface IPatientRepository
    {
        //List of All Patients
        IEnumerable<Patients> SelectAllPatients();

        //Add Patient
        void InsertPatient(Patients patient);
        //Get All membership
        List<Membership> SelectAllMembership();

        //5 - Edit and Update Patient
        void UpdatePatient(Patients patients);

        //6- Patient by  id
        Patients SelectPatientById(int? PatientId);
    }


}


