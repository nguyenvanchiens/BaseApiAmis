using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.InterFace.Service
{
    /// <summary>
    /// Viết base Repository dùng chung
    /// </summary>
    /// <typeparam name="TEntity">Đối tương</typeparam>
    /// CreateBy: NVChien(20/12/2021)
    public interface IBaseService<TEntity>
    {
        #region Method
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <returns>Trả về danh sách của đối tượng</returns>
        /// CreateBy: NVChien(20/12/2021)
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Lấy về đối tượng dựa vào entityId
        /// </summary>
        /// <param name="entityId">entityId của đối tương</param>
        /// <returns>Trả về các thuộc tính nếu tìm thấy, không thì trả về null</returns>
        /// CreateBy: NVChien(20/12/2021)
        TEntity GetById(Guid entityId);
        /// <summary>
        /// Thêm mới bản ghi
        /// </summary>
        /// <param name="entity">Các thuộc tính đối tượng</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreateBy: NVChien(20/12/2021)
        int? Insert(TEntity entity);
        /// <summary>
        /// Sửa bản ghi
        /// </summary>
        /// <param name="entity">Các thuộc tính đối tượng</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreateBy: NVChien(20/12/2021)
        int? Update(Guid entityId, TEntity entity);
        /// <summary>
        /// Xóa bản ghi
        /// </summary>
        /// <param name="entityId">entityId của đối tượng</param>
        /// <returns>Trả về số bản ghi bị ảnh hưởng</returns>
        /// CreateBy: NVChien(20/12/2021)
        int Delete(Guid entityId);
        #endregion

    }
}
