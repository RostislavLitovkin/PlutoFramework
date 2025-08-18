using PlutoFramework.Model.Xcavate;

namespace PlutoFrameworkTests
{
    public class QuestionaireModelTests
    {
        [Test]
        public async Task GetQuestionsAsync()
        {
            var questions = await QuestionaireModel.GetXcavateQuestionsAsync();

            foreach (var question in questions)
            {
                Console.WriteLine("\n---");
                Console.WriteLine($"Heading: {question.Heading}");
                Console.WriteLine($"Question: {question.QuestionText}");
                Console.WriteLine("Answers: " + string.Join(", ", question.Answers));
            }
        }

        [Test]
        public async Task PostAnswersAsync()
        {
            var answers = new QuestionaireAnswers
            {
                UserId = "user_12345",
                AccountAddress = "0x742d35Cc6634C0532925a3b8D4C9db96C4b4d8a4",
                Questions = [
                    new Question {
                        Heading = "H&W Investments Limited does not provide any advice relating to investment into any real estate assets listed on the Xcavate realXmarket application. If you are unsure whether investment via the Xcavate realXmarket application is right for you, you should seek financial advice.",
                        QuestionText = "Please confirm you understand that H&W Investments Limited has not provided you with any form of investment advice relating to investment via the Xcavate realXmarket application",
                        Answers = [
                            "Yes",
                            "No"
                        ],
                        SelectedAnswer = 0
                    }
                ]
            };

            var response = await QuestionaireModel.PostAnswersAsync(answers);

            Console.WriteLine(response);
        }
    }
}
