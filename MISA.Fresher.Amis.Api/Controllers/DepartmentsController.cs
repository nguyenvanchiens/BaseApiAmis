using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiSA.Fresher.Amis.Core.Entities;
using MiSA.Fresher.Amis.Core.InterFace.Service;
using MiSA.Fresher.Amis.Core.Service;

namespace MISA.Fresher.Amis.Api.Controllers
{
    public class DepartmentsController : BaseController<Department>
    {
        public DepartmentsController(IDepartmentService departmentService):base(departmentService)
        {

        }
    }
}
