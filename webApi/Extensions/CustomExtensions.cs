using FluentValidation;
using webApi.DataClasses;
using webApi.DataClasses.Validators;
using webApi.DataClasses.Entities;
using Microsoft.EntityFrameworkCore;

namespace webApi.Extensions;

public static class CustomExtensions
{
    public static IServiceCollection AdditionalServices(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddDbContextPool<DataContext>(x => x.UseSqlite($@"Data Source={DataContext.DbPath}"));
        //services.AddDbContext<DataContext>();
        services.AddSingleton<IValidator<WriterCl>, WriterClValidator>();
        services.AddSingleton<IValidator<Writer>, WriterValidator>();
        services.AddSingleton<IValidator<BookCl>, BookClValidator>();
        services.AddSingleton<IValidator<Book>, BookValidator>();

        return services;
    }
}