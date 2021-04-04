using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class Curriculo : Entity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public IEnumerable<Formacao> Formacao { get; set; }
        public int ExperienciaTotal { get; set; }
        public IEnumerable<Experiencia> Experiencias { get; set; }
        public IEnumerable<ExperienciaEmpresas> ExperienciasEmpresas { get; set; }
        
    }
}
