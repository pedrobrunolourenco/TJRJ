using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;
using TJRJ.Domain.Interfaces.Service;

namespace TJRJ.Domain.Services
{
    public class ServiceAssunto : IServiceAssunto
    {

        private readonly IUnitOfWork _unitOfWork;


        public ServiceAssunto(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Assunto>> ObterAssuntos()
        {
            return await _unitOfWork.RepositoryAssunto.Listar();
        }

        public async Task<Assunto> ObterAssuntoPorId(int id)
        {
            return await _unitOfWork.RepositoryAssunto.BuscarAssuntoPorId(id);
        }

        public async Task<Assunto> IncluirAssunto(Assunto assunto)
        {
            if (!assunto.Validar()) return assunto;
            var errosDominio = await ValidarRegrasDeDominioNaInclusao(assunto);
            if (errosDominio.ListaErros.Any()) return assunto;
            await _unitOfWork.RepositoryAssunto.Adicionar(assunto);
            await _unitOfWork.Commit();
            return assunto;
        }

        public async Task<Assunto> AlterarAssunto(Assunto assunto)
        {
            if (!assunto.Validar()) return assunto;
            if (!await VerificarSeIdJaExiste(assunto.CodAs)) assunto.ListaErros.Add($"O ID {assunto.CodAs} não foi localizado.");
            var errosDominio = await ValidarRegrasDeDominioNaAlteracao(assunto);
            if (errosDominio.ListaErros.Any()) return assunto;
            await _unitOfWork.RepositoryAssunto.Atualizar(assunto);
            await _unitOfWork.Commit();
            return assunto;
        }

        public async Task<Assunto> ExcluirAssunto(int CodAs)
        {
            var objAssunto = await _unitOfWork.RepositoryAssunto.BuscarAssuntoPorId(CodAs);
            if (objAssunto == null)
            {
                var retorno = new Assunto();
                retorno.ListaErros.Add($"O ID {CodAs} não foi localizado.");
                return retorno;
            }
            await _unitOfWork.RepositoryAssunto.Remover(objAssunto);
            await _unitOfWork.Commit();
            return objAssunto;
        }

        private async Task<Assunto> ValidarRegrasDeDominioNaAlteracao(Assunto assunto)
        {
            if (await VerificarSeDescricaoJaExiste(assunto.CodAs, assunto.Descricao)) assunto.ListaErros.Add($"O assunto {assunto.Descricao} já existe.");
            return assunto;
        }

        private async Task<Assunto> ValidarRegrasDeDominioNaInclusao(Assunto assunto)
        {
            if (await VerificarSeIdJaExiste(assunto.CodAs)) assunto.ListaErros.Add($"O ID {assunto.CodAs} já existe.");
            if (await VerificarSeDescricaoJaExiste(assunto.Descricao)) assunto.ListaErros.Add($"O assunto {assunto.Descricao} já existe.");
            return assunto;
        }

        private async Task<bool> VerificarSeIdJaExiste(int id)
        {
            var result = await _unitOfWork.RepositoryAssunto.BuscarAssuntoPorId(id);
            return result == null ? false : true;
        }

        private async Task<bool> VerificarSeDescricaoJaExiste(string descricao)
        {
            var result = await _unitOfWork.RepositoryAssunto.Listar();
            return result.Where(p => p.Descricao.ToUpper() == descricao.ToUpper()).Any();
        }

        private async Task<bool> VerificarSeDescricaoJaExiste(int codAs, string descricao)
        {
            var result = await _unitOfWork.RepositoryAssunto.Listar();
            return result.Where(p => p.Descricao.ToUpper() == descricao.ToUpper() && p.CodAs != codAs).Any();
        }




    }
}
