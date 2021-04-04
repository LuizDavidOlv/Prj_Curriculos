using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICurriculoRepository : IRepository<Curriculo>
    {
        Task<Curriculo> ObterCurriculoInformacoes(Guid id);
    }
}
