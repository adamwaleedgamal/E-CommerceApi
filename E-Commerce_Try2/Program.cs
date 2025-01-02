using E_Commerce_Try2.AppDbContext;
using E_Commerce_Try2.Repositorys.RepoCard;
using E_Commerce_Try2.Repositorys.RepoCustomer;
using E_Commerce_Try2.Repositorys.RepoOrder;
using E_Commerce_Try2.Repositorys.RepoProducts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration.GetConnectionString("myconnection");
builder.Services.AddDbContext<dbcontext>(options => options.UseSqlServer(connection));

builder.Services.AddControllers();

builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IProductsRepo, ProductRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<ICardRepo, CardRepo>();


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
