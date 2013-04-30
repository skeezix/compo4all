using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class qbert : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2560)]
            public byte[] Unused1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Checksum;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 140)]
            public byte[] NamesAndScoresFrom23To10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
            public byte[] Unknown; // Unknown data, but it is included in the checksum.

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1184)]
            public byte[] Unused2;


        }

        public qbert()
        {
            m_numEntries = 9;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "qbert,myqbert,qberttst,qbertjp,qberta";
            m_extensionsRequired = ".nv";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x0a && data[i] <= 0x23)
                    sb.Append(((char)((((int)data[i])) + 65 - 0x0a)));
                else if (data[i] == 0x25)
                    sb.Append('.');
                else if (data[i] == 0x24)
                    sb.Append(' '); // don't kow which is better: space or nothing
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, int maxLength)
        {
            byte[] data = new byte[maxLength];
            if (str.Length > maxLength)
                str = str.Substring(0, maxLength);
            else str = str.PadRight(maxLength, (char)0x24); // if str.lenght<max complete to max with 0x24, like the game

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - 65 + 0x0a));
                else if (str[i] == '.')
                    data[i] = 0x25;
                else if (str[i] == (char)0x24)
                    data[i] = 0x24;
                else if (str[i] == ' ')
                    data[i] = 0x24;                             
            }
            return data;
        }

        public int ByteArraySingleBCDToInt(byte[] byteArray)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < byteArray.Length; i++)
            {
                if (byteArray[i] < 0x0a)
                {
                    byte[] newData = HiConvert.HexStringToByteArray(byteArray[i].ToString("X2"));
                    sb.Append(newData[0]);
                }
            }

            return Int32.Parse(sb.ToString());
        }

        public byte[] IntToByteArraySingleBCD(int value, int numBytes)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byteArray = new byte[numBytes];
            String valAsStr = value.ToString().PadRight(numBytes, (char)(0x24 + 48)); //added +48 to quit later

            for (int i = 0; i < valAsStr.Length; i++)
                byteArray[i] = (byte)(valAsStr[i] - 48); // to get 1=01, 2=02,...,0x24+48-48=0x24
           
            return byteArray;
        }

        public byte[] CalculateChecksum(byte[] data)
        {
            int sum = 0x0000;
            int checkstart = 0x0a02; // First byte to consider
            int checkend = 0x0b60; // Last byte included in the checksum is data[0x0b60]           

            for (int i = checkstart; i < checkend; i++)
            {
                sum += (int)data[i];
            }
            string strsum = sum.ToString("X2");
            data[0x0a00] = Convert.ToByte(strsum.Substring(2, 2), 0x10); //0x10 -> Convert from hex number
            data[0x0a01] = Convert.ToByte(strsum.Substring(0, 2), 0x10);
            
            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].ToUpper();

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            
            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > ByteArraySingleBCDToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > ByteArraySingleBCDToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > ByteArraySingleBCDToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > ByteArraySingleBCDToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > ByteArraySingleBCDToInt(hiscoreData.Score5))
                rank = 4;
            else if (score > ByteArraySingleBCDToInt(hiscoreData.Score6))
                rank = 5;
            else if (score > ByteArraySingleBCDToInt(hiscoreData.Score7))
                rank = 6;
            else if (score > ByteArraySingleBCDToInt(hiscoreData.Score8))
                rank = 7;
            else if (score > ByteArraySingleBCDToInt(hiscoreData.Score9))
                rank = 8;
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
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    if (rank < 7)
                        goto case 6;
                    break;
             }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name, hiscoreData.Name1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, IntToByteArraySingleBCD(score, hiscoreData.Score1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name, hiscoreData.Name2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, IntToByteArraySingleBCD(score, hiscoreData.Score2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name, hiscoreData.Name3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, IntToByteArraySingleBCD(score, hiscoreData.Score3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name, hiscoreData.Name4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, IntToByteArraySingleBCD(score, hiscoreData.Score4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name, hiscoreData.Name5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, IntToByteArraySingleBCD(score, hiscoreData.Score5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name, hiscoreData.Name6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, IntToByteArraySingleBCD(score, hiscoreData.Score6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name, hiscoreData.Name7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, IntToByteArraySingleBCD(score, hiscoreData.Score7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name, hiscoreData.Name8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, IntToByteArraySingleBCD(score, hiscoreData.Score8.Length));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name, hiscoreData.Name9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, IntToByteArraySingleBCD(score, hiscoreData.Score9.Length));
                    break;           
            }
            #endregion
            
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);
            byteArray = CalculateChecksum(byteArray);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, IntToByteArraySingleBCD(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, IntToByteArraySingleBCD(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, IntToByteArraySingleBCD(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, IntToByteArraySingleBCD(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, IntToByteArraySingleBCD(0, hiscoreData.Score5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score6, IntToByteArraySingleBCD(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, IntToByteArraySingleBCD(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, IntToByteArraySingleBCD(0, hiscoreData.Score8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9, IntToByteArraySingleBCD(0, hiscoreData.Score9.Length));
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}", 1, ByteArraySingleBCDToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, ByteArraySingleBCDToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, ByteArraySingleBCDToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, ByteArraySingleBCDToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, ByteArraySingleBCDToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 6, ByteArraySingleBCDToInt(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 7, ByteArraySingleBCDToInt(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 8, ByteArraySingleBCDToInt(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 9, ByteArraySingleBCDToInt(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9)) + Environment.NewLine;

            return retString;
        }
    }
}