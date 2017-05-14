using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Mention
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// URL of user's profile (can be remote)
        /// </summary>
        [DeserializeAs(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The username of the account
        /// </summary>
        [DeserializeAs(Name = "username")]
        public string UserName { get; set; }

        /// <summary>
        /// Equals username for local users, includes @domain for remote ones
        /// </summary>
        [DeserializeAs(Name = "acct")]
        public string AccountName { get; set; }

    }
}
