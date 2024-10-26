using TJRJ.Application.Model;

namespace TJRJ.Application.Interfaces
{
    public interface IAppAssunto
    {
        Task<IEnumerable<AssuntoRetornoModel>> ObterAssuntos();
        Task<AssuntoRetornoModel> ObterAssuntoPorId(int id);
        Task<AssuntoRetornoModel> IncluirAssunto(AssuntoModel assunto);
        Task<AssuntoRetornoModel> AlterarAssunto(AssuntoModel assunto);
        Task<AssuntoRetornoModel> ExcluirAssunto(int CodAs);

    }
}
