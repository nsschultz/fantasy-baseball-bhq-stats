using System.IO;
using System.Threading.Tasks;
using FantasyBaseball.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace FantasyBaseball.BhqStatsService.Services
{
    /// <summary>Service for uploading a CSV file.</summary>
    public class CsvFileUploaderService : ICsvFileUploaderService
    {
        /// <summary>Reads the file off the HTTP request and saves it to file system.</summary>
        /// <param name="request">The HTTP request that was submitted.</param>
        /// <param name="fileName">The file name to process.</param>
        public async Task UploadFile(HttpRequest request, string fileName)
        {
            var file = await GetFileFromRequest(request);
            using var stream = new FileStream(fileName, FileMode.OpenOrCreate);
            await file.CopyToAsync(stream);
        }

        private static async Task<IFormFile> GetFileFromRequest(HttpRequest request)
        {
            var files = (await request.ReadFormAsync()).Files;
            if (files.Count == 0) throw new BadRequestException("There are no files attached.");
            return files[0];
        }
    }
}