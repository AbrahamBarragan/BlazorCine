using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCine.Shared.DTOs;
using BlazorCine.Server.Models.Entities;

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
        public async Task<ActionResult<List<PeliculaDTO>>> GetPeliculas()
        {
            var peliculas = await context.Peliculas.ToListAsync();

            var peliculasDto = new List<PeliculaDTO>();

            foreach (var pelicula in peliculas)
            {
                var peliculaDto = new PeliculaDTO();
                peliculaDto.Id = pelicula.Id;
                peliculaDto.Name = pelicula.Name;

                peliculasDto.Add(peliculaDto);
            }
            return peliculasDto;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeliculaDTO>> GetPelicula(int id)
        {
            var pelicula = await context.Peliculas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (pelicula == null)
            {
                return NotFound();
            }

            var peliculaDto = new PeliculaDTO();
            peliculaDto.Id = pelicula.Id;
            peliculaDto.Name = pelicula.Name;

            return peliculaDto;
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PeliculaDTO peliculaDto)
        {
            var pelicula = new Pelicula();
            pelicula.Id = peliculaDto.Id;
            pelicula.Name = peliculaDto.Name;

            context.Peliculas.Add(pelicula);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] PeliculaDTO peliculaDto)
        {
            var peliculaDb = await context.Peliculas
                .FirstOrDefaultAsync(x => x.Id == peliculaDto.Id);

            if (peliculaDb == null)
            {
                return NotFound();
            }

            peliculaDb.Name = peliculaDto.Name;

            context.Peliculas.Update(peliculaDb);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var peliculaDb = await context.Peliculas
                .FirstOrDefaultAsync(x => x.Id == id);

            if (peliculaDb == null)
            {
                return NotFound();
            }

            context.Peliculas.Remove(peliculaDb);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
