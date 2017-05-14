using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MastodonSharp.Entity
{
    public class Report
    {
        /// <summary>
        /// The ID of the report
        /// </summary>
        [DeserializeAs(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// The action taken in response to the report
        /// </summary>
        [DeserializeAs(Name = "action_taken")]
        public string ActionTaken { get; set; }
    }
}
