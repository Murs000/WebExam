﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using WebExamMVC.Models;

namespace WebExamMVC.Services
{
    public class UserService/*(HttpClient httpClient, *//*TokenManagementService tokenManagementService*//*)*/ 
    {
        private readonly HttpClient _httpClient;

        public UserService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<List<UserModel>> Get()
        {
            /*var jwtToken = await tokenManagementService.GetOrRenewTokenAsync("your_username", "your_password");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);*/

            var response = await _httpClient.GetAsync("https://localhost:7207/Users");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<UserModel>>(jsonString);
        }
        public async Task<UserModel> Get(int id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7207/Users/{id}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserModel>(jsonString);
        }
        public async Task<UserModel> Create(UserModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7207/Users", content);
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UserModel>(jsonString);
        }
        public async Task<bool> Update(UserModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("https://localhost:7207/Users", content);
            response.EnsureSuccessStatusCode();

            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7207/Users/{id}");
            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
