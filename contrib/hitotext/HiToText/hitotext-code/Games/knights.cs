using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class knights : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name;
            public byte Character;
            public byte Level;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Rank;
            public byte Unused;
        }

        public knights()
        {
            m_numEntries = 50;
            m_format = "RANK|SCORE|NAME|LEVEL|CHARACTER";
            m_gamesSupported = "knights,knightsj,knightsu";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x00 && data[i] <= 0x32)
                    sb.Append(((char)((((int)data[i]) / 2) + 65)));
                else if (data[i] == 0x34)
                    sb.Append('!');
                else if (data[i] == 0x36)
                    sb.Append('·');
                else if (data[i] == 0x38)
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
                    data[i] = (byte)((((int)str[i] - 65)) * 2);
                else if (str[i] == '!')
                    data[i] = 0x34;
                else if (str[i] == '·')
                    data[i] = 0x36;
                else if (str[i] == ' ')
                    data[i] = 0x38;
            }

            return data;
        }

        public int GetCharacter(String name)
        {
            switch (name.ToUpper())
            {
                case "LANCELOT":
                    return 0;
                case "ARTHUR":
                    return 1;
                case "PERCEVAL":
                    return 2;
            }
            return -1;
        }

        public String GetCharacter(int charNum)
        {
            switch (charNum)
            {
                case 0:
                    return "LANCELOT";
                case 1:
                    return "ARTHUR";
                case 2:
                    return "PERCEVAL";
            }
            return "";
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int level = System.Convert.ToInt32(args[3]);
            int character = GetCharacter(args[4]);
            int rank = 50;
            int offset;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData.Score = HiConvert.IntToByteArrayHex(score, 4);
            hiscoreData.Name = new byte[3];
            hiscoreData.Rank = new byte[2];
            hiscoreData.Character = (byte)character;
            hiscoreData.Level = (byte)(level - 1);
            HiConvert.ByteArrayCopy(hiscoreData.Name, StringToByteArray(name));

            #region DETERMINE RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = i * Marshal.SizeOf(typeof(HiscoreData));
                byte[] tmp = { m_data[offset], m_data[offset + 1], m_data[offset + 2], m_data[offset + 3] };

                int scoreToCompare = HiConvert.ByteArrayHexToInt(tmp);
                if (score > scoreToCompare)
                {
                    rank = i;
                    HiConvert.ByteArrayCopy(hiscoreData.Rank, HiConvert.IntToByteArrayHex(rank + 1, hiscoreData.Rank.Length));
                    break;
                }
            }
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);
            #endregion

            #region ADJUST
            int adjust = -1;
            if (rank < 49)
                adjust = 48;
            for (int i = adjust; i >= 0; i--)
            {
                if (rank > i)
                    break;

                int offsetOldLoc = i * Marshal.SizeOf(typeof(HiscoreData));
                int offsetNewLoc = (i + 1) * Marshal.SizeOf(typeof(HiscoreData));

                for (int j = 0; j < byteArray.Length; j++)
                {
                    if (j != 10 && j != 9) //Rank does not get transferred.
                        m_data[offsetNewLoc + j] = m_data[offsetOldLoc + j];
                }
            }

            #endregion

            #region REPLACE_NEW
            if (rank < 50)
            {
                offset = rank * Marshal.SizeOf(typeof(HiscoreData));

                for (int i = 0; i < byteArray.Length; i++)
                    m_data[offset + i] = byteArray[i];
            }
            #endregion
        }

        public override void EmptyScores()
        {
            for (int i = 0; i < NumEntries; i++)
            {
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData)))] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 1] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 2] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 3] = 0x00;
            }

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            for (int i = 0; i < NumEntries; i++)
            {
                HiscoreData hiscoreData = new HiscoreData();
                hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, i * Marshal.SizeOf(typeof(HiscoreData)), typeof(HiscoreData));

                retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                    i + 1,
                    HiConvert.ByteArrayHexToInt(hiscoreData.Score),
                    ByteArrayToString(hiscoreData.Name), 
                    hiscoreData.Level + 1,
                    GetCharacter((int)hiscoreData.Character)) + Environment.NewLine;
            }

            return retString;
        }
    }
}