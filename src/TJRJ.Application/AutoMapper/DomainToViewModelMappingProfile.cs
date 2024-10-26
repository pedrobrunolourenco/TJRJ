using AutoMapper;
using TJRJ.Application.Model;
using TJRJ.Domain.Entities;

namespace TJRJ.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Assunto, AssuntoRetornoModel>()
                .ForMember(dest => dest.Assunto, opt => opt.MapFrom(src => new AssuntoModel
                {
                    CodigoAssunto = src.CodAs,
                    Descricao = src.Descricao
                }))
                .ForMember(dest => dest.ListaErros, opt => opt.MapFrom(src => src.ListaErros));

            CreateMap<Autor, AutorRetornoModel>()
                .ForMember(dest => dest.Autor, opt => opt.MapFrom(src => new AutorModel
                {
                    CodigoAutor = src.CodAu,
                    Nome = src.Nome
                }))
                .ForMember(dest => dest.ListaErros, opt => opt.MapFrom(src => src.ListaErros));


        }
    }
}
