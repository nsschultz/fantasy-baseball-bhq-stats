using System.Collections.Generic;
using System.Threading.Tasks;
using FantasyBaseball.BhqStatsService.Models;
using FantasyBaseball.BhqStatsService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FantasyBaseball.BhqStatsService.Controllers
{
    /// <summary>Endpoint for retrieving BHQ player stats data.</summary>
    [Route("api/bhq-stats")] [ApiController] public class BhqStatsController : ControllerBase
    {
        private readonly ICsvFileReaderService _fileReaderService;
        private readonly ICsvFileUploaderService _fileUploadService;
        private readonly IConfiguration _configuration;

        /// <summary>Creates a new instance of the controller.</summary>
        /// <param name="service">The service for reading the CSV file.</param>
        /// <param name="configuration">The configuration for the application.</param>
        public BhqStatsController(ICsvFileReaderService fileReaderService, ICsvFileUploaderService fileUploadService, IConfiguration configuration)  
        {
            _fileReaderService = fileReaderService;
            _fileUploadService = fileUploadService;
            _configuration = configuration;
        }

        /// <summary>Gets all of the batters from the BHQ stats source.</summary>
        /// <returns>All of the batters from the BHQ stats source.</returns>
        [HttpGet("batters")] public IEnumerable<BhqBattingStats> GetBatters() =>
            _fileReaderService.ReadCsvData<BhqBattingStats>(_configuration.GetValue<string>("CsvFiles:BatterFile"));

        /// <summary>Gets all of the pitchers from the BHQ stats source.</summary>
        /// <returns>All of the pitchers from the BHQ stats source.</returns>
        [HttpGet("pitchers")] public IEnumerable<BhqPitchingStats> GetPitchers() =>
            _fileReaderService.ReadCsvData<BhqPitchingStats>(_configuration.GetValue<string>("CsvFiles:PitcherFile"));

        [HttpPost("batters/upload")] public async Task UploadBatterFile() => 
            await _fileUploadService.UploadFile(Request, _configuration.GetValue<string>("CsvFiles:BatterFile"));

        [HttpPost("pitchers/upload")] public async Task UploadPitcherFile() => 
            await _fileUploadService.UploadFile(Request, _configuration.GetValue<string>("CsvFiles:PitcherFile"));
    }
}