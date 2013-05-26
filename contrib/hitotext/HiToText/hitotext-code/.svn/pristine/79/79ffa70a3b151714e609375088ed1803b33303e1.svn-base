using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class gijoe : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score;
            public byte Character;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage;
        }

        public gijoe()
        {
            m_numEntries = 31;
            m_format = "RANK|SCORE|NAME|CHARACTER|STAGE";
            m_gamesSupported = "gijoe";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append((char)(int)data[i]);

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
                data[i] = (byte)((int)str[i]);

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int character = GetCharacter(args[3]);
            int stageFirst = GetStage(args[4], true);
            int stageSecond = GetStage(args[4], false);
            int rank = 31;
            int offset;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData.Name = new byte[3];
            HiConvert.ByteArrayCopy(hiscoreData.Name, StringToByteArray(name));
            hiscoreData.Score = HiConvert.IntToByteArrayHex(score, 2);
            hiscoreData.Stage = new byte[] { (byte)stageFirst, (byte)stageSecond };
            hiscoreData.Character = (byte)character;
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            #region DETERMINE RANK
            for (int i = NumEntries - 1; i >= 0; i--)
            {
                offset = i * Marshal.SizeOf(typeof(HiscoreData));
                byte[] tmp = { m_data[offset + 3], m_data[offset + 4] };

                int scoreToCompare = HiConvert.ByteArrayHexToInt(tmp);
                if (score > scoreToCompare)
                {
                    rank = NumEntries - i - 1;
                    break;
                }
            }
            #endregion

            #region ADJUST
            int adjust = -1;
            if (rank < 30)
                adjust = 29;
            for (int i = adjust; i >= 0; i--)
            {
                if (rank > i)
                    break;

                int offsetOldLoc = (NumEntries - 1 - i) * Marshal.SizeOf(typeof(HiscoreData));
                int offsetNewLoc = (NumEntries - 1 - (i + 1)) * Marshal.SizeOf(typeof(HiscoreData));

                for (int j = 0; j < byteArray.Length; j++)
                    m_data[offsetNewLoc + j] = m_data[offsetOldLoc + j];
            }

            #endregion

            #region REPLACE_NEW
            if (rank < 31)
            {
                offset = ((NumEntries - rank) - 1) * Marshal.SizeOf(typeof(HiscoreData));

                for (int i = 0; i < byteArray.Length; i++)
                    m_data[offset + i] = byteArray[i];
            }
            #endregion
        }

        private int GetStage(string p, bool isFirst)
        {
            if (isFirst)
                return Convert.ToInt32(p.Substring(0, 1)) - 1;
            else
                return Convert.ToInt32(p.Substring(p.IndexOf("-") + 1)) - 1;
        }

        private String GetStage(byte[] p)
        {
            int first = Convert.ToInt32(HiConvert.ByteArrayToHexString(new byte[] { p[0] })) + 1;
            int second = Convert.ToInt32(HiConvert.ByteArrayToHexString(new byte[] {p[1]})) + 1;
            return first.ToString() + "-" + second.ToString();
        }

        private int GetCharacter(String character)
        {
            switch (character)
            {
                case "DUKE":
                    return 0;
                case "SNAKE-EYES":
                    return 1;
                case "SCARLETT":
                    return 2;
                case "ROADBLOCK":
                    return 3;
            }
            return -1;
        }

        private String GetCharacter(int character)
        {
            switch (character)
            {
                case 0:
                    return "DUKE";
                case 1:
                    return "SNAKE-EYES";
                case 2:
                    return "SCARLETT";
                case 3:
                    return "ROADBLOCK";
            }
            return "";
        }

        public override void EmptyScores()
        {
            for (int i = 0; i < NumEntries; i++)
            {
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 3] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 4] = 0x00;
            }

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;
            for (int i = NumEntries - 1; i >= 0; i--)
            {
                HiscoreData hiscoreData = new HiscoreData();
                hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, i * Marshal.SizeOf(typeof(HiscoreData)), typeof(HiscoreData));

                retString += String.Format("{0}|{1}|{2}|{3}|{4}",
                    NumEntries - i, 
                    HiConvert.ByteArrayHexToInt(hiscoreData.Score),
                    ByteArrayToString(hiscoreData.Name),
                    GetCharacter((int)hiscoreData.Character),
                    GetStage(hiscoreData.Stage)) + Environment.NewLine;
            }

            return retString;
        }
    }
}