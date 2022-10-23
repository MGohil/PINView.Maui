using PINView.Maui.Helpers;

namespace PINView.Maui
{
    public partial class PINView
    {
        /// <summary>
        /// Gets or Sets the Focus Animation of the PIN Box from FocusAnimationType enum:
        ///
        /// None (Default), ZoomInOut ScaleUp
        /// </summary>
        public FocusAnimationType BoxFocusAnimation
        {
            get => (FocusAnimationType)GetValue(BoxFocusAnimationProperty);
            set => SetValue(BoxFocusAnimationProperty, value);
        }

        public static readonly BindableProperty BoxFocusAnimationProperty =
           BindableProperty.Create(
               nameof(BoxFocusAnimation),
               typeof(FocusAnimationType),
               typeof(PINView),
                FocusAnimationType.None,
               defaultBindingMode: BindingMode.OneWay,
               propertyChanged: BoxFocusAnimationPropertyChanged);

        private static void BoxFocusAnimationPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = ((PINView)bindable);

            control.PINBoxContainer.Children.ToList().ForEach(x =>
            {
                var boxTemplate = (BoxTemplate)x;
                boxTemplate.FocusAnimationType = (FocusAnimationType)newValue;
            });
        }
    }
}
