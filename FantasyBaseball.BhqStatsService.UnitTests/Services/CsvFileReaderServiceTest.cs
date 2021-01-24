using FantasyBaseball.BhqStatsService.Services;
using FantasyBaseball.CommonModels.Exceptions;
using Xunit;

namespace FantasyBaseball.BhqStatsService.UnitTests.Services
{
    public class CsvFileReaderServiceTest
    {
        [Fact] public void BadFileTest() => Assert.Throws<CsvFileException>(() => new CsvFileReaderService().ReadCsvData<object>("bad.csv"));

        [Fact] public void NullFileTest() => Assert.Throws<CsvFileException>(() => new CsvFileReaderService().ReadCsvData<object>(null));
    }
}