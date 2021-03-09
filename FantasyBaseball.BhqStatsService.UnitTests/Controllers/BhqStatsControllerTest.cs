using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.BhqStatsService.Models;
using FantasyBaseball.BhqStatsService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace FantasyBaseball.BhqStatsService.Controllers.UnitTests
{
    public class BhqStatsControllerTest
    {
        [Fact] public void GetBattersTest() 
        {
            var returnData = new List<BhqBattingStats> { new BhqBattingStats() };
            var section = new Mock<IConfigurationSection>();
            section.Setup(o => o.Value).Returns("batters.csv");
            var config = new Mock<IConfiguration>();
            config.Setup(o => o.GetSection("CsvFiles:BatterFile")).Returns(section.Object);
            var service = new Mock<ICsvFileReaderService>();
            service.Setup(o => o.ReadCsvData<BhqBattingStats>("batters.csv")).Returns(returnData);
            Assert.NotEmpty(new BhqStatsController(service.Object, null, config.Object).GetBatters());
        }

        [Fact] public void GetPitchersTest() 
        {
            var returnData = new List<BhqPitchingStats> { new BhqPitchingStats() };
            var section = new Mock<IConfigurationSection>();
            section.Setup(o => o.Value).Returns("pitchers.csv");
            var config = new Mock<IConfiguration>();
            config.Setup(o => o.GetSection("CsvFiles:PitcherFile")).Returns(section.Object);
            var service = new Mock<ICsvFileReaderService>();
            service.Setup(o => o.ReadCsvData<BhqPitchingStats>("pitchers.csv")).Returns(returnData);
            Assert.NotEmpty(new BhqStatsController(service.Object, null, config.Object).GetPitchers());
        }

        [Fact] public async Task UploadBattersTest() 
        {
            var section = new Mock<IConfigurationSection>();
            section.Setup(o => o.Value).Returns("batters.csv");
            var config = new Mock<IConfiguration>();
            config.Setup(o => o.GetSection("CsvFiles:BatterFile")).Returns(section.Object);
            var service = new Mock<ICsvFileUploaderService>();
            service.Setup(o => o.UploadFile(It.IsNotNull<HttpRequest>(), "batters.csv")).Returns(Task.FromResult(0));
            var request = new Mock<HttpRequest>();
            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Request).Returns(request.Object);
            var controller = new BhqStatsController(null, service.Object, config.Object);
            controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
            await controller.UploadBatterFile();
            service.VerifyAll();
        }

        [Fact] public async Task UploadPitcherssTest() 
        {
            var section = new Mock<IConfigurationSection>();
            section.Setup(o => o.Value).Returns("pitchers.csv");
            var config = new Mock<IConfiguration>();
            config.Setup(o => o.GetSection("CsvFiles:PitcherFile")).Returns(section.Object);
            var service = new Mock<ICsvFileUploaderService>();
            service.Setup(o => o.UploadFile(It.IsNotNull<HttpRequest>(), "pitchers.csv")).Returns(Task.FromResult(0));
            var request = new Mock<HttpRequest>().Object;
            var httpContext = new Mock<HttpContext>();
            httpContext.SetupGet(a => a.Request).Returns(request);
            var controller = new BhqStatsController(null, service.Object, config.Object);
            controller.ControllerContext = new ControllerContext() { HttpContext = httpContext.Object };
            await controller.UploadPitcherFile();
            service.VerifyAll();
        }
    }
}