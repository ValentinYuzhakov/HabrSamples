using AutoMapper;
using MappingToDbEntitiesApproach.Infrastructure.Mapping;
using Xunit;

namespace MappingToDbEntitiesApproach.UnitTests.Mapping;

public sealed class InfrastructureProfilesTests
{
    [Fact]
    public void Test_NotificationEntitiesProfile_NoExceptions()
    {
        // Arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<NotificationEntitiesProfile>());

        // Act
        var exception = Record.Exception(() => config.AssertConfigurationIsValid());

        // Assert
        Assert.Null(exception);
    }

    [Fact]
    public void Test_TechnicalObjectEntitiesProfile_NoExceptions()
    {
        // Arrange
        var config = new MapperConfiguration(cfg => cfg.AddProfile<TechnicalObjectEntitiesProfile>());

        // Act
        var exception = Record.Exception(() => config.AssertConfigurationIsValid());

        // Assert
        Assert.Null(exception);
    }
}
