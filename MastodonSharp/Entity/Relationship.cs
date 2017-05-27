using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Relationship
    {
        /// <summary>
        /// Target account id
        /// </summary>
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Whether the user is currently following the account
        /// </summary>
        [DeserializeAs(Name = "following")]
        public bool Following { get; set; }

        /// <summary>
        /// Whether the user is currently being followed by the account
        /// </summary>
        [DeserializeAs(Name = "followed_by")]
        public bool FollowedBy { get; set; }

        /// <summary>
        /// Whether the user is currently blocking the account
        /// </summary>
        [DeserializeAs(Name = "blocking")]
        public bool Blocking { get; set; }

        /// <summary>
        /// Whether the user is currently muting the account
        /// </summary>
        [DeserializeAs(Name = "muting")]
        public bool Muting { get; set; }

        /// <summary>
        /// Whether the user is currently muting the account
        /// </summary>
        [DeserializeAs(Name = "muting_boosts")]
        public bool MutingBoosts { get; set; }

        /// <summary>
        /// Whether the user has requested to follow the account
        /// </summary>
        [DeserializeAs(Name = "requested")]
        public bool Requested { get; set; }

        /// <summary>
        /// Whether the user has requested to follow the account
        /// </summary>
        [DeserializeAs(Name = "domain_blocking")]
        public bool DomainBlocking { get; set; }
    }
}
