using Business.Interfaces;
using Business.Models;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class ExperienciaEmpresasRepository : Repository<ExperienciaEmpresas> , IExperienciaEmpresasRepository
    {
        public ExperienciaEmpresasRepository(MeuDbContext context) : base(context) { }
    }
}
