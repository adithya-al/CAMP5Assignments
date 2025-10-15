using ProfessorList.Models;
using ProfessorList.Repository;

namespace ProfessorList.Service
{
    public class ProfessorServiceImpl:IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        //DI
        public ProfessorServiceImpl(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public IEnumerable<Professor> GetAllProfessors()
        {
            return _professorRepository.SelectAllProfessor();
        }

        //Add Professor
        public void AddProfessor(Professor professor)
        {
            _professorRepository.InsertProfessor(professor);
        }

        public List<Department> GetAllDepartments()
        {
            return _professorRepository.SelectAllDepartment();
        }

        public Professor GetProfessorById(int? ProfessorId)
        {
            return _professorRepository.SelectProfessorById(ProfessorId);
        }

        public void EditAndUpdateProfessor(Professor professor)
        {
            _professorRepository.UpdateProfessor(professor);
        }
    }
}

