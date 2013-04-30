using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class s1945ii : Hiscore
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
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            public byte Separator1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            public byte Separator2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            public byte Separator3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            public byte Separator4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            public byte Separator5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            public byte Separator6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            public byte Separator7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            public byte Separator8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            public byte Separator9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
            public byte Separator10;

            public byte Plane1;
            public byte Plane2;
            public byte Plane3;
            public byte Plane4;
            public byte Plane5;
            public byte Plane6;
            public byte Plane7;
            public byte Plane8;
            public byte Plane9;
            public byte Plane10;

            public byte Stage1;
            public byte Stage2;
            public byte Stage3;
            public byte Stage4;
            public byte Stage5;
            public byte Stage6;
            public byte Stage7;
            public byte Stage8;
            public byte Stage9;
            public byte Stage10;
        }

        public s1945ii()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|PLANE|STAGE";
            m_gamesSupported = "s1945ii";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x01 && data[i] <= 0x1a)
                    sb.Append(((char)(((int)data[i]) + 65 - 0x01)));
                else if (data[i] == 0x1b)
                    sb.Append('(');
                else if (data[i] == 0x1c)
                    sb.Append(')');
                else if (data[i] == 0x1d)
                    sb.Append(',');
                else if (data[i] == 0x1e)
                    sb.Append('-');
                else if (data[i] == 0x1f)
                    sb.Append('.');
                else if (data[i] == 0x20)
                    sb.Append('/');
                else if (data[i] == 0x21)
                    sb.Append('0');
                else if (data[i] == 0x22)
                    sb.Append('1');
                else if (data[i] == 0x23)
                    sb.Append('2');
                else if (data[i] == 0x24)
                    sb.Append('3');
                else if (data[i] == 0x25)
                    sb.Append('4');
                else if (data[i] == 0x26)
                    sb.Append('5');
                else if (data[i] == 0x27)
                    sb.Append('6');
                else if (data[i] == 0x28)
                    sb.Append('7');
                else if (data[i] == 0x29)
                    sb.Append('8');
                else if (data[i] == 0x2a)
                    sb.Append('9');
                else if (data[i] == 0x2b)
                    sb.Append(':');
                else if (data[i] == 0x2c)
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
                    data[i] = (byte)((int)str[i] - 65 + 0x01);
                else if (str[i] == '(')
                    data[i] = 0x1b;
                else if (str[i] == ')')
                    data[i] = 0x1c;
                else if (str[i] == ',')
                    data[i] = 0x1d;
                else if (str[i] == '-')
                    data[i] = 0x1e;
                else if (str[i] == '.')
                    data[i] = 0x1f;
                else if (str[i] == '/')
                    data[i] = 0x20;
                else if (str[i] == '0')
                    data[i] = 0x21;
                else if (str[i] == '1')
                    data[i] = 0x22;
                else if (str[i] == '2')
                    data[i] = 0x23;
                else if (str[i] == '3')
                    data[i] = 0x24;
                else if (str[i] == '4')
                    data[i] = 0x25;
                else if (str[i] == '5')
                    data[i] = 0x26;
                else if (str[i] == '6')
                    data[i] = 0x27;
                else if (str[i] == '7')
                    data[i] = 0x28;
                else if (str[i] == '8')
                    data[i] = 0x29;
                else if (str[i] == '9')
                    data[i] = 0x2a;
                else if (str[i] == ':')
                    data[i] = 0x2b;
                else if (str[i] == ' ')
                    data[i] = 0x2c;
            }

            return data;
        }

        private int GetStage(string stage)
        {
            if (stage.Equals("ALL"))
                return 16;
            else
            {
                if (stage.Substring(0, 1).Equals("2"))
                    return 8 + ((Convert.ToInt32(stage.Substring(2, 1))) - 1);
                else
                    return (Convert.ToInt32(stage.Substring(2, 1))) - 1;
            }
        }

        private string GetStage(int stage)
        {
            if (stage >= 16)
                return "ALL";
            else if (stage >= 8)
                return "2-" + (stage - 7).ToString();
            else if (stage >= 0)
                return "1-" + (stage + 1).ToString();
            else
                return "";
        }

        private int GetPlane(string plane)
        {
            switch (plane)
            {
                case "P38":
                    return 1;
                case "Ki84":
                    return 2;
                case "Ta152":
                    return 3;
                case "F5U":
                    return 4;
                case "J7W":
                    return 5;
                case "DH98":
                    return 6;
            }
            return -1;
        }

        private string GetPlane(int plane)
        {
            switch (plane)
            {
                case 1:
                    return "P38";
                case 2:
                    return "Ki84";
                case 3:
                    return "Ta152";
                case 4:
                    return "F5U";
                case 5:
                    return "J7W";
                case 6:
                    return "DH98";
            }
            return "";
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = Convert.ToInt32(args[1]);
            string name = args[2];
            int plane = GetPlane(args[3]);
            int stage = GetStage(args[4]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5))
                rank = 4;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6))
                rank = 5;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7))
                rank = 6;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8))
                rank = 7;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9))
                rank = 8;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10))
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
                    hiscoreData.Plane2 = hiscoreData.Plane1;
                    hiscoreData.Stage2 = hiscoreData.Stage1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    hiscoreData.Plane3 = hiscoreData.Plane2;
                    hiscoreData.Stage3 = hiscoreData.Stage2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    hiscoreData.Plane4 = hiscoreData.Plane3;
                    hiscoreData.Stage4 = hiscoreData.Stage3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    hiscoreData.Plane5 = hiscoreData.Plane4;
                    hiscoreData.Stage5 = hiscoreData.Stage4;
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    hiscoreData.Plane6 = hiscoreData.Plane5;
                    hiscoreData.Stage6 = hiscoreData.Stage5;
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    hiscoreData.Plane7 = hiscoreData.Plane6;
                    hiscoreData.Stage7 = hiscoreData.Stage6;
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    hiscoreData.Plane8 = hiscoreData.Plane7;
                    hiscoreData.Stage8 = hiscoreData.Stage7;
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    hiscoreData.Plane9 = hiscoreData.Plane8;
                    hiscoreData.Stage9 = hiscoreData.Stage8;
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    hiscoreData.Plane10 = hiscoreData.Plane9;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    hiscoreData.Plane1 = (byte)plane;
                    hiscoreData.Stage1 = (byte)stage;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    hiscoreData.Plane2 = (byte)plane;
                    hiscoreData.Stage2 = (byte)stage;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    hiscoreData.Plane3 = (byte)plane;
                    hiscoreData.Stage3 = (byte)stage;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    hiscoreData.Plane4 = (byte)plane;
                    hiscoreData.Stage4 = (byte)stage;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    hiscoreData.Plane5 = (byte)plane;
                    hiscoreData.Stage5 = (byte)stage;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    hiscoreData.Plane6 = (byte)plane;
                    hiscoreData.Stage6 = (byte)stage;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    hiscoreData.Plane7 = (byte)plane;
                    hiscoreData.Stage7 = (byte)stage;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    hiscoreData.Plane8 = (byte)plane;
                    hiscoreData.Stage8 = (byte)stage;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    hiscoreData.Plane9 = (byte)plane;
                    hiscoreData.Stage9 = (byte)stage;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    hiscoreData.Plane10 = (byte)plane;
                    hiscoreData.Stage10 = (byte)stage;
                    break;
                default:
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

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), GetPlane((int)hiscoreData.Plane1), GetStage((int)hiscoreData.Stage1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), GetPlane((int)hiscoreData.Plane2), GetStage((int)hiscoreData.Stage2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), GetPlane((int)hiscoreData.Plane3), GetStage((int)hiscoreData.Stage3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), GetPlane((int)hiscoreData.Plane4), GetStage((int)hiscoreData.Stage4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), GetPlane((int)hiscoreData.Plane5), GetStage((int)hiscoreData.Stage5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), GetPlane((int)hiscoreData.Plane6), GetStage((int)hiscoreData.Stage6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), GetPlane((int)hiscoreData.Plane7), GetStage((int)hiscoreData.Stage7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), GetPlane((int)hiscoreData.Plane8), GetStage((int)hiscoreData.Stage8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9), GetPlane((int)hiscoreData.Plane9), GetStage((int)hiscoreData.Stage9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10), GetPlane((int)hiscoreData.Plane10), GetStage((int)hiscoreData.Stage10)) + Environment.NewLine;
            
            return retString;
        }
    }
}
