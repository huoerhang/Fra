using System.Threading;
using System.Threading.Tasks;

namespace Fra.Ddd.Uow
{
    public interface ISupportRollback
    {
        Task RollbackAsync(CancellationToken cancellationToken);
    }
}
