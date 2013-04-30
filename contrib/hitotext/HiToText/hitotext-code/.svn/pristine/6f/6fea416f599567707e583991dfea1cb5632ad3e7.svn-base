using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class lrescue : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            public byte LengthName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] Name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score;  
        }

        public lrescue()
        {
            // Curiosity: mlander (bootleg of lrescue) has lengthname (0x20db) set to 0x01,
            // to avoid the game showing the text 'TAITO' as record name
            // Max. score: 99,990
            m_numEntries = 1;
            m_format = "SCORE|NAME";
            m_gamesSupported = "lrescue,desterth,grescue,lrescuem,mlander";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x00 && data[i] <= 0x19)
                    sb.Append((char)(((int)data[i]) + 65));
                else if (data[i] == 0x1b)
                    sb.Append(' ');
                else if (data[i] == 0x1a)
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
                    data[i] = (byte)(((int)str[i] - 65));
                else if (str[i] == ' ')
                    data[i] = 0x1b;
                else if (str[i] == '.')
                    data[i] = 0x1a;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int score = System.Convert.ToInt32(args[0]) / 10;
            string name = args[1].PadRight(10, ' ').ToUpper().Substring(0,10);
            byte lengthname = (byte)args[1].Length;

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score)))
                rank = 0;            
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name, StringToByteArray(name));
                    hiscoreData.LengthName = lengthname;
                    HiConvert.ByteArrayCopy(hiscoreData.Score, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score.Length)));
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(0, hiscoreData.Score.Length)));
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}", HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score)) * 10, ByteArrayToString(hiscoreData.Name)) + Environment.NewLine;

            return retString;
        }
    }
}