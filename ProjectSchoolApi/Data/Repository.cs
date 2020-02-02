using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchoolApi.Models;

namespace ProjectSchoolApi.Data
{
    public class Repository : IRepository
    {
        public DataContext Context { get; }
        public Repository(DataContext context)
        {
            this.Context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            Context.Update(entity);
        }
        //Aluno
        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync() > 0);
        }

        public async Task<Aluno[]> GetAllAlunosAsync(bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = Context.Alunos.AsQueryable();
            if (incluirProfessor)
            {
                query = query.Include(a => a.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoAsyncById(int id, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = Context.Alunos.Where(a => a.Id == id);
            if (incluirProfessor)
            {
                query = query.Include(a => a.Professor);
            }
            query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetAlunosAsyncByProfessorId(int professorId, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = Context.Alunos.Where(a => a.ProfessorId == professorId).AsQueryable();
            if (incluirProfessor)
            {
                query = query.Include(a => a.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            return await query.ToArrayAsync();
        }
        //Professor
        public async Task<Professor[]> GetAllProfessoresAsync(bool incluirAlunos = false)
        {
            IQueryable<Professor> query = Context.Professores.AsQueryable();
            if (incluirAlunos)
            {
                query = query.Include(p => p.Alunos);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorAsyncById(int id, bool incluirAlunos = false)
        {
            IQueryable<Professor> query = Context.Professores.Where(p => p.Id == id);
            if (incluirAlunos)
            {
                query = query.Include(p => p.Alunos);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
    }
}