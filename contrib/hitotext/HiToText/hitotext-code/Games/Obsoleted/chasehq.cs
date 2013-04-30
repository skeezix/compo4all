using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class chasehq : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] _1st;

            public byte SeparatorA;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Play1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;

            public byte SeparatorB;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] _2nd;

            public byte SeparatorC;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Play2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;

            public byte SeparatorD;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] _3rd;

            public byte SeparatorE;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Play3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;

            public byte SeparatorF;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] _4th;

            public byte SeparatorG;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Play4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;

            public byte SeparatorH;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] _5th;

            public byte SeparatorI;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Play5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;

            public byte SeparatorJ;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] _6th;

            public byte SeparatorK;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Play6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;

            public byte SeparatorL;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] _7th;

            public byte SeparatorM;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Play7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;

            public byte SeparatorN;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] _8th;

            public byte SeparatorO;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Play8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;

            public byte SeparatorP;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] _9th;

            public byte SeparatorQ;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Play9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;

            public byte SeparatorR;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] _10th;

            public byte SeparatorS;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Stage10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Play10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;

            public byte SeparatorT;
        }

        public chasehq()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|STAGE|PLAY";
            m_gamesSupported = "chasehq,chasehqj,chasehqu";
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
                data[i] = (byte)((int)str.ToUpper()[i]);

            return data;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int stage = System.Convert.ToInt32(args[3]);
            int play = System.Convert.ToInt32(args[4]);
            
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
                    HiConvert.ByteArrayCopy(hiscoreData.Stage2, hiscoreData.Stage1);
                    HiConvert.ByteArrayCopy(hiscoreData.Play2, hiscoreData.Play1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage3, hiscoreData.Stage2);
                    HiConvert.ByteArrayCopy(hiscoreData.Play3, hiscoreData.Play2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage4, hiscoreData.Stage3);
                    HiConvert.ByteArrayCopy(hiscoreData.Play4, hiscoreData.Play3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage5, hiscoreData.Stage4);
                    HiConvert.ByteArrayCopy(hiscoreData.Play5, hiscoreData.Play4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage6, hiscoreData.Stage5);
                    HiConvert.ByteArrayCopy(hiscoreData.Play6, hiscoreData.Play5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage7, hiscoreData.Stage6);
                    HiConvert.ByteArrayCopy(hiscoreData.Play7, hiscoreData.Play6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage8, hiscoreData.Stage7);
                    HiConvert.ByteArrayCopy(hiscoreData.Play8, hiscoreData.Play7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage9, hiscoreData.Stage8);
                    HiConvert.ByteArrayCopy(hiscoreData.Play9, hiscoreData.Play8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage10, hiscoreData.Stage9);
                    HiConvert.ByteArrayCopy(hiscoreData.Play10, hiscoreData.Play9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    if (rank < 8)
                        goto case 7;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage1, HiConvert.IntToByteArrayHex(stage, hiscoreData.Stage1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Play1, HiConvert.IntToByteArrayHex(play, hiscoreData.Play1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage2, HiConvert.IntToByteArrayHex(stage, hiscoreData.Stage2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Play2, HiConvert.IntToByteArrayHex(play, hiscoreData.Play2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage3, HiConvert.IntToByteArrayHex(stage, hiscoreData.Stage3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Play3, HiConvert.IntToByteArrayHex(play, hiscoreData.Play3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage4, HiConvert.IntToByteArrayHex(stage, hiscoreData.Stage4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Play4, HiConvert.IntToByteArrayHex(play, hiscoreData.Play4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage5, HiConvert.IntToByteArrayHex(stage, hiscoreData.Stage5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Play5, HiConvert.IntToByteArrayHex(play, hiscoreData.Play5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage6, HiConvert.IntToByteArrayHex(stage, hiscoreData.Stage6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Play6, HiConvert.IntToByteArrayHex(play, hiscoreData.Play6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage7, HiConvert.IntToByteArrayHex(stage, hiscoreData.Stage7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Play7, HiConvert.IntToByteArrayHex(play, hiscoreData.Play7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage8, HiConvert.IntToByteArrayHex(stage, hiscoreData.Stage8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Play8, HiConvert.IntToByteArrayHex(play, hiscoreData.Play8.Length));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage9, HiConvert.IntToByteArrayHex(stage, hiscoreData.Stage9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Play9, HiConvert.IntToByteArrayHex(play, hiscoreData.Play9.Length));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage10, HiConvert.IntToByteArrayHex(stage, hiscoreData.Stage10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Play10, HiConvert.IntToByteArrayHex(play, hiscoreData.Play10.Length));
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

            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 1, HiConvert.ByteArrayHexToInt(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1), HiConvert.ByteArrayHexToInt(hiscoreData.Stage1), HiConvert.ByteArrayHexToInt(hiscoreData.Play1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 2, HiConvert.ByteArrayHexToInt(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2), HiConvert.ByteArrayHexToInt(hiscoreData.Stage2), HiConvert.ByteArrayHexToInt(hiscoreData.Play2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 3, HiConvert.ByteArrayHexToInt(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3), HiConvert.ByteArrayHexToInt(hiscoreData.Stage3), HiConvert.ByteArrayHexToInt(hiscoreData.Play3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 4, HiConvert.ByteArrayHexToInt(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4), HiConvert.ByteArrayHexToInt(hiscoreData.Stage4), HiConvert.ByteArrayHexToInt(hiscoreData.Play4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 5, HiConvert.ByteArrayHexToInt(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5), HiConvert.ByteArrayHexToInt(hiscoreData.Stage5), HiConvert.ByteArrayHexToInt(hiscoreData.Play5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 6, HiConvert.ByteArrayHexToInt(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6), HiConvert.ByteArrayHexToInt(hiscoreData.Stage6), HiConvert.ByteArrayHexToInt(hiscoreData.Play6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 7, HiConvert.ByteArrayHexToInt(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7), HiConvert.ByteArrayHexToInt(hiscoreData.Stage7), HiConvert.ByteArrayHexToInt(hiscoreData.Play7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 8, HiConvert.ByteArrayHexToInt(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8), HiConvert.ByteArrayHexToInt(hiscoreData.Stage8), HiConvert.ByteArrayHexToInt(hiscoreData.Play8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 9, HiConvert.ByteArrayHexToInt(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9), HiConvert.ByteArrayHexToInt(hiscoreData.Stage9), HiConvert.ByteArrayHexToInt(hiscoreData.Play9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}|{4}", 10, HiConvert.ByteArrayHexToInt(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10), HiConvert.ByteArrayHexToInt(hiscoreData.Stage10), HiConvert.ByteArrayHexToInt(hiscoreData.Play10)) + Environment.NewLine;
           
            return retString;
        }
    }
}