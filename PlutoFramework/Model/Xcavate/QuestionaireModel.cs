using PlutoFramework.Components.Error;
using System.Text.Json.Serialization;

namespace PlutoFramework.Model.Xcavate
{
    public record Question
    {
        [JsonPropertyName("heading")]
        public required string Heading { get; set; }

        [JsonPropertyName("question_text")]
        public required string QuestionText { get; init; }

        [JsonPropertyName("answers")]
        public required string[] Answers { get; init; }

        public uint? SelectedAnswer { get; set; } = null;
    }

    public record QuestionaireInfo
    {
        public required int QuestionId { get; set; } = 0;
        public required List<Question> Questions { get; set; }
        public required Func<Task> Navigation { get; set; }
    }

    public record QuestionaireApiResponse
    {
        [JsonPropertyName("error")]
        public required bool Error { get; set; }

        [JsonPropertyName("data")]
        public required string Data { get; set; }

        [JsonPropertyName("code")]
        public required int Code { get; set; }

        [JsonPropertyName("result")]
        public required List<Question> Result { get; set; }
    }

    public record QuestionaireAnswers
    {
        [JsonPropertyName("userId")]
        public required string UserId { get; set; }

        [JsonPropertyName("account_address")]
        public required string AccountAddress { get; set; }

        [JsonPropertyName("questions")]
        public required List<Question> Questions { get; set; }
    }

    public class QuestionaireModel
    {
        private const string API_URL = "https://realxmarket.xcavate.io";
        public static async Task<List<Question>> GetXcavateQuestionsAsync()
        {
            try
            {
                var client = new HttpClient();

                var response = await client.GetAsync($"{API_URL}/api/questionnaire");

                response.EnsureSuccessStatusCode();

                var apiResponse = await response.Content.ReadAsAsync<QuestionaireApiResponse>();

                return apiResponse.Result;
            }
            catch(Exception ex)
            {
                Console.WriteLine("QuestionaireMode.GetXcavateQuestionsAsync Exception:");
                Console.WriteLine(ex);

                await Shell.Current.Navigation.PushAsync(new BadInternetConnectionPage());

                return [];
            }
        }

        public static async Task<string> PostAnswersAsync(QuestionaireAnswers answers)
        {
            try
            {
                var client = new HttpClient();

                var response = await client.GetAsync($"{API_URL}/api/questionnaire/post");

                response.EnsureSuccessStatusCode();

                var apiResponse = await response.Content.ReadAsStringAsync();

                return apiResponse;
            }
            catch
            {
                await Shell.Current.Navigation.PushAsync(new BadInternetConnectionPage());

                return "";
            }
        }
    }
}
