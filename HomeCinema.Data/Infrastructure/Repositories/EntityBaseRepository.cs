using HomeCinema.Core;
using HomeCinema.Core.Data;
using HomeCinema.Data.Infrastructure.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Data.Infrastructure.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : BaseEntity
    {
        #region fields
        private readonly IHomeCinemaDbContext context;
        private DbSet<T> entities;
        #endregion fields

        #region constructor
        public EntityBaseRepository(IHomeCinemaDbContext context)
        {
            this.context = context;
        }
        #endregion constructor

        #region Properties
        protected string NotFoundMessage { get { return "The resource you are trying to update does not exist."; } }
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                    entities = context.Set<T>();
                return entities;
            }
        }
        #endregion Properties

        #region IEntityBaseRepository
        public void Add(T entity)
        {
            Guard.ArgumentIsNotNull(entity, "entity cannot be null.");
            Entities.Add(entity);
        }        

        public void Edit(T entity)
        {
            Guard.ArgumentIsNotNull(entity, "entity cannot be null.");

            var dbEntity = FindBy(e => e.Id == entity.Id).FirstOrDefault();
            if (dbEntity == null)
                throw new Exception(NotFoundMessage);

            entity.CreatedBy = dbEntity.CreatedBy;
            entity.CreatedDate = dbEntity.CreatedDate;

            var entry = context.Entry<T>(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            Guard.ArgumentIsNotNull(entity, "entity cannot be null.");

            var dbEntity = FindBy(e => e.Id == entity.Id).FirstOrDefault();
            if (dbEntity == null)
                throw new Exception(NotFoundMessage);

            dbEntity.Deleted = true;
            context.Entry<T>(dbEntity).State = EntityState.Modified;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return Entities;
        }

        public Task<T> GetSingleAsync(int id)
        {
            return Entities.SingleAsync(e => e.Id == id && e.Deleted == false);
        }

        public T GetSingle(int id)
        {
            return Entities.Single(e => e.Id == id && e.Deleted == false);
        }

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Entities;
            foreach (var includeProperty in includeProperties)
            {
                query.Include(includeProperty);
            }
            return query;
        }
        #endregion IEntityBaseRepository
    }
}
