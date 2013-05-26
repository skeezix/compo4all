using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class bzone : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Unused1; //not sure about this, as the score is multiply by 1000
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Unused2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Unused3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Unused4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Unused5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Unused6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Unused7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Unused8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Unused9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Unused10;
           
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
        }

        public bzone()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "bzone,bzonec,bzone2";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x16 && data[i] <= 0x44)                    
                    // A: (22 / 2) + 11 + 65 - 22 = 65
                    // B: (24 / 2) + 11 + 65 - 22 = 66
                    // C: (36 / 2) + 11 + 65 - 22 = 67
                    sb.Append((char)(((int)data[i] / 2) + 0x0b + 0x41 - 0x16));
                else if (data[i] == 0x4a || data[i] == 0x00)
                    sb.Append(' ');
            }
                                     
            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, int numBytes)
        {
            str = str.PadRight(numBytes, ' ');
            byte[] data = new byte[str.Length];
        
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(2 * ((int)str[i] - 0x0b - 0x41 + 0x16));                
                else if (str[i] == ' ')
                    data[i] = 0x4a;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 1000; // only multipliers of 1000
            string name = args[2];
            
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
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);                    
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);                    
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);                    
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    if (rank < 8)
                        goto case 7;
                    break; 
             }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name, hiscoreData.Name1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length)));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name, hiscoreData.Name2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length)));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name, hiscoreData.Name3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length)));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name, hiscoreData.Name4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length)));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name, hiscoreData.Name5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length)));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name, hiscoreData.Name6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length)));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name, hiscoreData.Name7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length)));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name, hiscoreData.Name8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length)));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name, hiscoreData.Name9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length)));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name, hiscoreData.Name10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length)));
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

            retString += String.Format("{0}|{1}|{2}", 1, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)) * 1000, ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)) * 1000, ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)) * 1000, ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)) * 1000, ByteArrayToString(hiscoreData.Name4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)) * 1000, ByteArrayToString(hiscoreData.Name5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 6, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score6)) * 1000, ByteArrayToString(hiscoreData.Name6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 7, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score7)) * 1000, ByteArrayToString(hiscoreData.Name7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 8, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score8)) * 1000, ByteArrayToString(hiscoreData.Name8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 9, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score9)) * 1000, ByteArrayToString(hiscoreData.Name9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 10, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score10)) * 1000, ByteArrayToString(hiscoreData.Name10)) + Environment.NewLine;
           
            return retString;
        }
    }
}