using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Minh.EntityFramework.Repositories
{
    public abstract class MinhRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<MinhDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MinhRepositoryBase(IDbContextProvider<MinhDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class MinhRepositoryBase<TEntity> : MinhRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MinhRepositoryBase(IDbContextProvider<MinhDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
