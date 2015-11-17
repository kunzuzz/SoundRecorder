using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Xamarin.Forms;
using Button = Android.Widget.Button;

namespace VoiceRecorderXamarinForms.Droid
{
    public class SoundRecorder : ISoundRecorder
    {
        private const string Path = "/sdcard/test.3gpp";
        private MediaRecorder _recorder;
        private MediaPlayer _player;

        public void Record()
        {
            _recorder.SetAudioSource(AudioSource.Mic);
            _recorder.SetOutputFormat(OutputFormat.ThreeGpp);
            _recorder.SetAudioEncoder(AudioEncoder.AmrNb);
            _recorder.SetOutputFile(Path);
            _recorder.Prepare();
            _recorder.Start();
        }

        public void Stop()
        {
            _recorder.Stop();
            _recorder.Reset();

            _player.SetDataSource(Path);
            _player.Prepare();
            _player.Start();
        }

        protected void Pause()
        {
            //base.OnPause();

            _player.Release();
            _recorder.Release();
            _player.Dispose();
            _recorder.Dispose();
            _player = null;
            _recorder = null;
        }

        //public void Resume()
        //{
        //    //base.OnResume();

        //    _recorder = new MediaRecorder();
        //    _player = new MediaPlayer();

        //    _player.Completion += (sender, e) =>
        //    {
        //        _player.Reset();
        //        _start.Enabled = !_start.Enabled;
        //    };

        //}
    }
}