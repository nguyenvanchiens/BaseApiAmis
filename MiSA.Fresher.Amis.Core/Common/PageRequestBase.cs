using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSA.Fresher.Amis.Core.Common
{
    public class PageRequestBase
    {
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
        public string? entityFilter { get; set; }

    }
}
