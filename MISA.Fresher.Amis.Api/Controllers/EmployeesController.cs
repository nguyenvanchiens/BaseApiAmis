using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiSA.Fresher.Amis.Core.Entities;
using MiSA.Fresher.Amis.Core.InterFace.Service;

namespace MISA.Fresher.Amis.Api.Controllers
{
    public class EmployeesController : BaseController<Employee>
    {
        public EmployeesController(IEmployeeService employeeService):base(employeeService)
        {
        }
    }
}
