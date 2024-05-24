﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
                response = HttpClient.Send(request);
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

        public static async Task<RelatedArtistsResponse> GetRelatedArtists(string artistID, string accessToken)
        {
            HttpRequestMessage request = new()
            {
                Method = HttpMethod.Get,
                RequestUri = new($"https://api.spotify.com/v1/artists/{artistID}/related-artists")
            };
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response;
            lock(ClientLock)
            {
                response = HttpClient.Send(request);
            }

            string responseJson = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                RelatedArtistsResponse artistsResponse = JsonSerializer.Deserialize<RelatedArtistsResponse>(responseJson);
                return artistsResponse;
            }
            else
            {
                Console.WriteLine("ERROR with related artists");
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(responseJson);
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

        public class RelatedArtistsResponse
        {
            public List<Artist> artists { get; set; }

            public class Artist
            {
                public List<string> genres { get; set; }
                public string id { get; set; }
                public string name { get; set; }
                public string type { get; set; }
            }
        }
    }
}
