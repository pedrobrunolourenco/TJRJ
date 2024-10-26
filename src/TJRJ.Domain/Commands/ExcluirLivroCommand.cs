using TJRJ.Domain.Core.Messages;

namespace TJRJ.Domain.Commands
{
    public class ExcluirLivroCommand : Command
    {
        public int CodI { get; private set; }


        public ExcluirLivroCommand(int codI)
        {
            CodI = codI;
            AggregateId = codI;
        }

    }
}
