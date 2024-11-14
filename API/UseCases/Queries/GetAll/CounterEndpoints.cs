using Application.UsesCases.Counters.Queries.GetAll;
using Domain.Dtos;
using Domain.Entities;
using MediatR;

namespace API.UseCases.Queries.GetAll
{
    public static class CounterEndpoints
    {
        public static void MapGetAllCounterEndpoints(this IEndpointRouteBuilder app)
        {
            _ = app.MapGet("counter", GetAllCounter)
                .Produces<List<Counter>>()
                .Produces<ResultEntity>(StatusCodes.Status400BadRequest)
                .Produces<ResultEntity>(StatusCodes.Status404NotFound)
                .Produces<ResultEntity>(StatusCodes.Status500InternalServerError)
                .WithTags("Counter")
                .WithSummary("Retrieves all counter")
                .WithDescription("Retrieves all counter")
                .WithName("GetAllCounter");
        }

        public static async Task<IResult> GetAllCounter(IMediator mediator)

        {
            try
            {
                return await mediator.Send(new GetAllQueryUseCase());
            }

            catch
            {

                throw;
            }
        }
    }
}
