using System.Threading;
using System.Threading.Tasks;

namespace Fra.Uow
{
    public interface ISupportRollback
    {
        Task RollbackAsync(CancellationToken cancellationToken);
    }
}
