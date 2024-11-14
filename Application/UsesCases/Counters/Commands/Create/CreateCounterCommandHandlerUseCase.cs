using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Mapster;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;

namespace Application.UsesCases.Counters.Commands.Create
{
    public class CreateCounterCommandHandlerUseCase : IRequestHandler<CreateCounterCommandUseCase, IResult>
    {
        private readonly ICounterRepository _counterRepository;
        public CreateCounterCommandHandlerUseCase(
            ICounterRepository counterRepository)
        {
            _counterRepository = counterRepository;

        }
        public async Task<IResult> Handle(CreateCounterCommandUseCase request, CancellationToken cancellationToken)
        {
            try
            {

                var counter = request.Adapt<Counter>();
                using var memoryStream = new MemoryStream();
                await request.FormData.CopyToAsync(memoryStream);
                 counter.Base64 = Convert.ToBase64String(memoryStream.ToArray());
                await _counterRepository.AddAsync(counter);


                return Results.Ok(new ResultEntity()
                {
                    OutCode = StatusCodes.Status200OK.ToString(),
                    OutMessage = "The Counter saved successfully.",
                });
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
