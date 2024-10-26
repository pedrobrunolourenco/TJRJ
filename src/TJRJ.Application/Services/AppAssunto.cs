using AutoMapper;
using TJRJ.Application.Interfaces;
using TJRJ.Application.Model;
using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Service;

namespace TJRJ.Application.Services
{
    public class AppAssunto : IAppAssunto
    {
        private readonly IMapper _mapper;
        private readonly IServiceAssunto _serviceAssunto;

        public AppAssunto(IMapper mapper,
                          IServiceAssunto serviceAssunto)
        {
            _mapper = mapper;
            _serviceAssunto = serviceAssunto;

        }

        public async Task<IEnumerable<AssuntoRetornoModel>> ObterAssuntos()
        {
            return _mapper.Map<IEnumerable<AssuntoRetornoModel>>(await _serviceAssunto.ObterAssuntos());
        }
        public async Task<AssuntoRetornoModel> ObterAssuntoPorId(int id)
        {
            return _mapper.Map<AssuntoRetornoModel>(await _serviceAssunto.ObterAssuntoPorId(id));
        }

        public async Task<AssuntoRetornoModel> IncluirAssunto(AssuntoModel assunto)
        {
            return _mapper.Map<AssuntoRetornoModel>(await _serviceAssunto.IncluirAssunto(_mapper.Map<Assunto>(assunto)));
        }

        public async Task<AssuntoRetornoModel> AlterarAssunto(AssuntoModel assunto)
        {
            return _mapper.Map<AssuntoRetornoModel>(await _serviceAssunto.AlterarAssunto(_mapper.Map<Assunto>(assunto)));
        }

        public async Task<AssuntoRetornoModel> ExcluirAssunto(int CodAs)
        {
            return _mapper.Map<AssuntoRetornoModel>(await _serviceAssunto.ExcluirAssunto(CodAs));
        }



    }
}
