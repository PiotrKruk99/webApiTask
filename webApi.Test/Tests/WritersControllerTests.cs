using System;
using Xunit;
using FluentAssertions;
using Moq;
using webApi.Services;
using webApi.DataClasses.Validators;
using webApi.DataClasses.Entities;
using webApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace webApi.Test;

public class WritersControllerTests
{
    private WritersController controller;
    private Mock<BooksService> booksService;
    private Mock<WritersService> writersService;
    private Mock<WriterClValidator> clValidator;
    private Mock<WriterValidator> validator;

    public WritersControllerTests()
    {
        booksService = new Mock<BooksService>();
        writersService = new Mock<WritersService>(booksService.Object);
        clValidator = new Mock<WriterClValidator>();
        validator = new Mock<WriterValidator>();
        controller = new WritersController(writersService.Object, clValidator.Object, validator.Object);
    }

    [Fact]
    public async void AddWriter_ShouldReturnOkResult()
    {
        WriterCl writer = new WriterCl()
        {
            FullName = "Jan Kowalski",
            Country = "Polska",
            DateOfBirth = new DateTime(1975, 11, 11)
        };

        writersService.Setup(x => x.AddWriter(It.IsAny<WriterCl>()))
                .ReturnsAsync(true);

        var actionResult = await controller.AddWriter(writer);

        actionResult.Should().NotBeNull();

        var result = actionResult as ObjectResult;

        result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
    }
}
