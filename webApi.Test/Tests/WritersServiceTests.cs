using Xunit;
using FluentAssertions;
using Moq;
using webApi.DataClasses;
using webApi.DataClasses.Entities;
using webApi.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace webApi.Test;

public class WritersServiceTests
{
    private DataContext context;
    private IWritersService writersService;
    private Mock<IBooksService> booksService;

    private static IEnumerable<object[]> Writers()
    {
        yield return new object[] {
            new WriterCl
            {
                FullName = "Jan Kowalski",
                Country = "Polska",
                DateOfBirth = DateTime.Parse("1955-07-21")
            }};
        yield return new object[] {
            new WriterCl
            {
                FullName = "Zenon Zen",
                Country = "Zanumbia",
                DateOfBirth = DateTime.Parse("1975-05-03")
            }};
        yield return new object[] {
            new WriterCl
            {
                FullName = "Andrzej Andrzejewski",
                Country = "Polska",
                DateOfBirth = DateTime.Parse("1983-10-01")
            }};
    }

    public WritersServiceTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
                  .Options;
        context = new DataContext(options);

        booksService = new Mock<IBooksService>();
        writersService = new WritersService(booksService.Object, context);
    }

    [Theory]
    [MemberData(nameof(Writers))]
    public async void AddWriter_Should_Returns_True(WriterCl writer)
    {
        var result = await writersService.AddWriter(writer);

        result.Should().BeTrue();
    }

    [Fact]
    public void GetWriters_Returns_Three_Writers()
    {
        foreach (var writer in Writers())
        {
            writersService.AddWriter((writer[0] as WriterCl)!);
        }

        var result = writersService.GetWriters();

        result.Should().NotBeNull();
        result!.Length.Should().Be(3);
        result![1].Country.Should().Be("Zanumbia");
    }
}
