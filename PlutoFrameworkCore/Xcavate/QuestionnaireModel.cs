using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PlutoFramework.Model.Xcavate
{
    public record Question
    {
        [JsonPropertyName("heading")]
        public required string Heading { get; set; }

        [JsonPropertyName("questionText")]
        public required string QuestionText { get; init; }

        [JsonPropertyName("answers")]
        public required string[] Answers { get; init; }

        public uint? SelectedAnswer { get; set; } = null;
    }

    public record QuestionnaireInfo
    {
        public required int QuestionId { get; set; } = 0;
        public required List<Question> Questions { get; set; }
        public required Func<Task> Navigation { get; set; }
    }

    public record QuestionnaireApiResponse<ResultT>
    {
        [JsonPropertyName("error")]
        public required bool Error { get; set; }

        [JsonPropertyName("data")]
        public required string Data { get; set; }

        [JsonPropertyName("code")]
        public required int Code { get; set; }

        [JsonPropertyName("result")]
        public required ResultT Result { get; set; }
    }

    public record QuestionnaireAnswers
    {
        [JsonPropertyName("userId")]
        public required string UserId { get; set; }

        [JsonPropertyName("account_address")]
        public required string AccountAddress { get; set; }

        [JsonPropertyName("questions")]
        public required List<Question> Questions { get; set; }
    }


    public record QuestionnaireAcceptTerms
    {
        [JsonPropertyName("hasAgreedToTerms")]
        public required bool HasAgreedToTerms { get; set; }
    }

    public record QuestionnaireEvaluationDetail
    {
        [JsonPropertyName("result")]
        public string? Result { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }

    public record QuestionnaireEvaluation
    {
        [JsonPropertyName("evaluation")]
        public QuestionnaireEvaluationDetail? Evaluation { get; set; }
    }

    public class QuestionnaireModel
    {
        private const string API_URL = "https://app.realxmarket.io";
        public static async Task<List<Question>> GetXcavateQuestionsAsync()
        {
            var client = new HttpClient();

            var response = await client.GetAsync($"{API_URL}/api/questionnaire");

            response.EnsureSuccessStatusCode();

            var apiResponseJson = await response.Content.ReadAsStringAsync();

            Console.WriteLine(apiResponseJson);

            var apiResponse = JsonSerializer.Deserialize<QuestionnaireApiResponse<List<Question>>>(apiResponseJson);

            return apiResponse?.Result ?? throw new Exception();
        }

        public static async Task<string> PostAnswersAsync(QuestionnaireAnswers answers)
        {
            var client = new HttpClient();

            var response = await client.PostAsJsonAsync($"{API_URL}/api/questionnaire/post", answers);

            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }

        public static async Task<QuestionnaireEvaluation> EvaluateAnswersAsync(string address)
        {
            var client = new HttpClient();

            var response = await client.PutAsync($"{API_URL}/api/questionnaire/evaluate/{address}", null);
            
            response.EnsureSuccessStatusCode();

            var apiResponseJson = await response.Content.ReadAsStringAsync();

            Console.WriteLine(apiResponseJson);

            var apiResponse = JsonSerializer.Deserialize<QuestionnaireApiResponse<QuestionnaireEvaluation>>(apiResponseJson);

            return apiResponse?.Result ?? throw new Exception();
        }

        public static async Task<string> AcceptTermsAsync(string address)
        {
            var accept = new QuestionnaireAcceptTerms
            {
                HasAgreedToTerms = true
            };

            var client = new HttpClient();

            var response = await client.PutAsJsonAsync($"{API_URL}/api/questionnaire/terms/{address}", accept);

            response.EnsureSuccessStatusCode();

            var apiResponse = await response.Content.ReadAsStringAsync();

            return apiResponse;
        }
    }
}
