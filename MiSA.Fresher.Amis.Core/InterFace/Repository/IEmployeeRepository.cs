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
        /// <summary>
        /// Phân trang cho nhân viên
        /// </summary>
        /// <param name="limit">số bản ghi</param>
        /// <param name="offset">số trang</param>
        /// <returns>Trả về danh sách với số bản ghi</returns>
        /// CreateBy: NVChien(20/12/2021)
        object GetPaging(int limit,int offset);
    }
}
