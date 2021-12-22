using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiSA.Fresher.Amis.Core.Common;
using MiSA.Fresher.Amis.Core.Entities;
using MiSA.Fresher.Amis.Core.InterFace.Service;

namespace MISA.Fresher.Amis.Api.Controllers
{
    public class EmployeesController : BaseController<Employee>
    {
        IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService):base(employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("GetAllPaging")]
        public IActionResult GetAllPaging([FromQuery] PageRequestBase pageRequest)
        {
            try
            {
               var result = _employeeService.GetPaging(pageRequest);
                return Ok(result);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteMulti")]
        public IActionResult DeleteMulti([FromBody] List<string> listId)
        {
            try
            {
                var result = _employeeService.DeleteMultiRecord(listId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
