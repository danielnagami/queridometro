using FluentValidation.Results;
using Queridometro.Core.Data;
using System.Threading.Tasks;

namespace Queridometro.Core.Messages
{
    public class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string message)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, message));
        }

        protected async Task<ValidationResult> PersistData(IUnitOfWork uow)
        {
            if (!await uow.Commit()) AddError("An error ocurred while persisting data.");

            return ValidationResult;
        }
    }
}