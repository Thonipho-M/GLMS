using Xunit;

public class CurrencyServiceTests
{
    [Fact]
    public void ConvertUsdToZar_ShouldReturnCorrectValue()
    {
        // Arrange
        var service = new CurrencyService(null);
        decimal usd = 100;
        decimal rate = 18.5m;

        // Act
        var result = service.ConvertUsdToZar(usd, rate);

        // Assert
        Assert.Equal(1850, result);
    }

    [Fact]
    public void ConvertUsdToZar_ZeroValue_ShouldReturnZero()
    {
        var service = new CurrencyService(null);

        var result = service.ConvertUsdToZar(0, 18.5m);

        Assert.Equal(0, result);
    }
}