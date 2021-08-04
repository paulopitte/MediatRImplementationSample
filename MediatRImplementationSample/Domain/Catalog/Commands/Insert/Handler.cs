using MediatR;
using MediatRImplementationSample.Domain.Catalog.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRImplementationSample.Domain.Catalog.Commands.Insert
{
    public class Handler : IRequestHandler<Request, Result>
    {
        private readonly IMediator _mediator;
        private readonly Repository.IProductRepositoryReadOnly _productRepositoryReadOnly;
        private readonly Repository.IProductRepositoryWrite _productRepositoryWrite;

        public Handler(IMediator mediator, IProductRepositoryReadOnly productRepositoryReadOnly, IProductRepositoryWrite productRepositoryWrite)
        {
            _mediator = mediator;
            _productRepositoryReadOnly = productRepositoryReadOnly;
            _productRepositoryWrite = productRepositoryWrite;
        }

        public async Task<Result> Handle(Request request, CancellationToken cancellationToken)
        {

            var product = new Domain.Catalog.Product(request.Title, request.SalePrice);
            await _productRepositoryWrite.Insert(product, cancellationToken);

            await _mediator.Publish(new Notification
            {
               Id = product.Id,
               Title = product.Title,
               SalePrice = product.SalePrice,
               CreateAt = product.CreateAt,
               Status = product.Status
            }, cancellationToken);

            return Result.Ok;
        }
    }
}
