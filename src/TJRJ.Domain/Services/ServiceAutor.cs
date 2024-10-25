using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Service;

namespace TJRJ.Domain.Services
{
    public class ServiceAutor : IServiceAutor
    {

        public Task<IEnumerable<Autor>> ObterAutores()
        {
            throw new NotImplementedException();
        }

        public Task<Assunto> IncluirAutor(Autor autor)
        {
            throw new NotImplementedException();
        }

        public Task<Assunto> AlterarAutor(int CodAu, Autor autor)
        {
            throw new NotImplementedException();
        }

        public Task<Assunto> ExcluirAutor(int CodAu)
        {
            throw new NotImplementedException();
        }


    }
}
