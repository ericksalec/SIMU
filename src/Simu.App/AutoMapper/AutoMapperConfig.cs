using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Simu.App.Models;
using Simu.App.ViewModels;
using Simu.Business.Models;

namespace Simu.App.AutoMapper
{
    //Definindo perfil de mapeamento do Auto Mapper
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Tarefa, TarefaViewModel>().ReverseMap();
        }
    }
}
