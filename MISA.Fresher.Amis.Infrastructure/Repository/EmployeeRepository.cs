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
        public int DeleteMultiRecord(List<string> listId)
        {
            DynamicParameters parameters = new DynamicParameters();
            var listid = "";
            foreach (string id in listId)
            {
                listid += id+",";
            }
            //listid = listid.Substring(0, listid.Length - 1);
            parameters.Add("@listId", string.Join(',',listId)); 
            var result = _dbConnection.Execute("Proc_DeleteMultipleRecordEmployee", param:parameters,commandType:CommandType.StoredProcedure);
            var count = result;
            return result;
        }
        public object GetPaging(PageRequestBase pageRequest)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeFilter", pageRequest.entityFilter);
            parameters.Add("@PageSize", pageRequest.pageSize);
            parameters.Add("@PageIndex", pageRequest.pageIndex);
            parameters.Add("@TotalRecord", direction: ParameterDirection.Output);
            parameters.Add("@TotalPage", direction: ParameterDirection.Output);
            var result = _dbConnection.Query<Employee>($"Proc_GetEmployeePaging", param: parameters, commandType: CommandType.StoredProcedure);
            var TotalRecord = parameters.Get<int>("@TotalRecord");
            var TotalPage = parameters.Get<int>("@TotalPage");
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
