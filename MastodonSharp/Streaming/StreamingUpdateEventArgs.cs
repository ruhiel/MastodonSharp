using MastodonSharp.Entity;

namespace MastodonSharp.Streaming
{
    public class StreamingUpdateEventArgs
    {
        public Status Status { get; internal set; }
    }
}