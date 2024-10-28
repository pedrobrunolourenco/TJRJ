using TJRJ.Domain.Core.Messages;

namespace TJRJ.Domain.Commands
{
    public class ExcluirAutorCommand : Command
    {
        public int Livro_CodI { get; private set; }
        public int Autor_CodAu { get; private set; }

        public ExcluirAutorCommand(int livro_codi, int autor_codau)
        {
            Livro_CodI = livro_codi;
            Autor_CodAu = autor_codau;
        }

    }
}
