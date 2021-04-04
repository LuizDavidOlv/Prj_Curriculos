using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class FormacaoViewModel
    {
        [Key]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Curriculo")]
        public Guid CurriculoId { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Curso { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public IEnumerable<TipoStatus> Status { get; set; }



        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy{", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataConclusao { get; set; }


        public CurriculoViewModel Curriculo { get; set; }


        public IEnumerable<CurriculoViewModel> Curriculos { get; set; }

    }
}
