using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _context;
        private IRepositoryAssunto _repositoryAssunto;
        private IRepositoryAutor _repositoryAutor;
        private IRepositoryLivro _repositoryLivro;
        private IRepositoryLivroAutor _repositoryLivroAutor;
        private IRepositoryLivroAssunto _repositoryLivroAssunto;

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

        public IRepositoryLivro RepositoryLivro
        {
            get { return _repositoryLivro ??= new RepositoryLivro(_context); }
        }

        public IRepositoryLivroAutor RepositoryLivroAutor
        {
            get { return _repositoryLivroAutor ??= new RepositoryLivroAutor(_context); }
        }

        public IRepositoryLivroAssunto RepositoryLivroAssunto
        {
            get { return _repositoryLivroAssunto ??= new RepositoryLivroAssunto(_context); }
        }



        public async Task Commit()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var teste = ex.Message;
            }
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
