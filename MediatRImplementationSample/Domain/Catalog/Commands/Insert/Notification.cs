using MediatR;
using System;

namespace MediatRImplementationSample.Domain.Catalog.Commands.Insert
{
    public class Notification : INotification
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal SalePrice { get; set; }
        public DateTime CreateAt { get; set; }
        public Status Status { get; set; }

        public override string ToString() => $"Novo produto inserido: Titulo {Title} no dia {CreateAt} no valor de R${SalePrice}";
    }
}
