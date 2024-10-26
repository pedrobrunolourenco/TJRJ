using AutoMapper;
using TJRJ.Application.Model;
using TJRJ.Domain.Entities;

namespace TJRJ.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AssuntoModel, Assunto>()
                .ConstructUsing(p => new Assunto(p.CodigoAssunto, p.Descricao));
        }
    }
}
