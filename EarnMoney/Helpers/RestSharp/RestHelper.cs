using AutoMapper.Configuration.Annotations;
using EarnMoney.Helpers.PathURL;
using EarnMoney.Models.Requests.EarnMoney.Withdraw;
using EarnMoney.Models.Requests.WhatsApp;
using Microsoft.Extensions.Logging;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Collections.Concurrent;
using System.Net;

namespace EarnMoney.Helpers.RestSharp
{
    public class RestHelper
    {
        private static readonly string _baseUrl = EarnMoneyRoute.BaseUrl;

        private static readonly string _webhook = "http://192.168.32.229:1891/sendText";
        private static readonly string _noHP = "6287759895339@c.us";

        public static async Task<RestResponse> SendText(string message)
        {
            try
            {
                var client = new RestClient(_webhook);
                var request = new RestRequest("", Method.Post);
                request.AddBody(new WhatsAppSendTextRequest { Message = message, Phone = _noHP }, contentType: ContentType.Json);
                var response = await client.ExecuteAsync(request);
                return response;
            }
            catch (Exception)
            {
                return null!;
            }
        }

        public static async Task<RestResponse<T>> GetResponse<T>(string path, Method method, Dictionary<string, object> headers, object body = null!) where T : class
        {
            try
            {
                var client = new RestClient(_baseUrl, configureSerialization: s => s.UseNewtonsoftJson());
                var request = new RestRequest(path, method);
                if (body != null) request.AddBody(body, ContentType.FormUrlEncoded);
                foreach (var item in headers)
                {
                    request.AddOrUpdateHeader(item.Key, item.Value.ToString()!);
                }
                var response = await client.ExecuteAsync<T>(request);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static Dictionary<string, object> CreateHeaderFix(string token = "")
        {
            return new Dictionary<string, object>
                {
                    { "log-header", "I am the log request header." },
                    { "token", $"{token}" },
                    { "Content-Type", "application/x-www-form-urlencoded" },
                    { "Host", "admin.tgldy.xyz" },
                    { "Connection", "Keep-Alive" },
                    { "Accept-Encoding", "gzip" },
                    { "User-Agent", "okhttp/4.10.0" }
                };
        }
        public static async Task<RestResponse<T>> GetResponse2<T>(RestRequest request) where T : class
        {
            try
            {
                
                var client = new RestClient(_baseUrl, configureSerialization: s => s.UseNewtonsoftJson());
                var response = await client.ExecuteAsync<T>(request);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static async Task<RestResponse> GetResponse(string path, Method method, Dictionary<string, object> headers, object body = null!)
        {
            try
            {
                var client = new RestClient(_baseUrl, configureSerialization: s => s.UseNewtonsoftJson());
                var request = new RestRequest(path, method);
                if (body != null) request.AddBody(body, ContentType.FormUrlEncoded);
                foreach (var item in headers)
                {
                    request.AddOrUpdateHeader(item.Key, item.Value.ToString()!);
                }
                var response = await client.ExecuteAsync(request);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<RestResponse> GetRedirect(string url)
        {
            try
            {
                var client = new RestClient(url, configureSerialization: s => s.UseNewtonsoftJson());
                var request = new RestRequest("", Method.Get);
                var response = await client.ExecuteAsync(request);
                if (response.StatusCode == HttpStatusCode.Found)
                {
                    var location = response.Headers!.FirstOrDefault(e => e.Name == "Location");
                    if (location != null)
                    {
                        await GetRedirect(location!.Value!.ToString()!);
                    }
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
