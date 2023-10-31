using ExWebComputer.Data;
using ExWebComputer.Repositories;
using ExWebComputer.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//จัดการกับการเชื่อมต่อกับฐานข้อมูล
builder.Services.AddDbContext<AppDbcontext>(option =>{
    //การเชื่อมต่อกับฐานข้อมูล SQL Server โดยใช้ Connection String
    option.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddScoped<IProductRepositories, ProductRepositories>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IEmployeeRepositories, EmployeeRepositories>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
