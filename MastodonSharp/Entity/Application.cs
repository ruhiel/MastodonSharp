using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Application
    {
        /// <summary>
        /// Name of the app
        /// </summary>
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Homepage URL of the app
        /// </summary>
        [DeserializeAs(Name = "website")]
        public string Website { get; set; }
    }
}
