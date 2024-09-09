using Asp.Net_General_Concepts.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Asp.Net_General_Concepts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDistributedCache _distributedCache;
        public EmployeesController(IEmployeeService employeeService, IDistributedCache distributedCache)
        {
            _employeeService = employeeService;
            _distributedCache = distributedCache;
        }

        [HttpGet("GetEmployees")]
        public async Task<IActionResult> GetEmployeesAsync()
        {

            string? data = await _distributedCache.GetStringAsync("employees");
            if(!string.IsNullOrEmpty(data))
            {
                JsonConvert.DeserializeObject<string[]>(data!);
                return Ok(data);
            }
            var employees = _employeeService.GetEmployees();
            _distributedCache.SetString("employees",JsonConvert.SerializeObject(employees),new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10)));
            return Ok(employees);
        }
        
    }
}
