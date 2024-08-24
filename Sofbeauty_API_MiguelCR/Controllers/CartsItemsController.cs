using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sofbeauty_API_MiguelCR.Models;
using Sofbeauty_API_MiguelCR.ModelsDTOs;

namespace Sofbeauty_API_MiguelCR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsItemsController : ControllerBase
    {
        private readonly SofbeautyContext _context;

        public CartsItemsController(SofbeautyContext context)
        {
            _context = context;
        }

        // GET: api/CartsItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartsItem>>> GetCartsItems()
        {
            return await _context.CartsItems.ToListAsync();
        }

        // GET: api/CartsItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartsItem>> GetCartsItem(int id)
        {
            var cartsItem = await _context.CartsItems.FindAsync(id);

            if (cartsItem == null)
            {
                return NotFound();
            }

            return cartsItem;
        }

        // PUT: api/CartsItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartsItem(int id, CartsItem cartsItem)
        {
            if (id != cartsItem.CartsItemId)
            {
                return BadRequest();
            }

            _context.Entry(cartsItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartsItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CartsItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartsItem>> PostCartsItem(CartsItem cartsItem)
        {
            _context.CartsItems.Add(cartsItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartsItem", new { id = cartsItem.CartsItemId }, cartsItem);
        }

        //POST DE INGRESO DESDE AL APP USANDO DTO
        [HttpPost("AddCartsItemFromApp")]
        public async Task<ActionResult<CartsItemDTO>> AddCartsItemFromApp(CartsItemDTO cartsItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //normalmente usamos herramientas como auto mapper para hacer la transformación del DTO al modelo nativo (en este caso User). Pero
            //para entender mejor o por mayor control acá haremos el mapeo manualmente

            CartsItem NuevoUsuarioNativo = new()
            {
                CartsId = cartsItem.CarritoId,
                Carts = null,
                ProductsId = cartsItem.ProductoId,
                Products = null,
                Quantity = cartsItem.Cantidad
            };
            _context.CartsItems.Add(NuevoUsuarioNativo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartsItem", new { id = NuevoUsuarioNativo.CartsItemId }, NuevoUsuarioNativo);
        }

        // DELETE: api/CartsItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartsItem(int id)
        {
            var cartsItem = await _context.CartsItems.FindAsync(id);
            if (cartsItem == null)
            {
                return NotFound();
            }

            _context.CartsItems.Remove(cartsItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartsItemExists(int id)
        {
            return _context.CartsItems.Any(e => e.CartsItemId == id);
        }
    }
}
