﻿using AutoMapper;
using MediatR;
using TJRJ.Application.Interfaces;
using TJRJ.Application.Model;
using TJRJ.Domain.Commands;
using TJRJ.Domain.Core.Mediator;
using TJRJ.Domain.Core.Messages.CommonMessages;
using TJRJ.Domain.DTOs;
using TJRJ.Domain.Queries;

namespace TJRJ.Application.Services
{
    public class AppLivro : IAppLivro
    {

        private readonly DomainNotificationHandler _notifications;

        private readonly IMapper _mapper;
        private readonly IMediatrHandler _mediatrHandler;
        private readonly ILivroQuery _livroQuery;
        public AppLivro(IMapper mapper,
                 INotificationHandler<DomainNotification> notifications,
                 IMediatrHandler mediatrHandler,
                 ILivroQuery livroQuery)
        {
            _mapper = mapper;
            _notifications = (DomainNotificationHandler)notifications;
            _mediatrHandler = mediatrHandler;
            _livroQuery = livroQuery;
        }


        public async Task<IEnumerable<LivroDto>> ObterTodosOsLivros()
        {
            return await _livroQuery.ObterTodosOsLivros();
        }

        public async Task<LivroDto> ObterLivroPorId(int codLivro)
        {
            return await _livroQuery.ObterLivroPorId(codLivro);
        }

        public async Task<IEnumerable<AssuntoDto>> ObterAssuntosDoLivro(int codLivro)
        {
            return await _livroQuery.ObterAssuntosDoLivro(codLivro);
        }

        public async Task<IEnumerable<AutorDto>> ObterAutoresDoLivro(int codLivro)
        {
            return await _livroQuery.ObterAutoresDoLivro(codLivro);
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

        public async Task<LivroAutorRetornoModel> IncluirAutor(LivroAutorModel livroAutor)
        {
            var command = new AdicionarAutorCommand(livroAutor.Livro_CodI, livroAutor.Autor_CodAu);
            await _mediatrHandler.EnviarCommand(command);
            var livroAutorRetorno = new LivroAutorRetornoModel();
            livroAutorRetorno.LivroAutor = livroAutor;
            livroAutorRetorno.ListaErros = ObterMensagensDeErro();
            return livroAutorRetorno;
        }
        public async Task<LivroRetornoModel> AlterarLivro(LivroAlteracaoModel livro)
        {
            var command = new AlterarLivroCommand(livro.CodI, livro.Titulo, livro.Editora, livro.Edicao, livro.AnoPublicacao, livro.CodigoAssunto);
            await _mediatrHandler.EnviarCommand(command);
            var livroRetorno = new LivroRetornoModel();
            livroRetorno.Livro = new LivroModel
            {
                CodI = livro.CodI,
                Titulo = livro.Titulo,
                Editora = livro.Editora,
                Edicao = livro.Edicao,
                AnoPublicacao = livro.AnoPublicacao
            };
            livroRetorno.ListaErros = ObterMensagensDeErro();
            return livroRetorno;
        }

        public async Task<LivroRetornoModel> ExcluirLivro(int codLivro)
        {
            var command = new ExcluirLivroCommand(codLivro);
            await _mediatrHandler.EnviarCommand(command);
            var livroRetorno = new LivroRetornoModel();
            livroRetorno.Livro = new LivroModel
            {
                CodI = codLivro,
            };
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
