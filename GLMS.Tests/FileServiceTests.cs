using Xunit;
using Microsoft.AspNetCore.Http;
using Moq;

public class FileServiceTests
{
    [Fact]
    public void SavePdf_InvalidFileType_ShouldThrowException()
    {
        // Arrange
        var fileService = new FileService();

        var mockFile = new Mock<IFormFile>();
        mockFile.Setup(f => f.FileName).Returns("virus.exe");
        mockFile.Setup(f => f.Length).Returns(100);

        // Act & Assert
        Assert.Throws<Exception>(() => fileService.SavePdf(mockFile.Object));
    }
}