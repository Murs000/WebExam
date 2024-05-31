// File: Services/ExamService.cs
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebExamMVC.Models;

namespace WebExamMVC.Services
{
    public class ExamService
    {
        private readonly HttpClient _httpClient;

        public ExamService(IHttpClientFactory httpClientFactory, JwtTokenService tokenService)
        {
            _httpClient = httpClientFactory.CreateClient();
            SetToken(tokenService.GetToken());
        }

        private void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<ExamModel>> Get()
        {
            var response = await _httpClient.GetAsync("https://localhost:7207/Exams");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ExamModel>>(jsonString);
        }

        public async Task<ExamModel> Get(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7207/Exams/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ExamModel>(jsonString);
        }

        public async Task<ExamModel> Create(ExamModel exam)
        {
            var json = JsonConvert.SerializeObject(exam);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7207/Exams", content);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ExamModel>(jsonString);
        }

        public async Task<bool> Update(ExamModel exam)
        {
            var json = JsonConvert.SerializeObject(exam);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("https://localhost:7207/Exams", content);
            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7207/Exams/{id}");
            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}

