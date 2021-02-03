using FluentValidation.Results;
using Queridometro.Core.DomainObjects;
using Queridometro.Core.Messages;
using System.Threading.Tasks;

namespace Queridometro.Core.MediatorHandler
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}