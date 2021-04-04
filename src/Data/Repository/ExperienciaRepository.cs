using Business.Interfaces;
using Business.Models;
using Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class ExperienciaRepository : Repository<Experiencia> , IExperienciaRepository
    {
        public ExperienciaRepository(MeuDbContext context) : base(context) { }
    }
}
