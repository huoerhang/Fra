using Fra.Domain.Entities;
using System.Linq;

namespace Fra.Data.Filter
{
    public interface IDataFilterProcesser
    {
        IQueryable<TEntity> Process<TEntity>(IQueryable<TEntity> query,IDataFilter dataFilter)
            where TEntity : IEntity;
    }
}
