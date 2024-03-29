using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace firstAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {

        public string Titulo { get; set; }
        
        public string Genero { get; set; }
        
        public int Duracao { get; set; }
    }
}