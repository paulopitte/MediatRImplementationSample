using System;

namespace MediatRImplementationSample.Domain.Catalog
{
    public class Product
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Title { get; private set; }

        public decimal SalePrice { get; private set; }

        public DateTime CreateAt { get; set; } = DateTime.UtcNow.AddHours(-3);

        public Status Status { get; set; }
        public Product(string title, decimal salePrice)
        {
            Title = title;
            SalePrice = salePrice;
            SetStatus(Status.Ativo);
        }


        public void SetStatus(Status value) =>        
            this.Status = value;
       
    }
}
