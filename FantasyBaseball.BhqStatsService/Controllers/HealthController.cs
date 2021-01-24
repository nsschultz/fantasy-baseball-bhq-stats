using FantasyBaseball.CommonModels.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace FantasyBaseball.BhqStatsService.Controllers
{
    /// <summary>Endpoint for checking the health of the service.</summary>
    [Route("api/health")] [ApiController] public class HealthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IFileProvider _provider;

        /// <summary>Creates a new instance of the controller.</summary>
        /// <param name="configuration">The configuration for the application.</param>
        public HealthController(IConfiguration configuration, IFileProvider provider) 
        {
             _configuration = configuration;
             _provider = provider;
        }
        
        /// <summary>Ensures that the system has access to the stats files.</summary>
        [HttpGet] public void GetHealth() 
        {
            if (!_provider.GetFileInfo(_configuration.GetValue<string>("CsvFiles:BatterFile")).Exists)
                throw new CsvFileException("Batter File Doesn't Exist");
            if (!_provider.GetFileInfo(_configuration.GetValue<string>("CsvFiles:PitcherFile")).Exists)
                throw new CsvFileException("Pitcher File Doesn't Exist");
        }
    }
}