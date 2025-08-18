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
                Console.WriteLine("new Question {");
                Console.WriteLine($"Heading = \"{question.Heading}\",");
                Console.WriteLine($"QuestionText = \"{question.QuestionText}\",");
                Console.WriteLine("Answers = [\"" + string.Join("\", \"", question.Answers) + "\"");
                Console.WriteLine("], SelectedAnswer = 0 },");
            }
        }

        [Test]
        public async Task PostAnswersAsync()
        {
            var answers = new QuestionaireAnswers
            {
                UserId = "user_12345",
                AccountAddress = "5EU6EyEq6RhqYed1gCYyQRVttdy6FC9yAtUUGzPe3gfpFX8y",
                Questions = [
                    new Question {
Heading = "H&W Investments Limited does not provide any advice relating to investment into any real estate assets listed on the Xcavate realXmarket application. If you are unsure whether investment via the Xcavate realXmarket application is right for you, you should seek financial advice.",
QuestionText = "Please confirm you understand that H&W Investments Limited has not provided you with any form of investment advice relating to investment via the Xcavate realXmarket application",
Answers = ["Yes", "No"
], SelectedAnswer = 0 },
new Question {
Heading = "Investment via the Xcavate realXmarket application involves the purchase of property tokens. Each token represents a single share in a Limited Liability Partnership (LLP) known as a “Special Purpose Vehicle” (SPV). The SPV will acquire the real estate asset as marketed on the platform.",
QuestionText = "Please confirm you understand the above explanation.  ",
Answers = ["Yes", "No"
], SelectedAnswer = 0 },
new Question {
Heading = "Property tokens purchased via Xcavate realxmarket may be resold via the noticeboard section within the application. However, these tokens are not as liquid as, for example, shares that are listed on a stock exchange. As such, you might not be able to find a buyer for your token(s) should you wish to sell, and where you are able to, this might take some time.",
QuestionText = "Please confirm you have understood this and that you are only investing money you are able to lock away for a period of time without having access to",
Answers = ["Yes", "No"
], SelectedAnswer = 0 },
new Question {
Heading = "The value of your property tokens is linked to the value of the specific real estate asset owned by the SPV. The property market can be subject to fluctuations in value, and you should view any investment in real estate as a medium to long term investment. It is possible that you could lose some or all of your money in the event of a market downturn.",
QuestionText = "Please confirm you have understood that investment into real estate assets should be viewed as a medium to long term investment and that you could lose some or all of your money",
Answers = ["Yes", "No"
], SelectedAnswer = 0 },
new Question {
Heading = "The rental yield on your property tokens may vary depending on market conditions and could cease completely if the property is vacant.",
QuestionText = "Please confirm you have understood that rental yield can vary and may cease altogether in the event that the property is vacant for any period of time and that you are able to withstand the financial impact of any reduction in rental yield.",
Answers = ["Yes", "No"
], SelectedAnswer = 0 },
new Question {
Heading = "Please indicate your level of experience and knowledge in relation to:",
QuestionText = "Investment into real estate (property)",
Answers = ["High", "Medium", "Low", "None"
], SelectedAnswer = 0 },
new Question {
Heading = "Please indicate your level of experience and knowledge in relation to:",
QuestionText = "Investment in unlisted shares (that is, shares that are not subject to trading on a stock exchange)",
Answers = ["High", "Medium", "Low", "None"
], SelectedAnswer = 0 },
new Question {
Heading = "Please indicate your level of experience and knowledge in relation to:",
QuestionText = "Investment in Crypto assets",
Answers = ["High", "Medium", "Low", "None"
], SelectedAnswer = 0 },
new Question {
Heading = "Please indicate the number of transactions you have undertaken in the past five years involving:",
QuestionText = "Investment into real estate (property)",
Answers = ["Over 5", "1 to 5", "None"
], SelectedAnswer = 0 },
new Question {
Heading = "Please indicate the number of transactions you have undertaken in the past five years involving:",
QuestionText = "nvestment in unlisted shares (that is, shares that are not subject to trading on a stock exchange",
Answers = ["Over 5", "1 to 5", "None"
], SelectedAnswer = 0 },
new Question {
Heading = "Please indicate the number of transactions you have undertaken in the past five years involving:",
QuestionText = "Investment in Crypto  assets",
Answers = ["Over 5", "1 to 5", "None"], SelectedAnswer = 0 },
                ]
            };

            var response = await QuestionaireModel.PostAnswersAsync(answers);

            Console.WriteLine(response);
        }
    }
}
