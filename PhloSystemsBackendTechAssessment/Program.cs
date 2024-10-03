using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PhloSystemsBackendTechAssessment.ProductRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration configuration = builder.Configuration; // Access IConfiguration from the builder
builder.Services.AddControllers();
builder.Services.AddHttpClient<IProductService, ProductService>(); // Register the service
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

