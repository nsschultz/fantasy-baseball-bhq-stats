using System.Collections.Generic;

namespace FantasyBaseball.BhqStatsService.Services
{
    /// <summary>Service for reading CSV file.</summary>
    public interface ICsvFileReaderService
    {
        /// <summary>Reads in data from the given CSV file.</summary>
        /// <param name="fileName">The file name to process.</param>
        /// <returns>All of the data within the given file.</returns>
        IEnumerable<T> ReadCsvData<T>(string fileName);
    }
}