using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionEscolar.Models;
using SistemaDeGestionEscolar.Services;

namespace SistemaDeGestionEscolar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]

    public class AlumnoController : Controller
    {

        private readonly AlumnosServices _alumnosServices;

        public AlumnoController(AlumnosServices alumnosServices) =>
            _alumnosServices = alumnosServices;


        [HttpGet("get-alumnos")]
        public async Task<List<Alumnos>> Get() =>
        await _alumnosServices.GetAsync();

        [HttpGet("get-alumno/{id:length(24)}")]
        public async Task<ActionResult<Alumnos>> Get(string id)
        {
            var alumno = await _alumnosServices.GetAsync(id);

            if (alumno is null)
            {
                return NotFound();
            }

            return alumno;
        }

        [HttpPost("add-alumno")]
        public async Task<IActionResult> Post(Alumnos newAlumno)
        {
            await _alumnosServices.CreateAsync(newAlumno);

            return CreatedAtAction(nameof(Get), new { id = newAlumno.Id_alumno }, newAlumno);
        }

        [HttpPut("update-alumno/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Alumnos updateAlumno)
        {
            var alumno = await _alumnosServices.GetAsync(id);

            if (alumno is null)
            {
                return NotFound();
            }

            updateAlumno.Id_alumno = alumno.Id_alumno;

            await _alumnosServices.UpdateAsync(id, updateAlumno);

            return Ok("Alumno " + alumno.Apellidos_alumno + alumno.Nombre_alumno + " modificado correctamente");
        }

        [HttpDelete("delete-profesor/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var alumno = await _alumnosServices.GetAsync(id);

            if (alumno is null)
            {
                return NotFound();
            }

            await _alumnosServices.RemoveAsync(id);

            return Ok("Profesor " + alumno.Apellidos_alumno + alumno.Nombre_alumno + " eliminado");

        }
    }
}
