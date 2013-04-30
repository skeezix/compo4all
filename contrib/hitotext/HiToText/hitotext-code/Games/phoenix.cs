using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class phoenix : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScoreV1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] HiScoreV2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1V1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score1V2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2V1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score2V2;
        }

        //TODO: Set Alternates.
        public phoenix()
        {
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "phoenix,condor,falcon,nextfase,phoenix3,phoenixa,phoenixb,phoenixc,phoenixt,phoenixj,vautour,pleiads,pleiadbl,pleiadce,batman2,falconz,griffon,vautourz";
            m_extensionsRequired = ".hi";
        }

        public virtual int ByteArrayToScore(byte[] byteData)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < byteData.Length; i++)
            {
                string newData = byteData[i].ToString("X2");
                if (newData.Equals("20")) //Empty byte for display purposes.
                    sb.Append("0");
                else
                    sb.Append(newData[1]);
            }

            return Int32.Parse(sb.ToString());
        }

        public virtual byte[] ScoreToByteArray(int score)
        {
            int numDigitsInScore = 6;
            StringBuilder sb = new StringBuilder();
            String strScore = score.ToString();
            strScore = strScore.PadLeft(numDigitsInScore, 'F');

            for (int i = 0; i < numDigitsInScore; i++)
            {
                if (strScore[i].Equals('F'))
                    sb.Append("20");
                else
                    sb.Append("2" + strScore[i].ToString());
            }

            return HiConvert.HexStringToByteArray(sb.ToString());
        }

        private int GetLargestScore(HiscoreData hiscoreData)
        {
            int p1 = ByteArrayToScore(hiscoreData.Score1V2);
            int p2 = ByteArrayToScore(hiscoreData.Score2V2);
            int hi = ByteArrayToScore(hiscoreData.HiScoreV2);

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

            HiConvert.ByteArrayCopy(hiscoreData.HiScoreV1, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScoreV1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HiScoreV2, ScoreToByteArray(score));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScoreV1, HiConvert.IntToByteArrayHex(0, hiscoreData.HiScoreV1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HiScoreV2, ScoreToByteArray(0));

            HiConvert.ByteArrayCopy(hiscoreData.Score1V1, HiConvert.IntToByteArrayHex(0, hiscoreData.Score1V1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score1V2, ScoreToByteArray(0));

            HiConvert.ByteArrayCopy(hiscoreData.Score2V1, HiConvert.IntToByteArrayHex(0, hiscoreData.Score2V1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2V2, ScoreToByteArray(0));

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