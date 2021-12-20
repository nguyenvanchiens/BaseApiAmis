using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.Exceptions
{
    public class HttpResponseException: Exception
    {
        public HttpResponseException(object? value = null) =>
          (Value) = (value);
        public object? Value { get; }
    }
}
