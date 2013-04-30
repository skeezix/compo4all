using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class carnival : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score3;

            // These scores are never shown during the game
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score20;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score21;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score22;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score23;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score24;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score25;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score26;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score27;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score28;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score29;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score30;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;            
        }

        public carnival()
        {
            m_numEntries = 30;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "carnival,carnvckt";
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

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]) / 10;
            string name = args[2].ToUpper();
           
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)))
                rank = 2;            
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
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);                    
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    if (rank < 8)
                        goto case 7;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Score11, hiscoreData.Score10);
                    if (rank < 9)
                        goto case 8;
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.Score12, hiscoreData.Score11);
                    if (rank < 10)
                        goto case 9;
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.Score13, hiscoreData.Score12);
                    if (rank < 11)
                        goto case 10;
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.Score14, hiscoreData.Score13);
                    if (rank < 12)
                        goto case 11;
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.Score15, hiscoreData.Score14);
                    if (rank < 13)
                        goto case 12;
                    break;
                case 14:
                    HiConvert.ByteArrayCopy(hiscoreData.Score16, hiscoreData.Score15);
                    if (rank < 14)
                        goto case 13;
                    break;
                case 15:
                    HiConvert.ByteArrayCopy(hiscoreData.Score17, hiscoreData.Score16);
                    if (rank < 15)
                        goto case 14;
                    break;
                case 16:
                    HiConvert.ByteArrayCopy(hiscoreData.Score18, hiscoreData.Score17);
                    if (rank < 16)
                        goto case 15;
                    break;
                case 17:
                    HiConvert.ByteArrayCopy(hiscoreData.Score19, hiscoreData.Score18);
                    if (rank < 17)
                        goto case 16;
                    break;
                case 18:
                    HiConvert.ByteArrayCopy(hiscoreData.Score20, hiscoreData.Score19);
                    if (rank < 18)
                        goto case 17;
                    break;
                case 19:
                    HiConvert.ByteArrayCopy(hiscoreData.Score21, hiscoreData.Score20);
                    if (rank < 19)
                        goto case 18;
                    break;
                case 20:
                    HiConvert.ByteArrayCopy(hiscoreData.Score22, hiscoreData.Score21);
                    if (rank < 20)
                        goto case 19;
                    break;
                case 21:
                    HiConvert.ByteArrayCopy(hiscoreData.Score23, hiscoreData.Score22);
                    if (rank < 21)
                        goto case 20;
                    break;
                case 22:
                    HiConvert.ByteArrayCopy(hiscoreData.Score24, hiscoreData.Score23);
                    if (rank < 22)
                        goto case 21;
                    break;
                case 23:
                    HiConvert.ByteArrayCopy(hiscoreData.Score25, hiscoreData.Score24);
                    if (rank < 23)
                        goto case 22;
                    break;
                case 24:
                    HiConvert.ByteArrayCopy(hiscoreData.Score26, hiscoreData.Score25);
                    if (rank < 24)
                        goto case 23;
                    break;
                case 25:
                    HiConvert.ByteArrayCopy(hiscoreData.Score27, hiscoreData.Score26);
                    if (rank < 25)
                        goto case 24;
                    break;
                case 26:
                    HiConvert.ByteArrayCopy(hiscoreData.Score28, hiscoreData.Score27);
                    if (rank < 26)
                        goto case 25;
                    break;
                case 27:
                    HiConvert.ByteArrayCopy(hiscoreData.Score29, hiscoreData.Score28);
                    if (rank < 27)
                        goto case 26;
                    break;
                case 28:
                    HiConvert.ByteArrayCopy(hiscoreData.Score30, hiscoreData.Score29);
                    if (rank < 28)
                        goto case 27;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length)));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length)));
                    break;                                                                                                                               
                case 2:                                                                                                                                  
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));                                                                 
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length)));
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
            HiConvert.ByteArrayCopy(hiscoreData.Score11, HiConvert.IntToByteArrayHex(0, hiscoreData.Score11.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score12, HiConvert.IntToByteArrayHex(0, hiscoreData.Score12.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score13, HiConvert.IntToByteArrayHex(0, hiscoreData.Score13.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score14, HiConvert.IntToByteArrayHex(0, hiscoreData.Score14.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score15, HiConvert.IntToByteArrayHex(0, hiscoreData.Score15.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score16, HiConvert.IntToByteArrayHex(0, hiscoreData.Score16.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score17, HiConvert.IntToByteArrayHex(0, hiscoreData.Score17.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score18, HiConvert.IntToByteArrayHex(0, hiscoreData.Score18.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score19, HiConvert.IntToByteArrayHex(0, hiscoreData.Score19.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score20, HiConvert.IntToByteArrayHex(0, hiscoreData.Score20.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score21, HiConvert.IntToByteArrayHex(0, hiscoreData.Score21.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score22, HiConvert.IntToByteArrayHex(0, hiscoreData.Score22.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score23, HiConvert.IntToByteArrayHex(0, hiscoreData.Score23.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score24, HiConvert.IntToByteArrayHex(0, hiscoreData.Score24.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score25, HiConvert.IntToByteArrayHex(0, hiscoreData.Score25.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score26, HiConvert.IntToByteArrayHex(0, hiscoreData.Score26.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score27, HiConvert.IntToByteArrayHex(0, hiscoreData.Score27.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score28, HiConvert.IntToByteArrayHex(0, hiscoreData.Score28.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score29, HiConvert.IntToByteArrayHex(0, hiscoreData.Score29.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score30, HiConvert.IntToByteArrayHex(0, hiscoreData.Score30.Length));
            
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}", 1, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)) * 10, ByteArrayToString(hiscoreData.Name1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)) * 10, ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)) * 10, ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            
            return retString;
        }
    }
}