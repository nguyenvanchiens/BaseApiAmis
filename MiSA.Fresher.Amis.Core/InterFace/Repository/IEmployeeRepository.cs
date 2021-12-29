using MiSA.Fresher.Amis.Core.Common;
using MiSA.Fresher.Amis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.InterFace.Repository
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        #region Method
        /// <summary>
        /// Phân trang cho nhân viên
        /// </summary>
        /// <param name="pageSize">số bản ghi</param>
        /// <param name="pageNumber">số trang</param>
        /// <param name="employeeFilter">Dữ liệu tìm kiếm(chứa ký tự nhập vào theo mã, tên hoặc số điện thoại)</param>
        /// <returns>Trả về danh sách với số bản ghi</returns>
        /// CreateBy: NVChien(20/12/2021)
        object GetPaging(PagingRequestBase pageRequest);
        /// <summary>
        /// Tạo ra mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên</returns>
        /// CreateBy: NVChien(20/12/2021)
        string NewCodeEmployee();
        #endregion

    }
}
