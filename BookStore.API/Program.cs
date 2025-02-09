using BookStore.Application.Services;
using BookStore.Core.Abstractions;
using BookStore.DataAccess;
using BookStore.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookStoreDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(BookStoreDbContext)));
});
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBooksRepository, BooksRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
