using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Diagnostics;
using WebExamMVC.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebExamMVC.Services;

namespace WebExamMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JwtTokenService _jwtTokenService;
        public HomeController(IHttpClientFactory httpClientFactory, JwtTokenService jwtTokenService)
        {
            _httpClientFactory = httpClientFactory;
            _jwtTokenService = jwtTokenService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var token = await GetJwtToken(model.Login, model.Password);
            if (token != null)
            {
                _jwtTokenService.StoreToken(token);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }


        [HttpGet]
        public IActionResult Index()
        {
            var token = _jwtTokenService.GetToken();

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login");
            }

            return View();
        }
        private async Task<string> GetJwtToken(string login, string password)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7207/Login", new { login, password });

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var tokenResponse = JsonConvert.DeserializeObject(jsonResponse).ToString();

                return tokenResponse;
            }

            return null;
        }
    }
}
