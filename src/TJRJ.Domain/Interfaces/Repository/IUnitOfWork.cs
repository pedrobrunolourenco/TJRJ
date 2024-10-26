namespace TJRJ.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryAssunto RepositoryAssunto { get; }
        IRepositoryAutor RepositoryAutor { get; }
        IRepositoryLivro RepositoryLivro { get; }
        IRepositoryLivroAutor RepositoryLivroAutor { get; }
        IRepositoryLivroAssunto RepositoryLivroAssunto { get; }

        Task Commit();
        Task Rollback();
    }
}
