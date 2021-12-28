using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.Enum
{
    public enum Gender
    {
        /// <summary>
        /// Nữ
        /// </summary>
        Male = 0,
        /// <summary>
        /// Nam
        /// </summary>
        Female = 1,
        /// <summary>
        /// Khác
        /// </summary>
        Other = 2
    }
    public enum StatusError
    {
        /// <summary>
        /// Lỗi validate không hợp lệ
        /// </summary>
        BadRequest=400,
        /// <summary>
        /// Lỗi api
        /// </summary>
        Internal_Server_Error = 500
    }
}
