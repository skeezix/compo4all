using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class mpatrol : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore;
            public byte HiStage;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallengeZ;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallenge2T;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallenge2O;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallenge2J;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallenge2E;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallenge2Z;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallenge3T;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallenge3O;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallenge3J;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallenge3E;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallenge3Z;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallengeT;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallengeO;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallengeJ;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeChallengeE;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeBeginnerZ;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeBeginnerT;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeBeginnerO;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeBeginnerJ;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] BestTimeBeginnerE;
        }

        public mpatrol()
        {
            m_numEntries = 1;
            m_format = "SCORE|STAGE";
            m_altFormat = new string[20];
            m_altFormat[0] = "BEGINNER - E FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[1] = "BEGINNER - J FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[2] = "BEGINNER - O FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[3] = "BEGINNER - T FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[4] = "BEGINNER - Z FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[5] = "CHALLENGE - E FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[6] = "CHALLENGE - J FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[7] = "CHALLENGE - O FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[8] = "CHALLENGE - T FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[9] = "CHALLENGE - Z FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[10] = "CHALLENGE 2 - E FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[11] = "CHALLENGE 2 - J FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[12] = "CHALLENGE 2 - O FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[13] = "CHALLENGE 2 - T FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[14] = "CHALLENGE 2 - Z FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[15] = "CHALLENGE 3 - E FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[16] = "CHALLENGE 3 - J FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[17] = "CHALLENGE 3 - O FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[18] = "CHALLENGE 3 - T FASTEST TIME" + Environment.NewLine + "TIME";
            m_altFormat[19] = "CHALLENGE 3 - Z FASTEST TIME" + Environment.NewLine + "TIME";
            m_numAltEntries = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            m_gamesSupported = "mpatrol,mpatrolw,mranger";
            m_extensionsRequired = ".hi";
        }

        private int GetAlternateName(string name)
        {
            switch (name)
            {
                case "BEGINNER - E FASTEST TIME":
                    return 0;
                case "BEGINNER - J FASTEST TIME":
                    return 1;
                case "BEGINNER - O FASTEST TIME":
                    return 2;
                case "BEGINNER - T FASTEST TIME":
                    return 3;
                case "BEGINNER - Z FASTEST TIME":
                    return 4;
                case "CHALLENGE - E FASTEST TIME":
                    return 5;
                case "CHALLENGE - J FASTEST TIME":
                    return 6;
                case "CHALLENGE - O FASTEST TIME":
                    return 7;
                case "CHALLENGE - T FASTEST TIME":
                    return 8;
                case "CHALLENGE - Z FASTEST TIME":
                    return 9;
                case "CHALLENGE 2 - E FASTEST TIME":
                    return 10;
                case "CHALLENGE 2 - J FASTEST TIME":
                    return 11;
                case "CHALLENGE 2 - O FASTEST TIME":
                    return 12;
                case "CHALLENGE 2 - T FASTEST TIME":
                    return 13;
                case "CHALLENGE 2 - Z FASTEST TIME":
                    return 14;
                case "CHALLENGE 3 - E FASTEST TIME":
                    return 15;
                case "CHALLENGE 3 - J FASTEST TIME":
                    return 16;
                case "CHALLENGE 3 - O FASTEST TIME":
                    return 17;
                case "CHALLENGE 3 - T FASTEST TIME":
                    return 18;
                case "CHALLENGE 3 - Z FASTEST TIME":
                    return 19;
            }

            return -1;
        }

        private byte GetStageAsByte(string stage)
        {
            int stageValue = 0;
            int dash = stage.IndexOf(" - ");
            if (stage.Substring(0, dash).Equals("CHALLENGE"))
                stageValue = 26;
            stageValue += (int)Convert.ToChar(stage.Substring(dash + " - ".Length)) - 65 + 1;

            return (byte)stageValue;
        }

        private string GetStageAsString(byte stage)
        {
            int stageAsInt = Convert.ToInt32(stage) - 1;
            String toReturn = "BEGINNER - ";
            if (stageAsInt > 26)
            {
                toReturn = "CHALLENGE - ";
                stageAsInt -= 26;
            }
            return toReturn + (char)(stageAsInt + 65);
        }

        private int GetTime(string time)
        {
            if (time.Equals("NOT SET YET"))
                return 0;
            return Convert.ToInt32(time.Substring(0, time.IndexOf(" sec")));
        }

        private string GetTime(int time)
        {
            if (time == 0)
                return "NOT SET YET";
            return time.ToString() + " sec";
        }

        public override void SetHiScore(string[] args)
        {
            int score = System.Convert.ToInt32(args[0]);
            String stage = args[1];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.HiScore.Length)));
            hiscoreData.HiStage = GetStageAsByte(stage);

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void SetAlternateScore(string[] args)
        {
            int alternateName = GetAlternateName(args[0]);
            int time = GetTime(args[1]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            switch (alternateName)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeBeginnerE, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeBeginnerE.Length)));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeBeginnerJ, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeBeginnerJ.Length)));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeBeginnerO, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeBeginnerO.Length)));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeBeginnerT, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeBeginnerT.Length)));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeBeginnerZ, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeBeginnerZ.Length)));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallengeE, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallengeE.Length)));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallengeJ, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallengeJ.Length)));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallengeO, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallengeO.Length)));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallengeT, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallengeT.Length)));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallengeZ, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallengeZ.Length)));
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge2E, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallenge2E.Length)));
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge2J, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallenge2J.Length)));
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge2O, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallenge2O.Length)));
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge2T, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallenge2T.Length)));
                    break;
                case 14:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge2Z, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallenge2Z.Length)));
                    break;
                case 15:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge3E, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallenge3E.Length)));
                    break;
                case 16:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge3J, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallenge3J.Length)));
                    break;
                case 17:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge3O, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallenge3O.Length)));
                    break;
                case 18:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge3T, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallenge3T.Length)));
                    break;
                case 19:
                    HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge3Z, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(time, hiscoreData.BestTimeChallenge3Z.Length)));
                    break;
            }

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScore, HiConvert.IntToByteArrayHex(0, hiscoreData.HiScore.Length));
            hiscoreData.HiStage = 0x00;

            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge3Z, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallenge3Z.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge3T, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallenge3T.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge3O, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallenge3O.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge3J, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallenge3J.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge3E, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallenge3E.Length));

            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge2Z, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallenge2Z.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge2T, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallenge2T.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge2O, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallenge2O.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge2J, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallenge2J.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallenge2E, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallenge2E.Length));

            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallengeZ, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallengeZ.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallengeT, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallengeT.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallengeO, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallengeO.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallengeJ, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallengeJ.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeChallengeE, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeChallengeE.Length));

            HiConvert.ByteArrayCopy(hiscoreData.BestTimeBeginnerZ, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeBeginnerZ.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeBeginnerT, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeBeginnerT.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeBeginnerO, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeBeginnerO.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeBeginnerJ, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeBeginnerJ.Length));
            HiConvert.ByteArrayCopy(hiscoreData.BestTimeBeginnerE, HiConvert.IntToByteArrayHex(0, hiscoreData.BestTimeBeginnerE.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}", HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.HiScore)), GetStageAsString(hiscoreData.HiStage)) + Environment.NewLine;
            
            retString += Environment.NewLine + Environment.NewLine + AltFormat[0] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeBeginnerE)))) + Environment.NewLine;
            retString += AltFormat[1] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeBeginnerJ)))) + Environment.NewLine;
            retString += AltFormat[2] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeBeginnerO)))) + Environment.NewLine;
            retString += AltFormat[3] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeBeginnerT)))) + Environment.NewLine;
            retString += AltFormat[4] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeBeginnerZ)))) + Environment.NewLine;
            retString += AltFormat[5] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallengeE)))) + Environment.NewLine;
            retString += AltFormat[6] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallengeJ)))) + Environment.NewLine;
            retString += AltFormat[7] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallengeO)))) + Environment.NewLine;
            retString += AltFormat[8] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallengeT)))) + Environment.NewLine;
            retString += AltFormat[9] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallengeZ)))) + Environment.NewLine;
            retString += AltFormat[10] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallenge2E)))) + Environment.NewLine;
            retString += AltFormat[11] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallenge2J)))) + Environment.NewLine;
            retString += AltFormat[12] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallenge2O)))) + Environment.NewLine;
            retString += AltFormat[13] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallenge2T)))) + Environment.NewLine;
            retString += AltFormat[14] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallenge2Z)))) + Environment.NewLine;
            retString += AltFormat[15] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallenge3E)))) + Environment.NewLine;
            retString += AltFormat[16] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallenge3J)))) + Environment.NewLine;
            retString += AltFormat[17] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallenge3O)))) + Environment.NewLine;
            retString += AltFormat[18] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallenge3T)))) + Environment.NewLine;
            retString += AltFormat[19] + Environment.NewLine;
            retString += String.Format("{0}", GetTime(HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.BestTimeChallenge3Z)))) + Environment.NewLine;

            return retString;
        }
    }
}

