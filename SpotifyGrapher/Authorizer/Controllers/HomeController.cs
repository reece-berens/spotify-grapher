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

		public HomeController(ILogger<HomeController> logger, IConfiguration config)
		{
			_logger = logger;
			_config = config;
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

			return Redirect(sb.ToString());
		}

		public IActionResult SpotifyLoginRedirect(string code, string error)
		{
			//exchange the token for the code here...
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
}
