using BKProyecto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BKProyecto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaCreditoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public TarjetaCreditoController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<TarjetaCreditoController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var listarTarjeta = await _context.TarjetaCredito.ToListAsync();
                return Ok(listarTarjeta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TarjetaCreditoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TarjetaCreditoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] tarjeta TarjetaCredi )
        {
            try
            {
                _context.Add(TarjetaCredi);
                await _context.SaveChangesAsync();
                return Ok(TarjetaCredi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TarjetaCreditoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] tarjeta TarjetaCredi)
        {
            try
            {
                if ( id != TarjetaCredi.Id) {
                    return NotFound();
                }

                _context.Update(TarjetaCredi);
                await _context.SaveChangesAsync();
                return Ok( new{ message = "La tarjeta se actualizo correctamente" });
            }
            catch (Exception ex){
                return BadRequest(ex.Message);            
            }
        }

        // DELETE api/<TarjetaCreditoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var tarjeta = await _context.TarjetaCredito.FindAsync(id);
                if(tarjeta == null)
                {
                    return NotFound();
                }

                _context.TarjetaCredito.Remove(tarjeta);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La tarjeta se elimino correctamente" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
