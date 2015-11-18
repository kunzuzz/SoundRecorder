using Android.Media;
using Xamarin.Forms;

namespace VoiceRecorderXamarinForms.Droid
{
    public class SoundRecorder : ISoundRecorder
    {
        private const string Path1 = "test.3gpp";
        private MediaRecorder _recorder = new MediaRecorder();
        private MediaPlayer _player = new MediaPlayer();

        public void Record()
        {
            _recorder.SetAudioSource(AudioSource.Mic);
            _recorder.SetOutputFormat(OutputFormat.ThreeGpp);
            _recorder.SetAudioEncoder(AudioEncoder.AmrNb);
            _recorder.SetOutputFile(CreatePathToFile(Path1));
            _recorder.Prepare();
            _recorder.Start();
        }

        string CreatePathToFile(string filename)
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
            //return "";
        }

        public void Stop()
        {
            _recorder.Stop();
            _recorder.Reset();

            _player.SetDataSource(CreatePathToFile(Path1));
            _player.Prepare();
            _player.Start();
        }

        public void Pause()
        {
            _player.Release();
            _recorder.Release();
            _player.Dispose();
            _recorder.Dispose();
            _player = null;
            _recorder = null;
        }

        public void Resume()
        {
            //base.OnResume();

            _recorder = new MediaRecorder();
            _player = new MediaPlayer();

            _player.Completion += (sender, e) =>
            {
                _player.Reset();

                MessagingCenter.Send<ISoundRecorder>(this, "MediaPlayer.Complete");
            };
        }
    }
}