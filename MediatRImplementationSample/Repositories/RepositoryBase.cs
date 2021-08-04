using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace MediatRImplementationSample.Repositories
{
    public abstract class RepositoryBase<TCollection>
    {
        protected IMongoDatabase Database { get; }
        protected IMongoCollection<TCollection> Collection { get; }

        public RepositoryBase(IConfiguration configuraton)
        {
            var conectionString = configuraton.GetConnectionString("CosmosDB");
            MongoClient client = new(conectionString);

            Database = client.GetDatabase("Products");
            Collection = Database.GetCollection<TCollection>(typeof(TCollection).Name);
        }
    }

    //internal static class MongoExtensions
    //{
    //    public static IFindFluent<Product, Product> Sort(this IFindFluent<Product, Product> findFluent, ISortable sort, Func<SortField, Expression<Func<Product, object>>> sortItemIteract)
    //    {
    //        if (sort?.SortField != null)
    //        {
    //            var exp = sortItemIteract(sort.SortField);
    //            if (exp != null)
    //            {
    //                if (sort.SortField.IsDescending ?? false)
    //                {
    //                    findFluent.Sort(Builders<Product>.Sort.Descending(exp));
    //                }
    //                else
    //                {
    //                    findFluent.Sort(Builders<Product>.Sort.Ascending(exp));
    //                }
    //            }
    //        }

    //        return findFluent;
    //    }

    //    public static IFindFluent<Product, Product> Paginate(this IFindFluent<Product, Product> findFluent, IPaginable paginable)
    //    {
    //        if (paginable != null)
    //        {
    //            findFluent
    //                .Skip(paginable.Pagination.ItemStartIndex)
    //                .Limit(paginable.Pagination.PageSize);
    //        }

    //        return findFluent;
    //    }
    //}

}
