using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    // This is a clone of Scramble that records name with the hiscore
    class explorer : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2;            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3;            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4; 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score6;  
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore;
        }

        public explorer()
        {
            m_numEntries = 6;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "explorer";
            m_extensionsRequired = ".hi";
        }

     public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            byte[] newdata = new byte[3];
            
            // 2 bytes 3 characters
            // First, bits with weight 4,8,16,32,64 of byte 1
            // Second, bits with weight 32,64,128 of byte 2 plus bits with weight 1,2 from byte 1
            // Third, bits with  weight 1,2,4,8,16 of byte 2
            newdata[0] = (byte)(((int)data[0]& 0x7c)/4);
            newdata[1] = (byte)((((int)data[0] & 0x03)*8) + (((int)data[1] & 0xe0) / 32));
            newdata[2] = (byte)((int)data[1] & 0x1f);

            for (int i = 0; i < newdata.Length; i++)
            {
                if (newdata[i] >= 0x01 && newdata[i] <= 0x1a)
                    sb.Append(((char)((((int)newdata[i])) + 65 - 0x01)));
                else if (newdata[i] == 0x1b)
                    sb.Append('-');
                else if (newdata[i] == 0x00)
                    sb.Append(' ');
            }
                                     
            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];
            byte[] newdata = new byte[2];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - 65 + 0x01));                
                else if (str[i] == ' ')
                    data[i] = 0x00;
                else if (str[i] == '-')
                    data[i] = 0x1b;
            }

            newdata[0] = (byte)((((int)data[0]) * 4)+ (((int)data[1]& 0x18) /8));
            newdata[1] = (byte)((((int)data[1] & 0x07) * 32) + (int)data[2]);
            
            return newdata;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
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
             }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length)));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length)));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length)));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length)));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length)));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length)));
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
           
            HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(0, hiscoreData.HiScore.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}", 1, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)), ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)), ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)), ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)), ByteArrayToString(hiscoreData.Name4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)), ByteArrayToString(hiscoreData.Name5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 6, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score6)), ByteArrayToString(hiscoreData.Name6)) + Environment.NewLine;
           
            return retString;
        }
    }
}