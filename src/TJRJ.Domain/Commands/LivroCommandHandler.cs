using MediatR;
using TJRJ.Domain.Core.Mediator;
using TJRJ.Domain.Core.Messages;
using TJRJ.Domain.Core.Messages.CommonMessages;
using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Domain.Commands
{
    public class LivroCommandHandler :
        IRequestHandler<AdicionarLivroCommand, bool>
    {

        private readonly IMediatrHandler _mediatorHandler;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DomainNotificationHandler _notifications;


        public LivroCommandHandler(IMediatrHandler mediatorHandler,
                                   IUnitOfWork unitOfWork,
                                   INotificationHandler<DomainNotification> notifications
                                   )
        {
            _mediatorHandler = mediatorHandler;
            _notifications = (DomainNotificationHandler)notifications;
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> Handle(AdicionarLivroCommand message, CancellationToken cancellationToken)
        {
            if (!ValidarComando(message)) return false;

            if (await VerificarSeLivroExiste(message.CodigoAutor) == true)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"O Livro de código {message.CodI} já existe no cadastro."));
            }

            if (await VerificarSeAutorExiste(message.CodigoAutor) == false)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"O Autor de código {message.CodigoAutor} não foi localizado no cadastro."));
            }

            if (await VerificarSeAssuntoExiste(message.CodigoAssunto) == false)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, $"O Assunto de código {message.CodigoAssunto} não foi localizado no cadastro."));
            }

            if (_notifications.TemNotificacao()) 
            {
                return false;
            }

            var livro_assunto = new Livro_Assunto(message.CodI, message.CodigoAssunto);
            var livro_autor = new Livro_Autor(message.CodI, message.CodigoAutor);
            var livro = new Livro(message.CodI, message.Titulo, message.Editora, message.Edicao, message.AnoPublicacao);
            ClearEntity();
            await _unitOfWork.RepositoryLivroAssunto.Remover(livro_assunto);
            await _unitOfWork.RepositoryLivroAutor.Remover(livro_autor);
            await _unitOfWork.RepositoryLivro.Adicionar(livro);
            await _unitOfWork.RepositoryLivroAssunto.Adicionar(livro_assunto);
            await _unitOfWork.RepositoryLivroAutor.Adicionar(livro_autor);
            await _unitOfWork.Commit();
            return true;
        }


        private void ClearEntity()
        {
            _unitOfWork.RepositoryLivro.DetachAllEntities();
            _unitOfWork.RepositoryLivroAssunto.DetachAllEntities();
            _unitOfWork.RepositoryLivroAutor.DetachAllEntities();
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

        private async Task<bool> VerificarSeAutorExiste(int codAu)
        {
            var result = await _unitOfWork.RepositoryAutor.BuscarAutorPorId(codAu);
            if (result != null) return true;
            return false;
        }
        private async Task<bool> VerificarSeAssuntoExiste(int codAs)
        {
            var result = await _unitOfWork.RepositoryAssunto.BuscarAssuntoPorId(codAs);
            if (result != null) return true;
            return false;
        }

        private async Task<bool> VerificarSeLivroExiste(int codI)
        {
            var result = await _unitOfWork.RepositoryLivro.BuscarLivroPorId(codI);
            if (result != null) return true;
            return false;
        }

    }
}
