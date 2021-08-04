using MediatR;
using System.Threading;
using System.Threading.Tasks;
namespace MediatRImplementationSample.Notifications.Catalog
{

    using Insert = Domain.Catalog.Commands.Insert;

    /// <summary>
    /// Recebe um Notificação de Evento
    /// </summary>
    public class ProductEvents : INotificationHandler<Insert.Notification>
    {

        public async Task Handle(Insert.Notification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                //TODO: 
                // REALIZA ALGUMA AÇÃO CONFORME REGRA, EXEMPLO ENVIO DE EMAIL,SMS, COLOCA EM UMA FILA, ETC.....
                
                var title = notification.Title;
                

                
            }, cancellationToken);
        }
    }
}
