using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Notification
    {
        /// <summary>
        /// The notification ID
        /// </summary>
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// One of: "mention", "reblog", "favourite", "follow"
        /// </summary>
        [DeserializeAs(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// The time the notification was created
        /// </summary>
        [DeserializeAs(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The Account sending the notification to the user
        /// </summary>
        [DeserializeAs(Name = "account")]
        public Account Account { get; set; }

        /// <summary>
        /// The Status associated with the notification, if applicible
        /// </summary>
        [DeserializeAs(Name = "status")]
        public Status Status { get; set; }
    }
}
