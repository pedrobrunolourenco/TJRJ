namespace TJRJ.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryAssunto RepositoryAssunto { get; }
        IRepositoryAutor RepositoryAutor { get; }
        Task Commit();
        Task Rollback();
    }
}
