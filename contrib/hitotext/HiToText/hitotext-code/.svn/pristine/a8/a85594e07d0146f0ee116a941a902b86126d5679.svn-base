using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class ripoff : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SoloScorePart2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SoloScorePart1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TeamScorePart2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TeamScorePart1;
        }

        public ripoff()
        {
            // Max. score: 9,999,990
            m_numEntries = 1;
            m_format = "MODE|SCORE";
            m_altFormat = new string[2];
            m_altFormat[0] = "SOLO HIGH SCORE" + Environment.NewLine + "SCORE";
            m_altFormat[1] = "TEAM HIGH SCORE" + Environment.NewLine + "SCORE";
            m_numAltEntries = new int[] { 1, 1 };
            m_gamesSupported = "ripoff";
            m_extensionsRequired = ".hi";
        }

        private int GetModeOfPlay(string altName)
        {
            switch (altName)
            {
                case "SOLO HIGH SCORE":
                    return 0;
                case "TEAM HIGH SCORE":
                    return 1;
            }
            return -1;
        }

        public override void SetHiScore(string[] args)
        {
            int ModeOfPlay = GetModeOfPlay(args[0].ToUpper());
            int score1 = System.Convert.ToInt32(args[1].PadLeft(6, '0').Substring(0, 3));
            int score2 = System.Convert.ToInt32(args[1].PadLeft(6, '0').Substring(3, 3));

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumAltEntries[ModeOfPlay];
            switch (ModeOfPlay)
            {
                case 0:
                    if (score1 * 10000 + score2 *10 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.SoloScorePart1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.SoloScorePart2) * 10)
                        rank = 0;
                    break;
                case 1:
                    if (score1 * 10000 + score2 * 10 > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.TeamScorePart1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.TeamScorePart2) * 10)
                        rank = 0;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (ModeOfPlay)
            {
                case 0:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.SoloScorePart1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.SoloScorePart1.Length));
                            HiConvert.ByteArrayCopy(hiscoreData.SoloScorePart2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.SoloScorePart2.Length));
                            break;
                    }
                    break;
                case 1:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.TeamScorePart1, HiConvert.IntToByteArrayHexAsHex(score1, hiscoreData.TeamScorePart1.Length));
                            HiConvert.ByteArrayCopy(hiscoreData.TeamScorePart2, HiConvert.IntToByteArrayHexAsHex(score2, hiscoreData.TeamScorePart2.Length));
                            break;
                    }
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.SoloScorePart1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.SoloScorePart1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.SoloScorePart2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.SoloScorePart2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.TeamScorePart1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.TeamScorePart1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.TeamScorePart2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.TeamScorePart2.Length));
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            string retString = AltFormat[0] + Environment.NewLine;
            retString += String.Format("{0}", HiConvert.ByteArrayHexAsHexToInt(hiscoreData.SoloScorePart1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.SoloScorePart2) * 10) + Environment.NewLine;

            retString += Environment.NewLine + AltFormat[1] + Environment.NewLine;
            retString += String.Format("{0}", HiConvert.ByteArrayHexAsHexToInt(hiscoreData.TeamScorePart1) * 10000 + HiConvert.ByteArrayHexAsHexToInt(hiscoreData.TeamScorePart2) * 10) + Environment.NewLine;

            return retString;
        }
    }
}