using ProductCommon = FutureComputer.Application.Products.Common.CommonConstant;
using FutureComputer.Domain.Entities;
using FutureComputer.Domain.Interfaces;
using MediatR;

namespace FutureComputer.Application.Categories.CategoriesOfTheMonth;

public class GetCategoriesOfTheMonthHandler : IRequestHandler<GetCategoriesOfTheMonthQuery, object>
{
    private readonly IRepository<Category> _repository;

    public GetCategoriesOfTheMonthHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<object> Handle(GetCategoriesOfTheMonthQuery request, CancellationToken cancellationToken)
    {
        var folderServerName = Path.Combine("Resources", ProductCommon.FOLDER_NAME);

        var filter = new GetCategoriesOfTheMonthSpecification();
        var lstFromDb = await _repository.ListAsync(filter, cancellationToken);

        var lstRespone = lstFromDb.Select(x => new
        {
            x.Name,
            Path = Path.Combine(folderServerName, x.Products[0].ImageUrls)
        });
        return lstRespone;

    }
}
