using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class dino : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            public byte SeparatorA1;
            public byte Character1;
            public byte Stage1;
            public byte Unknown1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SeparatorB1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            public byte SeparatorA2;
            public byte Character2;
            public byte Stage2;
            public byte Unknown2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SeparatorB2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            public byte SeparatorA3;
            public byte Character3;
            public byte Stage3;
            public byte Unknown3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SeparatorB3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            public byte SeparatorA4;
            public byte Character4;
            public byte Stage4;
            public byte Unknown4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SeparatorB4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            public byte SeparatorA5;
            public byte Character5;
            public byte Stage5;
            public byte Unknown5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SeparatorB5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            public byte SeparatorA6;
            public byte Character6;
            public byte Stage6;
            public byte Unknown6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SeparatorB6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            public byte SeparatorA7;
            public byte Character7;
            public byte Stage7;
            public byte Unknown7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SeparatorB7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            public byte SeparatorA8;
            public byte Character8;
            public byte Stage8;
            public byte Unknown8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SeparatorB8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            public byte SeparatorA9;
            public byte Character9;
            public byte Stage9;
            public byte Unknown9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SeparatorB9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
            public byte SeparatorA10;
            public byte Character10;
            public byte Stage10;
            public byte Unknown10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] SeparatorB10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 640)]
            public byte[] UnusedScoreData;
        }

        public dino()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|CHARACTER|STAGE";
            m_gamesSupported = "dino,dinoj,dinou";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x2c)
                    sb.Append(',');
                else if (data[i] == 0x2e)
                    sb.Append('.');
                else if (data[i] == 0x20)
                    sb.Append(' ');
                else
                    sb.Append((char)(int)data[i]);
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ',')
                    data[i] = 0x2c;
                else if (str[i] == '.')
                    data[i] = 0x2e;
                else if (str[i] == ' ')
                    data[i] = 0x20;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = System.Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int character = GetCharacter(args[3]);
            int stage = System.Convert.ToInt32(args[4]);

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
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score6))
                rank = 5;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score7))
                rank = 6;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score8))
                rank = 7;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score9))
                rank = 8;
            else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.Score10))
                rank = 9;
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
                    hiscoreData.Stage2 = hiscoreData.Stage1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    hiscoreData.Character3 = hiscoreData.Character2;
                    hiscoreData.Stage3 = hiscoreData.Stage2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    hiscoreData.Character4 = hiscoreData.Character3;
                    hiscoreData.Stage4 = hiscoreData.Stage3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    hiscoreData.Character5 = hiscoreData.Character4;
                    hiscoreData.Stage5 = hiscoreData.Stage4;
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    hiscoreData.Character6 = hiscoreData.Character5;
                    hiscoreData.Stage6 = hiscoreData.Stage5;
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    hiscoreData.Character7 = hiscoreData.Character6;
                    hiscoreData.Stage7 = hiscoreData.Stage6;
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    hiscoreData.Character8 = hiscoreData.Character7;
                    hiscoreData.Stage8 = hiscoreData.Stage7;
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    hiscoreData.Character9 = hiscoreData.Character8;
                    hiscoreData.Stage9 = hiscoreData.Stage8;
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    hiscoreData.Character10 = hiscoreData.Character9;
                    hiscoreData.Stage10 = hiscoreData.Stage9;
                    if (rank < 8)
                        goto case 7;
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
                    hiscoreData.Character1 = (byte)character;
                    hiscoreData.Stage1 = (byte)stage;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    hiscoreData.Character2 = (byte)character;
                    hiscoreData.Stage2 = (byte)stage;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    hiscoreData.Character3 = (byte)character;
                    hiscoreData.Stage3 = (byte)stage;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    hiscoreData.Character4 = (byte)character;
                    hiscoreData.Stage4 = (byte)stage;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    hiscoreData.Character5 = (byte)character;
                    hiscoreData.Stage5 = (byte)stage;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length));
                    hiscoreData.Character6 = (byte)character;
                    hiscoreData.Stage6 = (byte)stage;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length));
                    hiscoreData.Character7 = (byte)character;
                    hiscoreData.Stage7 = (byte)stage;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length));
                    hiscoreData.Character8 = (byte)character;
                    hiscoreData.Stage8 = (byte)stage;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length));
                    hiscoreData.Character9 = (byte)character;
                    hiscoreData.Stage9 = (byte)stage;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length));
                    hiscoreData.Character10 = (byte)character;
                    hiscoreData.Stage10 = (byte)stage;
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        private int GetCharacter(string charName)
        {
            switch (charName)
            {
                case "JACK TENREC":
                    return 0;
                case "MUSTAPHA CAIRO":
                    return 1;
                case "HANNAH DUNDEE":
                    return 2;
                case "MESS O'BRADOVICH":
                    return 3;
            }

            return -1;
        }

        private String GetCharacter(int charID)
        {
            switch (charID)
            {
                case 0:
                    return "JACK TENREC";
                case 1:
                    return "MUSTAPHA CAIRO";
                case 2:
                    return "HANNAH DUNDEE";
                case 3:
                    return "MESS O'BRADOVICH";
            }
            return "";
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(0, hiscoreData.Score5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(0, hiscoreData.Score8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(0, hiscoreData.Score9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(0, hiscoreData.Score10.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), GetCharacter((int)hiscoreData.Character1), (int)hiscoreData.Stage1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), GetCharacter((int)hiscoreData.Character2), (int)hiscoreData.Stage2) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), GetCharacter((int)hiscoreData.Character3), (int)hiscoreData.Stage3) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), GetCharacter((int)hiscoreData.Character4), (int)hiscoreData.Stage4) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), GetCharacter((int)hiscoreData.Character5), (int)hiscoreData.Stage5) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), GetCharacter((int)hiscoreData.Character6), (int)hiscoreData.Stage6) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), GetCharacter((int)hiscoreData.Character7), (int)hiscoreData.Stage7) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), GetCharacter((int)hiscoreData.Character8), (int)hiscoreData.Stage8) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9), GetCharacter((int)hiscoreData.Character9), (int)hiscoreData.Stage9) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10), GetCharacter((int)hiscoreData.Character10), (int)hiscoreData.Stage10) + Environment.NewLine;
           
            return retString;
        }
    }
}