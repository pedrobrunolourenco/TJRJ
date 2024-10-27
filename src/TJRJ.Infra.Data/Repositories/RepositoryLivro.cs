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

        public async Task<IEnumerable<AssuntoDto>> ObterAssuntosDoLivro(int codId)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"
                                SELECT DISTINCT 
                                        A.CodAs, A.Descricao,
                                        ISNULL(LASS.Assunto_CodAs,0) Flag
                                        FROM ASSUNTO A
                                        LEFT JOIN Livro_Assunto LASS WITH(NOLOCK) ON (LASS.Assunto_CodAs = A.CodAs AND LASS.Livro_CodI=@ID )
                                ORDER BY A.Descricao
                        ");
            var retorno = _context.Database.GetDbConnection().QueryAsync<AssuntoDto>(query.ToString(), new { ID = codId }).Result.ToList();
            return retorno;
        }

        public async Task<IEnumerable<AutorDto>> ObterAutoresDoLivro(int codId)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"
                            SELECT DISTINCT 
                                    A.CodAu, A.Nome,
                                    ISNULL(LAU.Autor_CodAu,0) Flag
                                    FROM AUTOR A
                                    LEFT JOIN Livro_Autor LAU WITH(NOLOCK) ON (LAU.Autor_CodAu = A.CodAu AND LAU.Livro_CodI=@ID )
                            ORDER BY A.Nome
                        ");
            var retorno = _context.Database.GetDbConnection().QueryAsync<AutorDto>(query.ToString(), new { ID = codId }).Result.ToList();
            return retorno;
        }

        public async Task<LivroDto> ObterLivroPorId(int codId)
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"
                         SELECT DISTINCT L.CodI AS CodigoLivro, 
                                         L.Titulo,
                                         L.Editora,
                                         L.Edicao,
                                         L.AnoPublicacao
                                    FROM Livro L WITH(NOLOCK) 
                            WHERE L.CodI = @ID
                            ORDER BY TAUT.Nome

                        ");
            var retorno = _context.Database.GetDbConnection().QueryAsync<LivroDto>(query.ToString(), new { ID = codId }).Result.ToList().FirstOrDefault();
            return retorno;
        }

        public async Task<IEnumerable<LivroDto>> ObterTodosOsLivros()
        {
            StringBuilder query = new StringBuilder();
            query.Append(@"
                         SELECT DISTINCT L.CodI AS CodigoLivro, 
                                         L.Titulo,
                                         L.Editora,
                                         L.Edicao,
                                         L.AnoPublicacao
                            FROM Livro L WITH(NOLOCK) 
                            ORDER BY L.Titulo

                        ");
            var retorno = _context.Database.GetDbConnection().QueryAsync<LivroDto>(query.ToString()).Result.ToList();
            return retorno;
        }
    }
}
