using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Tag
    {
        /// <summary>
        /// The hashtag, not including the preceding #
        /// </summary>
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The URL of the hashtag
        /// </summary>
        [DeserializeAs(Name = "url")]
        public string Url { get; set; }
    }
}
