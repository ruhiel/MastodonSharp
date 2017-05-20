using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Instance
    {
        /// <summary>
        /// URI of the current instance
        /// </summary>
        [DeserializeAs(Name = "uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The instance's title
        /// </summary>
        [DeserializeAs(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// A description for the instance
        /// </summary>
        [DeserializeAs(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// An email address which can be used to contact the instance administrator
        /// </summary>
        [DeserializeAs(Name = "email")]
        public string Email { get; set; }
    }
}
