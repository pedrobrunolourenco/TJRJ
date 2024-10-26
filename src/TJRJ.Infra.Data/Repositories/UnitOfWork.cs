using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _context;
        private IRepositoryAssunto _repositoryAssunto;
        private IRepositoryAutor _repositoryAutor;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IRepositoryAssunto RepositoryAssunto
        {
            get { return _repositoryAssunto ??= new RepositoryAssunto(_context); }
        }

        public IRepositoryAutor RepositoryAutor
        {
            get { return _repositoryAutor ??= new RepositoryAutor(_context); }
        }


        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
