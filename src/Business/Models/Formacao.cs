using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Formacao : Entity
    {
        public Guid CurriculoId { get; set; }
        public string Curso { get; set; }
        public TipoStatus Status { get; set; }
        public DateTime DataConclusao { get; set; }
        public Curriculo Curriculo { get; set; }
    }
}
