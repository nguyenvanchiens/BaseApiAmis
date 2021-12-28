using Dapper;
using Microsoft.Extensions.Configuration;
using MiSA.Fresher.Amis.Core.Common;
using MiSA.Fresher.Amis.Core.Entities;
using MiSA.Fresher.Amis.Core.InterFace.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Infrastructure.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Contructor
        public EmployeeRepository(IConfiguration configuration):base(configuration)
        {

        }

        #endregion
        #region Method
        public object GetPaging(PagingRequestBase pageRequest)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@keySearch", pageRequest.entityFilter);
            parameters.Add("@pageSize", pageRequest.pageSize);
            parameters.Add("@pageIndex", pageRequest.pageIndex);
            parameters.Add("@totalRecord", direction: ParameterDirection.Output);
            parameters.Add("@totalPage", direction: ParameterDirection.Output);
            var result = _dbConnection.Query<Employee>($"Proc_GetEtmployeePaging", param: parameters, commandType: CommandType.StoredProcedure);
            var TotalRecord = parameters.Get<int>("@totalRecord");
            var TotalPage = parameters.Get<int>("@totalPage");
            return new
            {
                totalRecord = TotalRecord,
                totalPage = TotalPage,
                Data = result
            };
        }

        public string NewCodeEmployee()
        {
            var result = _dbConnection.QueryFirstOrDefault<string>($"Proc_GetNew{_tableName}Code",commandType:CommandType.StoredProcedure);
            return result;
        }
        #endregion
    }
}
