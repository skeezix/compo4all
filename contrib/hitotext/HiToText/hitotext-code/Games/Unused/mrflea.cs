//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Runtime.InteropServices;
//using HiToText;
using HiToText.Utils;

//namespace HiGames
//{    
//    class mrflea : Hiscore
//    {
//        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
//        public struct HiscoreData
//        {
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public byte[] ScoreA;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//            public byte[] NameA;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
//            public byte[] UnusedA;

//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public byte[] ScoreB;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//            public byte[] NameB;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
//            public byte[] UnusedB;

//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public byte[] ScoreC;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//            public byte[] NameC;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
//            public byte[] UnusedC;

//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public byte[] ScoreD;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//            public byte[] NameD;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
//            public byte[] UnusedD;

//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public byte[] ScoreE;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//            public byte[] NameE;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
//            public byte[] UnusedE;

//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public byte[] ScoreF;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//            public byte[] NameF;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
//            public byte[] UnusedF;

//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public byte[] ScoreG;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//            public byte[] NameG;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
//            public byte[] UnusedG;

//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public byte[] ScoreH;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//            public byte[] NameH;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
//            public byte[] UnusedH;

//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public byte[] ScoreI;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//            public byte[] NameI;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
//            public byte[] UnusedI;

//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public byte[] ScoreJ;
//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//            public byte[] NameJ;

//            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//            public byte[] HiScore;
//        }

//        public mrflea()
//        {
//            m_numEntries = 10;
//            m_format = "RANK|NAME|SCORE";
//            m_gamesSupported = "mrflea";
//            m_extensionsRequired = ".hi";
//        }

//        public string ByteArrayToString(byte[] data)
//        {
//            StringBuilder sb = new StringBuilder();

//            for (int i = 0; i < data.Length; i++)
//            {
//                if (data[i] == 0x40)
//                    sb.Append(' ');
//                else
//                    sb.Append((char)(int)data[i]);
//            }

//            return sb.ToString();
//        }

//        public byte[] StringToByteArray(string str, int maxLength)
//        {
//            byte[] data = new byte[maxLength];
//            if (str.Length > maxLength)
//                str = str.Substring(0, maxLength);
//            else str = str.PadLeft(maxLength, '0'); // if str.lenght<max complete to max with 0x30, like the game

//            for (int i = 0; i < str.Length; i++)
//                data[i] = (byte)((int)str[i]);

//            return data;
//        }

//        public override void SetHiScore(string[] args)
//        {
//            int rankGiven = Convert.ToInt32(args[0]);
//            string name = args[1].ToUpper();
//            string score = args[2];

//            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));
            
//            #region DETERMINE_RANK
//            int rank = NumEntries;
//            if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score1)))
//                rank = 0;
//            else if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score2)))
//                rank = 1;
//            else if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score3)))
//                rank = 2;
//            else if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score4)))
//                rank = 3;
//            else if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score5)))
//                rank = 4;
//            else if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score6)))
//                rank = 5;
//            else if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score7)))
//                rank = 6;
//            else if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score8)))
//                rank = 7;
//            else if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score9)))
//                rank = 8;
//            else if (Convert.ToInt32(score) > Convert.ToInt32(ByteArrayToString(hiscoreData.Score10)))
//                rank = 9;
//            #endregion

//            #region ADJUST
//            int adjust = NumEntries - 1;
//            if (rank < NumEntries - 1)
//                adjust = NumEntries - 2;
//            switch (adjust)
//            {
//                case 0:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
//                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
//                    break;
//                case 1:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
//                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
//                    if (rank < 1)
//                        goto case 0;
//                    break;
//                case 2:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
//                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
//                    if (rank < 2)
//                        goto case 1;
//                    break;
//                case 3:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
//                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
//                    if (rank < 3)
//                        goto case 2;
//                    break;
//                case 4:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
//                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
//                    if (rank < 4)
//                        goto case 3;
//                    break;
//                case 5:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
//                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
//                    if (rank < 5)
//                        goto case 4;
//                    break;
//                case 6:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
//                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
//                    if (rank < 6)
//                        goto case 5;
//                    break;
//                case 7:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
//                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
//                    if (rank < 7)
//                        goto case 6;
//                    break;
//                case 8:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
//                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
//                    if (rank < 8)
//                        goto case 7;
//                    break;
//             }
//            #endregion

//            #region REPLACE_NEW
//            switch (rank)
//            {
//                case 0:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score1, StringToByteArray(score, hiscoreData.Score1.Length));
//                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name, hiscoreData.Name1.Length));
//                    HiConvert.ByteArrayCopy(hiscoreData.TopScore, hiscoreData.Score1);
//                    break;
//                case 1:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score2, StringToByteArray(score, hiscoreData.Score2.Length));
//                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name, hiscoreData.Name2.Length));
//                    break;
//                case 2:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score3, StringToByteArray(score, hiscoreData.Score3.Length));
//                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name, hiscoreData.Name3.Length));
//                    break;
//                case 3:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score4, StringToByteArray(score, hiscoreData.Score4.Length));
//                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name, hiscoreData.Name4.Length));
//                    break;
//                case 4:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score5, StringToByteArray(score, hiscoreData.Score5.Length));
//                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name, hiscoreData.Name5.Length));
//                    break;
//                case 5:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score6, StringToByteArray(score, hiscoreData.Score6.Length));
//                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name, hiscoreData.Name6.Length));
//                    break;
//                case 6:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score7, StringToByteArray(score, hiscoreData.Score7.Length));
//                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name, hiscoreData.Name7.Length));
//                    break;
//                case 7:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score8, StringToByteArray(score, hiscoreData.Score8.Length));
//                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name, hiscoreData.Name8.Length));
//                    break;
//                case 8:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score9, StringToByteArray(score, hiscoreData.Score9.Length));
//                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name, hiscoreData.Name9.Length));
//                    break;
//                case 9:
//                    HiConvert.ByteArrayCopy(hiscoreData.Score10, StringToByteArray(score, hiscoreData.Score10.Length));
//                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name, hiscoreData.Name10.Length));
//                    break;
//            }
//            #endregion

//            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

//            HiConvert.ByteArrayCopy(m_data, byteArray);
//        }

//        public override void EmptyScores()
//        {
//            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

//            HiConvert.ByteArrayCopy(hiscoreData.Score1, StringToByteArray("000000", hiscoreData.Score1.Length));
//            HiConvert.ByteArrayCopy(hiscoreData.Score2, StringToByteArray("000000", hiscoreData.Score2.Length));
//            HiConvert.ByteArrayCopy(hiscoreData.Score3, StringToByteArray("000000", hiscoreData.Score3.Length));
//            HiConvert.ByteArrayCopy(hiscoreData.Score4, StringToByteArray("000000", hiscoreData.Score4.Length));
//            HiConvert.ByteArrayCopy(hiscoreData.Score5, StringToByteArray("000000", hiscoreData.Score5.Length));
//            HiConvert.ByteArrayCopy(hiscoreData.Score6, StringToByteArray("000000", hiscoreData.Score6.Length));
//            HiConvert.ByteArrayCopy(hiscoreData.Score7, StringToByteArray("000000", hiscoreData.Score7.Length));
//            HiConvert.ByteArrayCopy(hiscoreData.Score8, StringToByteArray("000000", hiscoreData.Score8.Length));
//            HiConvert.ByteArrayCopy(hiscoreData.Score9, StringToByteArray("000000", hiscoreData.Score9.Length));
//            HiConvert.ByteArrayCopy(hiscoreData.Score10, StringToByteArray("000000", hiscoreData.Score10.Length));
 
//            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

//            HiConvert.ByteArrayCopy(m_data, byteArray);

//            SaveData();
//        }

//        public override string HiToString()
//        {
//            string retString = m_format + Environment.NewLine;

//            HiscoreData hiscoreData = new HiscoreData();
//            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

//            List<string> Scores = new List<string>();
//            List<string> Names = new List<string>();

// //           for (int i = 0; i < 10; i++)
// //           {
//                Scores.Add(ByteArrayToString(hiscoreData.Score1));
//                Scores.Add(ByteArrayToString(hiscoreData.Score2));
//                Scores.Add(ByteArrayToString(hiscoreData.Score3));
//                Scores.Add(ByteArrayToString(hiscoreData.Score4));
//                Scores.Add(ByteArrayToString(hiscoreData.Score5));
//                Scores.Add(ByteArrayToString(hiscoreData.Score6));
//                Scores.Add(ByteArrayToString(hiscoreData.Score7));
//                Scores.Add(ByteArrayToString(hiscoreData.Score8));
//                Scores.Add(ByteArrayToString(hiscoreData.Score9));
//                Scores.Add(ByteArrayToString(hiscoreData.Score10));

//  //          }

//            Scores.Sort();
//            Scores.Reverse();
//        //    Names.Sort();
           

//            for (int i = 0; i < 10; i++)
//            {
//                retString += String.Format("{0}|{1}", i, Scores[i]) + Environment.NewLine;
//            }
//            retString += String.Format("{0}|{1}|{2}", 1, ByteArrayToString(hiscoreData.Name1), ByteArrayToString(hiscoreData.Score1)) + Environment.NewLine;
//            retString += String.Format("{0}|{1}|{2}", 2, ByteArrayToString(hiscoreData.Name2), ByteArrayToString(hiscoreData.Score2)) + Environment.NewLine;
//            retString += String.Format("{0}|{1}|{2}", 3, ByteArrayToString(hiscoreData.Name3), ByteArrayToString(hiscoreData.Score3)) + Environment.NewLine;
//            retString += String.Format("{0}|{1}|{2}", 4, ByteArrayToString(hiscoreData.Name4), ByteArrayToString(hiscoreData.Score4)) + Environment.NewLine;
//            retString += String.Format("{0}|{1}|{2}", 5, ByteArrayToString(hiscoreData.Name5), ByteArrayToString(hiscoreData.Score5)) + Environment.NewLine;
//            retString += String.Format("{0}|{1}|{2}", 6, ByteArrayToString(hiscoreData.Name6), ByteArrayToString(hiscoreData.Score6)) + Environment.NewLine;
//            retString += String.Format("{0}|{1}|{2}", 7, ByteArrayToString(hiscoreData.Name7), ByteArrayToString(hiscoreData.Score7)) + Environment.NewLine;
//            retString += String.Format("{0}|{1}|{2}", 8, ByteArrayToString(hiscoreData.Name8), ByteArrayToString(hiscoreData.Score8)) + Environment.NewLine;
//            retString += String.Format("{0}|{1}|{2}", 9, ByteArrayToString(hiscoreData.Name9), ByteArrayToString(hiscoreData.Score9)) + Environment.NewLine;
//            retString += String.Format("{0}|{1}|{2}", 10, ByteArrayToString(hiscoreData.Name10), ByteArrayToString(hiscoreData.Score10)) + Environment.NewLine;

//            return retString;
//        }
//    }
//}