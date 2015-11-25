using System;
using Xamarin.Forms;

namespace VoiceRecorderXamarinForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<ISoundRecorder>(this, "MediaPlayer.Complete", (sender) =>
            {
                StartButton.IsEnabled = !StartButton.IsEnabled;
            });
        }

        //void OnTranslate(object sender, EventArgs e)
        //{
        //    translatedNumber = PhonewordTranslator.ToNumber(phoneNumberText.Text);
        //    if (!string.IsNullOrWhiteSpace(translatedNumber))
        //    {
        //        callButton.IsEnabled = true;
        //        callButton.Text = "Call " + translatedNumber;
        //    }
        //    else
        //    {
        //        callButton.IsEnabled = false;
        //        callButton.Text = "Call";
        //    }
        //}

        async void OnStart(object sender, EventArgs e)
        {
            //if (await this.DisplayAlert(
            //        "Start recording",
            //        "Please speak",
            //        "Yes",
            //        "No"))
            //{
                StopButton.IsEnabled = !StopButton.IsEnabled;
                StartButton.IsEnabled = !StartButton.IsEnabled;

                var recorder = DependencyService.Get<ISoundRecorder>();
                if (recorder != null)
                    recorder.Record();
            //}
        }

        async void OnStop(object sender, EventArgs e)
        {
            //if (await this.DisplayAlert(
            //        "Stop recording",
            //        "Are you sure?",
            //        "Yes",
            //        "No"))
            //{
                StopButton.IsEnabled = !StopButton.IsEnabled;
                //startButton.IsEnabled = !startButton.IsEnabled;

                var recorder = DependencyService.Get<ISoundRecorder>();
                if (recorder != null)
                {
                    recorder.Stop();
                }
            //}
        }
    }
}
