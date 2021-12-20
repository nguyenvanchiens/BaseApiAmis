using MiSA.Fresher.Amis.Core.Attributes;
using MiSA.Fresher.Amis.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.Entities
{
    public class Employee
    {
        /// <summary>
        /// Id nhân viên
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        /// 
        [NotEmpty]
        [CheckDuplicate]
        [PropertyName("Mã nhân viên")]
        public string? EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        /// 
        [NotEmpty]
        public string? EmployeeName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public Gender Gender { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        /// 
        [NotEmpty]
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Căn cước công dân
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi cấp chứng minh thư nhân dân
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? IdentityPlace{ get; set; }
        /// <summary>
        /// Chức danh
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? EmployeePosition { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? Address { get; set; }
        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? BankAccountNumber { get; set; }
        /// <summary>
        /// Tên tài khoản
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? BankName { get; set; }
        /// <summary>
        /// Tên chi nhánh ngân hàng
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? BankBranchName { get; set; }
        /// <summary>
        /// Tỉnh ngân hàng
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? BankProvinceName { get; set; }
        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        [CheckDuplicate]
        [PropertyName("Số điện thoại")]
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        /// 
        public string? TelephoneNumber { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? DepartmentName { get; }
        /// <summary>
        /// Email
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? Email { get; set; }
        /// <summary>
        /// Người tạo bản ghi
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        ///  CreateBy: NVChien(20/12/2021)
        public DateTime CreatedDate { get;set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        /// CreateBy: NVChien(20/12/2021)
        public string? ModifiedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedDate  { get; set; }
}
}
