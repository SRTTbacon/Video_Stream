﻿using System;
using System.Windows;
using System.Windows.Forms;
using DxLibDLL;

namespace Video_Stream_DX
{
    public partial class MainWindow : Window
    {
        int SHandle;
        Timer Main_Timer = new Timer();
        Timer _timer = new Timer();
        Timer _timer2 = new Timer();
        Timer _timer3 = new Timer();
        public MainWindow()
        {
            InitializeComponent();
            DX.SetAlwaysRunFlag(DX.TRUE);
            DX.SetDrawScreen(DX.DX_SCREEN_BACK);
            DX.SetUseFPUPreserveFlag(DX.TRUE);
            DX.SetWaitVSyncFlag(DX.FALSE);
            DX.SetOutApplicationLogValidFlag(DX.FALSE);
            DX.SetDoubleStartValidFlag(DX.TRUE);
            DX.SetMouseDispFlag(DX.TRUE);
            DX.SetUseDXArchiveFlag(DX.TRUE);
            DX.SetUserWindow(Handle);
            DX.SetWindowVisibleFlag(DX.FALSE);
            if (DX.DxLib_Init() < 0)
            {
                System.Windows.MessageBox.Show("初期化エラー");
                return;
            }
            Opacity = 0;
            _timer3.Interval = 20;
            _timer3.Tick += delegate
            {
                double num = double.Parse(Opacity.ToString());
                double ha = num + 0.1;
                Opacity = ha;
                if (Opacity == 1)
                {
                    _timer3.Stop();
                }
            };
            _timer3.Start();
            slider.Maximum = 10;
            slider.Value = 7;
            slider.Minimum = 1;
            slider.ValueChanged += delegate
            {
                Timer_Main();
            };
            Volume_V.Maximum = 255;
            Volume_V.Minimum = 0;
            Volume_V.Value = 175;
            Volume_V.ValueChanged += delegate
            {
                DX.ChangeVolumeSoundMem((int)Volume_V.Value, SHandle);
            };
            mediaElement.MaxWidth = 4096;
            mediaElement.MaxHeight = 2160;
            mediaElement.LoadedBehavior = System.Windows.Controls.MediaState.Manual;
            mediaElement.UnloadedBehavior = System.Windows.Controls.MediaState.Stop;
            mediaElement.Stretch = System.Windows.Media.Stretch.Fill;
            button2.Visibility = Visibility.Hidden;
            Minus_B.Visibility = Visibility.Hidden;
            Plas_B.Visibility = Visibility.Hidden;
            slider.Visibility = Visibility.Hidden;
            Volume_V.Visibility = Visibility.Hidden;
            Stop_B.Visibility = Visibility.Hidden;
            Start_B.Visibility = Visibility.Hidden;
            Main_Timer.Interval = 100;
            Main_Timer.Tick += delegate
            {
                string Time_01;
                string Time_02;
                string Time_03;
                int a1 = mediaElement.Position.Hours;
                int a2 = mediaElement.Position.Minutes;
                int a3 = mediaElement.Position.Seconds;
                if (a1 < 10)
                {
                    Time_01 = "0" + a1.ToString();
                }
                else
                {
                    Time_01 = a1.ToString();
                }
                if (a2 < 10)
                {
                    Time_02 = "0" + a2.ToString();
                }
                else
                {
                    Time_02 = a2.ToString();
                }
                if (a3 < 10)
                {
                    Time_03 = "0" + a3.ToString();
                }
                else
                {
                    Time_03 = a3.ToString();
                }
                textBlock.Text = Time_01 + ":" + Time_02 + ":" + Time_03;
            };
            Main_Timer.Start();
            Loop();
        }
        double Progress_V;
        async void Loop()
        {
            while (true)
            {
                double GetNumber = Math.Round(slider.Value, MidpointRounding.AwayFromZero);
                Progress_V = GetNumber;
                await System.Threading.Tasks.Task.Delay(200);
            }
        }
        public IntPtr Handle
        {
            get
            {
                var helper = new System.Windows.Interop.WindowInteropHelper(this);
                return helper.Handle;
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Title = "再生ファイルを選択してください。";
            f.Multiselect = false;
            f.Filter = "再生ファイル(*.mp3;*.mp4;;*.avi;*.wmv)|*.mp3;*.mp4;*.avi;*.wmv";
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mediaElement.Visibility = Visibility.Visible;
                mediaElement.Source = new Uri(f.FileName);
                SHandle = DX.LoadSoundMem(f.FileName, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                GetPitch = DX.GetFrequencySoundMem(SHandle);
                slider.Value = 7;
                button.Visibility = Visibility.Hidden;
                label.Visibility = Visibility.Hidden;
                checkBox.Visibility = Visibility.Hidden;
                mediaElement.Volume = 0;
                mediaElement.Play();
                button2.Visibility = Visibility.Visible;
                Minus_B.Visibility = Visibility.Visible;
                Plas_B.Visibility = Visibility.Visible;
                slider.Visibility = Visibility.Visible;
                Volume_V.Visibility = Visibility.Visible;
                Stop_B.Visibility = Visibility.Visible;
                Start_B.Visibility = Visibility.Visible;
                DX.ChangeVolumeSoundMem((int)Volume_V.Value, SHandle);
                DX.SetCurrentPositionSoundMem(0, SHandle);
                DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                _timer.Interval = 1000;
                _timer.Tick += delegate
                {
                    int Qu = GetPitch;
                    double GetNumber = Math.Round(slider.Value, MidpointRounding.AwayFromZero);
                    double GetPosition = mediaElement.Position.TotalSeconds * 1000;
                    double SetPosition = Math.Round(GetPosition, MidpointRounding.AwayFromZero);
                    int a2 = (int)SetPosition;
                    DX.StopSoundMem(SHandle);
                    DX.SetFrequencySoundMem(Qu, SHandle);
                    DX.SetSoundCurrentTime(a2, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                    mediaElement.SpeedRatio = 1.0;
                    _timer.Stop();
                };
                _timer.Start();
                if (checkBox.IsChecked == true)
                {
                    WindowState = WindowState.Maximized;
                }
                Width = 960;
                Height = 540;
            }
        }
        private void Media_State(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = new TimeSpan(0, 0, 0);
            mediaElement.Play();
            _timer.Interval = 100;
            _timer.Tick += delegate
            {
                DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                _timer.Stop();
            };
            _timer.Start();
        }
        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("終了しますか？", "本当に？", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                _timer2.Interval = 20;
                _timer2.Tick += delegate
                {
                    double num = double.Parse(Opacity.ToString());
                    double ha = num - 0.1;
                    Opacity = ha;
                    if (Opacity == 0)
                    {
                        _timer2.Stop();
                        Close();
                    }
                };
                _timer2.Start();
            }
            if (result == MessageBoxResult.No)
            {

            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DX.DxLib_End();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            DX.StopSoundMem(SHandle);
            mediaElement.Stop();
            mediaElement.Visibility = Visibility.Hidden;
            mediaElement.Close();
            mediaElement.Clock = null;
            DX.DeleteSoundMem(SHandle);
            Width = 582.684;
            Height = 378.474;
            textBlock.Text = "00:00:00";
            WindowState = WindowState.Normal;
            button2.Visibility = Visibility.Hidden;
            Minus_B.Visibility = Visibility.Hidden;
            Plas_B.Visibility = Visibility.Hidden;
            slider.Visibility = Visibility.Hidden;
            Volume_V.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Visible;
            checkBox.Visibility = Visibility.Visible;
            label.Visibility = Visibility.Visible;
            Stop_B.Visibility = Visibility.Hidden;
            Start_B.Visibility = Visibility.Hidden;
            Height = 378.474;
            Width = 582.684;
        }

        private void Minus_B_Click(object sender, RoutedEventArgs e)
        {
            if (Play_States == 0)
            {
                double GetNumber2 = Math.Round(mediaElement.Position.TotalSeconds, MidpointRounding.AwayFromZero);
                TimeSpan time = TimeSpan.FromSeconds(GetNumber2 - 10);
                if (GetNumber2 < 10)
                {
                    DX.StopSoundMem(SHandle);
                    DX.SetSoundCurrentTime(0, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                }
                else
                {
                    DX.StopSoundMem(SHandle);
                    DX.SetSoundCurrentTime(((int)GetNumber2 - 10) * 1000, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                }
                mediaElement.Position = time;
            }
        }

        private void Plas_B_Click(object sender, RoutedEventArgs e)
        {
            if (Play_States == 0)
            {
                double GetNumber2 = Math.Round(mediaElement.Position.TotalSeconds, MidpointRounding.AwayFromZero);
                TimeSpan time = TimeSpan.FromSeconds(GetNumber2 + 10);
                DX.StopSoundMem(SHandle);
                DX.SetSoundCurrentTime(((int)GetNumber2 + 10) * 1000, SHandle);
                DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                mediaElement.Position = time;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            mediaElement.Height = Height;
            mediaElement.Width = Width;
            slider.Margin = new Thickness(0, Height - 35, 0, 0);
            Volume_V.Margin = new Thickness(Width - 174, 10, 0, 0);
            Minus_B.Margin = new Thickness((Width / 2) - 83, Height -35, 0, 0);
            Plas_B.Margin = new Thickness((Width / 2), Height - 35, 0, 0);
            button1.Margin = new Thickness(Width - 142, Height - 41, 0, 0);
            Stop_B.Margin = new Thickness(0, Height - 70, 0, 0);
            Start_B.Margin = new Thickness(80, Height - 70, 0, 0);
        }
        double Pause_Time;
        int Play_States = 0;
        private void Stop_B_Click(object sender, RoutedEventArgs e)
        {
            Pause_Time = Math.Round(mediaElement.Position.TotalSeconds, MidpointRounding.AwayFromZero);
            mediaElement.Pause();
            DX.StopSoundMem(SHandle);
            Play_States = 1;
        }

        private void Start_B_Click(object sender, RoutedEventArgs e)
        {
            if (Play_States == 1)
            {
                TimeSpan time = TimeSpan.FromSeconds(Pause_Time);
                DX.StopSoundMem(SHandle);
                DX.SetSoundCurrentTime(((int)Pause_Time) * 1000, SHandle);
                DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                mediaElement.Position = time;
                mediaElement.Play();
                Play_States = 0;
            }
        }
    }
}
