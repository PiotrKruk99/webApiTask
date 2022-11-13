using Xunit;
using FluentAssertions;
using Moq;
using webApi.Services;
using webApi.DataClasses;
using Microsoft.EntityFrameworkCore;

namespace webApi.Test;

public class DataServiceTests
{
    // private Mock<DataContext> _context;
    // private DataService service;

    // public DataServiceTests()
    // {
    //     var options = new Mock<DbContextOptions<DataContext>>();
    //     _context = new Mock<DataContext>(options);
    //     service = new DataService(_context.Object);
    // }

    // [Fact]
    // public void AddWriter_ReturnTrue()
    // {
    //     var result = service.AddWriter();
    //     result.Should().BeTrue();
    // }
}
