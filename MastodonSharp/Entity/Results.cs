using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Results
    {
        /// <summary>
        /// An array of matched Accounts
        /// </summary>
        [DeserializeAs(Name = "accounts")]
        public List<Account> Accounts { get; set; }

        /// <summary>
        /// An array of matchhed Statuses
        /// </summary>
        [DeserializeAs(Name = "statuses")]
        public List<Status> Statuses { get; set; }

        /// <summary>
        /// An array of matched hashtags, as strings
        /// </summary>
        [DeserializeAs(Name = "hashtags")]
        public List<string> Hashtags { get; set; }
    }
}
