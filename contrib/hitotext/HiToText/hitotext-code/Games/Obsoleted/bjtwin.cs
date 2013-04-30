using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class bjtwin : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score;
            public byte UnknownA;
            public byte Round;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] UnknownB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name;
        }

        public bjtwin()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|ROUND";
            m_gamesSupported = "bjtwin,bjtwina";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i = i + 2)
            {
                if (data[i + 1] >= 0x00 && data[i + 1] <= 0x64)
                    sb.Append(((char)((((int)data[i + 1]) / 4) + 65)));
                else if (data[i + 1] == 0x68)
                    sb.Append('.');
                else if (data[i + 1] == 0x80)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length * 2];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    data[(i * 2)] = 0x0c;
                    data[(i * 2) + 1] = (byte)((((int)str[i]) - 65) * 4);
                }
                else if (str[i] == '.')
                {
                    data[(i * 2)] = 0x0c;
                    data[(i * 2) + 1] = 0x68;
                }
                else if (str[i] == ' ')
                {
                    data[(i * 2)] = 0x0c;
                    data[(i * 2) + 1] = 0x80;
                }
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int round = System.Convert.ToInt32(args[3]);

            int rank = NumEntries;
            int offset;

            HiscoreData hiscoreData = new HiscoreData();
            //Do not change the below.
            hiscoreData.Score = HiConvert.IntToByteArrayHex(score, 4);
            hiscoreData.Name = new byte[6];
            hiscoreData.Round = (byte)round;
            HiConvert.ByteArrayCopy(hiscoreData.Name, StringToByteArray(name));
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            #region DETERMINE RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = i * Marshal.SizeOf(typeof(HiscoreData));
                byte[] tmp = { m_data[offset], m_data[offset + 1], m_data[offset + 2], m_data[offset + 3] };

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

                int offsetOldLoc = i * Marshal.SizeOf(typeof(HiscoreData));
                int offsetNewLoc = (i + 1) * Marshal.SizeOf(typeof(HiscoreData));

                for (int j = 0; j < byteArray.Length; j++)
                    m_data[offsetNewLoc + j] = m_data[offsetOldLoc + j];
            }
            #endregion

            #region REPLACE NEW
            if (rank < NumEntries)
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

            for (int i = 0; i < m_numEntries; i++)
            {
                HiscoreData hiscoreData = new HiscoreData();
                hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, i * Marshal.SizeOf(typeof(HiscoreData)), typeof(HiscoreData));

                retString += String.Format("{0}|{1}|{2}|{3}",
                    i + 1,
                    HiConvert.ByteArrayHexToInt(hiscoreData.Score),
                    ByteArrayToString(hiscoreData.Name),
                    Int32.Parse(hiscoreData.Round.ToString("X2"))) + Environment.NewLine;
            }

            return retString;
        }
    }
}
