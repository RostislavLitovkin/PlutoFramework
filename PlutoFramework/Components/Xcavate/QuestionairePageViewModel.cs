

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlutoFramework.Components.Error;
using PlutoFramework.Model;
using PlutoFramework.Model.Xcavate;

namespace PlutoFramework.Components.Xcavate
{
    public partial class QuestionairePageViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Steps))]
        [NotifyPropertyChangedFor(nameof(Step))]
        [NotifyPropertyChangedFor(nameof(Question))]
        [NotifyPropertyChangedFor(nameof(Answer0))]
        [NotifyPropertyChangedFor(nameof(Answer1))]
        [NotifyPropertyChangedFor(nameof(Answer2))]
        [NotifyPropertyChangedFor(nameof(Answer3))]
        private QuestionaireInfo? info;

        public Question? Question => Info?.Questions[Info?.QuestionId ?? 0];

        public string Answer0 => (Question is not null && Question.Answers.Length > 0) ? Question.Answers[0] : "";
        public string Answer1 => (Question is not null && Question.Answers.Length > 1) ? Question.Answers[1] : "";
        public string Answer2 => (Question is not null && Question.Answers.Length > 2) ? Question.Answers[2] : "";
        public string Answer3 => (Question is not null && Question.Answers.Length > 3) ? Question.Answers[3] : "";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Answer0FontAttributes))]
        [NotifyPropertyChangedFor(nameof(Answer1FontAttributes))]
        [NotifyPropertyChangedFor(nameof(Answer2FontAttributes))]
        [NotifyPropertyChangedFor(nameof(Answer3FontAttributes))]
        private uint? selectedAnswer = null;
        
        public FontAttributes Answer0FontAttributes => SelectedAnswer == 0 ? FontAttributes.Bold : FontAttributes.None;
        public FontAttributes Answer1FontAttributes => SelectedAnswer == 1 ? FontAttributes.Bold : FontAttributes.None;
        public FontAttributes Answer2FontAttributes => SelectedAnswer == 2 ? FontAttributes.Bold : FontAttributes.None;
        public FontAttributes Answer3FontAttributes => SelectedAnswer == 3 ? FontAttributes.Bold : FontAttributes.None;


        public int? Step => Info?.QuestionId;

        public int? Steps => Info?.Questions?.Count;

        [RelayCommand]
        public async Task SelectAnswerAsync(string selectedString)
        {
            uint selected;

            if(!uint.TryParse(selectedString, out selected))
            {
                return;
            }

            if (Info is null || Question is null || selected >= Question.Answers.Length)
                return;

            Question.SelectedAnswer = selected;

            Info.QuestionId++;

            SelectedAnswer = selected;

            const int DELAY = 500;

            if (Info.QuestionId < Info.Questions.Count())
            {
                await Task.Delay(DELAY);

                await Shell.Current.Navigation.PushAsync(
                    new QuestionairePage(
                        Info
                    )
                );
            }
            else
            {
                var address = KeysModel.GetPublicKey();
                var answers = new QuestionaireAnswers {
                    AccountAddress = address,
                    UserId = "User_TODO",
                    Questions = Info.Questions
                };

                await QuestionaireModel.PostAnswersAsync(answers);

                await Task.Delay(DELAY);

                var evaluation = await QuestionaireModel.EvaluateAnswersAsync(address);

                if (evaluation is null)
                {
                    await Shell.Current.Navigation.PushAsync(
                        new BadInternetConnectionPage()
                    );
                    return;
                }

                if (evaluation?.Evaluation?.Result == "Fail")
                {
                    await Shell.Current.Navigation.PushAsync(
                        new QuestionaireFailedPage(
                            evaluation.Evaluation
                        )
                    );
                }
                else
                {
                    await Shell.Current.Navigation.PushAsync(
                        new QuestionairePassPage(
                            evaluation?.Evaluation,
                            Info.Navigation
                        )
                    );
                }
            }

            SelectedAnswer = null;
        }
    }
}
