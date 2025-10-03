using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoFramework.Components.Messaging;

public partial class ChatItemView : ContentView
{
    public static readonly BindableProperty IsApprovedColorProperty = BindableProperty.Create(nameof(IsApprovedColor), 
        typeof(Color), typeof(ChatItemView));

    public Color IsApprovedColor
    {
        get => (Color)GetValue(IsApprovedColorProperty);
        set => SetValue(IsApprovedColorProperty, value);
    }
        
    public static readonly BindableProperty StateProperty = BindableProperty.Create(nameof(State), typeof(string),
        typeof(ChatItemView));

    public string State
    {
        get => (string)GetValue(StateProperty);
        set => SetValue(StateProperty, value);
    }
        
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), 
        typeof(string), typeof(ChatItemView));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
        
    public static readonly BindableProperty TimeProperty = BindableProperty.Create(nameof(Time), 
        typeof(string), typeof(ChatItemView));

    public string Time
    {
        get => (string)GetValue(TimeProperty);
        set => SetValue(TimeProperty, value);
    }
    
    public static readonly BindableProperty IsApprovedProperty = BindableProperty.Create(nameof(IsApproved), typeof(string),
        typeof(ChatItemView));

    public string IsApproved
    {
        get => (string)GetValue(IsApprovedProperty);
        set => SetValue(IsApprovedProperty, value);
    }
    
    public ChatItemView()
    {
        InitializeComponent();
        
        BindingContext = this;
    }
}