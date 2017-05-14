using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
   public  class Context
    {
        /// <summary>
        /// The ancestors of the status in the conversation
        /// </summary>
        [DeserializeAs(Name = "ancestors")]
        public List<Status> Ancestors { get; set; }

        /// <summary>
        /// The descendants of the status in the conversation
        /// </summary>
        [DeserializeAs(Name = "descendants")]
        public List<Status> Descendants { get; set; }
    }
}
