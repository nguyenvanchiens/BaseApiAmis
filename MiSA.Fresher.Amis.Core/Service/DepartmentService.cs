using MiSA.Fresher.Amis.Core.Entities;
using MiSA.Fresher.Amis.Core.InterFace.Repository;
using MiSA.Fresher.Amis.Core.InterFace.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.Service
{
    public class DepartmentService:BaseService<Department>,IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository):base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<Department> FilterDepartment(string? filterName)
        {
            return _departmentRepository.FilterDepartment(filterName);
        }
    }
}
