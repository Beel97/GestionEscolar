using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionEscolar.Models;
using SistemaDeGestionEscolar.Services;

namespace SistemaDeGestionEscolar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]

    public class CalificacionController : Controller
    {
        private readonly CalificacionesServices _calificacionesService;

        public CalificacionController(CalificacionesServices calificacionesServices) =>
            _calificacionesService = calificacionesServices;


        [HttpGet("get-calificaciones")]
        public async Task<List<Calificaciones>> Get() =>
        await _calificacionesService.GetAsync();

        [HttpGet("get-calificacion/{id:length(24)}")]
        public async Task<ActionResult<Calificaciones>> Get(string id)
        {
            var calificacion = await _calificacionesService.GetAsync(id);

            if (calificacion is null)
            {
                return NotFound();
            }

            return calificacion;
        }

        [HttpPost("add-calificacion")]
        public async Task<IActionResult> Post(Calificaciones newCalificacion)
        {
            await _calificacionesService.CreateAsync(newCalificacion);

            return CreatedAtAction(nameof(Get), new { id = newCalificacion.Id_calificacion }, newCalificacion);
        }

        [HttpPut("update-calificacion/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Calificaciones updateCalificacion)
        {
            var calificacion = await _calificacionesService.GetAsync(id);

            if (calificacion is null)
            {
                return NotFound();
            }

            updateCalificacion.Id_calificacion = calificacion.Id_calificacion;

            await _calificacionesService.UpdateAsync(id, updateCalificacion);

            return Ok("calificacion modificada correctamente");
        }

        [HttpDelete("delete-calificacion/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var calificacion = await _calificacionesService.GetAsync(id);

            if (calificacion is null)
            {
                return NotFound();
            }

            await _calificacionesService.RemoveAsync(id);

            return Ok("calificacion eliminada");

        }
    }
}
