using FluentAssertions;

namespace SharedKernel.UnitTests;

public class EntityBaseTests
{
    private class Entity(int id) : EntityBase(id);

    private class EntityWithGuid(Guid id) : EntityBase<Guid>(id);

    [Fact]
    public void EntityBase()
    {
        // Arrange
        var entity = new Entity(1);

        // Act

        // Assert
        entity.Id.GetType().Should().Be(typeof(int));
        entity.Id.Should().Be(1);
    }

    [Fact]
    public void GenericEntityBase()
    {
        // Arrange
        var entity = new EntityWithGuid(new Guid());

        // Act

        // Assert
        entity.Id.GetType().Should().Be(typeof(Guid));
    }
}
