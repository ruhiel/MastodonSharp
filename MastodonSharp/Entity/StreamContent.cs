using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastodonSharp.Entity
{
    public class StreamContent<T>
    {
        public List<T> Content { get; set; }
        public int? Prev { get; set; }
        public int? Next { get; set; }
    }
}
