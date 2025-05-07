using System.Text.Json;
using AIFormHelper.Models;
using AIFormHelper.utils;
using Microsoft.Extensions.Configuration;
namespace AIFormHelper.Services
{
    public class ChatService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        private readonly static string basePrompt = "Your are a helpful assistant and your only responsibility is help users fill out the form. " +
            //"Being asked question not related with form completion, tell the user that that's not your responsibility." +
            " You will get question always in the same specified way and you must answear in the same template. First five lines are as follows:" +
            " Firstname (string, max 20 characters, Lastname (string, max 20 characters), Email(string in valid format)," +
            " Reason of contact (string, max 100 characters), Urgency(int in range 1 to 10). Then you will get question from person, related to filling out the form. Your goal is" +
            "to answear to that question, and based on that question, if there is a need, change the form. Your answear must be in the same pattern as the question." +
            "You shouldn't ignore the questions and answear them. You should always give answear, even brief. Think thoroughly about the form filling.";
            
        public ChatService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["ApiKey"];
        }
        public async Task<MyRequestDTO> GetAIResponse(MyRequestDTO request)
        {
            var promptBuilder = new PromptBuilder(request);
            var prompt = promptBuilder.Build();

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        role = "user",
                        parts = new []
                        {
                            new {text=basePrompt }
                        }
                    },
                    new
                    {
                        role = "user",
                        parts = new []
                        {
                            new {text=prompt }
                        }
                    }
                },
            };
            var response = await _httpClient.PostAsJsonAsync($"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}", requestBody);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<JsonElement>();
            var answear = result
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString();

            var answearBuilder = new AnswearBuilder(answear);
            var answearRequest = answearBuilder.Build();
            return answearRequest;
        }


    }
}
