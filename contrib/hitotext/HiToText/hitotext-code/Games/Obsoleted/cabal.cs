using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class cabal : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score;
            public byte UnknownA;
            public byte Round;
            public byte UnknownB;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreDataLast
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score;
            public byte UnknownA;
            public byte Round;
        }

        public cabal()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|ROUND";
            m_gamesSupported = "cabal,cabalbl,cabalus2,cabalus,cabala";
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

        public int GetRound(string round)
        {
            if (round.Equals("ALL"))
                return 20;
            else
            {
                int first = Convert.ToInt32(round.Substring(0, 1));
                int second = Convert.ToInt32(round.Substring(2, 1));

                return ((first - 1) * 4) + (second - 1);
            }
        }

        public string GetRound(int round)
        {
            if (round == 20)
                return "ALL";
            else
            {
                int first = (round / 4) + 1;
                int second = (round % 4) + 1;
                return first.ToString() + "-" + second.ToString();
            }
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int round = GetRound(args[3]);

            int rank = NumEntries;
            int offset;

            HiscoreData hiscoreData = new HiscoreData();
            //Do not change the below.
            hiscoreData.Score = HiConvert.IntToByteArrayHex(score, 4);
            hiscoreData.Name = new byte[3];
            hiscoreData.Round = (byte)round;
            HiConvert.ByteArrayCopy(hiscoreData.Name, StringToByteArray(name));
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            #region DETERMINE RANK
            for (int i = 0; i < NumEntries; i++)
            {
                offset = i * Marshal.SizeOf(typeof(HiscoreData));
                byte[] tmp = { m_data[offset + 3], m_data[offset + 4], m_data[offset + 5], m_data[offset + 6] };

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

                for (int j = 0; j < byteArray.Length - 1; j++) //-1 because we do not need the buffer, and the 10th score does not have that buffer.
                    m_data[offsetNewLoc + j] = m_data[offsetOldLoc + j];
            }
            #endregion

            #region REPLACE NEW
            if (rank < NumEntries)
            {
                offset = rank * Marshal.SizeOf(typeof(HiscoreData));

                for (int i = 0; i < byteArray.Length - 1; i++) //-1 because we do not need the buffer, and the 10th score does not have that buffer.
                    m_data[offset + i] = byteArray[i];
            }
            #endregion
        }

        public override void EmptyScores()
        {
            for (int i = 0; i < NumEntries; i++)
            {
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 3] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 4] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 5] = 0x00;
                m_data[(i * Marshal.SizeOf(typeof(HiscoreData))) + 6] = 0x00;
            }

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            for (int i = 0; i < m_numEntries; i++)
            {
                HiscoreData hiscoreData = new HiscoreData();
                if (i == NumEntries - 1)
                {
                    HiscoreDataLast hsdl = new HiscoreDataLast();
                    hsdl = (HiscoreDataLast)HiConvert.RawDeserialize(m_data, i * Marshal.SizeOf(typeof(HiscoreData)), typeof(HiscoreDataLast));

                    retString += String.Format("{0}|{1}|{2}|{3}",
                        i + 1,
                        HiConvert.ByteArrayHexToInt(hsdl.Score).ToString().PadLeft(8, '0'),
                        ByteArrayToString(hsdl.Name),
                        GetRound((int)hsdl.Round)) + Environment.NewLine;
                }
                else
                {
                    hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, i * Marshal.SizeOf(typeof(HiscoreData)), typeof(HiscoreData));

                    retString += String.Format("{0}|{1}|{2}|{3}",
                        i + 1,
                        HiConvert.ByteArrayHexToInt(hiscoreData.Score).ToString().PadLeft(8, '0'),
                        ByteArrayToString(hiscoreData.Name),
                        GetRound((int)hiscoreData.Round)) + Environment.NewLine;
                }
            }

            return retString;
        }
    }
}
