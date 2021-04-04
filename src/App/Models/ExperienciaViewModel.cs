using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class ExperienciaViewModel
    {
        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Tecnologia { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int TempoExperiencia { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string DetalhesExperiencia { get; set; }


        public CurriculoViewModel Curriculo { get; set; }

        

        //[HiddenInput]
        //public Guid CurriculoId { get; set; }
    }
}
