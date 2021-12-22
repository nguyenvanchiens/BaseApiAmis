using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.Common
{
    public class ApiResult<T>
    {
        public string? Messgae { get; set; }
        public bool isSuucess { get; set; }
        public T obj { get; set; }
    }
}
