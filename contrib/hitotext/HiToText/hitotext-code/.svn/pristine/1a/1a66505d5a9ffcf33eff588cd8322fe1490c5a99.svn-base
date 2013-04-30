using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class esprade : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Character1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Character2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Character3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Character4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Character5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastScore5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;
        }

        public esprade()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|STAGE|CHARACTER";
            m_gamesSupported = "esprade,espradeo,espradej";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < data.Length; i = i + 2)
            {
                if (data[i] >= 0x99 && data[i] <= 0xb2)
                    sb.Append(((char)((((int)data[i])) + 65 - 0x99)));
                else if (data[i] == 0x86)
                    sb.Append('.');
                else if (data[i] == 0x00)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length * 2];

            for (int i = 0; i < str.Length; i++)
            {
                data[(i * 2)] = 0x00;

                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[(i * 2) + 1] = (byte)(((int)str[i] - 65 + 0x99));
                else if (str[i] == '.')
                    data[(i * 2) + 1] = 0x86;
                else if (str[i] == ' ')
                    data[(i * 2) + 1] = 0x00;
            }

            return data;
        }

        public string GetCharacter(int character)
        {
            //The default scores have 3, 4, and 5 as well. They are just repeats of 0, 1, and 2.
            //When you make a new score, only 0, 1, and 2 are used.
            switch (character)
            {
                case 0:
                    return "YUSUKE SAGAMI";
                case 1:
                    return "J-B 5TH";
                case 2:
                    return "IRORI MIMASAKA";
                case 3:
                    return "YUSUKE SAGAMI";
                case 4:
                    return "J-B 5TH";
                case 5:
                    return "IRORI MIMASAKA";
            }

            return "";
        }

        public int GetCharacter(string character)
        {
            switch (character)
            {
                case "YUSUKE SAGAMI":
                    return 0;
                case "J-B 5TH":
                    return 1;
                case "IRORI MIMASAKA":
                    return 2;
            }

            return -1;
        }

        public byte[] GetLastScore(int lastScore)
        {
            return new byte[] { 0x00, Convert.ToByte(lastScore + 0x88) };
        }

        public int GetLastScore(byte[] lastScore)
        {
            return Convert.ToInt32(lastScore[1] - 0x88);
        }

        public int GetStage(byte[] stage)
        {
            return HiConvert.ByteArrayHexAsHexToInt(new byte[] { 0x00, stage[1] }) / 2;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 10;
            int lastScore = System.Convert.ToInt32(args[1]) % 10;
            string name = args[2];
            int stage = System.Convert.ToInt32(args[3]) * 2;
            int character = GetCharacter(args[4]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score5))
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
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore2, hiscoreData.LastScore1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage2, hiscoreData.Stage1);
                    HiConvert.ByteArrayCopy(hiscoreData.Character2, hiscoreData.Character1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore3, hiscoreData.LastScore2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage3, hiscoreData.Stage2);
                    HiConvert.ByteArrayCopy(hiscoreData.Character3, hiscoreData.Character2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore4, hiscoreData.LastScore3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage4, hiscoreData.Stage3);
                    HiConvert.ByteArrayCopy(hiscoreData.Character4, hiscoreData.Character3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore5, hiscoreData.LastScore4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage5, hiscoreData.Stage4);
                    HiConvert.ByteArrayCopy(hiscoreData.Character5, hiscoreData.Character4);
                    if (rank < 3)
                        goto case 2;
                    break;
                default:
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage1, new byte[] { 0xae, (byte)stage });
                    HiConvert.ByteArrayCopy(hiscoreData.Character1, HiConvert.IntToByteArrayHex(character, hiscoreData.Character1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore1, GetLastScore(lastScore));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage2, new byte[] { 0xae, (byte)stage });
                    HiConvert.ByteArrayCopy(hiscoreData.Character2, HiConvert.IntToByteArrayHex(character, hiscoreData.Character2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore2, GetLastScore(lastScore));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage3, new byte[] { 0xae, (byte)stage });
                    HiConvert.ByteArrayCopy(hiscoreData.Character3, HiConvert.IntToByteArrayHex(character, hiscoreData.Character3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore3, GetLastScore(lastScore));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage4, new byte[] { 0xae, (byte)stage });
                    HiConvert.ByteArrayCopy(hiscoreData.Character4, HiConvert.IntToByteArrayHex(character, hiscoreData.Character4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore4, GetLastScore(lastScore));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage5, new byte[] { 0xae, (byte)stage });
                    HiConvert.ByteArrayCopy(hiscoreData.Character5, HiConvert.IntToByteArrayHex(character, hiscoreData.Character5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.LastScore5, GetLastScore(lastScore));
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(0, hiscoreData.Score5.Length));

            HiConvert.ByteArrayCopy(hiscoreData.LastScore1, HiConvert.IntToByteArrayHex(0, hiscoreData.LastScore1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LastScore2, HiConvert.IntToByteArrayHex(0, hiscoreData.LastScore2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LastScore3, HiConvert.IntToByteArrayHex(0, hiscoreData.LastScore3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LastScore4, HiConvert.IntToByteArrayHex(0, hiscoreData.LastScore4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.LastScore5, HiConvert.IntToByteArrayHex(0, hiscoreData.LastScore5.Length));
            
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1) * 10 + GetLastScore(hiscoreData.LastScore1), ByteArrayToString(hiscoreData.Name1), GetStage(hiscoreData.Stage1), GetCharacter((int)hiscoreData.Character1[1])) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2) * 10 + GetLastScore(hiscoreData.LastScore2), ByteArrayToString(hiscoreData.Name2), GetStage(hiscoreData.Stage2), GetCharacter((int)hiscoreData.Character2[1])) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3) * 10 + GetLastScore(hiscoreData.LastScore3), ByteArrayToString(hiscoreData.Name3), GetStage(hiscoreData.Stage3), GetCharacter((int)hiscoreData.Character3[1])) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4) * 10 + GetLastScore(hiscoreData.LastScore4), ByteArrayToString(hiscoreData.Name4), GetStage(hiscoreData.Stage4), GetCharacter((int)hiscoreData.Character4[1])) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5) * 10 + GetLastScore(hiscoreData.LastScore5), ByteArrayToString(hiscoreData.Name5), GetStage(hiscoreData.Stage5), GetCharacter((int)hiscoreData.Character5[1])) + Environment.NewLine;
            
            return retString;
        }
    }
}