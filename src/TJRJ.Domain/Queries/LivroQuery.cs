using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Domain.DTOs;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Domain.Queries
{
    public class LivroQuery : ILivroQuery
    {

        private readonly IRepositoryLivro _repositoryLivro;

        public LivroQuery(IRepositoryLivro repositoryLivro)
        {
            _repositoryLivro = repositoryLivro;
        }

        public async Task<IEnumerable<LivroDto>> ObterTodosOsLivros()
        {
            return await _repositoryLivro.ObterTodosOsLivros();
        }
    }
}
