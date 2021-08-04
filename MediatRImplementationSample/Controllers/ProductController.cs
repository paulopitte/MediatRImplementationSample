using MediatR;
using MediatRImplementationSample.Domain.Catalog.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRImplementationSample.Controllers
{
    public class ProductController : Controller
    {

        private readonly IMediator _mediator;
        private readonly Domain.Catalog.Repository.IProductRepositoryReadOnly _productRepositoryReadOnly;

        public ProductController(IMediator mediator, IProductRepositoryReadOnly productRepositoryReadOnly)
        {
            _mediator = mediator;
            _productRepositoryReadOnly = productRepositoryReadOnly;
        }


        public async Task<IActionResult> Index()
        {
            var products =
                await _productRepositoryReadOnly.GetAll(Domain.Catalog.Status.Ativo, CancellationToken.None);

            return View(products);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Domain.Catalog.Commands.Request request)
        {
            Domain.Result result = await _mediator.Send(request, CancellationToken.None);
            return ValidationHandler(request, result, "Index");
        }

        private IActionResult ValidationHandler<TCommand>(TCommand command, Domain.Result result, string redirectAction)
        {
            if (!result.HasValidation)
            {
                return RedirectToAction(redirectAction);
            }

            foreach (string validation in result.Validations)
                ModelState.AddModelError("", validation);

            return View(command);
        }

    }
}
