using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace firstAPI.Data.Dtos
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage ="Movie title is required")]
        [StringLength(50, ErrorMessage ="Movie must be less than 50 characters")]
        public string Titulo { get; set; }
        [Required(ErrorMessage ="Genre name is required")]
        public string Genero { get; set; }
        [Required(ErrorMessage ="Duration is required")]
        [Range(70,600, ErrorMessage ="Duration must be between 70 and 600 characters")]
        public int Duracao { get; set; }
    }
}