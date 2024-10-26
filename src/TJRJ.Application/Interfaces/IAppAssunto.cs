using TJRJ.Application.Model;

namespace TJRJ.Application.Interfaces
{
    public interface IAppAssunto
    {
        Task<AssuntoListaRetornoModel> ObterAssuntos();
        Task<AssuntoRetornoModel> ObterAssuntoPorId(int id);
        Task<AssuntoRetornoModel> IncluirAssunto(AssuntoModel assunto);
        Task<AssuntoRetornoModel> AlterarAssunto(AssuntoModel assunto);
        Task<AssuntoRetornoModel> ExcluirAssunto(int CodAs);

    }
}
