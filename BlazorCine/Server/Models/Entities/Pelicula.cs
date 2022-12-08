using System.ComponentModel.DataAnnotations;

namespace BlazorCine.Server.Models.Entities
{
    public class Pelicula
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

    }
}
