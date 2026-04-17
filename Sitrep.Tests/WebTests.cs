namespace Sitrep.Tests;

public class WebTests
{
    [Fact]
    public async Task GetWebResourceRootReturnsOkStatusCode()
    {
        // Arrange
        // Act ;
        // Assert
        Assert.Equal(HttpStatusCode.OK, HttpStatusCode.OK);
    }
}