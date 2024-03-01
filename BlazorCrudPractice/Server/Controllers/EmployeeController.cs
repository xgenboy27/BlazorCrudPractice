using BlazorCrudPractice.Server.Model;
using BlazorCrudPractice.Server.Services;
using BlazorCrudPractice.Service.Employee;
using BlazorCrudPractice.Shared;
using BlazorCrudPractice.Shared.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudPractice.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : Controller
    {
        private IMainEmployee _mainEmployee;

        public EmployeeController()
        {
            _mainEmployee = new MainEmployee();
        }

        [HttpPost("save-createEmployee")]
        public async Task<ActionResult<string>> SaveEmployee([FromBody] EmployeeModel model)
        {
            var result = await _mainEmployee.CreateEmplyees(model);
            return Ok(result);
        }

        [HttpPut("save-updateEmployee")]
        public async Task<ActionResult<string>> UpdateEmployee([FromBody] EmployeeModel model)
        {
            var result = await _mainEmployee.UpdateEmplyees(model);
            return Ok(result);
        }
        [HttpDelete("save-deleteEmployee/{recid}")]
        public async Task<ActionResult<string>> DeleteEmployee(int recid)
        {
            var result = await _mainEmployee.DeleteEmplyees(recid);
            return Ok(result);
        }

        [HttpGet("get-employeeList")]
        public async Task<ActionResult<List<EmployeeServiceList>>> GetEmployeeList()
        {
            var result = _mainEmployee.GetEmployeeList();
            return Ok(result);
        }

        [HttpGet("get-EmployeeById/{recid}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeById(int recid)
        {
            var result = await _mainEmployee.GetEmployeeByid(recid);
            return Ok(result);
        }
    }
}
