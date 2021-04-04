using App.Models;
using AutoMapper;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.AutoMapper
{
    public class AutoMapperConfig :Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Curriculo, CurriculoViewModel>().ReverseMap();
            CreateMap<Formacao, FormacaoViewModel>().ReverseMap();
            CreateMap<Experiencia, ExperienciaViewModel>().ReverseMap();
            CreateMap<ExperienciaEmpresas, ExperienciaEmpresasViewModel>().ReverseMap();
        }
    }
}
