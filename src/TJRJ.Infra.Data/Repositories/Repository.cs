using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class Repository<TEntidade> : IRepository<TEntidade> where TEntidade : Entity
    {

        protected DataContext _context;
        protected DbSet<TEntidade> DbSet;

        public Repository(DataContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntidade>();
        }

        public async Task<TEntidade> BuscarId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntidade>> Listar()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Adicionar(TEntidade obj)
        {
            await DbSet.AddAsync(obj);
        }

        public async Task Atualizar(TEntidade obj)
        {
            await Task.Run(() => DbSet.Update(obj));
        }

        public async Task Remover(TEntidade obj)
        {
            await Task.Run(() => DbSet.Remove(obj));
        }

        public async Task Salvar()
        {
            await Task.Run(() => _context.SaveChanges());
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }

}
