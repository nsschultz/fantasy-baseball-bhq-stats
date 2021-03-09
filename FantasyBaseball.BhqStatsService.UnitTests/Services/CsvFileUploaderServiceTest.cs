using FantasyBaseball.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace FantasyBaseball.BhqStatsService.Services.UnitTets
{
    public class CsvFileUploaderServiceTest
    {
        [Fact] public void NoFilesTest() 
        {
            var formFileCollection = new Mock<IFormFileCollection>();
            formFileCollection.Setup(o => o.Count).Returns(0);
            var formCollection = new Mock<IFormCollection>();
            formCollection.Setup(o => o.Files).Returns(formFileCollection.Object);
            var request = new Mock<HttpRequest>();
            request.Setup(o => o.ReadFormAsync(default)).ReturnsAsync(formCollection.Object);
            Assert.ThrowsAsync<BadRequestException>(() => new CsvFileUploaderService().UploadFile(request.Object, "file.csv"));
        }
    }
}