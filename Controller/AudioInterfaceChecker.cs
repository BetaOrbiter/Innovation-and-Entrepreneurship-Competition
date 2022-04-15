using NAudio.Wave;
using NAudio.WaveFormRenderer;
using System.Drawing;

namespace Controller
{
    public static class AudioInterfaceChecker
    {
        public static Action UpdateResultUI;
        public static Action<int, Image> UpdateProgressUI;
        private static Timer timer;
        private static WaveInEvent microphoneCap;
        private static WasapiLoopbackCapture speakerCap;
        private static WaveFileWriter speakerWriter;
        private static WaveFileWriter microphoneWriter;
        private static FileStream speakerOutputFile;
        private static FileStream microphoneOutputFile;
        private static WaveStream WaveStream;
        public static ManualResetEvent stopSignal;

        public static void Work()
        {
            //WasapiLoopbackCapture cap = new WasapiLoopbackCapture();
            ProgressChanger.UpdateProgressUI(TestType.AudioInterfaceTest, 0, 2);
            speakerCap = new();
            microphoneCap = new();
            speakerOutputFile = File.OpenWrite("speakerRecorded.wav");
            microphoneOutputFile= File.OpenWrite("microphoneRecorded.wav");
            speakerWriter = new(speakerOutputFile, speakerCap.WaveFormat);
            microphoneWriter = new(microphoneOutputFile, microphoneCap.WaveFormat);
            speakerCap.DataAvailable += (s, args) => speakerWriter.Write(args.Buffer, 0, args.Buffer.Length - (args.Buffer.Length % speakerCap.WaveFormat.BlockAlign));
            speakerCap.StartRecording();
            microphoneCap.DataAvailable+= (s, args) => microphoneWriter.Write(args.Buffer, 0, args.Buffer.Length-(args.Buffer.Length% microphoneCap.WaveFormat.BlockAlign));
            microphoneCap.StartRecording();
            System.Media.SystemSounds.Beep.Play();
            System.Media.SystemSounds.Beep.Play();
            timer = new Timer(
                new TimerCallback(OnTimer)
                , null
                , 3000
                , 3000
             );
        }
        private static void OnTimer(object state)
        {
            timer.Change(-1, -1);
            ProgressChanger.UpdateProgressUI(TestType.AudioInterfaceTest, 1, 2);
            // 停止录制
            speakerCap.StopRecording();
            microphoneCap.StopRecording();
            // 关闭 FileWriter, 保存数据
            microphoneWriter.Close();
            speakerWriter.Close();
            speakerOutputFile.Dispose();
            microphoneOutputFile.Dispose();
            _ = stopSignal.WaitOne();


            var myRendererSettings = new SoundCloudBlockWaveFormSettings(Color.OrangeRed, Color.OrangeRed, Color.OrangeRed, Color.OrangeRed)
            {
                Width = 600,
                TopHeight = 250,
                BottomHeight = 250,
                BackgroundColor = Color.Transparent,
                SpacerPixels = 1,
                DecibelScale = true
            };
            WaveFileReader reader = new("speakerRecorded.wav");
            WaveStream waveStream = reader;
            var myPeakProvider = new MaxPeakProvider();
            var renderer = new WaveFormRenderer();
            Console.WriteLine(waveStream.BlockAlign);
            var  image = renderer.Render(waveStream, myPeakProvider, myRendererSettings);
            UpdateProgressUI(1, image);
            Thread.Sleep(3000);
            reader.Dispose();
            reader = new("microphoneRecorded.wav");
            waveStream = reader;
            image = renderer.Render(waveStream, myPeakProvider, myRendererSettings);
            UpdateProgressUI(2, image);
            MyTool.Log.GetInstance().Record(MyTool.LogType.Success, "音频接口测试通过");
            ProgressChanger.UpdateProgressUI(TestType.AudioInterfaceTest, 2, 2);
            Thread.Sleep(5000);
            reader.Dispose();
            waveStream.Dispose();
            File.Delete("speakerRecorded.wav");
            File.Delete("microphoneRecorded.wav");
            UpdateResultUI();
        }
    }
}
