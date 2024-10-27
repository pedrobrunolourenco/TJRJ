using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TJRJ.Domain.DTOs;
using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class RepositoryLivro : Repository<Livro>, IRepositoryLivro
    {

        private readonly DataContext _context;

        public RepositoryLivro(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Livro> BuscarLivroPorId(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.CodI == id);
        }


        public async Task<IEnumerable<LivroDto>> ObterTodosOsLivros()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"
                            SELECT DISTINCT L.CodI AS CodigoLivro, 
                                            L.Titulo,
                                            L.Editora,
                                            L.Edicao,
                                            L.AnoPublicacao,
				                            TASS.Descricao AS Assunto,
				                            TAUT.Nome AS Autor
                                    FROM Livro L WITH(NOLOCK) 
		                            INNER JOIN Livro_Assunto ASS WITH(NOLOCK) ON (L.CodI = ASS.Livro_CodI)
		                            INNER JOIN Livro_Autor AUT WITH(NOLOCK) ON (L.CodI = AUT.Livro_CodI)
		                            INNER JOIN Assunto TASS WITH(NOLOCK) ON (ASS.Assunto_CodAs = TASS.CodAs)
		                            INNER JOIN Autor TAUT WITH(NOLOCK) ON (AUT.Autor_CodAu = TAUT.CodAu)
                            ORDER BY TAUT.Nome

                        ");
            var retorno = _context.Database.GetDbConnection().QueryAsync<LivroDto>(query.ToString()).Result.ToList();
            return retorno;
        }
    }
}
