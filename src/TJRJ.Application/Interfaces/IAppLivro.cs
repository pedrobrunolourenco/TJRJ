using TJRJ.Application.Model;
using TJRJ.Domain.DTOs;

namespace TJRJ.Application.Interfaces
{
    public interface IAppLivro
    {
        Task<LivroRetornoModel> IncluirLivro(LivroModel livro);
        Task<LivroRetornoModel> AlterarLivro(LivroAlteracaoModel livro);
        Task<LivroRetornoModel> ExcluirLivro(int codLivro);
        Task<LivroAutorRetornoModel> IncluirAutor(LivroAutorModel livroAutor);
        Task<LivroAssuntoRetornoModel> IncluirAssunto(LivroAssuntoModel livroAssunto);

        Task<IEnumerable<LivroDto>> ObterTodosOsLivros();
        Task<LivroDto> ObterLivroPorId(int codLivro);
        Task<IEnumerable<AssuntoDto>> ObterAssuntosDoLivro(int codLivro);
        Task<IEnumerable<AutorDto>> ObterAutoresDoLivro(int codLivro);


    }
}
