using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.UsesCases.Counters.Commands.Create
{
    public class CreateCounterCommandUseCase : IRequest<IResult>
    {
        
        [Required]
        public required IFormFile FormData { get; set; }

        [Required]
        public required double Value { get; set; }

        [Required]
        public required bool? IsSubscribed { get; set; }
    }
}

