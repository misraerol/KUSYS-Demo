using KUSYS_Demo.DAL;
using KUSYS_Demo.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KUSYS_Demo.Repository
{
    public class EntityRepositoryBase<TEntity> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
    {
        private readonly AppDbContext _context;

        public EntityRepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {

            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();

        }

        public void Delete(TEntity entity)
        {

            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {

            return _context.Set<TEntity>().SingleOrDefault(filter);


        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null ?
                 _context.Set<TEntity>().ToList() :
                 _context.Set<TEntity>().Where(filter).ToList();

        }

        public void Update(TEntity entity)
        {

            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();

        }
    }
}
