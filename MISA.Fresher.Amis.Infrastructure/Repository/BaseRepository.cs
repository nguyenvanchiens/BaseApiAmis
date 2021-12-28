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
        #region initialization
        IConfiguration _configuration;
        protected IDbConnection _dbConnection;
        private readonly string _connectionString = string.Empty;
        protected readonly string _tableName = string.Empty;
        #endregion
        #region Contructor
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISAConnectionStrings");
            _dbConnection = new MySqlConnection(_connectionString);
            _tableName = typeof(TEntity).Name;
        }
        #endregion
        #region Method
        public int Delete(Guid entityId)
        {
            var paramas = new DynamicParameters();
            paramas.Add($"@{_tableName}Id",entityId);
            var rowAffect = _dbConnection.Execute($"Proc_Delete{_tableName}ById", param: paramas, commandType: CommandType.StoredProcedure);
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
            DynamicParameters param = MappingType(entity);
            var rowAffect = _dbConnection.Execute($"Proc_Insert{_tableName}", param: param, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }

        public int Update(Guid entityId,TEntity entity)
        {
            DynamicParameters parameters = MappingType(entity);
            parameters.Add($"@{_tableName}Id", entityId);
            var rowAffect = _dbConnection.Execute($"Proc_Update{_tableName}", param: parameters, commandType: CommandType.StoredProcedure);
            return rowAffect;
        }
        #endregion
        #region design
        /// <summary>
        /// Chuyển đổi enity về 1 mảng đối tượng @...
        /// </summary>
        /// <param name="entity">đối tượng</param>
        /// <returns>Trả về 1 DynamicParameters</returns>
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
        /// <summary>
        /// Kiểm tra tồn tại đối tượng dưới databse
        /// </summary>
        /// <param name="propertyName">entity cần kiểm tra</param>
        /// <param name="propertyValue">Dữ liệu entity</param>
        /// <returns>Trả về đối tượng nếu tồn tại</returns>
        /// CreateBy: NVChien(20/12/2021)
        public TEntity GetDuplicateProperty(Guid entityId, string propertyName, object propertyValue)
        {
            //truyền vào id để kiểm tra mã đó của id đó, nếu khác mới kiểm tra
            // Kiểm tra mã nhân viên và số điện thoại nhân viên có bị trùng không, nhưng với điều kiện nó khác với id ban đầu
            // Khi update entityId ban đầu đã có nên chỉ kiểm tra nếu có thay đổi trường đó, còn k thì của nó ban đầu kệ nó

            // Khi thêm mới entityId đã được tạo mới

            var query = $"Select*from {_tableName} where {propertyName} = '{propertyValue}' and {_tableName}Id != '{entityId}'";
            var entityy = _dbConnection.QueryFirstOrDefault<TEntity>(query, commandType: CommandType.Text);
            return entityy;
        }

        public int DeleteMultiEntity(List<string> entityIds)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@listId", string.Join(',', entityIds));
            var result = _dbConnection.Execute($"Proc_DeleteMultipleRecord{_tableName}", param: parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
        #endregion
    }
}
