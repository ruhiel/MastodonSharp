# MastodonSharp
MastodonSharp is Mastodon Wrapper Library for C#

# Usage
```
static void Main(string[] args)
{
    var accessToken = Console.ReadLine();

    var host = Console.ReadLine();

    var client = new MastodonSharpClient(host, accessToken);

    var streaming = client.GetPublicTimelineStreaming();

    streaming.OnUpdate += Streaming_OnUpdate;

    streaming.Start().Wait();
}

private static void Streaming_OnUpdate(object sender, MastodonSharp.Streaming.StreamingUpdateEventArgs e)
{
    Console.WriteLine(e.Status.Content);
}
```

## License
MIT
