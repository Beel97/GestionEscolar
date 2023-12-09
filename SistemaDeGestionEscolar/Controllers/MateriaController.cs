using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionEscolar.Models;
using SistemaDeGestionEscolar.Services;

namespace SistemaDeGestionEscolar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]

    public class MateriaController : Controller
    {
        private readonly MateriaServices _materiasService;

        public MateriaController(MateriaServices materiaServices) =>
            _materiasService = materiaServices;


        [HttpGet("get-materias")]
        public async Task<List<Materias>> Get() =>
        await _materiasService.GetAsync();

        [HttpGet("get-materia/{id:length(24)}")]
        public async Task<ActionResult<Materias>> Get(string id)
        {
            var book = await _materiasService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost("add-materia")]
        public async Task<IActionResult> Post(Materias newMateria)
        {
            await _materiasService.CreateAsync(newMateria);

            return CreatedAtAction(nameof(Get), new { id = newMateria.Id_materia }, newMateria);
        }

        [HttpPut("update-materia/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Materias updatedMateria)
        {
            var materia = await _materiasService.GetAsync(id);

            if (materia is null)
            {
                return NotFound();
            }

            updatedMateria.Id_materia = materia.Id_materia;

            await _materiasService.UpdateAsync(id, updatedMateria);

            return Ok("materia " + materia.Nombre_materia + " modificada correctamente");
        }

        [HttpDelete("delete-materia/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var materia = await _materiasService.GetAsync(id);

            if (materia is null)
            {
                return NotFound();
            }

            await _materiasService.RemoveAsync(id);

            return Ok("materia " + materia.Nombre_materia + " eliminada");

        }
    }
}
