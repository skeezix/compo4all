using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class marble : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name;
        }

        public marble()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "marble,marble2,marble3,marble4,marble5,marblea";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("X2"));

            String name = sb.ToString();
            String toReturn = "";
            
            int val = System.Convert.ToInt32(name, 16);
            int everyFirst = 1600;
            int everySecond = 40;

            toReturn = ((char)(System.Convert.ToInt32((val / everyFirst).ToString("X2"), 16) + 64)).ToString();
            int restOfLastTwo = val - ((val / everyFirst) * everyFirst);

            toReturn += ((char)(System.Convert.ToInt32((restOfLastTwo / everySecond).ToString("X2"), 16) + 64)).ToString();
            int last = restOfLastTwo - ((restOfLastTwo / everySecond) * everySecond);

            toReturn += ((char)(System.Convert.ToInt32(last.ToString("X2"), 16) + 64)).ToString();
            return toReturn.Replace('@', ' ');
        }

        public byte[] StringToByteArray(string str)
        {
            int val = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    val += ((int)str[i] - (65 - 0x01)) * System.Convert.ToInt32(Math.Pow(40, str.Length - 1 - i));
            }
            
            return HiConvert.HexStringToByteArray(val.ToString("X").PadLeft(4, '0'));
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int rank = 10;
            int offset;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData.Score = HiConvert.IntToByteArrayHexAsHex(score, 3);
            hiscoreData.Name = new byte[2];
            HiConvert.ByteArrayCopy(hiscoreData.Name, StringToByteArray(name));
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            #region DETERMINE RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = i * Marshal.SizeOf(typeof(HiscoreData));
                byte[] tmp = { m_data[offset], m_data[offset + 1], m_data[offset + 2] };

                int scoreToCompare = HiConvert.ByteArrayHexAsHexToInt(tmp);
                if (score > scoreToCompare)
                {
                    rank = i;
                    break;
                }
            }
            #endregion

            #region ADJUST
            int adjust = -1;
            if (rank < 9)
                adjust = 8;
            for (int i = adjust; i >= 0; i--)
            {
                if (rank > i)
                    break;

                int offsetOldLoc = i * Marshal.SizeOf(typeof(HiscoreData));
                int offsetNewLoc = (i + 1) * Marshal.SizeOf(typeof(HiscoreData));

                for (int j = 0; j < byteArray.Length; j++)
                    m_data[offsetNewLoc + j] = m_data[offsetOldLoc + j];
            }

            #endregion

            #region REPLACE_NEW
            if (rank < 10)
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

                retString += String.Format("{0}|{1}|{2}",
                    i + 1,
                    HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score),
                    ByteArrayToString(hiscoreData.Name)) + Environment.NewLine;
            }

            return retString;
        }
    }
}
