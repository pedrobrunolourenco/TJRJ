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
                .ForMember(dest => dest.ListaErros, opt => opt.MapFrom(src => src.ListaErros))
                .ForMember(dest => dest.Sucesso, opt => opt.MapFrom(src => !src.ListaErros.Any()));


            CreateMap<List<Assunto>, AssuntoListaRetornoModel>()
                .ForMember(dest => dest.Assuntos, opt => opt.MapFrom(src => src.Select(a => new AssuntoModel
                {
                    CodigoAssunto = a.CodAs,
                    Descricao = a.Descricao
                }).ToList()))
                .ForMember(dest => dest.ListaErros, opt => opt.MapFrom(src => src.SelectMany(a => a.ListaErros).ToList()))
                .ForMember(dest => dest.Sucesso, opt => opt.MapFrom(src => src.All(a => !a.ListaErros.Any())));
        }
    }
}
