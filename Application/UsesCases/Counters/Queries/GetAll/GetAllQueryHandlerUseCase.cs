using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace Application.UsesCases.Counters.Queries.GetAll
{
    public class GetAllQueryHandlerUseCase : IRequestHandler<GetAllQueryUseCase, IResult>
    {
        private readonly ICounterRepository _counterRepository;
        public GetAllQueryHandlerUseCase(
            ICounterRepository counterRepository)
        {
            _counterRepository = counterRepository;

        }

        public async Task<IResult> Handle(GetAllQueryUseCase request,
            CancellationToken cancellationToken)
        {
            try
            {

                return Results.Ok(await _counterRepository.GetAllAsync());

            }

            catch (Exception ex)
            {
                Log.Error("An unhandled exception has been thrown {0}", ex);
                return Results.BadRequest(new ResultEntity
                {
                    OutMessage = "An error has occurred, please try again later.",
                    OutCode = StatusCodes.Status500InternalServerError.ToString()
                });
            }
        }
    }
}
