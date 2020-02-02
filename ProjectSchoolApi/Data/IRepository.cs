using System.Threading.Tasks;
using ProjectSchoolApi.Models;

namespace ProjectSchoolApi.Data
{
    public interface IRepository
    {
        ///Geral
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //Aluno
        Task<Aluno[]> GetAllAlunosAsync(bool incluirProfessor);
        Task<Aluno> GetAlunoAsyncById(int id, bool incluirProfessor);
        Task<Aluno[]> GetAlunosAsyncByProfessorId(int professorId, bool incluirProfessor);
        //Professor
        Task<Professor[]> GetAllProfessoresAsync(bool incluirAlunos);
        Task<Professor> GetProfessorAsyncById(int id, bool incluirAlunos);
    }
}