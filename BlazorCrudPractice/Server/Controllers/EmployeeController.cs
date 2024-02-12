using BlazorCrudPractice.Server.Services;
using BlazorCrudPractice.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudPractice.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : Controller
    {
        private readonly IService _service;

        public EmployeeController(IService service)
        {
            _service = service;
        }


        [HttpPost("SaveEmployee")]
        public async Task<ActionResult<ServiceResponse<string>>> SaveEmployee([FromBody] EmployeeModel model)
        {
            var result = await _service.SaveEmployee(model);
            return Ok(result);
        }
        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateEmployee([FromBody] EmployeeModel model)
        {
            var result = await _service.UpdateEmployee(model);
            return Ok(result);
        }
        [HttpDelete("DeleteEmployee/{recid}")]
        public async Task<ActionResult<ServiceResponse<string>>> DeleteEmployee(int recid)
        {
            var result = await _service.DeleteEmployee(recid);
            return Ok(result);
        }
        [HttpGet("EmployeeList")]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> GetEmployeeList()
        {
            var result = await _service.GetEmployeeList();
            return Ok(result);
        }
        [HttpGet("EmployeeById/{recid}")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> GetEmployeeById(int recid)
        {
            var result = await _service.GetEmployeeById(recid);
            return Ok(result);
        }
    }
}
