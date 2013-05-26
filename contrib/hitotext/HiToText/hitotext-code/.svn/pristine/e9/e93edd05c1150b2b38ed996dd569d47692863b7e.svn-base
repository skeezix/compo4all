using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class kchamp : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreUnused1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Dan1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreUnused2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Dan2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreUnused3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Dan3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreUnused4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Dan4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreUnused5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Dan5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreUnused6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Dan6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore;
        }

        public kchamp()
        {
            m_numEntries = 6;
            m_format = "RANK|SCORE|NAME|DAN";
            m_gamesSupported = "kchamp,kchampvs,karatedo,karatevs";
            m_extensionsRequired = ".hi";
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
                else if (data[i] == 0x26)
                    sb.Append('-');
                else if (data[i] == 0x27)
                    sb.Append('l'); // left foot
                else if (data[i] == 0x2d)
                    sb.Append('r'); // right foot
                else if (data[i] == 0x2f)
                    sb.Append('♥');
                else if (data[i] == 0x3c)
                    sb.Append(' ');                
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            // We must format the byte array properly, because you could put only 3 letters
            // and the rest of the name would be 00 00 ... instead of 3c b0 ...
            byte[] data = new byte[10] { 0x3c, 0xb0, 0x3c, 0xb0, 0x3c, 0xb0, 0x3c, 0xb0, 0x3c, 0xb0 };
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[count] = (byte)(((int)str[i] - 65 + 0x0a));
                else if (str[i] == '.')
                    data[count] = 0x25;
                else if (str[i] == '-')
                    data[count] = 0x26;
                else if (str[i] == 'l') // left foot
                    data[count] = 0x27;
                else if (str[i] == 'r') // right foot
                    data[count] = 0x2d;
                else if (str[i] == '♥')
                    data[count] = 0x2f;
                else if (str[i] == ' ')
                    data[count] = 0x3c;
                count=count+2;           
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int dan = System.Convert.ToInt32(args[3]) - 1; // Rest 1 to the Dan value

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
                    HiConvert.ByteArrayCopy(hiscoreData.Dan2, hiscoreData.Dan1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Dan3, hiscoreData.Dan2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Dan4, hiscoreData.Dan3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Dan5, hiscoreData.Dan4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Dan6, hiscoreData.Dan5);
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Dan1, HiConvert.IntToByteArrayHex(dan, hiscoreData.Dan1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Dan2, HiConvert.IntToByteArrayHex(dan, hiscoreData.Dan2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Dan3, HiConvert.IntToByteArrayHex(dan, hiscoreData.Dan3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Dan4, HiConvert.IntToByteArrayHex(dan, hiscoreData.Dan4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Dan5, HiConvert.IntToByteArrayHex(dan, hiscoreData.Dan5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Dan6, HiConvert.IntToByteArrayHex(dan, hiscoreData.Dan6.Length));
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
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), HiConvert.ByteArrayHexToInt(hiscoreData.Dan1) + 1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), HiConvert.ByteArrayHexToInt(hiscoreData.Dan2) + 1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), HiConvert.ByteArrayHexToInt(hiscoreData.Dan3) + 1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), HiConvert.ByteArrayHexToInt(hiscoreData.Dan4) + 1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), HiConvert.ByteArrayHexToInt(hiscoreData.Dan5) + 1) + Environment.NewLine;
           
            return retString;
        }
    }
}