using AutoMapper;
using TJRJ.Application.Interfaces;
using TJRJ.Application.Model;
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

        public async Task<AssuntoListaRetornoModel> ObterAssuntos()
        {
            var assuntos = await _serviceAssunto.ObterAssuntos();
            var retorno = new AssuntoListaRetornoModel
            {
                Assuntos = _mapper.Map<List<AssuntoModel>>(assuntos),
                ListaErros = assuntos.SelectMany(a => a.ListaErros).ToList(),
                Sucesso = assuntos.All(a => !a.ListaErros.Any())
            };
            return retorno;
        }

        public async Task<AssuntoRetornoModel> ObterAssuntoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AssuntoRetornoModel> IncluirAssunto(AssuntoModel assunto)
        {
            throw new NotImplementedException();
        }

        public async Task<AssuntoRetornoModel> AlterarAssunto(AssuntoModel assunto)
        {
            throw new NotImplementedException();
        }

        public async Task<AssuntoRetornoModel> ExcluirAssunto(int CodAs)
        {
            throw new NotImplementedException();
        }



    }
}
