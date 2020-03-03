using System.Windows;
using System.Windows.Forms;
using DxLibDLL;
using System;

namespace Video_Stream_DX
{
    public partial class MainWindow : Window
    {
        int GetPitch;
        void Timer_Main()
        {
            if (Play_States == 0)
            {
                int Qu = GetPitch;
                double GetNumber = Math.Round(slider.Value, MidpointRounding.AwayFromZero);
                double GetPosition = mediaElement.Position.TotalSeconds * 1000;
                double SetPosition = Math.Round(GetPosition, MidpointRounding.AwayFromZero);
                int a2 = (int)SetPosition;
                if (GetNumber == 1)
                {
                    slider.Value = 1;
                    double GetNumber2 = Math.Round(Qu * 0.4, MidpointRounding.AwayFromZero);
                    int a = (int)GetNumber2;
                    DX.StopSoundMem(SHandle);
                    DX.SetFrequencySoundMem(a, SHandle);
                    DX.SetSoundCurrentTime(a2, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                    mediaElement.SpeedRatio = 0.4;
                }
                else if (GetNumber == 2)
                {
                    slider.Value = 2;
                    double GetNumber2 = Math.Round(Qu * 0.5, MidpointRounding.AwayFromZero);
                    int a = (int)GetNumber2;
                    DX.StopSoundMem(SHandle);
                    DX.SetFrequencySoundMem(a, SHandle);
                    DX.SetSoundCurrentTime(a2, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                    mediaElement.SpeedRatio = 0.5;
                }
                else if (GetNumber == 3)
                {
                    slider.Value = 3;
                    double GetNumber2 = Math.Round(Qu * 0.6, MidpointRounding.AwayFromZero);
                    int a = (int)GetNumber2;
                    DX.StopSoundMem(SHandle);
                    DX.SetFrequencySoundMem(a, SHandle);
                    DX.SetSoundCurrentTime(a2, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                    mediaElement.SpeedRatio = 0.6;
                }
                else if (GetNumber == 4)
                {
                    slider.Value = 4;
                    double GetNumber2 = Math.Round(Qu * 0.7, MidpointRounding.AwayFromZero);
                    int a = (int)GetNumber2;
                    DX.StopSoundMem(SHandle);
                    DX.SetFrequencySoundMem(a, SHandle);
                    DX.SetSoundCurrentTime(a2, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                    mediaElement.SpeedRatio = 0.7;
                }
                else if (GetNumber == 5)
                {
                    slider.Value = 5;
                    double GetNumber2 = Math.Round(Qu * 0.8, MidpointRounding.AwayFromZero);
                    int a = (int)GetNumber2;
                    DX.StopSoundMem(SHandle);
                    DX.SetFrequencySoundMem(a, SHandle);
                    DX.SetSoundCurrentTime(a2, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                    mediaElement.SpeedRatio = 0.8;
                }
                else if (GetNumber == 6)
                {
                    slider.Value = 6;
                    double GetNumber2 = Math.Round(Qu * 0.9, MidpointRounding.AwayFromZero);
                    int a = (int)GetNumber2;
                    DX.StopSoundMem(SHandle);
                    DX.SetFrequencySoundMem(a, SHandle);
                    DX.SetSoundCurrentTime(a2, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                    mediaElement.SpeedRatio = 0.9;
                }
                else if (GetNumber == 7)
                {
                    slider.Value = 7;
                    DX.StopSoundMem(SHandle);
                    DX.SetFrequencySoundMem(Qu, SHandle);
                    DX.SetSoundCurrentTime(a2, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                    mediaElement.SpeedRatio = 1.0;
                }
                else if (GetNumber == 8)
                {
                    slider.Value = 8;
                    double GetNumber2 = Math.Round(Qu * 1.1, MidpointRounding.AwayFromZero);
                    int a = (int)GetNumber2;
                    DX.StopSoundMem(SHandle);
                    DX.SetFrequencySoundMem(a, SHandle);
                    DX.SetSoundCurrentTime(a2, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                    mediaElement.SpeedRatio = 1.1;
                }
                else if (GetNumber == 9)
                {
                    slider.Value = 9;
                    double GetNumber2 = Math.Round(Qu * 1.2, MidpointRounding.AwayFromZero);
                    int a = (int)GetNumber2;
                    DX.StopSoundMem(SHandle);
                    DX.SetFrequencySoundMem(a, SHandle);
                    DX.SetSoundCurrentTime(a2, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                    mediaElement.SpeedRatio = 1.2;
                }
                else if (GetNumber == 10)
                {
                    slider.Value = 10;
                    double GetNumber2 = Math.Round(Qu * 1.3, MidpointRounding.AwayFromZero);
                    int a = (int)GetNumber2;
                    DX.StopSoundMem(SHandle);
                    DX.SetFrequencySoundMem(a, SHandle);
                    DX.SetSoundCurrentTime(a2, SHandle);
                    DX.PlaySoundMem(SHandle, DX.DX_PLAYTYPE_BACK, DX.FALSE);
                    mediaElement.SpeedRatio = 1.3;
                }
            }
            else
            {
                slider.Value = Progress_V;
            }
        }
    }
}
