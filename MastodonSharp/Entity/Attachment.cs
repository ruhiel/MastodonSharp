using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Attachment
    {
        /// <summary>
        /// ID of the attachment
        /// </summary>
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// One of: "image", "video", "gifv"
        /// </summary>
        [DeserializeAs(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// URL of the locally hosted version of the image
        /// </summary>
        [DeserializeAs(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// For remote images, the remote URL of the original image
        /// </summary>
        [DeserializeAs(Name = "remote_url")]
        public string RemoteUrl { get; set; }

        /// <summary>
        /// URL of the preview image
        /// </summary>
        [DeserializeAs(Name = "preview_url")]
        public string PreviewUrl { get; set; }

        /// <summary>
        /// Shorter URL for the image, for insertion into text (only present on local images)
        /// </summary>
        [DeserializeAs(Name = "text_url")]
        public string TextUrl { get; set; }
    }
}
