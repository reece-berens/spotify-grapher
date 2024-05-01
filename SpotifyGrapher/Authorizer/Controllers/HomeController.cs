using Authorizer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace Authorizer.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _config;
		private readonly HttpClient _httpClient;

		public HomeController(ILogger<HomeController> logger, IConfiguration config)
		{
			_logger = logger;
			_config = config;
			_httpClient = new();
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult MyLoginPage()
		{
			string redirect = _config["RedirectURL"];
			string clientID = _config["ClientID"];
			StringBuilder sb = new("https://accounts.spotify.com/authorize?");
			sb.Append($"client_id={clientID}&");
			sb.Append($"response_type=code&");
			sb.Append($"redirect_uri={redirect}&");
			sb.Append($"scope=playlist-modify-public playlist-read-private user-read-private");
			return Redirect(sb.ToString());
		}

		public async Task<IActionResult> SpotifyLoginRedirect(string code, string error)
		{
            string redirect = _config["RedirectURL"];
			string clientID = _config["ClientID"];
			string clientSecret = _config["ClientSecret"];
            HttpRequestMessage request = new();
			Dictionary<string, string> bodyValues = new()
			{
				{ "grant_type", "authorization_code" },
				{ "code", code },
				{ "redirect_uri", redirect }
			};
			request.Method = HttpMethod.Post;
			string plainClient = $"{clientID}:{clientSecret}";
			byte[] plainBytes = Encoding.UTF8.GetBytes(plainClient);
			string b64 = Convert.ToBase64String(plainBytes);
			request.Headers.Authorization = new("Basic", b64);
			request.Content = new FormUrlEncodedContent(bodyValues);
			request.RequestUri = new("https://accounts.spotify.com/api/token");
			

			HttpResponseMessage response = await _httpClient.SendAsync(request);
			SpotifyTokenExchangeResponse tokenResponse = await response.Content.ReadFromJsonAsync<SpotifyTokenExchangeResponse>();

			ViewData["AccessToken"] = tokenResponse.access_token;
			ViewData["RefreshToken"] = tokenResponse.refresh_token;
			ViewData["Expiration"] = tokenResponse.expires_in;

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}

	public class SpotifyTokenExchangeResponse
	{
		public string access_token { get; set; }
		public string token_type { get; set; }
		public string scope { get; set; }
		public int expires_in { get; set; }
		public string refresh_token { get; set; }
	}
}
