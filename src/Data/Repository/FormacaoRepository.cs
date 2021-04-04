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
    public class FormacaoRepository : Repository<Formacao> ,IFormacaoRepository
    {
        public FormacaoRepository(MeuDbContext context) : base(context) { }

        public async Task<Formacao> ObterFormacoesCurriculo(Guid id)
        {
            //throw new NotImplementedException();
            return await Db.Formacoes.AsNoTracking()
                //.Include(c => c.Curriculo.Nome)
                .Include(c => c.Curso)
                .Include(c => c.Status)
                .Include(c => c.DataConclusao)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
