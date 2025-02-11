using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using webApi.DataClasses;
using webApi.DataClasses.Entities;
using webApi.Services;
using Xunit;

namespace webApi.Test.Tests;

public class WritersServiceTests
{
    private readonly DataContext _context;
    private readonly IWritersService _writersService;
    private readonly Mock<IBooksService> _booksService;

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
        _context = new DataContext(options);

        _booksService = new Mock<IBooksService>();
        _writersService = new WritersService(_booksService.Object, _context);
    }

    [Theory]
    [MemberData(nameof(Writers))]
    public async void AddWriter_Should_Returns_True(WriterCl writer)
    {
        var result = await _writersService.AddWriter(writer);

        result.Should().BeTrue();
    }

    [Fact]
    public void GetWriters_Returns_Three_Writers()
    {
        foreach (var writer in Writers())
        {
            _writersService.AddWriter((writer[0] as WriterCl)!);
        }

        var result = _writersService.GetWriters();

        result.Should().NotBeNull();
        result!.Length.Should().Be(3);
        result![1].Country.Should().Be("Zanumbia");
    }
}
