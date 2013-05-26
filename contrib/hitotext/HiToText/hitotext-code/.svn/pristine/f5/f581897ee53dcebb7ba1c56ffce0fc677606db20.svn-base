using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class frogs : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] HiScore;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] HiScoreText;
        }

        public frogs()
        {
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "frogs";
            m_extensionsRequired = ".hi";
        }

        public byte[] IntToByteArrayAsText(int score, int numBytes)
        {            
            byte[] byteArray = new byte[numBytes];            
            String valAsStr = score.ToString();
            
            for (int i = score.ToString().Length-1; i >= 0; i--)
            {
                byteArray[numBytes-1] = Convert.ToByte(0x30 + Convert.ToByte(score.ToString().Substring(i, 1)));
                numBytes--;                
            }
            return byteArray;
        }

        public override void SetHiScore(string[] args)
        {            
            int score = System.Convert.ToInt32(args[0]);
           
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScoreText, IntToByteArrayAsText(score, hiscoreData.HiScoreText.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArraySingleBCD(score, hiscoreData.HiScore.Length));
                        
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArraySingleBCD(0, hiscoreData.HiScore.Length));
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}", HiConvert.ByteArraySingleBCDToInt(hiscoreData.HiScore)) + Environment.NewLine;
          
            return retString;
        }
    }
}