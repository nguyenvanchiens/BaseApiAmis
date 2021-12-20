using MiSA.Fresher.Amis.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.Entities
{
    public class Department
    {
        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        /// 
        [NotEmpty]
        [PropertyName("Mã phòng ban")]
        public string? DepartmentName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? Description { get; set; }
        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        ///  CreateBy: NVChien(20/12/2021)
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? ModifiedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
