using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRImplementationSample.Domain.Catalog.Repository
{
    public interface IProductRepositoryReadOnly
    {        
        Task<Product> GetByCode(Guid id, CancellationToken cancellationToken);        
        Task<IEnumerable<Product>> GetAll(Status status,  CancellationToken cancellationToken);
    }

    public interface IProductRepositoryWrite
    {
        Task Insert(Product product, CancellationToken cancellationToken);
    }


}
