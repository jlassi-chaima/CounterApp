using Application.UsesCases.Counters.Commands.Create;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.UseCases.Commands.Create
{
    public static class CounterEndpoints
    {

        public static void MapCreateCounterEndpoints(this IEndpointRouteBuilder app)
        {
            _ = app.MapPost("counters", CreateCounter)
                //.AddEndpointFilter<ValidationFilter<CreateCustomFieldCommandUseCase>>()
                .Produces<ResultEntity>()
                .Produces<ResultEntity>(StatusCodes.Status400BadRequest)
                .Produces<ResultEntity>(StatusCodes.Status500InternalServerError)
                .WithTags("Counter")
                .WithSummary("Creates a counter")
                .WithDescription("Creates a counter")
                .WithName("CreateCounter");
        }

        public static async Task<IResult> CreateCounter(IMediator mediator,
           [FromForm]  CreateCounterCommandUseCase command)
        {
            try
            {
             
                return await mediator.Send(command);
            }

            catch
            {

                throw;
            }
        }
    }
}

