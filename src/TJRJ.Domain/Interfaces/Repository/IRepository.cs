﻿using TJRJ.Domain.Entities;

namespace TJRJ.Domain.Interfaces.Repository
{
    public interface IRepository<TEntidade> : IDisposable where TEntidade : Entity
    {
        void DetachAllEntities();
        Task<IEnumerable<TEntidade>> Listar();
        Task Adicionar(TEntidade obj);
        Task Atualizar(TEntidade obj);
        Task Remover(TEntidade obj);
    }
}
