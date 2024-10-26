using MediatR;
using TJRJ.Domain.Core.Mediator;
using TJRJ.Domain.Core.Messages;
using TJRJ.Domain.Core.Messages.CommonMessages;

namespace TJRJ.Domain.Commands
{
    public class LivroCommandHandler :
        IRequestHandler<AdicionarLivroCommand, bool>
    {

        private readonly IMediatrHandler _mediatorHandler;

        public LivroCommandHandler(IMediatrHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }


        public Task<bool> Handle(AdicionarLivroCommand message, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
            return false;
        }

    }
}
