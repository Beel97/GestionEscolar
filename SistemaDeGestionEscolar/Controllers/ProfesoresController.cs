using SistemaDeGestionEscolar.Services;
using SistemaDeGestionEscolar.Models;

using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Profesores;
using Microsoft.AspNetCore.Cors;

namespace SistemaDeGestionEscolar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]

    public class ProfesoresController : ControllerBase
    {
        private readonly ProfesorServices _profesoresService;

        public ProfesoresController(ProfesorServices profesoresServices) =>
            _profesoresService = profesoresServices;


        [HttpGet("get-profesores")]
        public async Task<List<Profesores.Profesores>> Get() =>
        await _profesoresService.GetAsync();

        [HttpGet("get-profesor/{id:length(24)}")]
        public async Task<ActionResult<Profesores.Profesores>> Get(string id)
        {
            var book = await _profesoresService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost("add-profesor")]
        public async Task<IActionResult> Post(Profesores.Profesores newProfesor)
        {
            await _profesoresService.CreateAsync(newProfesor);

            return CreatedAtAction(nameof(Get), new { id = newProfesor.Id_profesor }, newProfesor);
        }

        [HttpPut("update-profesor/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Profesores.Profesores updatedProfesor)
        {
            var profesor = await _profesoresService.GetAsync(id);

            if (profesor is null)
            {
                return NotFound();
            }

            updatedProfesor.Id_profesor = profesor.Id_profesor;

            await _profesoresService.UpdateAsync(id, updatedProfesor);

            return Ok("Profesor " + profesor.Apellidos_profesor + profesor.Nombre_profesor + " modificado correctamente");
        }

        [HttpDelete("delete-profesor/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var profesor = await _profesoresService.GetAsync(id);

            if (profesor is null)
            {
                return NotFound();
            }

            await _profesoresService.RemoveAsync(id);

            return Ok("Profesor " + profesor.Apellidos_profesor + profesor.Nombre_profesor + " eliminado");

        }
    }
}
