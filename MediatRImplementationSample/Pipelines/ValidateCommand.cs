using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRImplementationSample.Pipelines
{
    public class ValidateCommand<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : Domain.Result
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (request is Domain.Validatable validate)
            {
                validate.Validate();
                if (validate.Invalid)
                {
                    Domain.Result validations = new Domain.Result();
                    foreach (Flunt.Notifications.Notification notification in validate.Notifications)                    
                        validations.AddValidation(notification.Message);

                    return validations as TResponse;
                }
            }
            return await next();
        }
    }
}
