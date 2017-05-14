using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class AppRegistration
    {
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        [DeserializeAs(Name = "redirect_uri")]
        public string RedirectUri { get; set; }

        [DeserializeAs(Name = "client_id")]
        public string ClientId { get; set; }

        [DeserializeAs(Name = "client_secret")]
        public string ClientSecret { get; set; }

        public string Instance { get; set; }

        public OAuthScope Scope { get; set; }

        public string AuthUrl { get; set; }
    }
}
