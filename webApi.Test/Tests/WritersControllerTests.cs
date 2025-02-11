using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using webApi.Controllers;
using webApi.DataClasses.Entities;
using webApi.Services;
using Xunit;

namespace webApi.Test.Tests;

public class WritersControllerTests
{
    private readonly WritersController _controller;
    //private Mock<IBooksService> booksService;
    private readonly Mock<IWritersService> _writersService;
    private readonly Mock<IValidator<WriterCl>> _clValidator;
    private readonly Mock<IValidator<Writer>> _validator;

    public WritersControllerTests()
    {
        _writersService = new Mock<IWritersService>();
        _clValidator = new Mock<IValidator<WriterCl>>();
        _validator = new Mock<IValidator<Writer>>();
        _controller = new WritersController(_writersService.Object, _clValidator.Object, _validator.Object);
    }

    [Fact]
    public async void AddWriter_Should_Return_OkObjectResult()
    {
        WriterCl writer = new WriterCl()
        {
            FullName = "Jan Kowalski",
            Country = "Polska",
            DateOfBirth = new DateTime(1975, 11, 11)
        };

        _writersService.Setup(x => x.AddWriter(It.IsAny<WriterCl>())).ReturnsAsync(true);

        _clValidator.Setup(x => x.Validate(It.IsAny<WriterCl>()))
                    .Returns(new ValidationResult()
                    {
                        Errors = new List<ValidationFailure>()
                    });


        var actionResult = await _controller.AddWriter(writer);

        actionResult.Should().NotBeNull();

        var result = actionResult as ObjectResult;

        result.Should().NotBeNull().And.BeOfType<OkObjectResult>();
    }
}
