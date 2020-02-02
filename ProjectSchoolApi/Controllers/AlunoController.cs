using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchoolApi.Data;
using ProjectSchoolApi.Models;

namespace ProjectSchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        public IRepository Repo { get; }
        public AlunoController(IRepository repo)
        {
            this.Repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await Repo.GetAllAlunosAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpGet("{AlunoId}")]
        public async Task<IActionResult> Get(int alunoId)
        {
            try
            {
                var result = await Repo.GetAlunoAsyncById(alunoId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpGet("ByProfessor/{ProfessorId}")]
        public async Task<IActionResult> GetByProfessorId(int professorId)
        {
            try
            {
                var result = await Repo.GetAlunosAsyncByProfessorId(professorId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno aluno)
        {
            try
            {
                Repo.Add(aluno);
                if (await Repo.SaveChangesAsync())
                {
                    return Created($"/Aluno/{aluno.Id}", aluno);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }

        }
        [HttpPut("{AlunoId}")]
        public async Task<IActionResult> Put(int alunoId, Aluno aluno)
        {
            try
            {
                var alunoBd = await Repo.GetAlunoAsyncById(alunoId, false);
                if (alunoBd != null)
                {
                    Repo.Update(aluno);
                    if (await Repo.SaveChangesAsync())
                    {
                        alunoBd = await Repo.GetAlunoAsyncById(alunoId, true);
                        return Created($"/Aluno/{aluno.Id}", alunoBd);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound();
                }

            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }
        [HttpDelete("{AlunoId}")]
        public async Task<IActionResult> Delete(int alunoId)
        {
            try
            {
                var alunoBd = await Repo.GetAlunoAsyncById(alunoId, false);
                if (alunoBd != null)
                {
                    Repo.Delete(alunoBd);
                    if (await Repo.SaveChangesAsync())
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }
    }
}