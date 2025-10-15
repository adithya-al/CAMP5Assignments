using ProfessorList.Models;

namespace ProfessorList.Service
{
    public interface IProfessorService
    {
        //List Professor
        IEnumerable<Professor> GetAllProfessors();

        //List of DEpartmenets
        List<Department> GetAllDepartments();
        //Add Professor
        void AddProfessor(Professor professor);
        //Get Professor By Id
        Professor GetProfessorById(int? ProfessorId);
        //Edit and Upate Professor
        void EditAndUpdateProfessor(Professor professor);

    }
}


