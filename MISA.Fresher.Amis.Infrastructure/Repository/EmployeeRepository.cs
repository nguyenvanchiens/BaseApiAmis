using Dapper;
using Microsoft.Extensions.Configuration;
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
        public EmployeeRepository(IConfiguration configuration):base(configuration)
        {

        }
        public object GetPaging(int limit, int offset)
        {
            var parama = new DynamicParameters();
            parama.Add("limit", limit);
            parama.Add("offset", offset);
            var result = _dbConnection.Query<Employee>($"Proc_GetAllPaging", param: parama, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}
