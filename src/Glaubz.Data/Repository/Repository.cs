using Glaubz.Business.Interfaces;
using Glaubz.Business.Models;
using Glaubz.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Glaubz.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new() //O new() indica que o TEntity pode ser criado na classe
    {
        protected readonly MVC_CompletoContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MVC_CompletoContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await Db.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
            //Db.Set<TEntity>() é uma forma de chamar o contexto e manipular o banco. No curso é utilizado o 'protected readonly DbSet<Entity> DbSet' como atalho, para que não fique verboso desta forma e possa ser utilizado o DbSet.
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
