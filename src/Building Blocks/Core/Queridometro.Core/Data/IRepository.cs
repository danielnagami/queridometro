using Queridometro.Core.DomainObjects;

namespace Queridometro.Core.Data
{
    public interface IRepository<T> : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
