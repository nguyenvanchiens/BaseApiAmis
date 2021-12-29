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
        /// <summary>
        /// Custom lại validate bên hàm cha nếu thêm thuộc tính mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected override bool ValidateObjectCustom(Employee entity)
        {
            List<string> errorMsg = new List<string> { };
            // Lấy ra tất cả các property của employee
            var properties = typeof(Employee).GetProperties();
            foreach (var property in properties)
            {
                // Lấy ra value của property
                var propertyValue = property.GetValue(entity);
                // Lấy ra propertyName
                var propertyNameOriginal = property.Name;
                // Lấy ra attribute PropertyName nếu property đó có khai báo
                var propertyDisplay = property.GetCustomAttributes(typeof(PropertyName), true);
                // Lấy ra attribute Duplicate nếu property đó có khai báo
                var propertyDuplicate = property.GetCustomAttributes(typeof(CheckDuplicate), true);
                // Lấy ra attribute Date nếu property đó có khai báo
                var checkDate = property.GetCustomAttributes(typeof(checkDate), true);
                if (propertyDisplay.Length > 0)
                {
                    propertyNameOriginal = ((PropertyName)propertyDisplay[0]).Name;
                }
                if (propertyDuplicate.Length > 0)
                {
                    if (propertyValue != null)
                    {
                        var checkDuplicate = _employeeRepository.GetDuplicateProperty(entity.EmployeeId, property.Name, propertyValue);
                        if (checkDuplicate != null)
                        {
                            errorMsg.Add($"Dữ liệu {propertyNameOriginal} đã tồn tại");
                        }
                    }

                }
                if (checkDate.Length > 0)
                {
                    if (propertyValue != null)
                    {
                        if ((DateTime)propertyValue > DateTime.Now)
                        {
                            errorMsg.Add($"{propertyNameOriginal} lớn không thể lớn hơn ngày hiện tại");
                        }
                    }
                }
            }
            if (errorMsg.Count > 0)
            {
                throw new HttpResponseException(errorMsg);
            }
            return true;
        }
        #endregion
    }
}
