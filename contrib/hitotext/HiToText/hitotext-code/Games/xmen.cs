using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class xmen : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            #region CYCLOPS
            public byte StageY10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameY10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreY10;

            public byte StageY9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameY9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreY9;

            public byte StageY8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameY8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreY8;

            public byte StageY7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameY7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreY7;

            public byte StageY6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameY6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreY6;

            public byte StageY5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameY5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreY5;

            public byte StageY4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameY4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreY4;

            public byte StageY3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameY3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreY3;

            public byte StageY2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameY2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreY2;

            public byte StageY1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameY1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreY1;
            #endregion

            #region COLOSSUS
            public byte StageC10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameC10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreC10;

            public byte StageC9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameC9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreC9;

            public byte StageC8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameC8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreC8;

            public byte StageC7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameC7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreC7;

            public byte StageC6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameC6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreC6;

            public byte StageC5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameC5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreC5;

            public byte StageC4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameC4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreC4;

            public byte StageC3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameC3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreC3;

            public byte StageC2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameC2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreC2;

            public byte StageC1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameC1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreC1;
            #endregion

            #region WOLVERINE
            public byte StageW10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameW10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreW10;

            public byte StageW9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameW9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreW9;

            public byte StageW8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameW8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreW8;

            public byte StageW7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameW7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreW7;

            public byte StageW6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameW6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreW6;

            public byte StageW5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameW5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreW5;

            public byte StageW4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameW4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreW4;

            public byte StageW3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameW3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreW3;

            public byte StageW2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameW2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreW2;

            public byte StageW1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameW1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreW1;
            #endregion

            #region STORM
            public byte StageS10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameS10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreS10;

            public byte StageS9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameS9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreS9;

            public byte StageS8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameS8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreS8;

            public byte StageS7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameS7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreS7;

            public byte StageS6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameS6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreS6;

            public byte StageS5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameS5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreS5;

            public byte StageS4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameS4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreS4;

            public byte StageS3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameS3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreS3;

            public byte StageS2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameS2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreS2;

            public byte StageS1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameS1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreS1;
            #endregion

            #region NIGHTCRAWLER
            public byte StageN10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameN10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreN10;

            public byte StageN9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameN9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreN9;

            public byte StageN8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameN8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreN8;

            public byte StageN7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameN7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreN7;

            public byte StageN6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameN6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreN6;

            public byte StageN5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameN5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreN5;

            public byte StageN4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameN4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreN4;

            public byte StageN3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameN3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreN3;

            public byte StageN2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameN2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreN2;

            public byte StageN1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameN1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreN1;
            #endregion

            #region DAZZLER
            public byte StageD10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameD10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreD10;

            public byte StageD9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameD9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreD9;

            public byte StageD8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameD8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreD8;

            public byte StageD7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameD7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreD7;

            public byte StageD6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameD6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreD6;

            public byte StageD5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameD5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreD5;

            public byte StageD4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameD4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreD4;

            public byte StageD3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameD3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreD3;

            public byte StageD2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameD2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreD2;

            public byte StageD1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] NameD1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] ScoreD1;
            #endregion
        }

        public xmen()
        {
            m_numEntries = 60;
            m_format = "RANK|SCORE|NAME|STAGE|CHARACTER";
            m_gamesSupported = "xmen,xmen2p,xmenj,xmen2pj,xmen6pu,xmen6p";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] >= 0x00 && data[i] <= 0x19)
                    sb.Append(((char)((((int)data[i])) + 65)));
                else if (data[i] == 0x2a)
                    sb.Append('·');
                else if (data[i] == 0x29)
                    sb.Append('-');
                else if (data[i] == 0x28)
                    sb.Append('.');
                else if (data[i] == 0x27)
                    sb.Append(',');
                else if (data[i] == 0x26)
                    sb.Append(':');
                else if (data[i] == 0x25)
                    sb.Append('?');
                else if (data[i] == 0x24)
                    sb.Append('!');
                else if (data[i] == 0x23)
                    sb.Append('9');
                else if (data[i] == 0x22)
                    sb.Append('8');
                else if (data[i] == 0x21)
                    sb.Append('7');
                else if (data[i] == 0x20)
                    sb.Append('6');
                else if (data[i] == 0x1f)
                    sb.Append('5');
                else if (data[i] == 0x1e)
                    sb.Append('4');
                else if (data[i] == 0x1d)
                    sb.Append('3');
                else if (data[i] == 0x1c)
                    sb.Append('2');
                else if (data[i] == 0x1b)
                    sb.Append('1');
                else if (data[i] == 0x1a)
                    sb.Append('0');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                int tmp = (int)str[i];
                if (str[i] >= 'A' && str[i] <= 'Z')
                    data[i] = (byte)(((int)str[i] - 65));
                else if (str[i] == '0')
                    data[i] = 0x1a;
                else if (str[i] == '1')
                    data[i] = 0x1b;
                else if (str[i] == '2')
                    data[i] = 0x1c;
                else if (str[i] == '3')
                    data[i] = 0x1d;
                else if (str[i] == '4')
                    data[i] = 0x1e;
                else if (str[i] == '5')
                    data[i] = 0x1f;
                else if (str[i] == '6')
                    data[i] = 0x20;
                else if (str[i] == '7')
                    data[i] = 0x21;
                else if (str[i] == '8')
                    data[i] = 0x22;
                else if (str[i] == '9')
                    data[i] = 0x23;
                else if (str[i] == '!')
                    data[i] = 0x24;
                else if (str[i] == '?')
                    data[i] = 0x25;
                else if (str[i] == ':')
                    data[i] = 0x26;
                else if (str[i] == ',')
                    data[i] = 0x27;
                else if (str[i] == '.')
                    data[i] = 0x28;
                else if (str[i] == '-')
                    data[i] = 0x29;
                else if (str[i] == '·')
                    data[i] = 0x2a;
            }

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int stage = System.Convert.ToInt32(args[3]) - 1;
            string character = args[4];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region CHAR SELECT AND REPLACE
            int rank = 10;
            int adjust = 9;
            switch (character.ToUpper())
            {
                case "CYCLOPS":
                    #region DETERMINE_RANK
                    if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY1))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY2))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY3))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY4))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY5))
                        rank = 4;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY6))
                        rank = 5;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY7))
                        rank = 6;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY8))
                        rank = 7;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY9))
                        rank = 8;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY10))
                        rank = 9;
                    #endregion

                    #region ADJUST
                    if (rank < 9)
                        adjust = 8;
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY2, hiscoreData.ScoreY1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameY2, hiscoreData.NameY1);
                            hiscoreData.StageY2 = hiscoreData.StageY1;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY3, hiscoreData.ScoreY2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameY3, hiscoreData.NameY2);
                            hiscoreData.StageY3 = hiscoreData.StageY2;
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY4, hiscoreData.ScoreY3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameY4, hiscoreData.NameY3);
                            hiscoreData.StageY4 = hiscoreData.StageY3;
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY5, hiscoreData.ScoreY4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameY5, hiscoreData.NameY4);
                            hiscoreData.StageY5 = hiscoreData.StageY4;
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY6, hiscoreData.ScoreY5);
                            HiConvert.ByteArrayCopy(hiscoreData.NameY6, hiscoreData.NameY5);
                            hiscoreData.StageY6 = hiscoreData.StageY5;
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY7, hiscoreData.ScoreY6);
                            HiConvert.ByteArrayCopy(hiscoreData.NameY7, hiscoreData.NameY6);
                            hiscoreData.StageY7 = hiscoreData.StageY6;
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY8, hiscoreData.ScoreY7);
                            HiConvert.ByteArrayCopy(hiscoreData.NameY8, hiscoreData.NameY7);
                            hiscoreData.StageY8 = hiscoreData.StageY7;
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY9, hiscoreData.ScoreY8);
                            HiConvert.ByteArrayCopy(hiscoreData.NameY9, hiscoreData.NameY8);
                            hiscoreData.StageY9 = hiscoreData.StageY8;
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY10, hiscoreData.ScoreY9);
                            HiConvert.ByteArrayCopy(hiscoreData.NameY10, hiscoreData.NameY9);
                            hiscoreData.StageY10 = hiscoreData.StageY9;
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
                            HiConvert.ByteArrayCopy(hiscoreData.NameY1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY1, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreY1.Length));
                            hiscoreData.StageY1 = (byte)stage;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameY2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY2, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreY2.Length));
                            hiscoreData.StageY2 = (byte)stage;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameY3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY3, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreY3.Length));
                            hiscoreData.StageY3 = (byte)stage;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameY4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY4, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreY4.Length));
                            hiscoreData.StageY4 = (byte)stage;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameY5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY5, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreY5.Length));
                            hiscoreData.StageY5 = (byte)stage;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.NameY6, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY6, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreY6.Length));
                            hiscoreData.StageY6 = (byte)stage;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.NameY7, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY7, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreY7.Length));
                            hiscoreData.StageY7 = (byte)stage;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.NameY8, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY8, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreY8.Length));
                            hiscoreData.StageY8 = (byte)stage;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.NameY9, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY9, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreY9.Length));
                            hiscoreData.StageY9 = (byte)stage;
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.NameY10, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreY10, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreY10.Length));
                            hiscoreData.StageY10 = (byte)stage;
                            break;
                    }
                    #endregion
                    break;
                case "COLOSSUS":
                    #region DETERMINE_RANK
                    if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC1))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC2))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC3))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC4))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC5))
                        rank = 4;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC6))
                        rank = 5;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC7))
                        rank = 6;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC8))
                        rank = 7;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC9))
                        rank = 8;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC10))
                        rank = 9;
                    #endregion

                    #region ADJUST
                    if (rank < 9)
                        adjust = 8;
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC2, hiscoreData.ScoreC1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameC2, hiscoreData.NameC1);
                            hiscoreData.StageC2 = hiscoreData.StageC1;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC3, hiscoreData.ScoreC2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameC3, hiscoreData.NameC2);
                            hiscoreData.StageC3 = hiscoreData.StageC2;
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC4, hiscoreData.ScoreC3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameC4, hiscoreData.NameC3);
                            hiscoreData.StageC4 = hiscoreData.StageC3;
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC5, hiscoreData.ScoreC4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameC5, hiscoreData.NameC4);
                            hiscoreData.StageC5 = hiscoreData.StageC4;
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC6, hiscoreData.ScoreC5);
                            HiConvert.ByteArrayCopy(hiscoreData.NameC6, hiscoreData.NameC5);
                            hiscoreData.StageC6 = hiscoreData.StageC5;
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC7, hiscoreData.ScoreC6);
                            HiConvert.ByteArrayCopy(hiscoreData.NameC7, hiscoreData.NameC6);
                            hiscoreData.StageC7 = hiscoreData.StageC6;
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC8, hiscoreData.ScoreC7);
                            HiConvert.ByteArrayCopy(hiscoreData.NameC8, hiscoreData.NameC7);
                            hiscoreData.StageC8 = hiscoreData.StageC7;
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC9, hiscoreData.ScoreC8);
                            HiConvert.ByteArrayCopy(hiscoreData.NameC9, hiscoreData.NameC8);
                            hiscoreData.StageC9 = hiscoreData.StageC8;
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC10, hiscoreData.ScoreC9);
                            HiConvert.ByteArrayCopy(hiscoreData.NameC10, hiscoreData.NameC9);
                            hiscoreData.StageC10 = hiscoreData.StageC9;
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
                            HiConvert.ByteArrayCopy(hiscoreData.NameC1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC1, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreC1.Length));
                            hiscoreData.StageC1 = (byte)stage;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameC2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC2, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreC2.Length));
                            hiscoreData.StageC2 = (byte)stage;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameC3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC3, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreC3.Length));
                            hiscoreData.StageC3 = (byte)stage;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameC4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC4, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreC4.Length));
                            hiscoreData.StageC4 = (byte)stage;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameC5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC5, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreC5.Length));
                            hiscoreData.StageC5 = (byte)stage;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.NameC6, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC6, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreC6.Length));
                            hiscoreData.StageC6 = (byte)stage;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.NameC7, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC7, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreC7.Length));
                            hiscoreData.StageC7 = (byte)stage;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.NameC8, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC8, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreC8.Length));
                            hiscoreData.StageC8 = (byte)stage;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.NameC9, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC9, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreC9.Length));
                            hiscoreData.StageC9 = (byte)stage;
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.NameC10, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC10, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreC10.Length));
                            hiscoreData.StageC10 = (byte)stage;
                            break;
                    }
                    #endregion
                    break;
                case "WOLVERINE":
                    #region DETERMINE_RANK
                    if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW1))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW2))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW3))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW4))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW5))
                        rank = 4;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW6))
                        rank = 5;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW7))
                        rank = 6;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW8))
                        rank = 7;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW9))
                        rank = 8;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW10))
                        rank = 9;
                    #endregion

                    #region ADJUST
                    if (rank < 9)
                        adjust = 8;
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW2, hiscoreData.ScoreW1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameW2, hiscoreData.NameW1);
                            hiscoreData.StageW2 = hiscoreData.StageW1;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW3, hiscoreData.ScoreW2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameW3, hiscoreData.NameW2);
                            hiscoreData.StageW3 = hiscoreData.StageW2;
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW4, hiscoreData.ScoreW3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameW4, hiscoreData.NameW3);
                            hiscoreData.StageW4 = hiscoreData.StageW3;
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW5, hiscoreData.ScoreW4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameW5, hiscoreData.NameW4);
                            hiscoreData.StageW5 = hiscoreData.StageW4;
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW6, hiscoreData.ScoreW5);
                            HiConvert.ByteArrayCopy(hiscoreData.NameW6, hiscoreData.NameW5);
                            hiscoreData.StageW6 = hiscoreData.StageW5;
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW7, hiscoreData.ScoreW6);
                            HiConvert.ByteArrayCopy(hiscoreData.NameW7, hiscoreData.NameW6);
                            hiscoreData.StageW7 = hiscoreData.StageW6;
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW8, hiscoreData.ScoreW7);
                            HiConvert.ByteArrayCopy(hiscoreData.NameW8, hiscoreData.NameW7);
                            hiscoreData.StageW8 = hiscoreData.StageW7;
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW9, hiscoreData.ScoreW8);
                            HiConvert.ByteArrayCopy(hiscoreData.NameW9, hiscoreData.NameW8);
                            hiscoreData.StageW9 = hiscoreData.StageW8;
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW10, hiscoreData.ScoreW9);
                            HiConvert.ByteArrayCopy(hiscoreData.NameW10, hiscoreData.NameW9);
                            hiscoreData.StageW10 = hiscoreData.StageW9;
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
                            HiConvert.ByteArrayCopy(hiscoreData.NameW1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW1, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreW1.Length));
                            hiscoreData.StageW1 = (byte)stage;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameW2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW2, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreW2.Length));
                            hiscoreData.StageW2 = (byte)stage;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameW3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW3, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreW3.Length));
                            hiscoreData.StageW3 = (byte)stage;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameW4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW4, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreW4.Length));
                            hiscoreData.StageW4 = (byte)stage;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameW5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW5, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreW5.Length));
                            hiscoreData.StageW5 = (byte)stage;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.NameW6, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW6, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreW6.Length));
                            hiscoreData.StageW6 = (byte)stage;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.NameW7, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW7, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreW7.Length));
                            hiscoreData.StageW7 = (byte)stage;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.NameW8, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW8, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreW8.Length));
                            hiscoreData.StageW8 = (byte)stage;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.NameW9, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW9, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreW9.Length));
                            hiscoreData.StageW9 = (byte)stage;
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.NameW10, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreW10, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreW10.Length));
                            hiscoreData.StageW10 = (byte)stage;
                            break;
                    }
                    #endregion
                    break;
                case "STORM":
                    #region DETERMINE_RANK
                    if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS1))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS2))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS3))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS4))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS5))
                        rank = 4;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS6))
                        rank = 5;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS7))
                        rank = 6;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS8))
                        rank = 7;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS9))
                        rank = 8;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS10))
                        rank = 9;
                    #endregion

                    #region ADJUST
                    if (rank < 9)
                        adjust = 8;
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS2, hiscoreData.ScoreS1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameS2, hiscoreData.NameS1);
                            hiscoreData.StageS2 = hiscoreData.StageS1;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS3, hiscoreData.ScoreS2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameS3, hiscoreData.NameS2);
                            hiscoreData.StageS3 = hiscoreData.StageS2;
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS4, hiscoreData.ScoreS3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameS4, hiscoreData.NameS3);
                            hiscoreData.StageS4 = hiscoreData.StageS3;
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS5, hiscoreData.ScoreS4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameS5, hiscoreData.NameS4);
                            hiscoreData.StageS5 = hiscoreData.StageS4;
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS6, hiscoreData.ScoreS5);
                            HiConvert.ByteArrayCopy(hiscoreData.NameS6, hiscoreData.NameS5);
                            hiscoreData.StageS6 = hiscoreData.StageS5;
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS7, hiscoreData.ScoreS6);
                            HiConvert.ByteArrayCopy(hiscoreData.NameS7, hiscoreData.NameS6);
                            hiscoreData.StageS7 = hiscoreData.StageS6;
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS8, hiscoreData.ScoreS7);
                            HiConvert.ByteArrayCopy(hiscoreData.NameS8, hiscoreData.NameS7);
                            hiscoreData.StageS8 = hiscoreData.StageS7;
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS9, hiscoreData.ScoreS8);
                            HiConvert.ByteArrayCopy(hiscoreData.NameS9, hiscoreData.NameS8);
                            hiscoreData.StageS9 = hiscoreData.StageS8;
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS10, hiscoreData.ScoreS9);
                            HiConvert.ByteArrayCopy(hiscoreData.NameS10, hiscoreData.NameS9);
                            hiscoreData.StageS10 = hiscoreData.StageS9;
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
                            HiConvert.ByteArrayCopy(hiscoreData.NameS1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS1, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreS1.Length));
                            hiscoreData.StageS1 = (byte)stage;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameS2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS2, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreS2.Length));
                            hiscoreData.StageS2 = (byte)stage;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameS3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS3, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreS3.Length));
                            hiscoreData.StageS3 = (byte)stage;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameS4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS4, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreS4.Length));
                            hiscoreData.StageS4 = (byte)stage;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameS5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS5, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreS5.Length));
                            hiscoreData.StageS5 = (byte)stage;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.NameS6, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS6, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreS6.Length));
                            hiscoreData.StageS6 = (byte)stage;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.NameS7, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS7, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreS7.Length));
                            hiscoreData.StageS7 = (byte)stage;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.NameS8, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS8, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreS8.Length));
                            hiscoreData.StageS8 = (byte)stage;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.NameS9, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS9, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreS9.Length));
                            hiscoreData.StageS9 = (byte)stage;
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.NameS10, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreS10, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreS10.Length));
                            hiscoreData.StageS10 = (byte)stage;
                            break;
                    }
                    #endregion
                    break;
                case "NIGHTCRAWLER":
                    #region DETERMINE_RANK
                    if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN1))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN2))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN3))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN4))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN5))
                        rank = 4;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN6))
                        rank = 5;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN7))
                        rank = 6;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN8))
                        rank = 7;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN9))
                        rank = 8;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN10))
                        rank = 9;
                    #endregion

                    #region ADJUST
                    if (rank < 9)
                        adjust = 8;
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN2, hiscoreData.ScoreN1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameN2, hiscoreData.NameN1);
                            hiscoreData.StageN2 = hiscoreData.StageN1;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN3, hiscoreData.ScoreN2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameN3, hiscoreData.NameN2);
                            hiscoreData.StageN3 = hiscoreData.StageN2;
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN4, hiscoreData.ScoreN3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameN4, hiscoreData.NameN3);
                            hiscoreData.StageN4 = hiscoreData.StageN3;
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN5, hiscoreData.ScoreN4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameN5, hiscoreData.NameN4);
                            hiscoreData.StageN5 = hiscoreData.StageN4;
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN6, hiscoreData.ScoreN5);
                            HiConvert.ByteArrayCopy(hiscoreData.NameN6, hiscoreData.NameN5);
                            hiscoreData.StageN6 = hiscoreData.StageN5;
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN7, hiscoreData.ScoreN6);
                            HiConvert.ByteArrayCopy(hiscoreData.NameN7, hiscoreData.NameN6);
                            hiscoreData.StageN7 = hiscoreData.StageN6;
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN8, hiscoreData.ScoreN7);
                            HiConvert.ByteArrayCopy(hiscoreData.NameN8, hiscoreData.NameN7);
                            hiscoreData.StageN8 = hiscoreData.StageN7;
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN9, hiscoreData.ScoreN8);
                            HiConvert.ByteArrayCopy(hiscoreData.NameN9, hiscoreData.NameN8);
                            hiscoreData.StageN9 = hiscoreData.StageN8;
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN10, hiscoreData.ScoreN9);
                            HiConvert.ByteArrayCopy(hiscoreData.NameN10, hiscoreData.NameN9);
                            hiscoreData.StageN10 = hiscoreData.StageN9;
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
                            HiConvert.ByteArrayCopy(hiscoreData.NameN1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN1, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreN1.Length));
                            hiscoreData.StageN1 = (byte)stage;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameN2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN2, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreN2.Length));
                            hiscoreData.StageN2 = (byte)stage;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameN3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN3, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreN3.Length));
                            hiscoreData.StageN3 = (byte)stage;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameN4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN4, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreN4.Length));
                            hiscoreData.StageN4 = (byte)stage;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameN5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN5, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreN5.Length));
                            hiscoreData.StageN5 = (byte)stage;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.NameN6, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN6, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreN6.Length));
                            hiscoreData.StageN6 = (byte)stage;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.NameN7, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN7, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreN7.Length));
                            hiscoreData.StageN7 = (byte)stage;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.NameN8, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN8, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreN8.Length));
                            hiscoreData.StageN8 = (byte)stage;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.NameN9, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN9, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreN9.Length));
                            hiscoreData.StageN9 = (byte)stage;
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.NameN10, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreN10, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreN10.Length));
                            hiscoreData.StageN10 = (byte)stage;
                            break;
                    }
                    #endregion
                    break;
                case "DAZZLER":
                    #region DETERMINE_RANK
                    if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD1))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD2))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD3))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD4))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD5))
                        rank = 4;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD6))
                        rank = 5;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD7))
                        rank = 6;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD8))
                        rank = 7;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD9))
                        rank = 8;
                    else if (score > HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD10))
                        rank = 9;
                    #endregion

                    #region ADJUST
                    if (rank < 9)
                        adjust = 8;
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD2, hiscoreData.ScoreD1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameD2, hiscoreData.NameD1);
                            hiscoreData.StageD2 = hiscoreData.StageD1;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD3, hiscoreData.ScoreD2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameD3, hiscoreData.NameD2);
                            hiscoreData.StageD3 = hiscoreData.StageD2;
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD4, hiscoreData.ScoreD3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameD4, hiscoreData.NameD3);
                            hiscoreData.StageD4 = hiscoreData.StageD3;
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD5, hiscoreData.ScoreD4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameD5, hiscoreData.NameD4);
                            hiscoreData.StageD5 = hiscoreData.StageD4;
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD6, hiscoreData.ScoreD5);
                            HiConvert.ByteArrayCopy(hiscoreData.NameD6, hiscoreData.NameD5);
                            hiscoreData.StageD6 = hiscoreData.StageD5;
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD7, hiscoreData.ScoreD6);
                            HiConvert.ByteArrayCopy(hiscoreData.NameD7, hiscoreData.NameD6);
                            hiscoreData.StageD7 = hiscoreData.StageD6;
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD8, hiscoreData.ScoreD7);
                            HiConvert.ByteArrayCopy(hiscoreData.NameD8, hiscoreData.NameD7);
                            hiscoreData.StageD8 = hiscoreData.StageD7;
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD9, hiscoreData.ScoreD8);
                            HiConvert.ByteArrayCopy(hiscoreData.NameD9, hiscoreData.NameD8);
                            hiscoreData.StageD9 = hiscoreData.StageD8;
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD10, hiscoreData.ScoreD9);
                            HiConvert.ByteArrayCopy(hiscoreData.NameD10, hiscoreData.NameD9);
                            hiscoreData.StageD10 = hiscoreData.StageD9;
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
                            HiConvert.ByteArrayCopy(hiscoreData.NameD1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD1, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreD1.Length));
                            hiscoreData.StageD1 = (byte)stage;
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameD2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD2, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreD2.Length));
                            hiscoreData.StageD2 = (byte)stage;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameD3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD3, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreD3.Length));
                            hiscoreData.StageD3 = (byte)stage;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameD4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD4, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreD4.Length));
                            hiscoreData.StageD4 = (byte)stage;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameD5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD5, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreD5.Length));
                            hiscoreData.StageD5 = (byte)stage;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.NameD6, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD6, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreD6.Length));
                            hiscoreData.StageD6 = (byte)stage;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.NameD7, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD7, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreD7.Length));
                            hiscoreData.StageD7 = (byte)stage;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.NameD8, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD8, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreD8.Length));
                            hiscoreData.StageD8 = (byte)stage;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.NameD9, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD9, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreD9.Length));
                            hiscoreData.StageD9 = (byte)stage;
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.NameD10, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD10, HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreD10.Length));
                            hiscoreData.StageD10 = (byte)stage;
                            break;
                    }
                    #endregion
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreY1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreY1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreY2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreY2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreY3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreY3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreY4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreY4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreY5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreY5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreY6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreY6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreY7, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreY7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreY8, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreY8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreY9, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreY9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreY10, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreY10.Length));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreC1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC7, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC8, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC9, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC10, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC10.Length));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreW1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreW1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreW2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreW2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreW3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreW3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreW4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreW4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreW5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreW5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreW6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreW6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreW7, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreW7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreW8, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreW8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreW9, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreW9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreW10, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreW10.Length));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreS1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreS1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreS2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreS2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreS3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreS3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreS4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreS4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreS5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreS5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreS6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreS6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreS7, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreS7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreS8, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreS8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreS9, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreS9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreS10, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreS10.Length));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreN1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreN1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreN2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreN2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreN3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreN3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreN4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreN4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreN5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreN5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreN6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreN6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreN7, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreN7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreN8, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreN8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreN9, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreN9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreN10, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreN10.Length));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreD1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD7, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD8, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD9, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD10, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD10.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY1), ByteArrayToString(hiscoreData.NameY1), hiscoreData.StageY1 + 1, "CYCLOPS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY2), ByteArrayToString(hiscoreData.NameY2), hiscoreData.StageY2 + 1, "CYCLOPS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY3), ByteArrayToString(hiscoreData.NameY3), hiscoreData.StageY3 + 1, "CYCLOPS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY4), ByteArrayToString(hiscoreData.NameY4), hiscoreData.StageY4 + 1, "CYCLOPS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY5), ByteArrayToString(hiscoreData.NameY5), hiscoreData.StageY5 + 1, "CYCLOPS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY6), ByteArrayToString(hiscoreData.NameY6), hiscoreData.StageY6 + 1, "CYCLOPS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY7), ByteArrayToString(hiscoreData.NameY7), hiscoreData.StageY7 + 1, "CYCLOPS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY8), ByteArrayToString(hiscoreData.NameY8), hiscoreData.StageY8 + 1, "CYCLOPS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY9), ByteArrayToString(hiscoreData.NameY9), hiscoreData.StageY9 + 1, "CYCLOPS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreY10), ByteArrayToString(hiscoreData.NameY10), hiscoreData.StageY10 + 1, "CYCLOPS") + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC1), ByteArrayToString(hiscoreData.NameC1), hiscoreData.StageC1 + 1, "COLOSSUS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC2), ByteArrayToString(hiscoreData.NameC2), hiscoreData.StageC2 + 1, "COLOSSUS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC3), ByteArrayToString(hiscoreData.NameC3), hiscoreData.StageC3 + 1, "COLOSSUS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC4), ByteArrayToString(hiscoreData.NameC4), hiscoreData.StageC4 + 1, "COLOSSUS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC5), ByteArrayToString(hiscoreData.NameC5), hiscoreData.StageC5 + 1, "COLOSSUS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC6), ByteArrayToString(hiscoreData.NameC6), hiscoreData.StageC6 + 1, "COLOSSUS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC7), ByteArrayToString(hiscoreData.NameC7), hiscoreData.StageC7 + 1, "COLOSSUS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC8), ByteArrayToString(hiscoreData.NameC8), hiscoreData.StageC8 + 1, "COLOSSUS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC9), ByteArrayToString(hiscoreData.NameC9), hiscoreData.StageC9 + 1, "COLOSSUS") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreC10), ByteArrayToString(hiscoreData.NameC10), hiscoreData.StageC10 + 1, "COLOSSUS") + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW1), ByteArrayToString(hiscoreData.NameW1), hiscoreData.StageW1 + 1, "WOLVERINE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW2), ByteArrayToString(hiscoreData.NameW2), hiscoreData.StageW2 + 1, "WOLVERINE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW3), ByteArrayToString(hiscoreData.NameW3), hiscoreData.StageW3 + 1, "WOLVERINE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW4), ByteArrayToString(hiscoreData.NameW4), hiscoreData.StageW4 + 1, "WOLVERINE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW5), ByteArrayToString(hiscoreData.NameW5), hiscoreData.StageW5 + 1, "WOLVERINE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW6), ByteArrayToString(hiscoreData.NameW6), hiscoreData.StageW6 + 1, "WOLVERINE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW7), ByteArrayToString(hiscoreData.NameW7), hiscoreData.StageW7 + 1, "WOLVERINE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW8), ByteArrayToString(hiscoreData.NameW8), hiscoreData.StageW8 + 1, "WOLVERINE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW9), ByteArrayToString(hiscoreData.NameW9), hiscoreData.StageW9 + 1, "WOLVERINE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreW10), ByteArrayToString(hiscoreData.NameW10), hiscoreData.StageW10 + 1, "WOLVERINE") + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS1), ByteArrayToString(hiscoreData.NameS1), hiscoreData.StageS1 + 1, "STORM") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS2), ByteArrayToString(hiscoreData.NameS2), hiscoreData.StageS2 + 1, "STORM") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS3), ByteArrayToString(hiscoreData.NameS3), hiscoreData.StageS3 + 1, "STORM") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS4), ByteArrayToString(hiscoreData.NameS4), hiscoreData.StageS4 + 1, "STORM") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS5), ByteArrayToString(hiscoreData.NameS5), hiscoreData.StageS5 + 1, "STORM") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS6), ByteArrayToString(hiscoreData.NameS6), hiscoreData.StageS6 + 1, "STORM") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS7), ByteArrayToString(hiscoreData.NameS7), hiscoreData.StageS7 + 1, "STORM") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS8), ByteArrayToString(hiscoreData.NameS8), hiscoreData.StageS8 + 1, "STORM") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS9), ByteArrayToString(hiscoreData.NameS9), hiscoreData.StageS9 + 1, "STORM") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreS10), ByteArrayToString(hiscoreData.NameS10), hiscoreData.StageS10 + 1, "STORM") + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN1), ByteArrayToString(hiscoreData.NameN1), hiscoreData.StageN1 + 1, "NIGHTCRAWLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN2), ByteArrayToString(hiscoreData.NameN2), hiscoreData.StageN2 + 1, "NIGHTCRAWLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN3), ByteArrayToString(hiscoreData.NameN3), hiscoreData.StageN3 + 1, "NIGHTCRAWLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN4), ByteArrayToString(hiscoreData.NameN4), hiscoreData.StageN4 + 1, "NIGHTCRAWLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN5), ByteArrayToString(hiscoreData.NameN5), hiscoreData.StageN5 + 1, "NIGHTCRAWLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN6), ByteArrayToString(hiscoreData.NameN6), hiscoreData.StageN6 + 1, "NIGHTCRAWLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN7), ByteArrayToString(hiscoreData.NameN7), hiscoreData.StageN7 + 1, "NIGHTCRAWLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN8), ByteArrayToString(hiscoreData.NameN8), hiscoreData.StageN8 + 1, "NIGHTCRAWLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN9), ByteArrayToString(hiscoreData.NameN9), hiscoreData.StageN9 + 1, "NIGHTCRAWLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreN10), ByteArrayToString(hiscoreData.NameN10), hiscoreData.StageN10 + 1, "NIGHTCRAWLER") + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD1), ByteArrayToString(hiscoreData.NameD1), hiscoreData.StageD1 + 1, "DAZZLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD2), ByteArrayToString(hiscoreData.NameD2), hiscoreData.StageD2 + 1, "DAZZLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD3), ByteArrayToString(hiscoreData.NameD3), hiscoreData.StageD3 + 1, "DAZZLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD4), ByteArrayToString(hiscoreData.NameD4), hiscoreData.StageD4 + 1, "DAZZLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD5), ByteArrayToString(hiscoreData.NameD5), hiscoreData.StageD5 + 1, "DAZZLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD6), ByteArrayToString(hiscoreData.NameD6), hiscoreData.StageD6 + 1, "DAZZLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD7), ByteArrayToString(hiscoreData.NameD7), hiscoreData.StageD7 + 1, "DAZZLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD8), ByteArrayToString(hiscoreData.NameD8), hiscoreData.StageD8 + 1, "DAZZLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD9), ByteArrayToString(hiscoreData.NameD9), hiscoreData.StageD9 + 1, "DAZZLER") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.ScoreD10), ByteArrayToString(hiscoreData.NameD10), hiscoreData.StageD10 + 1, "DAZZLER") + Environment.NewLine;

            return retString;
        }

        public override String[] OptimizeScoresForGame(String[] webScores)
        {
            List<String[]> Cyclops = new List<String[]>();
            List<String[]> Colossus = new List<String[]>();
            List<String[]> Wolverine = new List<String[]>();
            List<String[]> Storm = new List<String[]>();
            List<String[]> Nightcrawler = new List<String[]>();
            List<String[]> Dazzler = new List<String[]>();

            for (int i = 0; i < webScores.Length; i++)
            {
                String[] webScore = webScores[i].Split(new char[] { '|' });
                switch (webScore[3].ToUpper())
                {
                    case "CYCLOPS":
                        Cyclops.Add(webScore);
                        break;
                    case "COLOSSUS":
                        Colossus.Add(webScore);
                        break;
                    case "WOLVERINE":
                        Wolverine.Add(webScore);
                        break;
                    case "STORM":
                        Storm.Add(webScore);
                        break;
                    case "NIGHTCRAWLER":
                        Nightcrawler.Add(webScore);
                        break;
                    case "DAZZLER":
                        Dazzler.Add(webScore);
                        break;
                }
            }

            Cyclops.Sort(new XmenComparator());
            Colossus.Sort(new XmenComparator());
            Wolverine.Sort(new XmenComparator());
            Storm.Sort(new XmenComparator());
            Nightcrawler.Sort(new XmenComparator());
            Dazzler.Sort(new XmenComparator());

            String[] toReturn = new String[NumEntries];

            for (int i = 0; i < NumEntries; i++)
            {
                switch (i / 10)
                {
                    case 0:
                        toReturn[i] = String.Join("|", Cyclops[i % 10]);
                        break;
                    case 1:
                        toReturn[i] = String.Join("|", Colossus[i % 10]);
                        break;
                    case 2:
                        toReturn[i] = String.Join("|", Wolverine[i % 10]);
                        break;
                    case 3:
                        toReturn[i] = String.Join("|", Storm[i % 10]);
                        break;
                    case 4:
                        toReturn[i] = String.Join("|", Nightcrawler[i % 10]);
                        break;
                    case 5:
                        toReturn[i] = String.Join("|", Dazzler[i % 10]);
                        break;
                }
            }
            return toReturn;
        }
    }

    class XmenComparator : IComparer<String[]>
    {

        #region IComparer<string[]> Members

        int IComparer<string[]>.Compare(string[] x, string[] y)
        {
            return Convert.ToInt32(y[1]).CompareTo(Convert.ToInt32(x[1]));
        }

        #endregion
    }
}