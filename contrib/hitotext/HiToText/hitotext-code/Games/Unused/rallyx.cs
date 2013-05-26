using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class rallyx : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] HiScore;
        }

        public rallyx()
        {
            // MAX. SCORE = 99,999,999
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "rallyx,rallyxm,nrallyx";
            m_extensionsRequired = ".hi";
        }

        public virtual int ByteArrayHexToScore(byte[] data)
        {        
            StringBuilder sb = new StringBuilder();

            for (int i = data.Length / 2; i < data.Length; i++) 
            {
                if (data[i] >= 0x00 && data[i] <= 0x09)
                    sb.Append((char)(data[i] + 0x30));
                else if (data[i] >= 0x30 && data[i] <= 0x39)
                    sb.Append((char)data[i]);                    
            }
            for (int i = 0; i < data.Length / 2; i++)
            {
                if (data[i] >= 0x00 && data[i] <= 0x09)
                    sb.Append((char)(data[i] + 0x30));
                else if (data[i] >= 0x30 && data[i] <= 0x39)
                    sb.Append((char)data[i]);
            }

            return Convert.ToInt32(sb.ToString());
        }

        public byte[] ScoreToByteArrayHex(int score, int maxLength)
        {
            byte[] data = new byte[maxLength];
            string valstr = score.ToString().PadLeft(maxLength, (char)0x40);

            for (int i = 0; i < maxLength / 2; i++) // Take firts 4 numbers...
            {
                if (valstr[i] >= 0x30 && valstr[i] <= 0x39)
                    data[(maxLength / 2) + i] = (byte)(valstr[i] - 0x30);
                else data[(maxLength / 2) + i] = (byte)valstr[i];
            }
            for (int i = maxLength / 2; i < maxLength; i++) // And then the last 4 numbers.
            {
                if (valstr[i] >= 0x30 && valstr[i] <= 0x39)
                     if (i == maxLength - 1) // If last byte in the score, always is ASCII (+0x30)
                        data[i - (maxLength / 2)] = (byte)(valstr[i]);
                     else data[i - (maxLength / 2)] = (byte)(valstr[i] - 0x30);
                else data[i - (maxLength / 2)] = (byte)valstr[i]; // If 0x40, traslate to data[i] as is.
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int score = System.Convert.ToInt32(args[0].PadLeft(8,'0').Substring(0,8));
                       
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > ByteArrayHexToScore(hiscoreData.HiScore))
                rank = 0;          
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, ScoreToByteArrayHex(score, hiscoreData.HiScore.Length));
                    break;      
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScore, ScoreToByteArrayHex(0, hiscoreData.HiScore.Length));
          
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}", ByteArrayHexToScore(hiscoreData.HiScore)) + Environment.NewLine;

            return retString;
        }
    }
}