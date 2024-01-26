using FluentAssertions;
using Newtonsoft.Json.Linq;

namespace SharedKernel.UnitTests;

public class ResultTests
{
    [Fact]
    public void GenericResult_Success_WithValue()
    {
        // Arrange
        const bool value = true;

        // Act
        var result = Result.Success(value);

        // Assert
        result.Errors.Should().BeNull();
        result.Status.Should().Be(ResultStatus.Ok);
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Value.Should().Be(value);
    }

    [Fact]
    public void GenericResult_Success_WithNullValue()
    {
        // Arrange

        // Act
        var result = Result<bool?>.Success(null);

        // Assert
        result.Errors.Should().BeNull();
        result.Status.Should().Be(ResultStatus.Ok);
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Value.Should().BeNull();
    }

    [Fact]
    public void GenericResult_Failure_ErrorEnumNotFound()
    {
        // Arrange

        // Act
        var result = Result<bool?>.Failure(ErrorEnum.NotFound);

        // Assert
        result.Errors.Should().ContainSingle().Which.Should().Be(ErrorEnum.NotFound);
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Value.Should().BeNull();
    }

    private class TestType;

    [Fact]
    public void GenericResult_operatorT_ResultT()
    {
        // Arrange
        var value = new TestType();
        var result = Result.Success(value);

        // Act
        var converted = (TestType)result;

        // Assert
        converted.Should().Be(value);
    }

    [Fact]
    public void GenericResult_operatorResultT_Value()
    {
        // Arrange
        var value = new TestType();
        var result = Result.Success(value);

        // Act
        var converted = (Result<TestType>)value;

        // Assert
        converted.Should().BeEquivalentTo(result);
    }

    [Fact]
    public void GenericResult_operatorResultT_Result()
    {
        // Arrange
        var result = Result.Success();

        // Act
        var converted = (Result<TestType>)result;

        // Assert
        converted.Should().BeEquivalentTo(result);
        converted.Value.Should().BeNull();
        converted.GetType().Should().Be(typeof(Result<TestType>));
    }

    [Fact]
    public void Result_Success()
    {
        // Arrange

        // Act
        var result = Result.Success();

        // Assert
        result.Errors.Should().BeNull();
        result.Status.Should().Be(ResultStatus.Ok);
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
    }

    [Fact]
    public void Result_Failure_ErrorEnumNotFound()
    {
        // Arrange

        // Act
        var result = Result.Failure(ErrorEnum.NotFound);

        // Assert
        result.Status.Should().Be(ResultStatus.NotFound);
        result.Errors.Should().ContainSingle().Which.Should().Be(ErrorEnum.NotFound);
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
    }
}