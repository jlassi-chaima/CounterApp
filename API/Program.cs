using API.UseCases.Commands.Create;
using API.UseCases.Queries.GetAll;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register services with the custom extension method
builder.AddCounterMgtInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Map controllers to route endpoints
app.MapControllers();

// Additional routes or route groups if needed
var group = app.MapGroup("/").DisableAntiforgery();
group.MapCreateCounterEndpoints();
group.MapGetAllCounterEndpoints();
app.Run();


