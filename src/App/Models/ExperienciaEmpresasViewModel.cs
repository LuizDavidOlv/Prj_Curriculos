using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class ExperienciaEmpresasViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Empresa { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Cargo { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayFormat(DataFormatString="dd/mm/yyyy")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime DataFim { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string DetalhesExperiencia { get; set; }
        public CurriculoViewModel Curriculo { get; set; }
    }
}
