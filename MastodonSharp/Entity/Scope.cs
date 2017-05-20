using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastodonSharp.Entity
{
    public enum Scope
    {
        Read = 1,
        Write = 1 << 1,
        Follow = 1 << 2
    }
}
