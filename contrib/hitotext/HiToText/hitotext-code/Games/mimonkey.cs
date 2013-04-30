using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class mimonkey : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] ScoreOnScreen;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
            public byte[] Name;   
        }

        public mimonkey()
        {
            // Max. score: 655,350
            m_numEntries = 1;
            m_format = "SCORE|NAME";
            m_gamesSupported = "mimonkey,mimonscr,mimonsco";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x11 && data[i] <= 0x2a)
                    sb.Append((char)(((int)data[i]) + 65 - 0x11));
                if (data[i] == 0x10 && i < data.Length - 1 && i > 0) // Maybe not the perfect code, but it works
                        if (data[i+1] != 0x10 && data[i-1] != 0x10)       // not showing the 0x10 at start and end.
                            sb.Append(' ');
                if (data[i] == 0x0d)
                    sb.Append(':');
                else if (data[i] == 0x0f)
                    sb.Append('.');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - 65 + 0x11));
                else if (str[i] >= '0' && str[i] <= '9')
                    data[i] = (byte)((int)str[i] - 48 + 0x00);
                else if (str[i] == ' ')
                    data[i] = 0x10;
                else if (str[i] == ':')
                    data[i] = 0x0d;
                else if (str[i] == '.')
                    data[i] = 0x0f;
                else if (str[i] == (char)0x10)
                    data[i] = 0x10;
            }
            return data;
        }

        public string CenterNameOnString(string str, int maxlength)
        {
            StringBuilder sb = new StringBuilder(maxlength);
            int offset = (maxlength - str.Length) / 2;
            if (((maxlength - str.Length) % 2) > 0)
                offset++;
            for (int i = 0; i < maxlength; i++)
            {
                if (i < offset || i >= offset + str.Length)
                    sb.Append((char)0x10);
                else sb.Append(str[i - offset]);
            }
            return sb.ToString();
        }

        public override void SetHiScore(string[] args)
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            int score = System.Convert.ToInt32(args[0]) / 10;
            string name = CenterNameOnString(args[1].ToUpper(), hiscoreData.Name.Length);
            string scoreonscreen = args[1].PadLeft(7, (char)0x10);

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score)))
                rank = 0;            
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name, HiConvert.ReverseByteArray(StringToByteArray(name)));
                    HiConvert.ByteArrayCopy(hiscoreData.Score, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.ScoreOnScreen, HiConvert.ReverseByteArray(StringToByteArray(scoreonscreen)));
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score.Length));
         
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}", HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score)) * 10, ByteArrayToString(HiConvert.ReverseByteArray(hiscoreData.Name))) + Environment.NewLine;

            return retString;
        }
    }
}