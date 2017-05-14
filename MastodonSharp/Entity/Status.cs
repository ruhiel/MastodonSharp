using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Status
    {
        /// <summary>
        /// The ID of the status
        /// </summary>
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// A Fediverse-unique resource ID
        /// </summary>
        [DeserializeAs(Name = "uri")]
        public string Uri { get; set; }

        /// <summary>
        /// URL to the status page (can be remote)
        /// </summary>
        [DeserializeAs(Name = "url")]
        public string Url { get; set; }

        /// <summary>
        /// The Account which posted the status
        /// </summary>
        [DeserializeAs(Name = "account")]
        public Account Account { get; set; }

        /// <summary>
        /// null or the ID of the status it replies to
        /// </summary>
        [DeserializeAs(Name = "in_reply_to_id")]
        public int? InReplyToId { get; set; }

        /// <summary>
        /// null or the ID of the account it replies to
        /// </summary>
        [DeserializeAs(Name = "in_reply_to_account_id")]
        public int? InReplyToAccountId { get; set; }

        /// <summary>
        /// null or the reblogged Status
        /// </summary>
        [DeserializeAs(Name = "reblog")]
        public Status Reblog { get; set; }

        /// <summary>
        /// Body of the status; this will contain HTML (remote HTML already sanitized)
        /// </summary>
        [DeserializeAs(Name = "content")]
        public string Content { get; set; }

        /// <summary>
        /// The time the status was created
        /// </summary>
        [DeserializeAs(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The number of reblogs for the status
        /// </summary>
        [DeserializeAs(Name = "reblogs_count")]
        public int ReblogCount { get; set; }

        /// <summary>
        /// The number of favourites for the status
        /// </summary>
        [DeserializeAs(Name = "favourites_count")]
        public int FavouritesCount { get; set; }

        /// <summary>
        /// Whether the authenticated user has reblogged the status
        /// </summary>
        [DeserializeAs(Name = "reblogged")]
        public bool? Reblogged { get; set; }

        /// <summary>
        /// Whether the authenticated user has favourited the status
        /// </summary>
        [DeserializeAs(Name = "favourited")]
        public bool? Favourited { get; set; }

        /// <summary>
        /// Whether media attachments should be hidden by default
        /// </summary>
        [DeserializeAs(Name = "sensitive")]
        public bool? Sensitive { get; set; }

        /// <summary>
        /// If not empty, warning text that should be displayed before the actual content
        /// </summary>
        [DeserializeAs(Name = "spoiler_text")]
        public string SpoilerText { get; set; }

        /// <summary>
        /// One of: public, unlisted, private, direct
        /// </summary>
        [DeserializeAs(Name = "visibility")]
        public string Visibility { get; set; }

        /// <summary>
        /// An array of Attachments
        /// </summary>
        [DeserializeAs(Name = "media_attachments")]
        public List<Attachment> MediaAttachments { get; set; }

        /// <summary>
        /// An array of Mentions
        /// </summary>
        [DeserializeAs(Name = "mentions")]
        public List<Mention> Mentions { get; set; }

        /// <summary>
        /// An array of Tags
        /// </summary>
        [DeserializeAs(Name = "tags")]
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Application from which the status was posted
        /// </summary>
        [DeserializeAs(Name = "application")]
        public Application Application { get; set; }

    }
}
