using TJRJ.Application.Model;

namespace TJRJ.Application.Interfaces
{
    public interface IAppLivro
    {
        Task<LivroRetornoModel> IncluirLivro(LivroModel livro);
        Task<LivroRetornoModel> AlterarLivro(LivroModel livro);
        Task<LivroRetornoModel> ExcluirLivro(int codLivro);

    }
}
