using MastodonSharp.Attributes;
using MastodonSharp.Entity;
using MastodonSharp.Extentions;
using MastodonSharp.Streaming;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MastodonSharp
{
    /// <summary>
    /// https://github.com/tootsuite/documentation/blob/master/Using-the-API/API.md
    /// </summary>
    public class MastodonSharpClient
    {
        protected string _Host;

        protected string _AccessToken;

        public MastodonSharpClient(string host, string accessToken = null)
        {
            _Host = host;
            _AccessToken = accessToken;
        }
        
        [Query(Method.GET, "/api/v1/accounts/{id}")]
        public async Task<Account> GetAccount(int id)
        {
            var response = await Execute<Account>(nameof(GetAccount),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/accounts/verify_credentials")]
        public async Task<Account> GetCurrentAccount()
        {
            var response = await Execute<Account>(nameof(GetCurrentAccount));

            return response.Data;
        }
        
        [Query(Method.PATCH, "/api/v1/accounts/update_credentials")]
        public async Task<Account> UpdateAccount(string display_name = null, string note = null, string avatar = null, string header = null)
        {
            var response = await Execute<Account>(nameof(UpdateAccount),
                new { display_name, note, avatar, header });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/accounts/{id}/followers")]
        public async Task<List<Account>> GetFollowers(int id, int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Account>>(nameof(GetFollowers),
                new { max_id, since_id, limit },
                new { id });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/accounts/{id}/following")]
        public async Task<List<Account>> GetFollowing(int id, int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Account>>(nameof(GetFollowing),
                new { max_id, since_id, limit },
                new { id });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/accounts/{id}/statuses")]
        public async Task<List<Status>> GetAccountsStatuses(int id, bool? only_media = null, bool? exclude_replies = null, int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Status>> (nameof(GetAccountsStatuses),
                new { only_media, exclude_replies, max_id, since_id, limit },
                new { id });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/accounts/{id}/follow")]
        public async Task<Relationship> Follow(int id)
        {
            var response = await Execute<Relationship>(nameof(Follow),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/accounts/{id}/unfollow")]
        public async Task<Relationship> Unfollow(int id)
        {
            var response = await Execute<Relationship>(nameof(Unfollow),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/accounts/{id}/block")]
        public async Task<Relationship> Block(int id)
        {
            var response = await Execute<Relationship>(nameof(Block),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/accounts/{id}/unblock")]
        public async Task<Relationship> UnBlock(int id)
        {
            var response = await Execute<Relationship>(nameof(UnBlock),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/accounts/{id}/mute")]
        public async Task<Relationship> Mute(int id)
        {
            var response = await Execute<Relationship>(nameof(Mute),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/accounts/{id}/unmute")]
        public async Task<Relationship> UnMute(int id)
        {
            var response = await Execute<Relationship>(nameof(UnMute),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/accounts/relationships")]
        public async Task<List<Relationship>> GetRelationships(int id)
        {
            var method = GetAllMethod(nameof(GetRelationships), new Type[] { typeof(int) });
            var response = await Execute<List<Relationship>>(method,
                new { id });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/accounts/relationships")]
        public async Task<List<Relationship>> GetRelationships(IEnumerable<int> id)
        {
            var method = GetAllMethod(nameof(GetRelationships), new Type[] { typeof(IEnumerable<int>) });
            var response = await Execute<List<Relationship>>(method,
                new { id });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/accounts/search")]
        public async Task<List<Account>> SearchAccount(string q, int limit = 40)
        {
            var response = await Execute<List<Account>>(nameof(SearchAccount),
                new { q, limit });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/apps")]
        public async Task<AppRegistration> Register(string client_name, OAuthScope scopes, string redirect_uris = "urn:ietf:wg:oauth:2.0:oob", string website = null)
        {
            var response = await Execute<AppRegistration>(nameof(Register),
                new { client_name, redirect_uris, scopes, website });

            response.Data.AuthUrl = OAuthUrl(response.Data.ClientId, scopes, response.Data.RedirectUri);

            response.Data.Scope = scopes;

            response.Data.Instance = _Host;

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/blocks")]
        public async Task<StreamContent<Account>> GetBlocks(int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Account>>(nameof(GetBlocks),
                new { max_id, since_id, limit });

            return CreateStreamContent(response);
        }
        
        [Query(Method.GET, "/api/v1/favourites")]
        public async Task<StreamContent<Status>> GetFavourites(int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Status>>(nameof(GetFavourites),
                new { max_id, since_id, limit });

            return CreateStreamContent(response);
        }
        
        [Query(Method.GET, "/api/v1/follow_requests")]
        public async Task<StreamContent<Account>> GetFollowRequests(int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Account>>(nameof(GetFollowRequests),
                new { max_id, since_id, limit });

            return CreateStreamContent(response);
        }
        
        [Query(Method.POST, "/api/v1/follow_requests/{id}/authorize")]
        public async Task AuthorizeFollowRequest(int id)
        {
            await Execute(nameof(AuthorizeFollowRequest),
                null,
                new { id });
        }
        
        [Query(Method.POST, "/api/v1/follow_requests/{id}/reject")]
        public async Task RejectFollowRequest(int id)
        {
            await Execute(nameof(RejectFollowRequest),
                null,
                new { id });
        }

        [Query(Method.POST, "/api/v1/follows")]
        public async Task<Account> FollowRemoteUser(string uri)
        {
            var response = await Execute<Account>(nameof(FollowRemoteUser),
                new { uri });

            return response.Data;
        }

        [Query(Method.GET, "/api/v1/instance")]
        public async Task<Instance> GetInstance()
        {
            var response = await Execute<Instance>(nameof(GetInstance));

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/media")]
        public async Task<Attachment> UploadMedia(FileInfo file)
        {
            var response = await Execute<Attachment>(nameof(UploadMedia),
                new { file });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/mutes")]
        public async Task<List<Account>> GetMutes(int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Account>>(nameof(GetMutes),
                new { max_id, since_id, limit });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/notifications")]
        public async Task<StreamContent<Notification>> GetNotifications(int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Notification>>(nameof(GetNotifications),
                new { max_id, since_id, limit });

            return CreateStreamContent(response);
        }

        [Query(Method.GET, "/api/v1/notifications/{id}")]
        public async Task<Notification> GetNotification(int id)
        {
            var response = await Execute<Notification>(nameof(GetNotification),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/notifications/clear")]
        public async Task ClearNotifications()
        {
            await Execute(nameof(ClearNotifications));
        }
        
        [Query(Method.GET, "/api/v1/reports")]
        public async Task<List<Report>> GetReports()
        {
            var response = await Execute<List<Report>>(nameof(GetReports));

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/reports")]
        public async Task<Report> Report(int account_id, IEnumerable<int> status_ids, string comment)
        {
            var response = await Execute<Report>(nameof(Report),
                new { account_id, status_ids, comment });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/search")]
        public async Task<Results> Search(string q, bool resolve = false)
        {
            var response = await Execute<Results>(nameof(Search),
                new { q, resolve });

            return response.Data;
        }

        [Query(Method.GET, "/api/v1/statuses/{id}")]
        public async Task<Status> GetStatus(int id)
        {
            var response = await Execute<Status>(nameof(GetStatus),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/statuses/{id}/context")]
        public async Task<Context> GetStatusContext(int id)
        {
            var response = await Execute<Context>(nameof(GetStatusContext),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/statuses/{id}/card")]
        public async Task<Card> GetStatusCard(int id)
        {
            var response = await Execute<Card>(nameof(GetStatusCard),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/statuses/{id}/reblogged_by")]
        public async Task<List<Account>> GetRebloggedStatus(int id, int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Account>> (nameof(GetRebloggedStatus),
                new { max_id, since_id, limit },
                new { id });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/statuses/{id}/favourited_by")]
        public async Task<List<Account>> GetFavouritedStatus(int id, int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Account>>(nameof(GetFavouritedStatus),
                new { max_id, since_id, limit },
                new { id });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/statuses")]
        public async Task<Status> PostStatus(string status, int? in_reply_to_id = null, IEnumerable<int> media_ids = null, bool? sensitive = null, string spoiler_text = null, Visibility? visibility = null)
        {
            var response = await Execute<Status>(nameof(PostStatus),
                new { status, in_reply_to_id, media_ids, sensitive, spoiler_text, visibility });

            return response.Data;
        }
        
        [Query(Method.DELETE, "/api/v1/statuses/{id}")]
        public Task DeleteStatus(int id)
        {
            return Execute(nameof(DeleteStatus),
                null,
                new { id });
        }
        
        [Query(Method.POST, "/api/v1/statuses/{id}/reblog")]
        public async Task<Status> Reblog(int id)
        {
            var response = await Execute<Status>(nameof(Reblog),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/statuses/{id}/unreblog")]
        public async Task<Status> UnReblog(int id)
        {
            var response = await Execute<Status>(nameof(UnReblog),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/statuses/{id}/favourite")]
        public async Task<Status> Favourite(int id)
        {
            var response = await Execute<Status>(nameof(Favourite),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.POST, "/api/v1/statuses/{id}/unfavourite")]
        public async Task<Status> UnFavourite(int id)
        {
            var response = await Execute<Status>(nameof(UnFavourite),
                null,
                new { id });

            return response.Data;
        }
        
        [Query(Method.GET, "/api/v1/timelines/home")]
        public async Task<StreamContent<Status>> GetHomeTimeline(int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Status>>(nameof(GetHomeTimeline),
                new { max_id, since_id, limit });

            return CreateStreamContent(response);
        }
        
        [Query(Method.GET, "/api/v1/timelines/public")]
        public async Task<StreamContent<Status>> GetPublicTimeline(bool? local = null, int? max_id = null, int? since_id = null, int? limit = 20)
        {
            var response = await Execute<List<Status>>(nameof(GetPublicTimeline),
                new { local, max_id, since_id, limit });

            return CreateStreamContent(response);
        }

        [Query(Method.GET, "/api/v1/timelines/tag/{hashtag}")]
        public async Task<StreamContent<Status>> GetHashtagTimeline(string hashtag, bool? local = null, int? max_id = null, int? since_id = null, int? limit = null)
        {
            var response = await Execute<List<Status>>(nameof(GetHashtagTimeline),
                new { local, max_id, since_id, limit },
                new { hashtag });

            return CreateStreamContent(response);
        }

        [Query(Method.GET, "/api/v1/streaming/public")]
        public TimelineStreaming GetPublicTimelineStreaming()
        {
            var methodBase = GetAllMethod(nameof(GetPublicTimelineStreaming));

            var query = GetQuery(methodBase);

            var url = $"https://{_Host}{query.Item1}";

            return new TimelineStreaming(url, _AccessToken);
        }

        [Query(Method.GET, "/api/v1/streaming/user")]
        public TimelineStreaming GetUserTimelineStreaming()
        {
            var methodBase = GetAllMethod(nameof(GetPublicTimelineStreaming));

            var query = GetQuery(methodBase);

            var url = $"https://{_Host}{query.Item1}";

            return new TimelineStreaming(url, _AccessToken);
        }

        [Query(Method.GET, "/api/v1/streaming/hashtag")]
        public TimelineStreaming GetHashTagTimelineStreaming(string tag)
        {
            var methodBase = GetAllMethod(nameof(GetPublicTimelineStreaming));

            var query = GetQuery(methodBase);

            var url = $"https://{_Host}{query.Item1}?tag={tag}";

            return new TimelineStreaming(url, _AccessToken);
        }

        private Tuple<string , Method> GetQuery(MethodBase methodBase)
        {
            var queryAttribute = (QueryAttribute)methodBase.GetCustomAttribute(typeof(QueryAttribute));
            return Tuple.Create(queryAttribute.Query, queryAttribute.Method);
        }

        private Task<IRestResponse<T>> Execute<T>(MethodBase methodBase, object parameter = null, object urlSegment = null) where T : new()
        {
            var client = new RestClient($"https://{_Host}");

            var query = GetQuery(methodBase);

            var request = CreateRequest(query.Item1, query.Item2, parameter, urlSegment);

            return client.ExecuteTaskAsync<T>(request);
        }

        private Task Execute(MethodBase methodBase, object parameter = null, object urlSegment = null)
        {
            var client = new RestClient($"https://{_Host}");

            var query = GetQuery(methodBase);

            var request = CreateRequest(query.Item1, query.Item2, parameter, urlSegment);

            return client.ExecuteTaskAsync(request);
        }

        private Task<IRestResponse<T>> Execute<T>(string methodName, object parameter = null, object urlSegment = null) where T : new()
        {
            return Execute<T>(GetAllMethod(methodName), parameter, urlSegment);
        }

        private Task Execute(string methodName, object parameter = null, object urlSegment = null)
        {
            return Execute(GetAllMethod(methodName), parameter, urlSegment);
        }

        private MethodInfo GetAllMethod(string methodName)
        {
            return typeof(MastodonSharpClient).GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        }

        private MethodInfo GetAllMethod(string methodName, Type[] types)
        {
            return typeof(MastodonSharpClient).GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, types, null);
        }

        private RestRequest CreateRequest(string query, Method method, object parameter, object urlSegment)
        {
            var request = new RestRequest(query, method);

            if (!string.IsNullOrEmpty(_AccessToken))
            {
                request.AddHeader("Authorization", $"Bearer {_AccessToken}");
            }

            var parameterSet = parameter?.ToDictionary();

            if (parameterSet != null)
            {
                foreach (var item in parameterSet)
                {
                    if (item.Value is string)
                    {
                        request.AddParameter(item.Key, item.Value);
                    }
                    else if (item.Value is FileInfo fileinfo)
                    {
                        var bs = File.ReadAllBytes(fileinfo.FullName);

                        request.AddFileBytes(item.Key, bs, fileinfo.Name);
                    }
                    else if (item.Value is IEnumerable enumerable)
                    {
                        foreach (var element in enumerable)
                        {
                            request.AddParameter($"{item.Key}[]", element);
                        }
                    }
                    else if (item.Value is Visibility visibility)
                    {
                        request.AddParameter(item.Key, visibility.ToParam());
                    }
                    else if (item.Value is bool flag && flag)
                    {
                        request.AddParameter(item.Key, "1");
                    }
                    else if (item.Value is OAuthScope scope)
                    {
                        request.AddParameter(item.Key, scope.ToString());
                    }
                    else
                    {
                        request.AddParameter(item.Key, item.Value);
                    }
                }
            }

            var urlSegmentSet = urlSegment?.ToUrlSegment();

            if (urlSegmentSet != null)
            {
                foreach (var item in urlSegmentSet)
                {
                    request.AddUrlSegment(item.Key, item.Value);
                }
            }

            return request;
        }

        private string OAuthUrl(string clientid, OAuthScope scope, string redirectUri)
        {
            return $"https://{_Host}/oauth/authorize?response_type=code&client_id={clientid}&scope={scope.ToString().Replace(" ", "%20")}&redirect_uri={redirectUri}";
        }

        private StreamContent<T> CreateStreamContent<T>(IRestResponse<List<T>> response)
        {
            var linkHeader = response.Headers.FirstOrDefault(x => x.Name == "Link");

            var streamContent = new StreamContent<T>();

            streamContent.Content = response.Data;
            var header = linkHeader.Value.ToString().GetHeader();
            streamContent.Next = header.Item1;
            streamContent.Prev = header.Item2;

            return streamContent;
        }
    }
}
