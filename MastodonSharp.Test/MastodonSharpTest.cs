﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using MastodonSharp.Entity;

namespace MastodonSharp.Test
{
    [TestClass]
    public class MastodonSharpTest
    {
        protected static string _AccessToken;
        protected static string _Host;
        protected static int _TestUserID;
        protected static int _TestTargetUserId;
        protected static string _TestPicture;
        protected static string _RemoteUser;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // アセンブリ内のすべてのテストが実行される前に、アセンブリによって取得されるリソースを割り当てるために使用されるコードを含むメソッドを識別します。 
            Trace.WriteLine("AssemblyInit " + context.TestName);

            _AccessToken = Environment.GetEnvironmentVariable("TestAuthCode");

            _Host = Environment.GetEnvironmentVariable("TestHost");

            _TestUserID = int.Parse(Environment.GetEnvironmentVariable("TestUserID"));

            _TestTargetUserId = int.Parse(Environment.GetEnvironmentVariable("TestTargetUserId"));

            _TestPicture = Environment.GetEnvironmentVariable("TestPicture");

            _RemoteUser = Environment.GetEnvironmentVariable("RemoteUser");
        }

        [TestMethod]
        public async Task TestGetFollowers()
        {
            var client = new MastodonSharpClient(_Host, _AccessToken);
            var id = _TestUserID;

            var stream = await client.GetPublicTimeline();

            Assert.IsTrue(stream.Content.Any());
        }

        [TestMethod]
        public async Task TestGetInstance()
        {
            var client = new MastodonSharpClient(_Host, _AccessToken);

            var result = await client.GetInstance();

            Assert.IsNotNull(result.Description);

            Assert.IsNotNull(result.Email);

            Assert.IsNotNull(result.Title);

            Assert.IsNotNull(result.Uri);

            Assert.IsNotNull(result.Version);
        }

        [TestMethod]
        public async Task TestRegister()
        {
            var client = new MastodonSharpClient(_Host, _AccessToken);

            var result = await client.Register("MastodonClient", OAuthScope.of(Scope.Read, Scope.Write, Scope.Follow));

            Assert.IsNotNull(result.Id);

            Assert.IsNotNull(result.ClientId);

            Assert.IsNotNull(result.ClientSecret);

            Assert.IsNotNull(result.AuthUrl);

            Assert.IsNotNull(result.RedirectUri);

            Assert.IsNotNull(result.Scope);

            Assert.IsNotNull(result.Instance);
        }

        [TestMethod]
        public async Task MyMute()
        {
            var client = new MastodonSharpClient(_Host, _AccessToken);
            var result = await client.Mute(_TestTargetUserId);

            Assert.IsNotNull(result.Blocking);

            Assert.IsNotNull(result.DomainBlocking);

            Assert.IsNotNull(result.FollowedBy);

            Assert.IsNotNull(result.Following);

            Assert.IsNotNull(result.Id);

            Assert.IsNotNull(result.Muting);

            Assert.IsNotNull(result.MutingBoosts);

            Assert.IsNotNull(result.Requested);

            await client.UnMute(_TestTargetUserId);
        }
    }
}
