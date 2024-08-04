using Microsoft.OpenApi.Models;
using Tesodev.Shared.Data.Service.CustomerService;
using Tesodev.Shared.Data.Service.OrderService;
using Tesodev.Shared.Data.Service.ProductService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddSwaggerGen(c=> 
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tesodev.API", Version = "v1" }));

var app = builder.Build();

app.MapGet("/", () => "Hello");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tesodev API V1");
});
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.Run();