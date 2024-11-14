using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.UsesCases.Counters.Queries.GetAll
{
    public class GetAllQueryUseCase : IRequest<IResult>
    {
    }
}
