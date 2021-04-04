using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CurriculoRepository : Repository<Curriculo>, ICurriculoRepository
    {
        public CurriculoRepository(MeuDbContext context) : base(context) { }

        public async Task<Curriculo> ObterCurriculoInformacoes(Guid id)
        {
            return await Db.Curriculos.AsNoTracking()
                .Include(c => c.Experiencias)
                .Include(c => c.ExperienciasEmpresas)
                .Include(c => c.Formacao)
                .FirstOrDefaultAsync(c=>c.Id==id);
        }
    }
}
