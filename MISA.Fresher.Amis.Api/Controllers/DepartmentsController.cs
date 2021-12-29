using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiSA.Fresher.Amis.Core.Entities;
using MiSA.Fresher.Amis.Core.InterFace.Service;
using MiSA.Fresher.Amis.Core.Service;

namespace MISA.Fresher.Amis.Api.Controllers
{
    public class DepartmentsController : BaseController<Department>
    {
        #region Declaration
        private IDepartmentService _departmentsService;
        #endregion
        #region Contructor
        public DepartmentsController(IDepartmentService departmentService):base(departmentService)
        {
            _departmentsService = departmentService;
        }
        #endregion
        #region Method
        [HttpGet("filter")]
        public IActionResult Filter([FromQuery]string? filter)
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
        #endregion
    }
}
