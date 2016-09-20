using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wangjianlong.functionality.Tools.Tools
{
    interface ITang
    {
        string Description { get; }
        string Error { get; set; }
        int Count { get; set; }
        bool Init();
    }
}
