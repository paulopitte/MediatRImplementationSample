using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRImplementationSample.Repositories.Catalog
{
    public class ProductWriteRepository : RepositoryBase<Domain.Catalog.Product>, Domain.Catalog.Repository.IProductRepositoryWrite
    {
        public ProductWriteRepository(IConfiguration configuration)
              : base(configuration)
        { }
       

        public async Task Insert(Domain.Catalog.Product  product, CancellationToken cancellationToken)
          => await Collection.InsertOneAsync(product, cancellationToken: cancellationToken);
    }
}
