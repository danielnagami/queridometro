using System.Threading.Tasks;

namespace Queridometro.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}