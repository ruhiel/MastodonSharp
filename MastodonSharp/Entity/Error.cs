using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Error
    {
        /// <summary>
        /// A textual description of the error
        /// </summary>
        [DeserializeAs(Name = "error")]
        public string Description { get; set; }
    }
}
