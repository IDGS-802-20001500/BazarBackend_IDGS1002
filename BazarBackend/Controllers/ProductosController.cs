using BazarBackend.Context;
using Microsoft.AspNetCore.Mvc;

namespace BazarBackend.Controllers
{
    [Route("api/items")]
    [ApiController]

    public class ProductosController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }



        // GET: api/<ProductosController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.Productos.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("search={search}", Name = "Search")]
        public ActionResult Get(string search)
        {
            try
            {
                var productos = _context.Productos.Where(p => 
                    p.title.Contains(search) ||
                    p.description.Contains(search) ||
                    p.brand.Contains(search)

                ).ToList();

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}", Name = "Productos")]
        public ActionResult GetDetalle(int id)
        {
            try
            {
                var producto = _context.Productos.FirstOrDefault(p => p.id == id);
                if (producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
