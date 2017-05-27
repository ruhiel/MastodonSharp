using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Card
    {
        /// <summary>
        /// The url associated with the card
        /// </summary>
        [DeserializeAs(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The title of the card
        /// </summary>
        [DeserializeAs(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// The card description
        /// </summary>
        [DeserializeAs(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The image associated with the card, if any
        /// </summary>
        [DeserializeAs(Name = "image")]
        public string Image { get; set; }

        /// <summary>
        /// "link", "photo", "video", or "rich"
        /// </summary>
        [DeserializeAs(Name = "type")]
        public string Type { get; set; }
    }
}
