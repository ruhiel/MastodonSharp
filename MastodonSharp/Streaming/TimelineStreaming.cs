using MastodonSharp.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MastodonSharp.Streaming
{
    public class TimelineStreaming
    {
        private string url;
        private string accessToken;
        private HttpClient client;


        public event EventHandler<StreamingUpdateEventArgs> OnUpdate;
        public event EventHandler<StreamingNotificationEventArgs> OnNotification;
        public event EventHandler<StreamingDeleteEventArgs> OnDelete;

        internal TimelineStreaming(string url, string accessToken)
        {
            this.url = url;
            this.accessToken = accessToken;
        }

        public async Task Start()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

            var stream = await client.GetStreamAsync(url);

            var reader = new StreamReader(stream);

            string eventName = null;
            string data = null;

            while (client != null)
            {
                var line = await reader.ReadLineAsync();


                if (string.IsNullOrEmpty(line) || line.StartsWith(":"))
                {
                    eventName = data = null;
                    continue;
                }

                if (line.StartsWith("event: "))
                {
                    eventName = line.Substring("event: ".Length).Trim();
                }
                else if (line.StartsWith("data: "))
                {
                    data = line.Substring("data: ".Length);

                    switch (eventName)
                    {
                        case "update":
                            var status = JsonConvert.DeserializeObject<Status>(data);
                            OnUpdate?.Invoke(this, new StreamingUpdateEventArgs() { Status = status });
                            break;
                        case "notification":
                            var notification = JsonConvert.DeserializeObject<Notification>(data);
                            OnNotification?.Invoke(this, new StreamingNotificationEventArgs() { Notification = notification });
                            break;
                        case "delete":
                            var statusId = int.Parse(data);
                            OnDelete?.Invoke(this, new StreamingDeleteEventArgs() { StatusId = statusId });
                            break;
                    }
                }
            }
            this.Stop();
        }

        public void Stop()
        {
            if (client != null)
            {
                client.Dispose();
                client = null;
            }
        }
    }
}
