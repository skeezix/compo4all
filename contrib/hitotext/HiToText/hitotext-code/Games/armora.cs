using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class armora : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            // SOLO PLAY (ONE PLAYER)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] SoloScore;
            // TEAM PLAY (TWO PLAYERS)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] TeamScore;
        }

        public armora()
        {
            m_numEntries = 1;
            m_format = "MODE|SCORE";
            m_altFormat = new string[2];
            m_altFormat[0] = "SOLO HIGH SCORE" + Environment.NewLine + "SCORE";
            m_altFormat[1] = "TEAM HIGH SCORE" + Environment.NewLine + "SCORE";
            m_numAltEntries = new int[] { 1 , 1 };
            m_gamesSupported = "armora,armorap,armorar";
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
            int score = System.Convert.ToInt32(args[1]) / 10;

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumAltEntries[ModeOfPlay];
            switch (ModeOfPlay)
            {
                case 0:
                    if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.SoloScore) / 10)
                        rank = 0;
                    break;
                case 1:
                    if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.TeamScore) / 10)
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
                            HiConvert.ByteArrayCopy(hiscoreData.SoloScore, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.SoloScore.Length));
                            break;                        
                    }
                    break;
                case 1:
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.TeamScore, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.TeamScore.Length));
                            break;
                    }
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        //No name so we do nothing.
        public override void ModifyName(int rank, string name)
        {
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.SoloScore, HiConvert.IntToByteArrayHex(0, hiscoreData.SoloScore.Length));
            HiConvert.ByteArrayCopy(hiscoreData.TeamScore, HiConvert.IntToByteArrayHex(0, hiscoreData.TeamScore.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            HiscoreData hiscoreData = new HiscoreData();

            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            string retString = AltFormat[0] + Environment.NewLine;
            retString += String.Format("{0}", HiConvert.ByteArrayHexAsHexToInt(hiscoreData.SoloScore) * 10) + Environment.NewLine;

            retString += Environment.NewLine + AltFormat[1] + Environment.NewLine;
            retString += String.Format("{0}", HiConvert.ByteArrayHexAsHexToInt(hiscoreData.TeamScore) * 10) + Environment.NewLine;
          
            return retString;
        }
    }
}