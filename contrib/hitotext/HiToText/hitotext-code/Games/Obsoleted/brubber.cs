using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class brubber : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 300)]
            public byte[] ScoreArray;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 300)]
            public byte[] NameArray;
        }

        public brubber()
        {
            m_numEntries = 100;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "brubber,bnj,caractn,cburnrub,cbnj,cburnrub2,cburnrb2";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x3b && data[i] <= 0x54)
                    sb.Append(((char)(((int)data[i]) + 65 - 0x3b)));
                else if (data[i] == 0x55)
                    sb.Append('!');
                else if (data[i] == 0x56)
                    sb.Append(':');
                else if (data[i] == 0x57)
                    sb.Append(',');
                else if (data[i] == 0x58)
                    sb.Append('.');
                else if (data[i] == 0x00)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)((int)str[i] - 65 + 0x3b);
                else if (str[i] == '!')
                    data[i] = 0x55;
                else if (str[i] == ':')
                    data[i] = 0x56;
                else if (str[i] == ',')
                    data[i] = 0x57;
                else if (str[i] == '.')
                    data[i] = 0x58;
                else if (str[i] == ' ')
                    data[i] = 0x00;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            int rank = NumEntries;
            int offset;

            #region DETERMINE_RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = i * 3; //The size of each score.
                byte[] tmp = { 
                    hiscoreData.ScoreArray[offset], 
                    hiscoreData.ScoreArray[offset + 1], 
                    hiscoreData.ScoreArray[offset + 2] };

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

                int offsetOldLoc = i * 3; //The size of each score.
                int offsetNewLoc = (i + 1) * 3; //The size of each score.

                for (int j = 0; j < 3; j++) //The size of each score, and each name.
                {
                    hiscoreData.ScoreArray[offsetNewLoc + j] = hiscoreData.ScoreArray[offsetOldLoc + j];
                    hiscoreData.NameArray[offsetNewLoc + j] = hiscoreData.NameArray[offsetOldLoc + j];
                }
            }
            #endregion

            #region REPLACE_NEW
            if (rank < NumEntries)
            {
                offset = rank * 3; //The size of each score, and each name.
                byte[] newScore = HiConvert.IntToByteArrayHex(score, 3);
                byte[] newName = StringToByteArray(name);

                for (int i = 0; i < 3; i++) //The size of each score, and each name.
                {
                    hiscoreData.ScoreArray[offset + i] = newScore[i];
                    hiscoreData.NameArray[offset + i] = newName[i];
                }
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreArray, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreArray.Length));

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

            for (int i = 0; i < m_numEntries; i++)
            {
                offset = i * 3; //The size of each score, and name.
                byte[] score = { 
                    hiscoreData.ScoreArray[offset], 
                    hiscoreData.ScoreArray[offset + 1], 
                    hiscoreData.ScoreArray[offset + 2] };
                byte[] name = { 
                    hiscoreData.NameArray[offset], 
                    hiscoreData.NameArray[offset + 1], 
                    hiscoreData.NameArray[offset + 2] };

                retString += String.Format("{0}|{1}|{2}",
                    i + 1,
                    HiConvert.ByteArrayHexToInt(score),
                    ByteArrayToString(name)) + Environment.NewLine;
            }

            return retString;
        }
    }
}