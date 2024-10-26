using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Application.Interfaces;
using TJRJ.Application.Model;
using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Service;
using TJRJ.Domain.Services;

namespace TJRJ.Application.Services
{
    public class AppAutor : IAppAutor
    {

        private readonly IMapper _mapper;
        private readonly IServiceAutor _serviceAutor;

        public AppAutor(IMapper mapper,
                          IServiceAutor serviceAutor)
        {
            _mapper = mapper;
            _serviceAutor = serviceAutor;

        }

        public async Task<IEnumerable<AutorRetornoModel>> ObterAutores()
        {
            return _mapper.Map<IEnumerable<AutorRetornoModel>>(await _serviceAutor.ObterAutores());
        }

        public async Task<AutorRetornoModel> ObterAutorPorId(int id)
        {
            return _mapper.Map<AutorRetornoModel>(await _serviceAutor.ObterAutorPorId(id));
        }

        public async Task<AutorRetornoModel> IncluirAutor(AutorModel autor)
        {
            return _mapper.Map<AutorRetornoModel>(await _serviceAutor.IncluirAutor(_mapper.Map<Autor>(autor)));
        }

        public async Task<AutorRetornoModel> AlterarAutor(AutorModel autor)
        {
            return _mapper.Map<AutorRetornoModel>(await _serviceAutor.AlterarAutor(_mapper.Map<Autor>(autor)));
        }

        public async Task<AutorRetornoModel> ExcluirAutor(int codAu)
        {
            return _mapper.Map<AutorRetornoModel>(await _serviceAutor.ExcluirAutor(codAu));
        }


    }
}
