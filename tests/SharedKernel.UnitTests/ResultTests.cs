using FluentAssertions;

namespace SharedKernel.UnitTests;

public class ResultTests
{
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
    }

    [Fact]
    public void Result_Failure()
    {
        // Arrange

        // Act
        var result = Result.Failure(ErrorEnum.NotFound);

        // Assert
        result.Errors.Should().ContainSingle();
        result.Status.Should().Be(ResultStatus.NotFound);
        result.IsSuccess.Should().BeFalse();
    }

    [Fact]
    public void GenericResult_SuccessWithValue()
    {
        // Arrange
        const bool value = true;

        // Act
        var result = Result<bool>.Success(value);

        // Assert
        result.Errors.Should().BeNull();
        result.Status.Should().Be(ResultStatus.Ok);
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(value);
    }

    [Fact]
    public void GenericResult_SuccessWithNullValue()
    {
        // Arrange

        // Act
        var result = Result<bool?>.Success(null);

        // Assert
        result.Errors.Should().BeNull();
        result.Status.Should().Be(ResultStatus.Ok);
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeNull();
    }
}