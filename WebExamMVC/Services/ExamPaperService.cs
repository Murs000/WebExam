using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebExamMVC.Models;

namespace WebExamMVC.Services
{
    public class ExamPaperService
    {
        private readonly HttpClient _httpClient;

        public ExamPaperService(IHttpClientFactory httpClientFactory, JwtTokenService tokenService)
        {
            _httpClient = httpClientFactory.CreateClient();
            SetToken(tokenService.GetToken());
        }

        private void SetToken(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<ExamPaperModel>> Get()
        {
            var response = await _httpClient.GetAsync("https://localhost:7207/ExamPapers");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ExamPaperModel>>(jsonString);
        }

        public async Task<ExamPaperModel> Get(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7207/ExamPapers/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ExamPaperModel>(jsonString);
        }

        public async Task<ExamPaperModel> Create(ExamPaperModel exam)
        {
            var json = JsonConvert.SerializeObject(exam);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7207/ExamPapers", content);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ExamPaperModel>(jsonString);
        }

        public async Task<bool> Update(ExamPaperModel exam)
        {
            var json = JsonConvert.SerializeObject(exam);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("https://localhost:7207/ExamPapers", content);
            response.EnsureSuccessStatusCode();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7207/ExamPapers/{id}");
            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
