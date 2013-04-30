using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class steelwkr : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreP1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreP2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] HiScore;
        }

        //TODO: Set Alternates.
        public steelwkr()
        {
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "steelwkr";
            m_extensionsRequired = ".hi";
        }

        private int GetLargestScore(HiscoreData hiscoreData)
        {
            int p1 = HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreP1));
            int p2 = HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.ScoreP2));
            int hi = HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.HiScore));

            if (p1 >= p2 && p1 >= hi)
                return p1;
            else if (p2 >= p1 && p2 >= hi)
                return p2;
            else
                return hi;
        }

        public override void SetHiScore(string[] args)
        {
            int score = System.Convert.ToInt32(args[0]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length)));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(0, hiscoreData.HiScore.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreP1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreP1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreP2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreP2.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}", GetLargestScore(hiscoreData)) + Environment.NewLine;

            return retString;
        }
    }
}

