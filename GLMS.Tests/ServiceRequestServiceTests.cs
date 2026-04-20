using Xunit;

public class ServiceRequestServiceTests
{
    [Fact]
    public void CannotCreate_WhenContractExpired()
    {
        var service = new ServiceRequestService();

        var result = service.CanCreateServiceRequest("Expired");

        Assert.False(result);
    }

    [Fact]
    public void CannotCreate_WhenContractOnHold()
    {
        var service = new ServiceRequestService();

        var result = service.CanCreateServiceRequest("On Hold");

        Assert.False(result);
    }

    [Fact]
    public void CanCreate_WhenContractActive()
    {
        var service = new ServiceRequestService();

        var result = service.CanCreateServiceRequest("Active");

        Assert.True(result);
    }
}