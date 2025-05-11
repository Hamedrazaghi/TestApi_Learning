using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Test.application.Service.Implementation;
using Test.application.Service.Interface;
using Test.DataLayer.Context;
using Test.DataLayer.Entitis.Accont;
using Test.DataLayer.Repository;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Test.DataLayer"))
);

    
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

#region Config Services
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
#endregion
builder.Services.AddScoped < IBookService,BookService>();
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
