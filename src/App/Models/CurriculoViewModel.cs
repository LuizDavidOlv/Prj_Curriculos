using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class CurriculoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Anos de Experiência")]
        public int ExperienciaTotal { get; set; }

        public IEnumerable<FormacaoViewModel> Formacoes { get; set; }

        public IEnumerable<ExperienciaViewModel> Experiencias { get; set; }

        public IEnumerable<ExperienciaEmpresasViewModel> ExperienciasEmpresas { get; set; }
    }
}
