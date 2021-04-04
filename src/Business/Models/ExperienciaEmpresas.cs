using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class ExperienciaEmpresas : Entity
    {
        public Guid CurriculoId { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string DetalhesExperiencia { get; set; }
        public Curriculo Curriculo { get; set; }
    }
}
