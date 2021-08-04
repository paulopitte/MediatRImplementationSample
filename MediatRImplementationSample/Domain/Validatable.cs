using Flunt.Notifications;
using Flunt.Validations;

namespace MediatRImplementationSample.Domain
{
    public abstract class Validatable : Notifiable, IValidatable
    {
        public abstract void Validate();
    }
}
