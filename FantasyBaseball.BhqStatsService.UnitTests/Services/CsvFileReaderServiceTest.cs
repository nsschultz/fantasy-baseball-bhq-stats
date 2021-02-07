using System.Linq;
using FantasyBaseball.BhqStatsService.Models;
using FantasyBaseball.Common.Exceptions;
using Xunit;

namespace FantasyBaseball.BhqStatsService.Services.UnitTets
{
    public class CsvFileReaderServiceTest
    {
        [Fact] public void BadFileTest() => Assert.Throws<CsvFileException>(() => new CsvFileReaderService().ReadCsvData<object>("bad.csv"));

        [Fact] public void NullFileTest() => Assert.Throws<CsvFileException>(() => new CsvFileReaderService().ReadCsvData<object>(null));

        [Fact] public void RealFileTest() 
        {
            var results = new CsvFileReaderService().ReadCsvData<BhqBattingStats>("test.csv");
            Assert.Single(results);
            Assert.Equal(1234, results.First().BhqId);
        }
    }
}