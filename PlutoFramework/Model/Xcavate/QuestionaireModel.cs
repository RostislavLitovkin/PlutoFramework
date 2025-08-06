namespace PlutoFramework.Model.Xcavate
{
    public record Question
    {
        public required string QuestionText { get; init; }
        public required string[] Answers { get; init; }
        public uint? SelectedAnswer { get; set; } = null;
    }

    public record QuestionaireInfo
    {
        public required int QuestionId { get; set; } = 0;
        public required List<Question> Questions { get; set; }
        public required Func<Task> Navigation { get; set; }
    }

    public class QuestionaireModel
    {
        public static List<Question> GetXcavateQuestions() => [
            new Question
            {
                QuestionText = "How long have you been involved in real estate development?",
                Answers = new[] { "Less than 1 year", "1 - 2 years", "3 - 5 years", "More than 5 years" }
            },
            new Question
            {
                QuestionText = "How long have you been involved in real estate development?",
                Answers = new[] { "Less than 1 year", "1 - 2 years", "3 - 5 years", "More than 5 years" }
            },
            new Question
            {
                QuestionText = "How long have you been involved in real estate development?",
                Answers = new[] { "Less than 1 year", "1 - 2 years", "3 - 5 years", "More than 5 years" }
            },
            new Question
            {
                QuestionText = "How long have you been involved in real estate development?",
                Answers = new[] { "Less than 1 year", "1 - 2 years", "3 - 5 years", "More than 5 years" }
            }
        ];
    }
}
