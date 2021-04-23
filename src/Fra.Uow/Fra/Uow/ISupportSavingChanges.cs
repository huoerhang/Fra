using System.Threading;
using System.Threading.Tasks;

namespace Fra.Ddd.Uow
{
    public interface ISupportSavingChanges
    {
        Task SavingChanges(CancellationToken cancellationToken); 
    }
}
