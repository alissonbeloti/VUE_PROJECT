using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSchoolApi.Data;
using ProjectSchoolApi.Models;

namespace ProjectSchoolApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository Repo;

        public ProfessorController(IRepository repo)
        {
            this.Repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await Repo.GetAllProfessoresAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> Get(int professorId)
        {
            try
            {
                var result = await Repo.GetProfessorAsyncById(professorId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou!");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Professor professor)
        {
            try
            {
                Repo.Add(professor);
                if (await Repo.SaveChangesAsync())
                {
                    return Created($"/Professor/{professor.Id}", professor);
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
        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> Put(int professorId, Professor professor)
        {
            try
            {
                var professorBd = await Repo.GetProfessorAsyncById(professorId, false);
                if (professorBd != null)
                {
                    Repo.Update(professor);
                    if (await Repo.SaveChangesAsync())
                    {
                        professorBd = await Repo.GetProfessorAsyncById(professorId, true);
                        return Created($"/Professor/{professor.Id}", professorBd);
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
        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> Delete(int professorId)
        {
            try
            {
                var professorBd = await Repo.GetProfessorAsyncById(professorId, false);
                if (professorBd != null)
                {
                    Repo.Delete(professorBd);
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