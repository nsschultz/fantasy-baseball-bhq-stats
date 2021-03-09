using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FantasyBaseball.BhqStatsService.Services
{
    /// <summary>Service for uploading a CSV file.</summary>
    public interface ICsvFileUploaderService
    {
        /// <summary>Reads the file off the HTTP request and saves it to file system.</summary>
        /// <param name="request">The HTTP request that was submitted.</param>
        /// <param name="fileName">The file name to process.</param>
        Task UploadFile(HttpRequest request, string fileName);
    }
}