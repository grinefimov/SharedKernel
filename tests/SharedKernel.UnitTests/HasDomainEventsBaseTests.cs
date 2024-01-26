using FluentAssertions;

namespace SharedKernel.UnitTests;

public class HasDomainEventsBaseTests
{
    private class TestDomainEvent : DomainEventBase { }

    private class TestEntity : HasDomainEventsBase
    {
        public void AddTestDomainEvent()
        {
            var domainEvent = new TestDomainEvent();
            RegisterDomainEvent(domainEvent);
        }

        public void ClearDomainEvents()
        {
            base.ClearDomainEvents();
        }
    }

    [Fact]
    public void RegisterDomainEvent()
    {
        // Arrange
        var entity = new TestEntity();

        // Act
        entity.AddTestDomainEvent();

        // Assert
        entity.DomainEvents.Should().HaveCount(1);
        entity.DomainEvents.Should().AllBeOfType<TestDomainEvent>();
    }

    [Fact]
    public void ClearDomainEvents()
    {
        // Arrange
        var entity = new TestEntity();

        // Act
        entity.ClearDomainEvents();

        // Assert
        entity.DomainEvents.Should().BeEmpty();
    }
}