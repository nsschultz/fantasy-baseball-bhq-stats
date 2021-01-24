using System.Collections.Generic;
using FantasyBaseball.BhqStatsService.Controllers;
using FantasyBaseball.BhqStatsService.Models;
using FantasyBaseball.BhqStatsService.Services;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace FantasyBaseball.BhqStatsService.UnitTests.Controllers
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
            Assert.NotEmpty(new BhqStatsController(service.Object, config.Object).GetBatters());
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
            Assert.NotEmpty(new BhqStatsController(service.Object, config.Object).GetPitchers());
        }
    }
}