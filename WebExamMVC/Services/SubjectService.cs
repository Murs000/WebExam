using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebExamMVC.Models;

namespace WebExamMVC.Services
{
    public class SubjectService
    {
        private readonly HttpClient _httpClient;
        public SubjectService(IHttpClientFactory httpClientFactory, JwtTokenService tokenService)
        {
            _httpClient = httpClientFactory.CreateClient();
            SetToken(tokenService.GetToken());
        }
        private void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<List<SubjectModel>> Get()
        {
            var response = await _httpClient.GetAsync("https://localhost:7207/Subjects");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<SubjectModel>>(jsonString);
        }
        public async Task<SubjectModel> Get(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7207/Subjects/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SubjectModel>(jsonString);
        }
        public async Task<SubjectModel> Create(SubjectModel subject)
        {
            var json = JsonConvert.SerializeObject(subject);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7207/Subjects", content);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SubjectModel>(jsonString);
        }
        public async Task<bool> Update(SubjectModel subject)
        {
            var json = JsonConvert.SerializeObject(subject);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("https://localhost:7207/Subjects", content);
            response.EnsureSuccessStatusCode();

            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7207/Subjects/{id}");
            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
