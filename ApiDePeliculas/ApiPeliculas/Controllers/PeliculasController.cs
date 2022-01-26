using ApiPeliculas.Modelos;
using ApiPeliculas.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPeliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        //https://localhost:44311/api/Films/
        [HttpGet]
        public IActionResult Get()
        {
            RPpeliculas rpelis = new RPpeliculas();
            return Ok(rpelis.ObtenerPelicula());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RPpeliculas rpPelis = new RPpeliculas();

            var peli = rpPelis.ObtenerPeliculaId(id);

            if (peli == null)
            {
                var nf = NotFound("La Pelicula con el ID = " + id.ToString() + " no existe o no se encuentra registrado.");
                return nf;
            }

            return Ok(peli);
        }

        [HttpGet("DirectorId {Director}")]
        public ActionResult BuscarporDirector(string director)
        {
            RPpeliculas buscarporD = new RPpeliculas();
            var pelicula = buscarporD.BuscarporDirector(director);
            if (pelicula.Count() == 0)
            {
                return NotFound($"El director {director} no existe o se encuentra mal escrito");
            }
            return Ok(pelicula);

        }

        [HttpPost("Crear")]
        public IActionResult AgregarPelicula(Pelicula nuevapelicula)
        {
            RPpeliculas nuevapeli = new RPpeliculas();
            nuevapeli.Agregar(nuevapelicula);
            return CreatedAtAction(nameof(AgregarPelicula), nuevapelicula);
        }

        [HttpDelete("Borrar {id}")]
        public IActionResult BorrarPelicula(int id)
        {
            RPpeliculas nuevapeli = new RPpeliculas();
            var Validacion = nuevapeli.ObtenerPeliculaId(id);
            if (Validacion == null)
            {
                return NotFound($"El id {id} ingresado no existe  ");
            }
            nuevapeli.BorrarPelicula(id);
            return Ok($"Se elimino la pelicula con el id  {id}");
        }

        [HttpPut("Actualizar {id}")]
        public IActionResult ActualizarPelicula(int id, Pelicula actualizarpelicula)
        {
            RPpeliculas actualizarpeli = new RPpeliculas();
            var Validacion = actualizarpeli.ObtenerPeliculaId(id);
            if (Validacion == null)
            {
                return NotFound($"El id {id} ingresado no existe");
            }
            actualizarpeli.ActualizarPelicula(id, actualizarpelicula);
            return Ok($"Se ha actualizado Correctamente el registro con la id {id} exitosamente");
        }
    }
}
