
using Agendamento.App.Models;
using AutoMapper;
using Bussines.Models;

namespace Agendamento.App.AutoMapper
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ConsultaData, ConsultaDataViewModel>().ReverseMap();
            CreateMap<DataModel, DataModelViewModel>().ReverseMap();
            CreateMap<PessoaModel, PessoaViewModel>().ReverseMap();
        }
    }
}
