using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace VoiceRecorderXamarinForms.Droid
{
    [Activity(Label = "VoiceRecorderXamarinForms", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        private SoundRecorder _soundRecorder;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            _soundRecorder = new SoundRecorder();
        }

        protected override void OnResume()
        {
            base.OnResume();
            _soundRecorder.Resume();
        }

        protected override void OnPause()
        {
            base.OnPause();
            _soundRecorder.Pause();
        }
    }
}

