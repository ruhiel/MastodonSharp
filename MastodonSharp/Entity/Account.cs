using RestSharp.Deserializers;
using System;

namespace MastodonSharp.Entity
{
    public class Account
    {
        /// <summary>
        /// The ID of the account
        /// </summary>
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

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

        /// <summary>
        /// The account's display name
        /// </summary>
        [DeserializeAs(Name = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Boolean for when the account cannot be followed without waiting for approval first
        /// </summary>
        [DeserializeAs(Name = "locked")]
        public bool Locked { get; set; }

        /// <summary>
        /// The time the account was created
        /// </summary>
        [DeserializeAs(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The number of followers for the account
        /// </summary>
        [DeserializeAs(Name = "followers_count")]
        public int FollowersCount { get; set; }

        /// <summary>
        /// The number of accounts the given account is following
        /// </summary>
        [DeserializeAs(Name = "following_count")]
        public int FollowingCount { get; set; }

        /// <summary>
        /// The number of statuses the account has made
        /// </summary>
        [DeserializeAs(Name = "statuses_count")]
        public int StatusesCount { get; set; }

        /// <summary>
        /// Biography of user
        /// </summary>
        [DeserializeAs(Name = "note")]
        public string Note { get; set; }

        /// <summary>
        /// URL of the user's profile page (can be remote)
        /// </summary>
        [DeserializeAs(Name = "url")]
        public string ProfileUrl { get; set; }

        /// <summary>
        /// URL to the avatar image
        /// </summary>
        [DeserializeAs(Name = "avatar")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// URL to the avatar static image (gif)
        /// </summary>
        [DeserializeAs(Name = "avatar_static")]
        public string AvatarStaticUrl { get; set; }

        /// <summary>
        /// URL to the header image
        /// </summary>
        [DeserializeAs(Name = "header")]
        public string HeaderUrl { get; set; }

        /// <summary>
        /// URL to the header image
        /// </summary>
        [DeserializeAs(Name = "header_static")]
        public string HeaderStaticUrl { get; set; }
    }
}
