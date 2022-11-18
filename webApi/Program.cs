using webApi.Services;
using webApi.DataClasses.Validators;
using webApi.DataClasses.Entities;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IWritersService, WritersService>();
builder.Services.AddTransient<IBooksService, BooksService>();
builder.Services.AddSingleton<IValidator<WriterCl>, WriterClValidator>();
builder.Services.AddSingleton<IValidator<Writer>, WriterValidator>();
builder.Services.AddSingleton<IValidator<BookCl>, BookClValidator>();
builder.Services.AddSingleton<IValidator<Book>, BookValidator>();

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
