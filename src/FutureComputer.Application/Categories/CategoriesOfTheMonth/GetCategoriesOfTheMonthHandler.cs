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
        var filter = new GetCategoriesOfTheMonthSpecification();
        var lstFromDb = await _repository.ListAsync(filter, cancellationToken);

        return lstFromDb;

    }
}
