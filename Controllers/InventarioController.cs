using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaQuala.Models;

namespace pruebaQuala.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly TestDBContext _context;

        public InventarioController(TestDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Inventarios>> Get()
        {
            return await _context.Inventarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
                return BadRequest();
            var registro = await _context.Inventarios.FirstOrDefaultAsync(m => m.Codigo == id);
            if (registro == null)
                return NotFound();
            return Ok(registro);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Inventarios inventarios)
        {
            _context.Add(inventarios);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Inventarios info)
        {
            if (info == null || info.Codigo == 0)
                return BadRequest();

            var fila = await _context.Inventarios.FindAsync(info.Codigo);
            if (fila == null)
                return NotFound();
            fila.Descripcion = info.Descripcion;
            fila.Direccion = info.Direccion;
            fila.Sucursal = info.Sucursal;
           // fila.Fechacreacion = info.Fechacreacion;
            fila.Idmoneda = info.Idmoneda;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dato = await _context.Inventarios.FindAsync(id);
            if (dato == null) return NotFound();
            _context.Inventarios.Remove(dato);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
