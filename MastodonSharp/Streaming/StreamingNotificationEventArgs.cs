using MastodonSharp.Entity;

namespace MastodonSharp.Streaming
{
    public class StreamingNotificationEventArgs
    {
        public Notification Notification { get; internal set; }
    }
}