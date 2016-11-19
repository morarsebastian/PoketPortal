using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace PoketPortal.EntityFramework.Repositories
{
    public abstract class PoketPortalRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<PoketPortalDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected PoketPortalRepositoryBase(IDbContextProvider<PoketPortalDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class PoketPortalRepositoryBase<TEntity> : PoketPortalRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected PoketPortalRepositoryBase(IDbContextProvider<PoketPortalDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
