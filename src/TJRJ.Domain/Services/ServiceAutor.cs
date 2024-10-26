using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;
using TJRJ.Domain.Interfaces.Service;

namespace TJRJ.Domain.Services
{
    public class ServiceAutor : IServiceAutor
    {

        private readonly IUnitOfWork _unitOfWork;


        public ServiceAutor(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Autor>> ObterAutores()
        {
            return await _unitOfWork.RepositoryAutor.Listar();
        }

        public async Task<Autor> ObterAutorPorId(int id)
        {
            return await _unitOfWork.RepositoryAutor.BuscarAutorPorId(id);
        }


        public async Task<Autor> IncluirAutor(Autor autor)
        {
            if (!autor.Validar()) return autor;
            var errosDominio = await ValidarRegrasDeDominioNaInclusao(autor);
            if (errosDominio.ListaErros.Any()) return autor;
            await _unitOfWork.RepositoryAutor.Adicionar(autor);
            await _unitOfWork.Commit();
            return autor;

        }


        public async Task<Autor> AlterarAutor(Autor autor)
        {

            if (!autor.Validar()) return autor;
            if (!await VerificarSeIdJaExiste(autor.CodAu)) autor.ListaErros.Add($"O ID {autor.CodAu} não foi localizado.");
            var errosDominio = await ValidarRegrasDeDominioNaAlteracao(autor);
            if (errosDominio.ListaErros.Any()) return autor;
            await _unitOfWork.RepositoryAutor.Atualizar(autor);
            await _unitOfWork.Commit();
            return autor;

        }

        public async Task<Autor> ExcluirAutor(int CodAu)
        {
            var objAutor = await _unitOfWork.RepositoryAutor.BuscarAutorPorId(CodAu);
            if (objAutor == null)
            {
                var retorno = new Autor();
                retorno.ListaErros.Add($"O ID {CodAu} não foi localizado.");
                return retorno;
            }
            await _unitOfWork.RepositoryAutor.Remover(objAutor);
            await _unitOfWork.Commit();
            return objAutor;
        }

        private async Task<Autor> ValidarRegrasDeDominioNaAlteracao(Autor autor)
        {
            if (await VerificarSeNomeJaExiste(autor.CodAu, autor.Nome)) autor.ListaErros.Add($"O autor {autor.Nome} já existe.");
            return autor;
        }

        private async Task<Autor> ValidarRegrasDeDominioNaInclusao(Autor autor)
        {
            if (await VerificarSeIdJaExiste(autor.CodAu)) autor.ListaErros.Add($"O ID {autor.CodAu} já existe.");
            if (await VerificarSeNomeJaExiste(autor.Nome)) autor.ListaErros.Add($"O autor {autor.Nome} já existe.");
            return autor;
        }

        private async Task<bool> VerificarSeIdJaExiste(int id)
        {
            var result = await _unitOfWork.RepositoryAutor.BuscarAutorPorId(id);
            return result == null ? false : true;
        }

        private async Task<bool> VerificarSeNomeJaExiste(string nome)
        {
            var result = await _unitOfWork.RepositoryAutor.Listar();
            return result.Where(p => p.Nome.ToUpper() == nome.ToUpper()).Any();
        }

        private async Task<bool> VerificarSeNomeJaExiste(int codAu, string nome)
        {
            var result = await _unitOfWork.RepositoryAutor.Listar();
            return result.Where(p => p.Nome.ToUpper() == nome.ToUpper() && p.CodAu != codAu).Any();
        }
    }
}
