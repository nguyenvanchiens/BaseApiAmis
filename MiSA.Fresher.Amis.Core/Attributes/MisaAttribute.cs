using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.Attributes
{
    /// <summary>
    /// Atribute cung cấp cho các property bắt buộc nhập - sử dụng để phục vụ cho validate chung của các đối tượng khác nhau
    /// </summary>
    /// CreatedBy: NVChien(19/12/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class NotEmpty:Attribute
    {
    }
    /// <summary>
    /// Attribute kiểm tra độ dài của chuỗi
    /// </summary>
    /// CreatedBy: NVChien(19/12/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class MaxLength : Attribute
    {
        public int Length { get; set; }
        public MaxLength(int length)
        {
            this.Length = length;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {

    }
    /// <summary>
    /// Attribute check trùng cho property
    /// </summary>
    /// <summary>
    /// CreatedBy: NVChien(19/12/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {

    }

    /// Attribute đặt tên cho các property
    /// </summary>
    /// CreatedBy: NVChien(19/12/2021)
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyName : Attribute
    {
        public string Name { get; set; }
        public PropertyName(string name)
        {
            this.Name = name;
        }
    }
}
