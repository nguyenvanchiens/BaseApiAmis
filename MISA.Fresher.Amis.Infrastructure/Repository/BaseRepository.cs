using Dapper;
using Microsoft.Extensions.Configuration;
using MiSA.Fresher.Amis.Core.InterFace.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Amis.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        IConfiguration _configuration;
        protected IDbConnection _dbConnection;
        private readonly string _connectionString = string.Empty;
        protected readonly string _tableName = string.Empty;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISAConnectionStrings");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }
        public int Delete(Guid entityId)
        {
            var paramas = new DynamicParameters();
            paramas.Add($"@m_{_tableName}Id",entityId);
            var rowAffect = _dbConnection.Execute($"Proc_Delete{_tableName}", param: paramas, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var entities = _dbConnection.Query<TEntity>($"Proc_Get{_tableName}", commandType: CommandType.StoredProcedure);
            return entities;
        }

        public TEntity GetById(Guid entityId)
        {
            var parama = new DynamicParameters();
            parama.Add($"@{_tableName}Id", entityId);
            var entity = _dbConnection.QueryFirstOrDefault<TEntity>($"Proc_Get{_tableName}ById", param: parama, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public int Insert(TEntity entity)
        {
            var param = MappingType(entity);
            var rowAffect = _dbConnection.Execute($"Proc_Inserts{_tableName}", param: param, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }

        public int Update(Guid entityId,TEntity entity)
        {
            DynamicParameters parameters = MappingType(entity);
            parameters.Add($"@{_tableName}Id", entityId);
            var rowAffect = _dbConnection.Execute($"Proc_Update{_tableName}", param: parameters, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }
        private DynamicParameters MappingType(TEntity entity)
        {
            //Lấy ra tất cả các property của class gọi đến
            var properties = typeof(TEntity).GetProperties();
            // Tạo mới 1 đối tượng DynamicParameters để lưu trữ thông tin khi lặp qua các property
            var paramenters = new DynamicParameters();
            foreach(var property in properties)
            {
                // Lấy tên của property
                var propertyName = property.Name;
                // Lấy ra giá trị của property
                var propertyValue = property.GetValue(entity);
                // Lấy ra kiểu dữ liệu của property
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    paramenters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    paramenters.Add($"@{propertyName}", propertyValue);
                }
            }
            return paramenters;
        }

        public TEntity GetEntityByProperty(string propertyName, object propertyValue)
        {
            var query = $"Select*from {_tableName} where {propertyName} = '{propertyValue}'";
            var entity = _dbConnection.QueryFirstOrDefault<TEntity>(query, commandType: CommandType.Text);
            return entity;
        }
    }
}
