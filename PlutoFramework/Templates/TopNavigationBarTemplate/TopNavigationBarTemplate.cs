﻿using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Layouts;

namespace PlutoFramework.Templates.TopNavigationBarTemplate
{
    public class TopNavigationBarTemplate : ContentView
    {
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(TopNavigationBarTemplate));
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty Extra1TextProperty =
           BindableProperty.Create(nameof(Extra1Text), typeof(string), typeof(TopNavigationBarTemplate));
        public string Extra1Text
        {
            get => (string)GetValue(Extra1TextProperty);
            set => SetValue(Extra1TextProperty, value);
        }

        public static readonly BindableProperty Extra1ImageProperty =
           BindableProperty.Create(nameof(Extra1Image), typeof(string), typeof(TopNavigationBarTemplate));
        public string Extra1Image
        {
            get => (string)GetValue(Extra1ImageProperty);
            set => SetValue(Extra1ImageProperty, value);
        }

        public static readonly BindableProperty Extra1CommandProperty =
           BindableProperty.Create(nameof(Extra1Command), typeof(IAsyncRelayCommand), typeof(TopNavigationBarTemplate),
               propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {
                   ((TopNavigationBarViewModel)bindable.BindingContext).Extra1IsVisible = newValue is not null;
               });
        public string Extra1Command
        {
            get => (string)GetValue(Extra1CommandProperty);
            set => SetValue(Extra1CommandProperty, value);
        }

        public static readonly BindableProperty Extra2TextProperty =
           BindableProperty.Create(nameof(Extra2Text), typeof(string), typeof(TopNavigationBarTemplate));
        public string Extra2Text
        {
            get => (string)GetValue(Extra2TextProperty);
            set => SetValue(Extra2TextProperty, value);
        }

        public static readonly BindableProperty Extra2ImageProperty =
           BindableProperty.Create(nameof(Extra2Image), typeof(string), typeof(TopNavigationBarTemplate));
        public string Extra2Image
        {
            get => (string)GetValue(Extra2ImageProperty);
            set => SetValue(Extra2ImageProperty, value);
        }

        public static readonly BindableProperty Extra2CommandProperty =
           BindableProperty.Create(nameof(Extra2Command), typeof(IAsyncRelayCommand), typeof(TopNavigationBarTemplate),
               propertyChanged: (BindableObject bindable, object oldValue, object newValue) => {
                   ((TopNavigationBarViewModel)bindable.BindingContext).Extra1IsVisible = newValue is not null;
               });
        public string Extra2Command
        {
            get => (string)GetValue(Extra2CommandProperty);
            set => SetValue(Extra2CommandProperty, value);
        }

        public TopNavigationBarTemplate()
        {
            BindingContext = new TopNavigationBarViewModel();

            ControlTemplate = (ControlTemplate)Application.Current.Resources["TopNavigationBarTemplate"];

            var height = (double)Application.Current.Resources["TopNavigationBarHeight"];
            AbsoluteLayout.SetLayoutBounds(this, new Rect(0.5, 0, 1, height));
            AbsoluteLayout.SetLayoutFlags(this, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
        }
    }
}
