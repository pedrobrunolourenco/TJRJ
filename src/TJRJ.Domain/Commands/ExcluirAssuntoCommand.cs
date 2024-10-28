using TJRJ.Domain.Core.Messages;

namespace TJRJ.Domain.Commands
{
    public class ExcluirAssuntoCommand : Command
    {
        public int Livro_CodI { get; private set; }
        public int Assunto_CodAs { get; private set; }

        public ExcluirAssuntoCommand(int livro_codI, int assunto_codAs)
        {
            Livro_CodI = livro_codI;
            Assunto_CodAs = assunto_codAs;
        }
    }
}





