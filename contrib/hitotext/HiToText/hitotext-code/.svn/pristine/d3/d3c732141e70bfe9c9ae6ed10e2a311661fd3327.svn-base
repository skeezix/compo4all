using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class nitd : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1222)]
            public byte[] UnusedFirst;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Separator1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Separator2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Separator3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Separator4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Separator5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Stage5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6910)]
            public byte[] UnusedSecond;
        }

        public nitd()
        {
            m_numEntries = 5;
            m_format = "RANK|SCORE|NAME|STAGE";
            m_gamesSupported = "nitd";
            m_extensionsRequired = ".nv";
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
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            int stageFirst = GetStage(args[3], true);
            int stageSecond = GetStage(args[3], false);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = 5;
            if (score > HiConvert.ByteArrayHexToInt(HiConvert.ByteSwapArray(hiscoreData.Score1)))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ByteSwapArray(hiscoreData.Score2)))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ByteSwapArray(hiscoreData.Score3)))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ByteSwapArray(hiscoreData.Score4)))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexToInt(HiConvert.ByteSwapArray(hiscoreData.Score5)))
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
                    HiConvert.ByteArrayCopy(hiscoreData.Stage2, hiscoreData.Stage1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage3, hiscoreData.Stage2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage4, hiscoreData.Stage3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Stage5, hiscoreData.Stage4);
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
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, HiConvert.ByteSwapArray(StringToByteArray(name)));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ByteSwapArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score1.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage1, new byte[] {(byte)stageSecond, (byte)stageFirst});
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, HiConvert.ByteSwapArray(StringToByteArray(name)));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ByteSwapArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score2.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage2, new byte[] { (byte)stageSecond, (byte)stageFirst });
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, HiConvert.ByteSwapArray(StringToByteArray(name)));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ByteSwapArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score3.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage3, new byte[] { (byte)stageSecond, (byte)stageFirst }); 
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, HiConvert.ByteSwapArray(StringToByteArray(name)));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ByteSwapArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score4.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage4, new byte[] { (byte)stageSecond, (byte)stageFirst });
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, HiConvert.ByteSwapArray(StringToByteArray(name)));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ByteSwapArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score5.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Stage5, new byte[] { (byte)stageSecond, (byte)stageFirst });
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        private int GetStage(string p, bool isFirst)
        {
            if (isFirst)
                return Convert.ToInt32(p.Substring(0, 1)) - 1;
            else
                return Convert.ToInt32(p.Substring(p.IndexOf("-") + 1)) - 1;
        }

        private String GetStage(byte[] p)
        {
            int first = Convert.ToInt32(HiConvert.ByteArrayToHexString(new byte[] { p[0] })) + 1;
            int second = Convert.ToInt32(HiConvert.ByteArrayToHexString(new byte[] { p[1] })) + 1;
            return first.ToString() + "-" + second.ToString();
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

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexToInt(HiConvert.ByteSwapArray(hiscoreData.Score1)), ByteArrayToString(HiConvert.ByteSwapArray(hiscoreData.Name1)), GetStage(HiConvert.ByteSwapArray(hiscoreData.Stage1))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexToInt(HiConvert.ByteSwapArray(hiscoreData.Score2)), ByteArrayToString(HiConvert.ByteSwapArray(hiscoreData.Name2)), GetStage(HiConvert.ByteSwapArray(hiscoreData.Stage2))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexToInt(HiConvert.ByteSwapArray(hiscoreData.Score3)), ByteArrayToString(HiConvert.ByteSwapArray(hiscoreData.Name3)), GetStage(HiConvert.ByteSwapArray(hiscoreData.Stage3))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexToInt(HiConvert.ByteSwapArray(hiscoreData.Score4)), ByteArrayToString(HiConvert.ByteSwapArray(hiscoreData.Name4)), GetStage(HiConvert.ByteSwapArray(hiscoreData.Stage4))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexToInt(HiConvert.ByteSwapArray(hiscoreData.Score5)), ByteArrayToString(HiConvert.ByteSwapArray(hiscoreData.Name5)), GetStage(HiConvert.ByteSwapArray(hiscoreData.Stage5))) + Environment.NewLine;
            
            return retString;
        }
    }
}