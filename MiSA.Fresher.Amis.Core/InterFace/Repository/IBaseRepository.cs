using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.InterFace.Repository
{
    /// <summary>
    /// Viết base Repository dùng chung
    /// </summary>
    /// <typeparam name="TEntity">Đối tương</typeparam>
    /// CreateBy: NVChien(20/12/2021)
    public interface IBaseRepository<TEntity>
    {
        #region Method
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns>Trả về danh sách của đối tượng</returns>
        /// CreateBy: NVChien(20/12/2021)
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Lấy về đối tượng dựa vào id
        /// </summary>
        /// <param name="entityId">id của đối tương</param>
        /// <returns>Trả về các thuộc tính nếu tìm thấy, không thì trả về null</returns>
        /// CreateBy: NVChien(20/12/2021)
        TEntity GetById(Guid entityId);
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Các thuộc tính đối tượng</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreateBy: NVChien(20/12/2021)
        int Insert(TEntity entity);
        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="entity">Các thuộc tính đối tượng</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreateBy: NVChien(20/12/2021)
        int Update(Guid entityId, TEntity entity);
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">id của đối tượng</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreateBy: NVChien(20/12/2021)
        int Delete(Guid entityId);
        /// <summary>
        /// Check trùng property
        /// </summary>
        /// <param name="propertyName">Tên</param>
        /// <param name="propertyValue">Giá trị</param>
        /// <returns>trả về đối tượng thì sai, k thì đúng</returns>
        /// CreateBy: NVChien(20/12/2021)
        TEntity GetDuplicateProperty(Guid entityId, string propertyName, object propertyValue);
        /// <summary>
        /// Xóa danh sách các đối tượng
        /// </summary>
        /// <param name="entityIds">Danh sách id các đối tượng cần xóa</param>
        /// <returns>Trả về số bản ghi được xóa</returns>
        /// CreateBy:NVChien(20/12/2021)
        int DeleteMultiEntity(List<string> entityIds);
        #endregion
    }
}
