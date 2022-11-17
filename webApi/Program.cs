using webApi.Services;
using webApi.DataClasses.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<WritersService>();
builder.Services.AddTransient<BooksService>();
builder.Services.AddSingleton<WriterClValidator>();
builder.Services.AddSingleton<WriterValidator>();
builder.Services.AddSingleton<BookClValidator>();
builder.Services.AddSingleton<BookValidator>();

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
