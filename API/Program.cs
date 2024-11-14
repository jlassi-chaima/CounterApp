using API.UseCases.Commands.Create;
using API.UseCases.Queries.GetAll;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.AllowAnyOrigin()    
             .AllowAnyHeader()    
             .AllowAnyMethod();                 
    });
});
// Register services with the custom extension method
builder.AddCounterMgtInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowLocalhost");
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


