using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class pulstar : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] HiScore;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            public byte Stage1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            public byte Stage2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            public byte Stage3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            public byte Stage4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            public byte Stage5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
        }

        public pulstar()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|STAGE";
            m_gamesSupported = "pulstar";
            m_extensionsRequired = "hi"; //TODO: Should convert this one to use the nvram file.
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x41 && data[i] <= 0x5a)
                    sb.Append((char)(int)data[i]);
                else if (data[i] == 0x30)
                    sb.Append('0');
                else if (data[i] == 0x31)
                    sb.Append('1');
                else if (data[i] == 0x32)
                    sb.Append('2');
                else if (data[i] == 0x33)
                    sb.Append('3');
                else if (data[i] == 0x34)
                    sb.Append('4');
                else if (data[i] == 0x35)
                    sb.Append('5');
                else if (data[i] == 0x36)
                    sb.Append('6');
                else if (data[i] == 0x37)
                    sb.Append('7');
                else if (data[i] == 0x38)
                    sb.Append('8');
                else if (data[i] == 0x39)
                    sb.Append('9');
                else if (data[i] == 0x5b)
                    sb.Append('[');
                else if (data[i] == 0x20)
                    sb.Append(' ');
                else if (data[i] == 0x40)
                    sb.Append('©');
                else if (data[i] == 0x5c)
                    sb.Append('£');
                else if (data[i] == 0x3f)
                    sb.Append('?');
                else if (data[i] == 0x3e)
                    sb.Append('>');
                else if (data[i] == 0x3d)
                    sb.Append('=');
                else if (data[i] == 0x3c)
                    sb.Append('<');
                else if (data[i] == 0x3b)
                    sb.Append(';');
                else if (data[i] == 0x3a)
                    sb.Append(':');
                else if (data[i] == 0x2d)
                    sb.Append('-');
                else if (data[i] == 0x2e)
                    sb.Append('.');
                else if (data[i] == 0x2f)
                    sb.Append('/');
                else if (data[i] == 0x5d)
                    sb.Append(']');
                else if (data[i] == 0x21)
                    sb.Append('!');
                else if (data[i] == 0x22)
                    sb.Append('"');                
                else if (data[i] == 0x23)
                    sb.Append('#');
                else if (data[i] == 0x24)
                    sb.Append('$');
                else if (data[i] == 0x25)
                    sb.Append('%');
                else if (data[i] == 0x26)
                    sb.Append('&');
                else if (data[i] == 0x27)
                    sb.Append('\'');
                else if (data[i] == 0x28)
                    sb.Append('(');
                else if (data[i] == 0x29)
                    sb.Append(')');
                else if (data[i] == 0x2a)
                    sb.Append('*');
                else if (data[i] == 0x2b)
                    sb.Append('+');
                else if (data[i] == 0x2c)
                    sb.Append(',');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)((int)str[i]);
                else if (str[i] == '0')
                    data[i] = 0x30;
                else if (str[i] == '1')
                    data[i] = 0x31;
                else if (str[i] == '2')
                    data[i] = 0x32;
                else if (str[i] == '3')
                    data[i] = 0x33;
                else if (str[i] == '4')
                    data[i] = 0x34;
                else if (str[i] == '5')
                    data[i] = 0x35;
                else if (str[i] == '6')
                    data[i] = 0x36;
                else if (str[i] == '7')
                    data[i] = 0x37;
                else if (str[i] == '8')
                    data[i] = 0x38;
                else if (str[i] == '9')
                    data[i] = 0x39;
                else if (str[i] == '[')
                    data[i] = 0x5b;
                else if (str[i] == ' ')
                    data[i] = 0x20;
                else if (str[i] == '©')
                    data[i] = 0x40;
                else if (str[i] == '£')
                    data[i] = 0x5c;
                else if (str[i] == '?')
                    data[i] = 0x3f;
                else if (str[i] == '>')
                    data[i] = 0x3e;
                else if (str[i] == '=')
                    data[i] = 0x3d;
                else if (str[i] == '<')
                    data[i] = 0x3c;
                else if (str[i] == ';')
                    data[i] = 0x3b;
                else if (str[i] == ':')
                    data[i] = 0x3a;
                else if (str[i] == '-')
                    data[i] = 0x2d;
                else if (str[i] == '.')
                    data[i] = 0x2e;
                else if (str[i] == '/')
                    data[i] = 0x2f;
                else if (str[i] == ']')
                    data[i] = 0x5d;
                else if (str[i] == '!')
                    data[i] = 0x21;
                else if (str[i] == '"')
                    data[i] = 0x22;
                else if (str[i] == '#')
                    data[i] = 0x23;
                else if (str[i] == '$')
                    data[i] = 0x24;
                else if (str[i] == '%')
                    data[i] = 0x25;
                else if (str[i] == '&')
                    data[i] = 0x26;
                else if (str[i] == '\'')
                    data[i] = 0x27;
                else if (str[i] == '(')
                    data[i] = 0x28;
                else if (str[i] == ')')
                    data[i] = 0x29;
                else if (str[i] == '*')
                    data[i] = 0x2a;
                else if (str[i] == '+')
                    data[i] = 0x2b;
                else if (str[i] == ',')
                    data[i] = 0x2c;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int stage = System.Convert.ToInt32(args[3]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 5;
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
            int adjust = 4;
            if (rank < 4)
                adjust = 3;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    hiscoreData.Stage2 = hiscoreData.Stage1;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    hiscoreData.Stage3 = hiscoreData.Stage2;
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    hiscoreData.Stage4 = hiscoreData.Stage3;
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    hiscoreData.Stage5 = hiscoreData.Stage4;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    hiscoreData.Stage1 = (byte)stage;
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    hiscoreData.Stage2 = (byte)stage;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    hiscoreData.Stage3 = (byte)stage;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    hiscoreData.Stage4 = (byte)stage;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    hiscoreData.Stage5 = (byte)stage;
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

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), hiscoreData.Stage1) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), hiscoreData.Stage2) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), hiscoreData.Stage3) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), hiscoreData.Stage4) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), hiscoreData.Stage5) + Environment.NewLine;
            
            return retString;
        }
    }
}
