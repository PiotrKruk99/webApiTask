using Xunit;
using FluentAssertions;
using FluentValidation.Results;
using webApi.DataClasses.Validators;
using webApi.DataClasses.Entities;
using System;

namespace webApi.Test;

public class WriterClValidatorTests
{
    private WriterClValidator validator;

    public WriterClValidatorTests()
    {
        validator = new WriterClValidator();
    }

    [Fact]
    public void Validate_ShouldReturnNoErrors()
    {
        WriterCl writer = new WriterCl()
        {
            FullName = "Jan Kowalski",
            Country = "Polska",
            DateOfBirth = new DateTime(1977, 3, 1)
        };

        ValidationResult result = validator.Validate(writer);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_ShouldReturnErrors()
    {
        WriterCl writer = new WriterCl()
        {
            FullName = "",
            Country = "",
            DateOfBirth = new DateTime(1977, 3, 1)
        };

        ValidationResult result = validator.Validate(writer);

        result.IsValid.Should().BeFalse();
        result.Errors.Count.Should().BeGreaterThan(0);
    }
}
