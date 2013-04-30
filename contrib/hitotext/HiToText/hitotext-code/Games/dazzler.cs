using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class dazzler : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastScore;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreOnScreen1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreOnScreen2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreOnScreen3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreOnScreen4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] ScoreOnScreen5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] LastName;

            public byte CheckByte;
        }

        public dazzler()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "dazzler";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x01 && data[i] <= 0x1a)
                    sb.Append(((char)((((int)data[i])) + 65 - 0x01)));
                else if (data[i] == 0x00)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - 65 + 0x01));
                else if (str[i] == (char)0x00 || str[i] == ' ')
                    data[i] = 0x00;
            }

            return data;
        }

        public byte[] ScoreOnScreenToByteArray(int score, int MaxLength)
        {
            
            byte[] data = new byte[MaxLength];
            string scoreStr = score.ToString().PadLeft(4, '0');

            for (int i = 0; i < MaxLength; i++)
            {
                if (scoreStr[i] >= '0' && scoreStr[i] <= '9')
                    data[i] = (byte)(((int)scoreStr[i] - 48 + 0x1b));
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1].PadLeft(6,'0').Substring(0,6)) / 100;
            string name = args[2].ToUpper().PadRight(10, (char)0x00).Substring(0, 10);
           
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
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen2, hiscoreData.ScoreOnScreen1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen3, hiscoreData.ScoreOnScreen2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen4, hiscoreData.ScoreOnScreen3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen5, hiscoreData.ScoreOnScreen4);
                    if (rank < 3)
                        goto case 2;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, HiConvert.ReverseByteArray(StringToByteArray(name)));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen1, HiConvert.ReverseByteArray(ScoreOnScreenToByteArray(score, hiscoreData.ScoreOnScreen1.Length)));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, HiConvert.ReverseByteArray(StringToByteArray(name)));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen2, HiConvert.ReverseByteArray(ScoreOnScreenToByteArray(score, hiscoreData.ScoreOnScreen2.Length)));
                    break;                                                                                                                               
                case 2:                                                                                                                                  
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, HiConvert.ReverseByteArray(StringToByteArray(name)));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen3, HiConvert.ReverseByteArray(ScoreOnScreenToByteArray(score, hiscoreData.ScoreOnScreen3.Length)));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, HiConvert.ReverseByteArray(StringToByteArray(name)));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen4, HiConvert.ReverseByteArray(ScoreOnScreenToByteArray(score, hiscoreData.ScoreOnScreen4.Length)));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, HiConvert.ReverseByteArray(StringToByteArray(name)));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen5, HiConvert.ReverseByteArray(ScoreOnScreenToByteArray(score, hiscoreData.ScoreOnScreen5.Length)));
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

            HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen1, ScoreOnScreenToByteArray(0, hiscoreData.ScoreOnScreen1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen2, ScoreOnScreenToByteArray(0, hiscoreData.ScoreOnScreen2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen3, ScoreOnScreenToByteArray(0, hiscoreData.ScoreOnScreen3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen4, ScoreOnScreenToByteArray(0, hiscoreData.ScoreOnScreen4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen5, ScoreOnScreenToByteArray(0, hiscoreData.ScoreOnScreen5.Length));

            HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray("          "));
            HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray("          "));
            HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray("          "));
            HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray("          "));
            HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray("          "));


            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}", 1, ((HiConvert.ByteArrayHexToInt(hiscoreData.Score1)) * 100).ToString().PadLeft(6, '0'), ByteArrayToString(HiConvert.ReverseByteArray(hiscoreData.Name1))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, ((HiConvert.ByteArrayHexToInt(hiscoreData.Score2)) * 100).ToString().PadLeft(6, '0'), ByteArrayToString(HiConvert.ReverseByteArray(hiscoreData.Name2))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, ((HiConvert.ByteArrayHexToInt(hiscoreData.Score3)) * 100).ToString().PadLeft(6, '0'), ByteArrayToString(HiConvert.ReverseByteArray(hiscoreData.Name3))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, ((HiConvert.ByteArrayHexToInt(hiscoreData.Score4)) * 100).ToString().PadLeft(6, '0'), ByteArrayToString(HiConvert.ReverseByteArray(hiscoreData.Name4))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, ((HiConvert.ByteArrayHexToInt(hiscoreData.Score5)) * 100).ToString().PadLeft(6, '0'), ByteArrayToString(HiConvert.ReverseByteArray(hiscoreData.Name5))) + Environment.NewLine;

            return retString;
        }
    }
}