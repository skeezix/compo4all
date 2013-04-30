using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class batsugun : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] TopScore;

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
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;

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
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name8;

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
            public byte[] Stage6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage8;

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
            public byte[] Character6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Character7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Character8;

            public byte Dummy;
        }

        public batsugun()
        {
            m_numEntries = 8;
            m_format = "RANK|SCORE|NAME|CHARACTER|STAGE";
            m_gamesSupported = "batsugun,batsugna,batugnsp";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < data.Length; i+=2)
            {
                if (data[i] >= 0x29 && data[i] <= 0x42)
                    sb.Append(((char)(((int)data[i]) + 65 - 0x29)));
                else if (data[i] == 0x15)
                    sb.Append('-');
                else if (data[i] == 0x16)
                    sb.Append('.');                
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, int maxLength)
        {
            byte[] data = new byte[maxLength];
            if (str.Length > maxLength/2)
                str = str.Substring(0, maxLength/2);
            else str = str.PadRight(maxLength/2, '.'); // The game does not allow lower that 3 characters.


            for (int i = 0; i < maxLength; i += 2)
            {
                data[i] = 0x81;
                if (str[i/2] >= 'A' && str[i/2] <= 'Z')
                    data[i+1] = (byte)((int)str[i/2] - 65 + 0x29);
                else if (str[i/2] == '.')
                    data[i + 1] = 0x16;
                else if (str[i/2] == '-')
                    data[i + 1] = 0x15;
            }

            return data;
        }

        public string GetCharacterToString(int character)
        {
            switch (character)
            {
                case 0:
                    return "JEENO";
                case 1:
                    return "BELTIANA";
                case 2:
                    return "ICEMAN";
                default:
                    return "JEENO";
            }
        }

        public int GetCharacterToInt(string character)
        {
            switch (character)
            {
                case "0":
                case "J":
                case "JEENO":
                    return 0;
                case "1":
                case "B":
                case "BELTIANA":
                    return 1;
                case "2":
                case "I":
                case "ICEMAN":
                    return 2;
                default:
                    return 0;
            }
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = Convert.ToInt32(args[1]);
            string name = args[2].ToUpper();
            int character = GetCharacterToInt(args[3].ToUpper());
            int stage = Convert.ToInt32(args[4]);
            
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
                    HiConvert.ByteArrayCopy(hiscoreData.Character2, hiscoreData.Character1);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage2, hiscoreData.Stage1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Character3, hiscoreData.Character2);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage3, hiscoreData.Stage2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Character4, hiscoreData.Character3);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage4, hiscoreData.Stage3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Character5, hiscoreData.Character4);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage5, hiscoreData.Stage4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Character6, hiscoreData.Character5);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage6, hiscoreData.Stage5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    HiConvert.ByteArrayCopy(hiscoreData.Character7, hiscoreData.Character6);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage7, hiscoreData.Stage6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    HiConvert.ByteArrayCopy(hiscoreData.Character8, hiscoreData.Character7);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage8, hiscoreData.Stage7);
                    hiscoreData.Dummy = hiscoreData.Name7[5];
                    if (rank < 6)
                        goto case 5;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name, hiscoreData.Name1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Character1, HiConvert.IntToByteArrayHex(character, hiscoreData.Character1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage1, HiConvert.IntToByteArrayHexAsHex(stage, hiscoreData.Stage1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name, hiscoreData.Name2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Character2, HiConvert.IntToByteArrayHex(character, hiscoreData.Character2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage2, HiConvert.IntToByteArrayHexAsHex(stage, hiscoreData.Stage2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name, hiscoreData.Name3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Character3, HiConvert.IntToByteArrayHex(character, hiscoreData.Character3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage3, HiConvert.IntToByteArrayHexAsHex(stage, hiscoreData.Stage3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name, hiscoreData.Name4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Character4, HiConvert.IntToByteArrayHex(character, hiscoreData.Character4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage4, HiConvert.IntToByteArrayHexAsHex(stage, hiscoreData.Stage4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name, hiscoreData.Name5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Character5, HiConvert.IntToByteArrayHex(character, hiscoreData.Character5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage5, HiConvert.IntToByteArrayHexAsHex(stage, hiscoreData.Stage5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name, hiscoreData.Name6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Character6, HiConvert.IntToByteArrayHex(character, hiscoreData.Character6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage6, HiConvert.IntToByteArrayHexAsHex(stage, hiscoreData.Stage6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name, hiscoreData.Name7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Character7, HiConvert.IntToByteArrayHex(character, hiscoreData.Character7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage7, HiConvert.IntToByteArrayHexAsHex(stage, hiscoreData.Stage7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name, hiscoreData.Name8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Character8, HiConvert.IntToByteArrayHex(character, hiscoreData.Character8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage8, HiConvert.IntToByteArrayHexAsHex(stage, hiscoreData.Stage8.Length));
                    hiscoreData.Dummy = hiscoreData.Name8[5];
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
            HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(0, hiscoreData.Score8.Length));
       
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), GetCharacterToString(HiConvert.ByteArrayHexToInt(hiscoreData.Character1)), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Stage1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), GetCharacterToString(HiConvert.ByteArrayHexToInt(hiscoreData.Character2)), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Stage2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), GetCharacterToString(HiConvert.ByteArrayHexToInt(hiscoreData.Character3)), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Stage3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), GetCharacterToString(HiConvert.ByteArrayHexToInt(hiscoreData.Character4)), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Stage4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), GetCharacterToString(HiConvert.ByteArrayHexToInt(hiscoreData.Character5)), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Stage5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), GetCharacterToString(HiConvert.ByteArrayHexToInt(hiscoreData.Character6)), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Stage6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), GetCharacterToString(HiConvert.ByteArrayHexToInt(hiscoreData.Character7)), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Stage7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), GetCharacterToString(HiConvert.ByteArrayHexToInt(hiscoreData.Character8)), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Stage8)) + Environment.NewLine;

            return retString;
        }
    }
}