using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class robocop : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            public byte Unused1;
            public byte Round1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            public byte Unused2;
            public byte Round2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            public byte Unused3;
            public byte Round3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            public byte Unused4;
            public byte Round4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            public byte Unused5;
            public byte Round5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            public byte Unused6;
            public byte Round6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            public byte Unused7;
            public byte Round7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            public byte Unused8;
            public byte Round8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            public byte Unused9;
            public byte Round9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;
            public byte Unused10;
            public byte Round10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Time10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public robocop()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|ROUND|TIME";
            m_gamesSupported = "robocop,robocopb,robocopw,robocopj,robocopu,robocpu0";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append((char)(int)data[i]);

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            string name = str.PadRight(8, ' ');
            byte[] data = new byte[name.Length];

            for (int i = 0; i < name.Length; i++)
                data[i] = (byte)((int)name[i]);
            
            return data;
        }

        public int GetTime(string time)
        {
            //Format mm:ss
            string[] saTime = time.Split(new char[] { ':' });
            return (Convert.ToInt32(saTime[0]) * 100) + Convert.ToInt32(saTime[1]);
        }

        public string GetTime(int time)
        {
            //Format mmm:ss
            int mins = time / 100;
            int secs = time % 100;
            return mins.ToString().PadLeft(2, '0') + ":" + secs.ToString().PadLeft(2, '0');
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int round = System.Convert.ToInt32(args[3]);
            int time = GetTime(args[4]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score5))
                rank = 4;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score6))
                rank = 5;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score7))
                rank = 6;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score8))
                rank = 7;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score9))
                rank = 8;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score10))
                rank = 9;
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    HiConvert.ByteArrayCopy(hiscoreData.Time2, hiscoreData.Time1);
                    hiscoreData.Round2 = hiscoreData.Round1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Time3, hiscoreData.Time2);
                    hiscoreData.Round3 = hiscoreData.Round2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Time4, hiscoreData.Time3);
                    hiscoreData.Round4 = hiscoreData.Round3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Time5, hiscoreData.Time4);
                    hiscoreData.Round5 = hiscoreData.Round4;
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Time6, hiscoreData.Time5);
                    hiscoreData.Round6 = hiscoreData.Round5;
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    HiConvert.ByteArrayCopy(hiscoreData.Time7, hiscoreData.Time6);
                    hiscoreData.Round7 = hiscoreData.Round6;
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    HiConvert.ByteArrayCopy(hiscoreData.Time8, hiscoreData.Time7);
                    hiscoreData.Round8 = hiscoreData.Round7;
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    HiConvert.ByteArrayCopy(hiscoreData.Time9, hiscoreData.Time8);
                    hiscoreData.Round9 = hiscoreData.Round8;
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    HiConvert.ByteArrayCopy(hiscoreData.Time10, hiscoreData.Time9);
                    hiscoreData.Round10 = hiscoreData.Round9;
                    if (rank < 8)
                        goto case 7;
                    break;
                default:
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time1, HiConvert.IntToByteArrayHex(time, hiscoreData.Time1.Length));
                    hiscoreData.Round1 = (byte)round;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time2, HiConvert.IntToByteArrayHex(time, hiscoreData.Time2.Length));
                    hiscoreData.Round2 = (byte)round;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time3, HiConvert.IntToByteArrayHex(time, hiscoreData.Time3.Length));
                    hiscoreData.Round3 = (byte)round;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time4, HiConvert.IntToByteArrayHex(time, hiscoreData.Time4.Length));
                    hiscoreData.Round4 = (byte)round;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time5, HiConvert.IntToByteArrayHex(time, hiscoreData.Time5.Length));
                    hiscoreData.Round5 = (byte)round;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time6, HiConvert.IntToByteArrayHex(time, hiscoreData.Time6.Length));
                    hiscoreData.Round6 = (byte)round;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time7, HiConvert.IntToByteArrayHex(time, hiscoreData.Time7.Length));
                    hiscoreData.Round7 = (byte)round;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time8, HiConvert.IntToByteArrayHex(time, hiscoreData.Time8.Length));
                    hiscoreData.Round8 = (byte)round;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time9, HiConvert.IntToByteArrayHex(time, hiscoreData.Time9.Length));
                    hiscoreData.Round9 = (byte)round;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Time10, HiConvert.IntToByteArrayHex(time, hiscoreData.Time10.Length));
                    hiscoreData.Round10 = (byte)round;
                    break;
                default:
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(0, hiscoreData.Score5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(0, hiscoreData.Score8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(0, hiscoreData.Score9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(0, hiscoreData.Score10.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), hiscoreData.Round1, GetTime(HiConvert.ByteArrayHexToInt(hiscoreData.Time1))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), hiscoreData.Round2, GetTime(HiConvert.ByteArrayHexToInt(hiscoreData.Time2))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), hiscoreData.Round3, GetTime(HiConvert.ByteArrayHexToInt(hiscoreData.Time3))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), hiscoreData.Round4, GetTime(HiConvert.ByteArrayHexToInt(hiscoreData.Time4))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), hiscoreData.Round5, GetTime(HiConvert.ByteArrayHexToInt(hiscoreData.Time5))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), hiscoreData.Round6, GetTime(HiConvert.ByteArrayHexToInt(hiscoreData.Time6))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), hiscoreData.Round7, GetTime(HiConvert.ByteArrayHexToInt(hiscoreData.Time7))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), hiscoreData.Round8, GetTime(HiConvert.ByteArrayHexToInt(hiscoreData.Time8))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9), hiscoreData.Round9, GetTime(HiConvert.ByteArrayHexToInt(hiscoreData.Time9))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10), hiscoreData.Round10, GetTime(HiConvert.ByteArrayHexToInt(hiscoreData.Time10))) + Environment.NewLine;

            return retString;
        }
    }
}
