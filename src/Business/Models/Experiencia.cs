using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Experiencia : Entity
    {
        public Guid CurriculoId { get; set; }
        public string Tecnologia { get; set; }
        public int TempoExperiencia { get; set; }
        public string DetalhesExperiencia { get; set; }
        public Curriculo Curriculo { get; set; }
    }
}
