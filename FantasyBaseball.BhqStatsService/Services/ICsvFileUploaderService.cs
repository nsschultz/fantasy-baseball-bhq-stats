using System.Threading.Tasks;
using FantasyBaseball.BhqStatsService.FileReaders;

namespace FantasyBaseball.BhqStatsService.Services
{
    /// <summary>Service for uploading a CSV file.</summary>
    public interface ICsvFileUploaderService
    {
        /// <summary>Reads the file off the HTTP request and saves it to file system.</summary>
        /// <param name="fileReader">Helper for reading the contents of a file.</param>
        /// <param name="fileName">The file name to process.</param>
        Task UploadFile(IFileReader fileReader, string fileName);
    }
}