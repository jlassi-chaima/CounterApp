using Application;
using Domain.Interfaces;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;

namespace Infrastructure
{
    public static class Extensions
    {
        public static void AddCounterMgtInfrastructure(
            this WebApplicationBuilder builder,
            IConfiguration configuration
        )
        {
            builder.Services.AddControllers();
            var applicationAssembly = typeof(ApplicationAssembly).Assembly;
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(o => o.RegisterServicesFromAssembly(applicationAssembly));
            builder.Services.AddTransient<ICounterRepository, CounterRepository>();
            builder.Services.AddDbContext<CounterDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}