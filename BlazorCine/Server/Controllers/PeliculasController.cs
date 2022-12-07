using BlazorCine.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCine.Server.Controllers
{
    [ApiController, Route("[controller]")]
    public class PeliculasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public PeliculasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pelicula>>> Get()
        {
            return await context.Peliculas.ToListAsync();
        }


    }
}
