using Microsoft.EntityFrameworkCore;
using RespawnTester.Domain.Interfaces;
using RespawnTestes.Infrastructure.Data;
using System.Linq.Expressions;

namespace RespawnTester.Infrastructure.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    internal DataContext context;
    internal DbSet<TEntity> dbSet;

    public Repository(DataContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context)); 
        this.dbSet = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();

        return await query.ToListAsync();
    }

    public virtual async Task<TEntity> GetByID(object id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual async Task Insert(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task Delete(object id)
    {
        TEntity entityToDelete = await dbSet.FindAsync(id);

        if (entityToDelete != null)
            await Delete(entityToDelete);
    }

    public virtual async Task Delete(TEntity entityToDelete)
    {
        await Task.Run(() =>
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
                dbSet.Attach(entityToDelete);

            dbSet.Remove(entityToDelete);
        });
    }

    public virtual async Task Update(TEntity entityToUpdate)
    {
        await Task.Run(() =>
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        });
        await context.SaveChangesAsync();
    }
}
