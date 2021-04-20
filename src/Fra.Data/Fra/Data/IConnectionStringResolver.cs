using System.Threading.Tasks;

namespace Fra.Data
{
    public interface IConnectionStringResolver
    {
        Task<string> ResolveAsync(string connectionStringName = null);
    }
}
