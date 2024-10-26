using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TJRJ.Application.Interfaces;
using TJRJ.Application.Services;
using TJRJ.Domain.Commands;
using TJRJ.Domain.Core.Mediator;
using TJRJ.Domain.Core.Messages.CommonMessages;
using TJRJ.Domain.Interfaces.Repository;
using TJRJ.Domain.Interfaces.Service;
using TJRJ.Domain.Services;
using TJRJ.Infra.Data;
using TJRJ.Infra.Data.Repositories;

namespace TJRJ.Ioc
{
    public static class DependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediatr
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            // notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Assunto
            services.AddScoped<IAppAssunto, AppAssunto>();
            services.AddScoped<IServiceAssunto, ServiceAssunto>();
            services.AddScoped<IRepositoryAssunto, RepositoryAssunto>();

            // Autor
            services.AddScoped<IAppAutor, AppAutor>();
            services.AddScoped<IServiceAutor, ServiceAutor>();
            services.AddScoped<IRepositoryAutor, RepositoryAutor>();

            // Livro
            services.AddScoped<IRequestHandler<AdicionarLivroCommand, bool>, LivroCommandHandler>();
            services.AddScoped<IRepositoryLivro, RepositoryLivro>();
            services.AddScoped<IRepositoryLivroAutor, RepositoryLivroAutor>();
            services.AddScoped<IRepositoryLivroAssunto, RepositoryLivroAssunto>();

            // outros
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DataContext>();
        }

    }
}
