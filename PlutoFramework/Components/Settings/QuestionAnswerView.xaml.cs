namespace PlutoFramework.Components.Settings;

public partial class QuestionAnswerView : ContentView
{

	public static readonly BindableProperty QuestionProperty = BindableProperty.Create(
        nameof(Question),
        typeof(string),
        typeof(QuestionAnswerView),
        string.Empty,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (QuestionAnswerView)bindable;
            view.questionLabel.Text = (string)newValue;
        });
    public static readonly BindableProperty AnswerProperty = BindableProperty.Create(
        nameof(Answer),
        typeof(string),
        typeof(QuestionAnswerView),
        string.Empty,
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (QuestionAnswerView)bindable;
            view.answerLabel.Text = (string)newValue;
        });
    public QuestionAnswerView()
	{
		InitializeComponent();
	}
	public string Question
    {
        get => (string)GetValue(QuestionProperty);
        set => SetValue(QuestionProperty, value);
    }
    public string Answer
    {
        get => answerLabel.Text;
        set => answerLabel.Text = value;
    }
}