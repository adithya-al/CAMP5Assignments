using ProfessorList.Models;

namespace ProfessorList.Repository
{
    public interface IProfessorRepository
    {
        //List all Professor
        IEnumerable<Professor> SelectAllProfessor();

        //Add Patient
        void InsertProfessor(Professor professor);
        //Get All membership
        List<Department> SelectAllDepartment();
        //Search Professor By ID
        Professor SelectProfessorById(int? ProfessorId);
        //Edit Professor
        void UpdateProfessor(Professor professor);

    }
}

