using NUnit.Framework;
using RestSharp;
using FluentAssertions;
using System.Net;
using Newtonsoft.Json.Linq;
using System;

namespace APITestingProject
{
    public class APITests : IDisposable
    {
        private RestClient _client;
        private const string BaseUrl = "https://jsonplaceholder.typicode.com";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(new RestClientOptions(BaseUrl));
        }

        [Test]
        public void Test1_GetRequest()
        {
            var request = new RestRequest("/posts/1");
            var response = _client.Execute(request);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.Should().NotBeNull();
            var jsonResponse = JObject.Parse(response.Content!);
            jsonResponse["userId"].Should().NotBeNull();
            jsonResponse["id"].Should().NotBeNull();
            jsonResponse["title"].Should().NotBeNull();
            jsonResponse["body"].Should().NotBeNull();

            Console.WriteLine($"GET Request - Response: {response.Content}");
        }

        [Test]
        public void Test2_PostRequest()
        {
            var request = new RestRequest("/posts").AddJsonBody(new
            {
                userId = 1,
                title = "New Post Title",
                body = "This is the body of the new post."
            });

            var response = _client.Execute(request, Method.Post);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            response.Content.Should().NotBeNull();
            var jsonResponse = JObject.Parse(response.Content!);
            jsonResponse["id"].Should().NotBeNull();
            jsonResponse["title"]?.Value<string>().Should().Be("New Post Title");
            jsonResponse["body"]?.Value<string>().Should().Be("This is the body of the new post.");

            Console.WriteLine($"POST Request - Response: {response.Content}");
        }

        [Test]
        public void Test3_PutRequest()
        {
            var request = new RestRequest("/posts/1").AddJsonBody(new
            {
                userId = 1,
                id = 1,
                title = "Updated Post Title",
                body = "This is the updated body of the post."
            });

            var response = _client.Execute(request, Method.Put);

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            response.Content.Should().NotBeNull();
            var jsonResponse = JObject.Parse(response.Content!);
            jsonResponse["title"]?.Value<string>().Should().Be("Updated Post Title");
            jsonResponse["body"]?.Value<string>().Should().Be("This is the updated body of the post.");

            Console.WriteLine($"PUT Request - Response: {response.Content}");
        }

        [Test]
        public void Test4_DeleteRequest()
        {
            var request = new RestRequest("/posts/1");
            var response = _client.Execute(request, Method.Delete);

            response.StatusCode.Should().BeOneOf(HttpStatusCode.OK, HttpStatusCode.NoContent);

            Console.WriteLine($"DELETE Request - Status Code: {response.StatusCode}");
            if (!string.IsNullOrEmpty(response.Content))
            {
                Console.WriteLine($"DELETE Request - Response: {response.Content}");
            }
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}