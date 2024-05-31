using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebExamMVC.Models;

namespace WebExamMVC.Services
{
    public class QuestionService
    {
        private readonly HttpClient _httpClient;
        public QuestionService(IHttpClientFactory httpClientFactory, JwtTokenService tokenService)
        {
            _httpClient = httpClientFactory.CreateClient();
            SetToken(tokenService.GetToken());
        }
        private void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<List<QuestionModel>> Get()
        {
            var response = await _httpClient.GetAsync("https://localhost:7207/Questions");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<QuestionModel>>(jsonString);
        }
        public async Task<QuestionModel> Get(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7207/Questions/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<QuestionModel>(jsonString);
        }
        public async Task<QuestionModel> Create(QuestionModel question)
        {
            var json = JsonConvert.SerializeObject(question);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7207/Questions", content);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<QuestionModel>(jsonString);
        }
        public async Task<bool> Update(QuestionModel question)
        {
            var json = JsonConvert.SerializeObject(question);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("https://localhost:7207/Questions", content);
            response.EnsureSuccessStatusCode();

            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7207/Questions/{id}");
            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
