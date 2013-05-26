using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class dynagear : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            public byte Character1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            public byte Character2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            public byte Character3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            public byte Character4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            public byte Character5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;       
        }

        public dynagear()
        {
            // Max. score: ???????
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|CHARACTER";
            m_gamesSupported = "dynagear";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x5b)
                    sb.Append(' ');
                else
                sb.Append((char)(int)data[i]);
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, int maxLength)
        {
            byte[] data = new byte[maxLength];
            if (str.Length > maxLength)
                str = str.Substring(0, maxLength).ToUpper();
            else str = str.PadRight(maxLength, ' ').ToUpper();


            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    data[i] = 0x5b;
                else
                data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public string GetCharacterToString(byte character)
        {
            switch (character)
            {
                case 0x00:
                    return "ROGER(P1)";
                case 0x01:
                    return "WOLF(P1)";
                case 0x09:
                    return "ROGER(P2)";
                case 0x0a:
                    return "WOLF(P2)";
                default:
                    return "UNKNOWN";
            }
        }

        public byte GetCharacterToByte(string character)
        {
            switch (character)
            {
                case "ROGER(P1)":
                case "RP1":
                    return 0x00;
                case "WOLF(P1)":
                case "WP1":
                    return 0x01;
                case "ROGER(P2)":
                case "RP2":
                    return 0x09;
                case "WOLF(P2)":
                case "WP2":
                    return 0x0a;
                default:
                    return 0x04;
            }
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].ToUpper().PadRight(3, ' ').Substring(0, 3);
            string character = args[3].ToUpper();

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)))
                rank = 4;
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    hiscoreData.Character2 = hiscoreData.Character1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    hiscoreData.Character3 = hiscoreData.Character2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    hiscoreData.Character4 = hiscoreData.Character3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    hiscoreData.Character5 = hiscoreData.Character4;
                    if (rank < 3)
                        goto case 2;
                    break;
             }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name, hiscoreData.Name1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score1.Length)));
                    hiscoreData.Character1 = GetCharacterToByte(character);
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, hiscoreData.Score1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name, hiscoreData.Name2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score2.Length)));
                    hiscoreData.Character2 = GetCharacterToByte(character);
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name, hiscoreData.Name3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score3.Length)));
                    hiscoreData.Character3 = GetCharacterToByte(character);
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name, hiscoreData.Name4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score4.Length)));
                    hiscoreData.Character4 = GetCharacterToByte(character);
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name, hiscoreData.Name5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score5.Length)));
                    hiscoreData.Character5 = GetCharacterToByte(character);
                    break;                
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score5.Length));
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)), ByteArrayToString(hiscoreData.Name1), GetCharacterToString(hiscoreData.Character1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)), ByteArrayToString(hiscoreData.Name2), GetCharacterToString(hiscoreData.Character2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)), ByteArrayToString(hiscoreData.Name3), GetCharacterToString(hiscoreData.Character3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)), ByteArrayToString(hiscoreData.Name4), GetCharacterToString(hiscoreData.Character4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)), ByteArrayToString(hiscoreData.Name5), GetCharacterToString(hiscoreData.Character5)) + Environment.NewLine;

            return retString;
        }
    }
}