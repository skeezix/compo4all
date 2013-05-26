using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class imgfight : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1;
            public byte Stage1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2;
            public byte Stage2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3;
            public byte Stage3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4;
            public byte Stage4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5;
            public byte Stage5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score6;
            public byte Stage6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score7;
            public byte Stage7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score8;
            public byte Stage8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score9;
            public byte Stage9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score10;
            public byte Stage10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Name10;
        }

        public imgfight()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|STAGE";
            m_gamesSupported = "imgfight,imgfigho";
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
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
                data[i] = (byte)((int)str[i]);

            return data;
        }

        private int GetStage(string stage)
        {
            if (stage.Substring(0, 1).Equals("P"))
                return 240 + Convert.ToInt32(stage.Substring(1, 1));
            else
            {
                int stageAsInt = Convert.ToInt32(stage); 
                
                if (stage.Length == 1)
                    return Convert.ToInt32(stage);
                
                return stageAsInt;
            }
        }

        private string GetStage(int stage)
        {
            if (stage >= 240)
                return "P" + (stage - 240).ToString();
            else
                return stage.ToString();
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 100;
            string name = args[2];
            int stage = GetStage(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)))
                rank = 4;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score6)))
                rank = 5;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score7)))
                rank = 6;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score8)))
                rank = 7;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score9)))
                rank = 8;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score10)))
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
                    hiscoreData.Stage2 = hiscoreData.Stage1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    hiscoreData.Stage3 = hiscoreData.Stage2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    hiscoreData.Stage4 = hiscoreData.Stage3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    hiscoreData.Stage5 = hiscoreData.Stage4;
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    hiscoreData.Stage6 = hiscoreData.Stage5;
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    hiscoreData.Stage7 = hiscoreData.Stage6;
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    hiscoreData.Stage8 = hiscoreData.Stage7;
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    hiscoreData.Stage9 = hiscoreData.Stage8;
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    hiscoreData.Stage10 = hiscoreData.Stage9;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length)));
                    hiscoreData.Stage1 = (byte)stage;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length)));
                    hiscoreData.Stage2 = (byte)stage;
                    break;                                                                                                                               
                case 2:                                                                                                                                  
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));                                                                 
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length)));
                    hiscoreData.Stage3 = (byte)stage;
                    break;                                                                                                                               
                case 3:                                                                                                                                  
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));                                                                 
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length)));
                    hiscoreData.Stage4 = (byte)stage;
                    break;                                                                                                                               
                case 4:                                                                                                                                  
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));                                                                 
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length)));
                    hiscoreData.Stage5 = (byte)stage;
                    break;                                                                                                                               
                case 5:                                                                                                                                  
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));                                                                 
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length)));
                    hiscoreData.Stage6 = (byte)stage;
                    break;                                                                                                                               
                case 6:                                                                                                                                  
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));                                                                 
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length)));
                    hiscoreData.Stage7 = (byte)stage;
                    break;                                                                                                                               
                case 7:                                                                                                                                  
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));                                                                 
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length)));
                    hiscoreData.Stage8 = (byte)stage;
                    break;                                                                                                                               
                case 8:                                                                                                                                  
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));                                                                 
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length)));
                    hiscoreData.Stage9 = (byte)stage;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length)));
                    hiscoreData.Stage10 = (byte)stage;
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

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)) * 100, ByteArrayToString(hiscoreData.Name1), GetStage((int)hiscoreData.Stage1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)) * 100, ByteArrayToString(hiscoreData.Name2), GetStage((int)hiscoreData.Stage2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)) * 100, ByteArrayToString(hiscoreData.Name3), GetStage((int)hiscoreData.Stage3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)) * 100, ByteArrayToString(hiscoreData.Name4), GetStage((int)hiscoreData.Stage4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)) * 100, ByteArrayToString(hiscoreData.Name5), GetStage((int)hiscoreData.Stage5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 6, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score6)) * 100, ByteArrayToString(hiscoreData.Name6), GetStage((int)hiscoreData.Stage6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 7, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score7)) * 100, ByteArrayToString(hiscoreData.Name7), GetStage((int)hiscoreData.Stage7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 8, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score8)) * 100, ByteArrayToString(hiscoreData.Name8), GetStage((int)hiscoreData.Stage8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 9, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score9)) * 100, ByteArrayToString(hiscoreData.Name9), GetStage((int)hiscoreData.Stage9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 10, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score10)) * 100, ByteArrayToString(hiscoreData.Name10), GetStage((int)hiscoreData.Stage10)) + Environment.NewLine;

            return retString;
        }
    }
}