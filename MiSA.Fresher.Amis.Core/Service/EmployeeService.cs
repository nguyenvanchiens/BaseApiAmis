using MiSA.Fresher.Amis.Core.Attributes;
using MiSA.Fresher.Amis.Core.Common;
using MiSA.Fresher.Amis.Core.Entities;
using MiSA.Fresher.Amis.Core.Exceptions;
using MiSA.Fresher.Amis.Core.InterFace.Repository;
using MiSA.Fresher.Amis.Core.InterFace.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Declaration
        IEmployeeRepository _employeeRepository;
        #endregion
        #region Contructor
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #endregion
        #region Method
        public object GetPaging(PagingRequestBase pageRequest)
        {
            return _employeeRepository.GetPaging(pageRequest);
        }
        public string NewCodeEmployee()
        {
            return _employeeRepository.NewCodeEmployee();
        }
        #endregion
        #region ValidateCustom
        
        #endregion
    }
}
