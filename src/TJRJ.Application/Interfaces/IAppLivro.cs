using TJRJ.Application.Model;
using TJRJ.Domain.DTOs;

namespace TJRJ.Application.Interfaces
{
    public interface IAppLivro
    {
        Task<LivroRetornoModel> IncluirLivro(LivroModel livro);
        Task<LivroRetornoModel> AlterarLivro(LivroModel livro);
        Task<LivroRetornoModel> ExcluirLivro(int codLivro);
        Task<IEnumerable<LivroDto>> ObterTodosOsLivros();

    }
}
