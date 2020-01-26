
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectSchoolApi.Models;

namespace ProjectSchoolApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Professor>()
            .HasData(new List<Professor> {
                new Professor() { Id = 1, Nome = "Alisson" },
                new Professor() { Id = 2, Nome = "Fernando" },
                new Professor() { Id = 3, Nome = "Paola" },
            });

            builder.Entity<Aluno>()
            .HasData(new List<Aluno> {
                new Aluno() { Id = 1, Nome = "José", Sobrenome = "da Silva", DataNasc = "01/01/2000", ProfessorId = 1 },
                new Aluno() { Id = 2, Nome = "João", Sobrenome = "Beloti", DataNasc = "11/12/1978", ProfessorId = 2 },
                new Aluno() { Id = 3, Nome = "Alex", Sobrenome = "Beluci", DataNasc = "07/08/1986", ProfessorId = 3 },
            });
        }
    }
}