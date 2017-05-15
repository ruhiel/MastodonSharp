using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastodonSharp.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class QueryAttribute : Attribute
    {
        public Method Method { get; private set; }
        public String Query { get; private set; }

        public QueryAttribute(Method method, String query)
        {
            Method = method;
            Query = query;
        }
    }
}
