using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiSA.Fresher.Amis.Core.Entities;
using MiSA.Fresher.Amis.Core.InterFace.Service;
using MiSA.Fresher.Amis.Core.Service;

namespace MISA.Fresher.Amis.Api.Controllers
{
    public class DepartmentsController : BaseController<Department>
    {
        private IDepartmentService _departmentsService;
        public DepartmentsController(IDepartmentService departmentService):base(departmentService)
        {
            _departmentsService = departmentService;
        }
        [HttpGet("filter")]
        public IActionResult Filter(string filter)
        {
            try
            {
                var result = _departmentsService.FilterDepartment(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
