using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Application.Model;

namespace TJRJ.Application.Interfaces
{
    public interface IAppAutor
    {
        Task<IEnumerable<AutorRetornoModel>> ObterAutores();
        Task<AutorRetornoModel> ObterAutorPorId(int id);
        Task<AutorRetornoModel> IncluirAutor(AutorModel autor);
        Task<AutorRetornoModel> AlterarAutor(AutorModel autor);
        Task<AutorRetornoModel> ExcluirAutor(int codAu);

    }
}
