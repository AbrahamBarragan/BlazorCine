using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCine.Shared.DTOs
{
	public class PeliculaDTO
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string? Name { get; set; }
    }
}
