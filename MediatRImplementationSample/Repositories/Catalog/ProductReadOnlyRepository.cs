using MediatRImplementationSample.Domain.Catalog;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRImplementationSample.Repositories.Catalog
{
    public class ProductReadOnlyRepository : RepositoryBase<Domain.Catalog.Product>, Domain.Catalog.Repository.IProductRepositoryReadOnly
    {

        public ProductReadOnlyRepository(IConfiguration configuration) 
            : base(configuration)
        { }

        public async Task<IEnumerable<Product>> GetAll(Status status, CancellationToken cancellationToken)
        {
            var filter = Builders<Domain.Catalog.Product>.Filter.Eq(s => s.Status, status);
            return await Collection.Find(filter).ToListAsync(cancellationToken);

        }

   
        public async Task<Product> GetByCode(Guid id, CancellationToken cancellationToken)
        {
            var filter = Builders<Domain.Catalog.Product>.Filter.Eq(s => s.Id, id);
            var result = await Collection.Find(filter).ToListAsync(cancellationToken).ConfigureAwait(false);
            return result.FirstOrDefault();
        }




    }
}
