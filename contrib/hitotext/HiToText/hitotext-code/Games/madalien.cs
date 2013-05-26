using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class madalien : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            public byte NumberofGamesPlayed;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] HiScore;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 198)]
            public byte[] AllScoresArray;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public byte[] TableScoresArray;

            public byte CheckByte;
        }

        public madalien()
        {
            m_numEntries = 99;
            m_format = "RANK|SCORE";
            m_gamesSupported = "madalien,madaliena,madalina";
            m_extensionsRequired = ".hi";
        }
          
        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 10;

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            int rank = NumEntries;
            int offset;
            int scorelength = 2; // The size of each score.

            #region DETERMINE_RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = i * scorelength; //The size of each score.
                byte[] tmp = { 
                    hiscoreData.AllScoresArray[offset], 
                    hiscoreData.AllScoresArray[offset + 1] };

                int scoreToCompare = HiConvert.ByteArrayHexToInt(tmp);
                if (score > scoreToCompare)
                {
                    rank = i;
                    break;
                }
            }
            #endregion

            #region ADJUST
            int adjust = -1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            for (int i = adjust; i >= 0; i--)
            {
                if (rank > i)
                    break;

                int offsetOldLoc = i * scorelength; //The size of each score.
                int offsetNewLoc = (i + 1) * scorelength; //The size of each score.

                for (int j = 0; j < scorelength; j++) //The size of each score.
                {
                    hiscoreData.AllScoresArray[offsetNewLoc + j] = hiscoreData.AllScoresArray[offsetOldLoc + j];
                    if (i < 4) // If Top5, we must move also the table scores (0x0300).
                        hiscoreData.TableScoresArray[offsetNewLoc + j] = hiscoreData.TableScoresArray[offsetOldLoc + j];
                }
            }
            #endregion

            #region REPLACE_NEW
            if (rank < NumEntries)
            {
                offset = rank * scorelength; //The size of each score.
                byte[] newScore = HiConvert.IntToByteArrayHex(score, scorelength);

                // Like we are registering a new score, its supposed that we have played a game, so
                // in order to the scores work properly, we must increment NumberofGamesPlayed
                // (number of games played x 2), so at least, this number div 2 was equal
                // to the scores registered.
                hiscoreData.NumberofGamesPlayed+=2;

                for (int i = 0; i < scorelength; i++) //The size of each score.
                {
                    hiscoreData.AllScoresArray[offset + i] = newScore[i];
                    if (rank < 5) // If Top5, we must also write the scores in Top5 table scores (0x0300).
                        hiscoreData.TableScoresArray[offset + i] = newScore[i];
                    if (rank < 1) // If Top 1, the Hiscore must be inverted.
                        hiscoreData.HiScore[offset + i] = newScore[scorelength - 1 - i];                    
                }
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.AllScoresArray, HiConvert.IntToByteArrayHex(0, hiscoreData.AllScoresArray.Length));
            HiConvert.ByteArrayCopy(hiscoreData.TableScoresArray, HiConvert.IntToByteArrayHex(0, hiscoreData.TableScoresArray.Length));
            HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(0, hiscoreData.HiScore.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            int offset;
            int scorelength = 2; // The size of each score.
         
            for (int i = 0; i < m_numEntries; i++)
            {
                offset = i * scorelength; //The size of each score
                byte[] allscoresarray = { 
                    hiscoreData.AllScoresArray[offset], 
                    hiscoreData.AllScoresArray[offset + 1] };
                int score = HiConvert.ByteArrayHexToInt(allscoresarray);
                if (score > 0)
                    retString += String.Format("{0}|{1}", i + 1, score * 10) + Environment.NewLine;
                else break;
            }

            return retString;
        }
    }
}