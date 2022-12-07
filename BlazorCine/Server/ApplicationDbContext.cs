using BlazorCine.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCine.Server
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Pelicula> Peliculas { get; set; }
    }
}
