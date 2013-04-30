using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;
using System.IO;

namespace HiGames
{
    class berzerk : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {   // NVRAM File is 1024 bytes
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 220)]
            public byte[] Unused1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 744)]
            public byte[] Unused2;

            // Now thehi file for 6th to 10th record
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;

            public byte CheckByte;
        }

        public berzerk()
        {
            // nvram file only stores the firts 5 hiscores. There are other 5 (up to 10)
            // not saved (we will use hi file for them)
            m_numEntries = 10; 
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "berzerk,berzerk1";
            m_extensionsRequired = ".nv,.hi";
        }

        public string ByteArrayToString(byte[] data, string file)
        {
            StringBuilder sb = new StringBuilder();
            int ToAdd = 1;
            if (file == "NV") ToAdd = 2;
       
            for (int i = 0; i < data.Length; i+=ToAdd)
                sb.Append((char)(int)data[i]);

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, string file)
        {
            byte[] data = new byte[str.Length];
            
            for (int i = 0; i < str.Length; i++)
                data[i] = (byte)str[i];

            if (file == "NV")
                return AddMirrorToByteArray(data, str.Length * 2);
            else
                return data;
        }

        public int MirroredScoreToInt(byte[] data)
        {
            byte[] score = new byte[data.Length/2];

            for (int i = 0; i < score.Length; i++)
                score[i] = data[i*2];
            return HiConvert.ByteArrayHexToInt(score);
        }

        public byte[] IntToMirroredScore(int score,int numBytes)
        {            
            return AddMirrorToByteArray(HiConvert.IntToByteArrayHex(score, numBytes / 2), numBytes);            
        }

        public byte[] AddMirrorToByteArray(byte[] data,int numBytes)
        {
            byte[] MirroredArray = new byte[numBytes];
            for (int i = 0; i < data.Length; i++)
            {
                MirroredArray[i * 2] = data[i];
                MirroredArray[(i * 2) + 1] = Convert.ToByte (data[i].ToString("X2").Substring(1, 1) + data[i].ToString("X2").Substring(0, 1),16);
            }
            return MirroredArray;
        }

        public byte[] DeleteMirrorToByteArray(byte[] data)
        {
            byte[] NoMirroredArray = new byte[data.Length / 2];
            for (int i = 0; i < NoMirroredArray.Length; i ++)
            {
                NoMirroredArray[i] = data[i * 2];  
            }
            return NoMirroredArray;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1].PadLeft(6,'0').Substring(0,6));
            string name = args[2].ToUpper().PadRight(3,'A').Substring(0,3);
            
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > MirroredScoreToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > MirroredScoreToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > MirroredScoreToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > MirroredScoreToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > MirroredScoreToInt(hiscoreData.Score5))
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
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, DeleteMirrorToByteArray(hiscoreData.Score5));
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, DeleteMirrorToByteArray(hiscoreData.Name5));
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
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
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name, "NV"));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, IntToMirroredScore(score, hiscoreData.Score1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name, "NV"));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, IntToMirroredScore(score, hiscoreData.Score2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name, "NV"));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, IntToMirroredScore(score, hiscoreData.Score3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name, "NV"));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, IntToMirroredScore(score, hiscoreData.Score4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name, "NV"));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, IntToMirroredScore(score, hiscoreData.Score5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name, "HI"));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHex(score, hiscoreData.Score6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name, "HI"));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHex(score, hiscoreData.Score7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name, "HI"));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHex(score, hiscoreData.Score8.Length));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name, "HI"));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHex(score, hiscoreData.Score9.Length));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name, "HI"));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHex(score, hiscoreData.Score10.Length));
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

            HiConvert.ByteArrayCopy(hiscoreData.Name1, HiConvert.IntToByteArrayHex(0, hiscoreData.Name1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Name2, HiConvert.IntToByteArrayHex(0, hiscoreData.Name2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Name3, HiConvert.IntToByteArrayHex(0, hiscoreData.Name3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Name4, HiConvert.IntToByteArrayHex(0, hiscoreData.Name4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Name5, HiConvert.IntToByteArrayHex(0, hiscoreData.Name5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Name6, HiConvert.IntToByteArrayHex(0, hiscoreData.Name6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Name7, HiConvert.IntToByteArrayHex(0, hiscoreData.Name7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Name8, HiConvert.IntToByteArrayHex(0, hiscoreData.Name8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Name9, HiConvert.IntToByteArrayHex(0, hiscoreData.Name9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Name10, HiConvert.IntToByteArrayHex(0, hiscoreData.Name10.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;
            int TempScore;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            TempScore=MirroredScoreToInt(hiscoreData.Score1);
            if (TempScore > 0)
                retString += String.Format("{0}|{1}|{2}", 1, TempScore, ByteArrayToString(hiscoreData.Name1, "NV")) + Environment.NewLine;
            TempScore=MirroredScoreToInt(hiscoreData.Score2);
            if (TempScore > 0)
                retString += String.Format("{0}|{1}|{2}", 2, TempScore, ByteArrayToString(hiscoreData.Name2, "NV")) + Environment.NewLine;
            TempScore=MirroredScoreToInt(hiscoreData.Score3);
            if (TempScore > 0)
                retString += String.Format("{0}|{1}|{2}", 3, TempScore, ByteArrayToString(hiscoreData.Name3, "NV")) + Environment.NewLine;
            TempScore=MirroredScoreToInt(hiscoreData.Score4);
            if (TempScore > 0)
                retString += String.Format("{0}|{1}|{2}", 4, TempScore, ByteArrayToString(hiscoreData.Name4, "NV")) + Environment.NewLine;
            TempScore=MirroredScoreToInt(hiscoreData.Score5);
            if (TempScore > 0)                
                retString += String.Format("{0}|{1}|{2}", 5, TempScore, ByteArrayToString(hiscoreData.Name5, "NV")) + Environment.NewLine;
            TempScore = HiConvert.ByteArrayHexToInt(hiscoreData.Score6);
            if (TempScore > 0)
                retString += String.Format("{0}|{1}|{2}", 6, TempScore, ByteArrayToString(hiscoreData.Name6,"HI")) + Environment.NewLine;
            TempScore = HiConvert.ByteArrayHexToInt(hiscoreData.Score7);
            if (TempScore > 0)
                retString += String.Format("{0}|{1}|{2}", 7, TempScore, ByteArrayToString(hiscoreData.Name7, "HI")) + Environment.NewLine;
            TempScore = HiConvert.ByteArrayHexToInt(hiscoreData.Score8);
            if (TempScore > 0)
                retString += String.Format("{0}|{1}|{2}", 8, TempScore, ByteArrayToString(hiscoreData.Name8, "HI")) + Environment.NewLine;
            TempScore = HiConvert.ByteArrayHexToInt(hiscoreData.Score9);
            if (TempScore > 0)
                retString += String.Format("{0}|{1}|{2}", 9, TempScore, ByteArrayToString(hiscoreData.Name9, "HI")) + Environment.NewLine;
            TempScore = HiConvert.ByteArrayHexToInt(hiscoreData.Score10);
            if (TempScore > 0)
                retString += String.Format("{0}|{1}|{2}", 10, TempScore, ByteArrayToString(hiscoreData.Name10, "HI")) + Environment.NewLine;
        
            return retString;
        }

        public override void SaveData()
        {
            byte[] nvRam = new byte[1024];
            byte[] hiFile = new byte[31];
            for (int i = 0; i < m_data.Length; i++)
            {
                if (i < nvRam.Length)
                    nvRam[i] = m_data[i];
                else
                    hiFile[i - nvRam.Length] = m_data[i];
            }
            File.WriteAllBytes(m_fileNames[0], nvRam);
            File.WriteAllBytes(m_fileNames[1], hiFile);
        }
    }
}