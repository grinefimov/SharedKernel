using FluentAssertions;

namespace SharedKernel.UnitTests;

public class EntityBaseTests
{
    private class Entity : EntityBase {}
    private class EntityWithGuid : EntityBase<Guid> {}

    [Fact]
    public void EntityBase()
    {
        // Arrange
        var entity = new Entity();

        // Act

        // Assert
        entity.Id.GetType().Should().Be(typeof(int));
        entity.Id.Should().Be(0);
    }

    [Fact]
    public void GenericEntityBase()
    {
        // Arrange
        var entity = new EntityWithGuid();

        // Act

        // Assert
        entity.Id.GetType().Should().Be(typeof(Guid));
    }
}
