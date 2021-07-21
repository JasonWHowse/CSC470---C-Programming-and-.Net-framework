﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace src {
    class Toaster {
        private readonly Border Toastie = new Border();
        private readonly string boarderXName = "Toastie";
        private readonly CornerRadius borderCornerRadius = new CornerRadius(10.0);
        private readonly int borderWidth = 160;
        private readonly int borderHeight = 50;
        private readonly HorizontalAlignment borderHorizontalAlignment = HorizontalAlignment.Center;
        private readonly VerticalAlignment borderVerticalAlignment = VerticalAlignment.Bottom;
        private readonly double borderBottomMargin = 10;
        private readonly double borderTopMargin = 0;
        private readonly double borderRightMargin = 0;
        private readonly double borderLeftMargin = 0;
        private readonly Thickness borderThickness = new Thickness(1.0);

        private readonly TextBlock ToastieText = new TextBlock();
        private readonly string textBlockXName = "ToastieText";
        private readonly TextAlignment textBlockTextAlignment = TextAlignment.Center;
        private readonly Thickness textBlockMargin = new Thickness(1.0);
        private readonly TextWrapping textBlockTextWrapping = TextWrapping.Wrap;
        private readonly VerticalAlignment textBlockVerticalAlignment = VerticalAlignment.Center;
        private readonly double textBlockFontSize = 12.0;
        private readonly string textBlockFontFamily = "Segoe UI";

        private Color PrimaryBackgroundColor;
        private Color PrimaryBorderColor;
        private Color PrimaryFontColor;
        private Color WarningBackgroundColor;
        private Color WarningBorderColor;
        private Color WarningFontColor;
        private Color ErrorBackgroundColor;
        private Color ErrorBorderColor;
        private Color ErrorFontColor;

        private readonly DispatcherTimer timer = new DispatcherTimer();

        public enum ToastColors { PRIMARY, WARNING, ERROR }

        public Toaster() {
            this.Toastie.Child = this.ToastieText;
            this.InstatiateBorder();
            this.InstatiateTextBlock();
            this.SetColors();
        }//public Toaster() {

        private void InstatiateBorder() {
            this.SetBorderXName(this.boarderXName);
            this.SetBorderCornerRadius(this.borderCornerRadius);
            this.SetBorderWidth(this.borderWidth);
            this.SetBorderHeight(this.borderHeight);
            this.SetBorderHorizontalAlignment(this.borderHorizontalAlignment);
            this.SetBorderVerticalAlignment(this.borderVerticalAlignment);
            this.SetBorderMargin(this.borderLeftMargin, this.borderTopMargin, this.borderRightMargin, this.borderBottomMargin);
            this.SetBorderThickness(this.borderThickness);
            this.Toastie.Visibility = Visibility.Hidden;
        }//private void InstatiateBorder() {

        private void InstatiateTextBlock() {
            this.SetTextBlockXName(this.textBlockXName);
            this.SetTextBlockTextAlignment(this.textBlockTextAlignment);
            this.SetTextBlockMargin(this.textBlockMargin);
            this.SetTextBlockTextWrapping(this.textBlockTextWrapping);
            this.SetTextBlockVerticalAlignment(this.textBlockVerticalAlignment);
            this.SetTextBlockFontSize(this.textBlockFontSize);
            this.SetTextBlockFontFamily(this.textBlockFontFamily);
        }//private void InstatiateTextBlock() {

        private void SetColors() {
            this.SetPrimaryColors(Color.FromArgb(225, 0, 125, 0), Color.FromArgb(225, 0, 255, 0), Color.FromArgb(225, 0, 255, 0));
            this.SetWarningColors(Color.FromArgb(225, 125, 125, 0), Color.FromArgb(225, 255, 255, 0), Color.FromArgb(225, 255, 255, 0));
            this.SetErrorColors(Color.FromArgb(225, 125, 0, 0), Color.FromArgb(225, 255, 0, 0), Color.FromArgb(225, 255, 0, 0));
        }//private void SetColors() {

        public void FlipTextBlockFontBold() {
            if (this.ToastieText.FontWeight.Equals(FontWeights.Normal)) {
                this.ToastieText.FontWeight = FontWeights.Bold;
            } else {//if (ToastieText.FontWeight.Equals(FontWeights.Normal)) {
                this.ToastieText.FontWeight = FontWeights.Normal;
            }//else {
        }//public void FlipTextBlockFontBold() {

        public void FlipTextBlockFontItalics() {
            if (this.ToastieText.FontStyle.Equals(FontStyles.Italic)) {
                this.ToastieText.FontStyle = FontStyles.Normal;
            } else {//if (ToastieText.FontStyle.Equals(FontStyles.Italic)) {
                this.ToastieText.FontStyle = FontStyles.Italic;
            }//else {
        }//public void FlipTextBlockFontItalics() {

        public Border GetToast() {
            return this.Toastie;
        }//public Border GetToast() {

        public void PopToastie(string message, ToastColors tc, int seconds) {
            switch (tc) {
                case ToastColors.PRIMARY:
                    this.Toastie.Background = new SolidColorBrush(this.PrimaryBackgroundColor);
                    this.Toastie.BorderBrush = new SolidColorBrush(this.PrimaryBorderColor);
                    this.ToastieText.Foreground = new SolidColorBrush(this.PrimaryFontColor);
                    break;
                case ToastColors.ERROR:
                    this.Toastie.Background = new SolidColorBrush(this.ErrorBackgroundColor);
                    this.Toastie.BorderBrush = new SolidColorBrush(this.ErrorBorderColor);
                    this.ToastieText.Foreground = new SolidColorBrush(this.ErrorFontColor);
                    break;
                case ToastColors.WARNING:
                    this.Toastie.Background = new SolidColorBrush(this.WarningBackgroundColor);
                    this.Toastie.BorderBrush = new SolidColorBrush(this.WarningBorderColor);
                    this.ToastieText.Foreground = new SolidColorBrush(this.WarningFontColor);
                    break;
                default:
                    this.Toastie.Background = new SolidColorBrush(Color.FromArgb(225, 255, 255, 255));
                    this.Toastie.BorderBrush = new SolidColorBrush(Color.FromArgb(225, 0, 0, 0));
                    this.ToastieText.Foreground = new SolidColorBrush(Color.FromArgb(225, 100, 100, 100));
                    break;
            }//switch (tc) {
            this.ToastieText.Text = message;
            this.Toastie.Visibility = Visibility.Visible;
            this.timer.Interval = TimeSpan.FromSeconds(seconds);
            this.timer.Stop();
            this.timer.Tick += (s, en) => {
                this.Toastie.Visibility = Visibility.Hidden;
                this.timer.Stop();
            };
            this.timer.Start();
        }//public void PopToastie(string message, ToastColors tc, int seconds) {

        public void SetBorderCornerRadius(CornerRadius borderCornerRadius) {
            this.Toastie.CornerRadius = borderCornerRadius;
        }//public void SetBorderCornerRadius(CornerRadius borderCornerRadius) {

        public void SetBorderHeight(int borderHeight) {
            this.Toastie.Height = borderHeight;
        }//public void SetBorderHeight(int borderHeight) {

        public void SetBorderHorizontalAlignment(HorizontalAlignment borderHorizontalAlignment) {
            this.Toastie.HorizontalAlignment = borderHorizontalAlignment;
        }//public void SetBorderHorizontalAlignment(HorizontalAlignment borderHorizontalAlignment) {

        public void SetBorderMargin(double borderLeftMargin, double borderTopMargin, double borderRightMargin, double borderBottomMargin) {
            this.Toastie.Margin = new Thickness(borderLeftMargin, borderTopMargin, borderRightMargin, borderBottomMargin);
        }//public void SetBorderMargin(double borderLeftMargin,double borderTopMargin,double borderRightMargin,double borderBottomMargin) {

        public void SetBorderThickness(Thickness borderThickness) {
            this.Toastie.BorderThickness = borderThickness;
        }//public void SetBorderThickness(Thickness borderThickness) {

        public void SetBorderVerticalAlignment(VerticalAlignment borderVerticalAlignment) {
            this.Toastie.VerticalAlignment = borderVerticalAlignment;
        }//public void SetBorderVerticalAlignment(VerticalAlignment borderVerticalAlignment) {

        public void SetBorderWidth(int borderWidth) {
            this.Toastie.Width = borderWidth;
        }//public void SetBorderWidth(int borderWidth) {

        public void SetBorderXName(string boarderXName) {
            this.Toastie.Name = boarderXName;
        }//public void SetBorderXName(string boarderXName) {

        public void SetErrorColors(Color backgroundColor, Color boarderColor, Color fontColor) {
            this.ErrorBackgroundColor = backgroundColor;
            this.ErrorBorderColor = boarderColor;
            this.ErrorFontColor = fontColor;
        }//public void SetErrorColors(Color backgroundColor, Color boarderColor, Color fontColor) {

        public void SetPrimaryColors(Color backgroundColor, Color boarderColor, Color fontColor) {
            this.PrimaryBackgroundColor = backgroundColor;
            this.PrimaryBorderColor = boarderColor;
            this.PrimaryFontColor = fontColor;
        }//public void SetPrimaryColors(Color backgroundColor, Color boarderColor, Color fontColor) {

        public void SetTextBlockFontFamily(string textBlockFontFamily) {
            this.ToastieText.FontFamily = new FontFamily(textBlockFontFamily);
        }//public void SetTextBlockFontFamily(string textBlockFontFamily) {

        public void SetTextBlockFontSize(double textBlockFontSize) {
            this.ToastieText.FontSize = textBlockFontSize;
        }//public void SetTextBlockFontSize(double textBlockFontSize) {

        public void SetTextBlockMargin(Thickness margin) {
            this.ToastieText.Margin = margin;
        }//public void SetTextBlockMargin(Thickness margin) {

        public void SetTextBlockMargin(double leftMargin, double topMargin, double rightMargin, double bottomMargin) {
            this.ToastieText.Margin = new Thickness(leftMargin, topMargin, rightMargin, bottomMargin);
        }//public void SetTextBlockMargin(double leftMargin, double topMargin,double rightMargin, double bottomMargin) {

        public void SetTextBlockTextAlignment(TextAlignment textBlockTextAlignment) {
            this.ToastieText.TextAlignment = textBlockTextAlignment;
        }//public void SetTextBlockTextAlignment(TextAlignment textBlockTextAlignment) {

        public void SetTextBlockTextWrapping(TextWrapping TextWrapping) {
            this.ToastieText.TextWrapping = TextWrapping;
        }//public void SetTextBlockTextWrapping(TextWrapping TextWrapping) {

        public void SetTextBlockVerticalAlignment(VerticalAlignment textBlockVerticalAlignment) {
            this.ToastieText.VerticalAlignment = textBlockVerticalAlignment;
        }//public void SetTextBlockVerticalAlignment(VerticalAlignment textBlockVerticalAlignment) {

        public void SetTextBlockXName(string textBlockXName) {
            this.ToastieText.Name = textBlockXName;
        }//public void SetTextBlockXName(string textBlockXName) {

        public void SetWarningColors(Color backgroundColor, Color boarderColor, Color fontColor) {
            this.WarningBackgroundColor = backgroundColor;
            this.WarningBorderColor = boarderColor;
            this.WarningFontColor = fontColor;
        }//public void SetWarningColors(Color backgroundColor, Color boarderColor, Color fontColor) {
    }//class Toaster {
}//namespace src {