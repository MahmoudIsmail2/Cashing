using Cashing.Bl.Interfaces;
using Cashing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cashing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppConfigrationsController : ControllerBase
    {
        private static string configrationsKey = "configKey";
        private readonly IMemoryCahService _memoryCahService;
        private readonly IConfigrationData _configrationData;
        public AppConfigrationsController(IMemoryCahService memoryCahService, IConfigrationData configrationData)
        {
            _memoryCahService = memoryCahService;
            _configrationData = configrationData;
        }
        [HttpGet("GetConfigrations")]
        public IActionResult GetConfigrations()
        {
            var configData= _memoryCahService.GetFromCash<AppConfigrationsModel>(configrationsKey);           
            if(configData is  null)
            {
                // Get Cash From Exetrnal resource 
                configData = _configrationData.GetConfigrations();

                // Set To Cash From Exetrnal resource 
                _memoryCahService.SettoCash(configrationsKey, configData);
            }           
            return Ok(configData);
        }
        [HttpPost("UpdateConfigration")] 
        public IActionResult  UpdateConfigration([FromBody]AppConfigrationsModel configData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Simulate Configrations Update
             configData = _configrationData.UpdateConfigrations(configData);

            _memoryCahService.RemoveFromCash(configrationsKey);

            return Ok();
        }
        
        
    }
}
