using MediatR;
using System;

namespace MediatRImplementationSample.Domain.Catalog.Commands
{
    public class Request : Validatable, IRequest<Result>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal SalePrice { get; set; }

        public override void Validate()
        {   

            if (true.Equals(string.IsNullOrEmpty(Title)))
                AddNotification("Título", "Titudo do Produto está sem preencher.");

            if (SalePrice <= 0)
                AddNotification("Valor", "Valor inválido");

        }
    }
}
