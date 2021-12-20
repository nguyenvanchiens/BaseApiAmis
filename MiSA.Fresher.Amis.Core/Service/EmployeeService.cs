using MiSA.Fresher.Amis.Core.Attributes;
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
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository):base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public object GetPaging(int limit, int offset)
        {
            var result = _employeeRepository.GetPaging(limit, offset);
            return result;
        }
        protected override bool ValidateObjectCustom(Employee entity)
        {
            List<string> errorMsg = new List<string> { };
            // Lấy ra trường muốn kiểm tra tồn tại
            var properties = typeof(Employee).GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                // Lấy ra các propertyName
                var propertyNameOriginal = property.Name;
                var propertyNames = property.GetCustomAttributes(typeof(PropertyName), true);
                if (propertyNames.Length > 0)
                {
                    propertyNameOriginal = ((PropertyName)propertyNames[0]).Name;
                }
                var propertyDuplicate = property.GetCustomAttributes(typeof(CheckDuplicate), true);
                if (propertyDuplicate.Length > 0)
                {
                    var checkDuplicate = _employeeRepository.GetEntityByProperty(property.Name, propertyValue);
                    if (checkDuplicate != null)
                    {
                        errorMsg.Add($"Dữ liệu {propertyNameOriginal} đã tồn tại trong cơ sở");
                    }
                }
            }
            if(errorMsg.Count > 0)
            {
                return true;
            }
            return true;
        }
    }
}
