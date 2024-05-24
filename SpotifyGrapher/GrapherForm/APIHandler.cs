using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrapherForm
{
    public static class APIHandler
    {
        public static HttpClient HttpClient { get; set; } = new();
        public static object ClientLock { get; set; } = new();

        public static async Task<string> RefreshAccessToken(string refreshToken, string clientID, string clientSecret)
        {
            HttpRequestMessage request = new()
            {
                Method = HttpMethod.Post,
                RequestUri = new("https://accounts.spotify.com/api/token"),
            };
            string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientID}:{clientSecret}"));
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", base64);

            Dictionary<string, string> body = new()
            {
                { "grant_type", "refresh_token" },
                { "refresh_token", refreshToken },
                { "client_id", clientID }
            };
            request.Content = new FormUrlEncodedContent(body);

            HttpResponseMessage response;
            lock(ClientLock)
            {
                response = HttpClient.SendAsync(request).Result;
            }

            string responseJson = await response.Content.ReadAsStringAsync();
            RefreshAccessTokenResponse tokenResponse = JsonSerializer.Deserialize<RefreshAccessTokenResponse>(responseJson);
            if (tokenResponse != null)
            {
                return tokenResponse.access_token;
            }
            else
            {
                return null;
            }
        }

        public class RefreshAccessTokenResponse
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public string scope { get; set; }
        }
    }
}
