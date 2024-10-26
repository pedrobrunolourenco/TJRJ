using TJRJ.Domain.Core.Messages;
using TJRJ.Domain.Core.Messages.CommonMessages;


namespace TJRJ.Domain.Core.Mediator
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarCommand<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
    }
}
