using AutoMapper;
using MediatR;
using TJRJ.Application.Interfaces;
using TJRJ.Application.Model;
using TJRJ.Domain.Commands;
using TJRJ.Domain.Core.Mediator;
using TJRJ.Domain.Core.Messages.CommonMessages;

namespace TJRJ.Application.Services
{
    public class AppLivro : IAppLivro
    {

        private readonly DomainNotificationHandler _notifications;

        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatrHandler;

        public AppLivro(IMapper mapper,
                 INotificationHandler<DomainNotification> notifications,
                 IMediatrHandler mediatrHandler)
        {
            _mapper = mapper;
            _notifications = (DomainNotificationHandler)notifications;
            _mediatrHandler = mediatrHandler;
        }



        public async Task<LivroRetornoModel> IncluirLivro(LivroModel livro)
        {

            var command = new AdicionarLivroCommand(livro.CodI, livro.Titulo, livro.Editora, livro.Edicao, livro.AnoPublicacao, livro.CodigoAssunto, livro.CodigoAutor);
            await _mediatrHandler.EnviarCommand(command);
            var livroRetorno = new LivroRetornoModel();
            livroRetorno.Livro = livro;
            livroRetorno.ListaErros = ObterMensagensDeErro();
            return livroRetorno;
        }

        public async Task<LivroRetornoModel> AlterarLivro(LivroModel livro)
        {
            var command = new AlterarLivroCommand(livro.CodI, livro.Titulo, livro.Editora, livro.Edicao, livro.AnoPublicacao, livro.CodigoAssunto, livro.CodigoAutor);
            await _mediatrHandler.EnviarCommand(command);
            var livroRetorno = new LivroRetornoModel();
            livroRetorno.Livro = livro;
            livroRetorno.ListaErros = ObterMensagensDeErro();
            return livroRetorno;
        }



        protected bool OperacaoValida()
        {
            return (!_notifications.TemNotificacao());
        }

        protected List<string> ObterMensagensDeErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Value).ToList();
        }

        protected void NotificarErros(string codigo, string mensagem)
        {
            _mediatrHandler.PublicarNotificacao(new DomainNotification(codigo, mensagem));
        }

    }
}
