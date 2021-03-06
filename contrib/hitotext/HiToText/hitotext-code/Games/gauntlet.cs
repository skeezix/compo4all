using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class gauntlet : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] LastLevelPlayed;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWarrior1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWarrior1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWarrior2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWarrior2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWarrior3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWarrior3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWarrior4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWarrior4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWarrior5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWarrior5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWarrior6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWarrior6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWarrior7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWarrior7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWarrior8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWarrior8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWarrior9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWarrior9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWarrior10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWarrior10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreValkyrie1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameValkyrie1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreValkyrie2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameValkyrie2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreValkyrie3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameValkyrie3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreValkyrie4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameValkyrie4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreValkyrie5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameValkyrie5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreValkyrie6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameValkyrie6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreValkyrie7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameValkyrie7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreValkyrie8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameValkyrie8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreValkyrie9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameValkyrie9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreValkyrie10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameValkyrie10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWizard1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWizard1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWizard2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWizard2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWizard3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWizard3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWizard4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWizard4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWizard5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWizard5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWizard6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWizard6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWizard7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWizard7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWizard8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWizard8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWizard9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWizard9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreWizard10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameWizard10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreElf1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameElf1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreElf2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameElf2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreElf3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameElf3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreElf4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameElf4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreElf5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameElf5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreElf6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameElf6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreElf7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameElf7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreElf8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameElf8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreElf9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameElf9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreElf10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NameElf10;
        }

        public gauntlet()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME|CHARACTER";
            m_gamesSupported = "gauntlet,gauntir1,gauntir2,gaunt2p,gaunt2";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("X2"));

            String name = sb.ToString();
            String toReturn = "";

            int val = System.Convert.ToInt32(name, 16);
            int everyFirst = 1600;
            int everySecond = 40;

            toReturn = ((char)(System.Convert.ToInt32((val / everyFirst).ToString("X2"), 16) + 64)).ToString();
            int restOfLastTwo = val - ((val / everyFirst) * everyFirst);

            toReturn += ((char)(System.Convert.ToInt32((restOfLastTwo / everySecond).ToString("X2"), 16) + 64)).ToString();
            int last = restOfLastTwo - ((restOfLastTwo / everySecond) * everySecond);

            toReturn += ((char)(System.Convert.ToInt32(last.ToString("X2"), 16) + 64)).ToString();
            return toReturn.Replace('@', ' ');
        }

        public byte[] StringToByteArray(string str)
        {
            int val = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                    val += ((int)str[i] - (65 - 0x01)) * System.Convert.ToInt32(Math.Pow(40, str.Length - 1 - i));
            }

            return HiConvert.HexStringToByteArray(val.ToString("X").PadLeft(4, '0'));
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];
            string character = args[3];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            switch (character)
            {
                case "WARRIOR":
                    if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior1))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior2))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior3))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior4))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior5))
                        rank = 4;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior6))
                        rank = 5;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior7))
                        rank = 6;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior8))
                        rank = 7;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior9))
                        rank = 8;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior10))
                        rank = 9;
                    break;
                case "VALKYRIE":
                    if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie1))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie2))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie3))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie4))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie5))
                        rank = 4;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie6))
                        rank = 5;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie7))
                        rank = 6;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie8))
                        rank = 7;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie9))
                        rank = 8;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie10))
                        rank = 9;
                    break;
                case "WIZARD":
                    if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard1))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard2))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard3))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard4))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard5))
                        rank = 4;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard6))
                        rank = 5;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard7))
                        rank = 6;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard8))
                        rank = 7;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard9))
                        rank = 8;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard10))
                        rank = 9;
                    break;
                case "ELF":
                    if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf1))
                        rank = 0;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf2))
                        rank = 1;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf3))
                        rank = 2;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf4))
                        rank = 3;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf5))
                        rank = 4;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf6))
                        rank = 5;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf7))
                        rank = 6;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf8))
                        rank = 7;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf9))
                        rank = 8;
                    else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf10))
                        rank = 9;
                    break;
            }
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (character)
            {
                case "WARRIOR":
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior2, hiscoreData.ScoreWarrior1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior2, hiscoreData.NameWarrior1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior3, hiscoreData.ScoreWarrior2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior3, hiscoreData.NameWarrior2);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior4, hiscoreData.ScoreWarrior3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior4, hiscoreData.NameWarrior3);
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior5, hiscoreData.ScoreWarrior4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior5, hiscoreData.NameWarrior4);
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior6, hiscoreData.ScoreWarrior5);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior6, hiscoreData.NameWarrior5);
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior7, hiscoreData.ScoreWarrior6);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior7, hiscoreData.NameWarrior6);
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior8, hiscoreData.ScoreWarrior7);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior8, hiscoreData.NameWarrior7);
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior9, hiscoreData.ScoreWarrior8);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior9, hiscoreData.NameWarrior8);
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior10, hiscoreData.ScoreWarrior9);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior10, hiscoreData.NameWarrior9);
                            if (rank < 8)
                                goto case 7;
                            break;
                    }
                    break;
                case "VALKYRIE":
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie2, hiscoreData.ScoreValkyrie1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie2, hiscoreData.NameValkyrie1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie3, hiscoreData.ScoreValkyrie2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie3, hiscoreData.NameValkyrie2);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie4, hiscoreData.ScoreValkyrie3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie4, hiscoreData.NameValkyrie3);
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie5, hiscoreData.ScoreValkyrie4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie5, hiscoreData.NameValkyrie4);
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie6, hiscoreData.ScoreValkyrie5);
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie6, hiscoreData.NameValkyrie5);
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie7, hiscoreData.ScoreValkyrie6);
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie7, hiscoreData.NameValkyrie6);
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie8, hiscoreData.ScoreValkyrie7);
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie8, hiscoreData.NameValkyrie7);
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie9, hiscoreData.ScoreValkyrie8);
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie9, hiscoreData.NameValkyrie8);
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie10, hiscoreData.ScoreValkyrie9);
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie10, hiscoreData.NameValkyrie9);
                            if (rank < 8)
                                goto case 7;
                            break;
                    }
                    break;
                case "WIZARD":
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard2, hiscoreData.ScoreWizard1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard2, hiscoreData.NameWizard1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard3, hiscoreData.ScoreWizard2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard3, hiscoreData.NameWizard2);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard4, hiscoreData.ScoreWizard3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard4, hiscoreData.NameWizard3);
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard5, hiscoreData.ScoreWizard4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard5, hiscoreData.NameWizard4);
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard6, hiscoreData.ScoreWizard5);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard6, hiscoreData.NameWizard5);
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard7, hiscoreData.ScoreWizard6);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard7, hiscoreData.NameWizard6);
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard8, hiscoreData.ScoreWizard7);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard8, hiscoreData.NameWizard7);
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard9, hiscoreData.ScoreWizard8);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard9, hiscoreData.NameWizard8);
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard10, hiscoreData.ScoreWizard9);
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard10, hiscoreData.NameWizard9);
                            if (rank < 8)
                                goto case 7;
                            break;
                    }
                    break;
                case "ELF":
                    switch (adjust)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf2, hiscoreData.ScoreElf1);
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf2, hiscoreData.NameElf1);
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf3, hiscoreData.ScoreElf2);
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf3, hiscoreData.NameElf2);
                            if (rank < 1)
                                goto case 0;
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf4, hiscoreData.ScoreElf3);
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf4, hiscoreData.NameElf3);
                            if (rank < 2)
                                goto case 1;
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf5, hiscoreData.ScoreElf4);
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf5, hiscoreData.NameElf4);
                            if (rank < 3)
                                goto case 2;
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf6, hiscoreData.ScoreElf5);
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf6, hiscoreData.NameElf5);
                            if (rank < 4)
                                goto case 3;
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf7, hiscoreData.ScoreElf6);
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf7, hiscoreData.NameElf6);
                            if (rank < 5)
                                goto case 4;
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf8, hiscoreData.ScoreElf7);
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf8, hiscoreData.NameElf7);
                            if (rank < 6)
                                goto case 5;
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf9, hiscoreData.ScoreElf8);
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf9, hiscoreData.NameElf8);
                            if (rank < 7)
                                goto case 6;
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf10, hiscoreData.ScoreElf9);
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf10, hiscoreData.NameElf9);
                            if (rank < 8)
                                goto case 7;
                            break;
                    }
                    break;
            }            
            #endregion

            #region REPLACE_NEW
            switch (character)
            {
                case "WARRIOR":
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior1, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWarrior1.Length));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior2, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWarrior2.Length));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior3, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWarrior3.Length));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior4, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWarrior4.Length));
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior5, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWarrior5.Length));
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior6, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior6, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWarrior6.Length));
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior7, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior7, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWarrior7.Length));
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior8, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior8, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWarrior8.Length));
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior9, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior9, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWarrior9.Length));
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWarrior10, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior10, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWarrior10.Length));
                            break;
                    }
                    break;
                case "VALKYRIE":
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie1, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreValkyrie1.Length));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie2, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreValkyrie2.Length));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie3, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreValkyrie3.Length));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie4, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreValkyrie4.Length));
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie5, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreValkyrie5.Length));
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie6, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie6, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreValkyrie6.Length));
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie7, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie7, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreValkyrie7.Length));
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie8, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie8, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreValkyrie8.Length));
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie9, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie9, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreValkyrie9.Length));
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.NameValkyrie10, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie10, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreValkyrie10.Length));
                            break;
                    }
                    break;
                case "WIZARD":
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard1, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWizard1.Length));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard2, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWizard2.Length));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard3, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWizard3.Length));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard4, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWizard4.Length));
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard5, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWizard5.Length));
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard6, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard6, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWizard6.Length));
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard7, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard7, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWizard7.Length));
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard8, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard8, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWizard8.Length));
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard9, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard9, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWizard9.Length));
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.NameWizard10, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard10, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreWizard10.Length));
                            break;
                    }
                    break;
                case "ELF":
                    switch (rank)
                    {
                        case 0:
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf1, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf1, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreElf1.Length));
                            break;
                        case 1:
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf2, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf2, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreElf2.Length));
                            break;
                        case 2:
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf3, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf3, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreElf3.Length));
                            break;
                        case 3:
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf4, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf4, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreElf4.Length));
                            break;
                        case 4:
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf5, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf5, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreElf5.Length));
                            break;
                        case 5:
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf6, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf6, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreElf6.Length));
                            break;
                        case 6:
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf7, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf7, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreElf7.Length));
                            break;
                        case 7:
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf8, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf8, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreElf8.Length));
                            break;
                        case 8:
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf9, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf9, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreElf9.Length));
                            break;
                        case 9:
                            HiConvert.ByteArrayCopy(hiscoreData.NameElf10, StringToByteArray(name));
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf10, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.ScoreElf10.Length));
                            break;
                    }
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWarrior1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWarrior2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWarrior3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWarrior4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWarrior5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWarrior6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior7, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWarrior7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior8, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWarrior8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior9, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWarrior9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWarrior10, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWarrior10.Length));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreValkyrie1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreValkyrie2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreValkyrie3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreValkyrie4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreValkyrie5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreValkyrie6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie7, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreValkyrie7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie8, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreValkyrie8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie9, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreValkyrie9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreValkyrie10, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreValkyrie10.Length));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWizard1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWizard2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWizard3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWizard4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWizard5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWizard6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard7, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWizard7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard8, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWizard8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard9, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWizard9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreWizard10, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreWizard10.Length));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreElf1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreElf2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf3, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreElf3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf4, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreElf4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf5, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreElf5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf6, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreElf6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf7, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreElf7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf8, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreElf8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf9, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreElf9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreElf10, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreElf10.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior1), ByteArrayToString(hiscoreData.NameWarrior1), "WARRIOR") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior2), ByteArrayToString(hiscoreData.NameWarrior2), "WARRIOR") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior3), ByteArrayToString(hiscoreData.NameWarrior3), "WARRIOR") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior4), ByteArrayToString(hiscoreData.NameWarrior4), "WARRIOR") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior5), ByteArrayToString(hiscoreData.NameWarrior5), "WARRIOR") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 6, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior6), ByteArrayToString(hiscoreData.NameWarrior6), "WARRIOR") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 7, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior7), ByteArrayToString(hiscoreData.NameWarrior7), "WARRIOR") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 8, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior8), ByteArrayToString(hiscoreData.NameWarrior8), "WARRIOR") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 9, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior9), ByteArrayToString(hiscoreData.NameWarrior9), "WARRIOR") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 10, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWarrior10), ByteArrayToString(hiscoreData.NameWarrior10), "WARRIOR") + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie1), ByteArrayToString(hiscoreData.NameValkyrie1), "VALKYRIE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie2), ByteArrayToString(hiscoreData.NameValkyrie2), "VALKYRIE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie3), ByteArrayToString(hiscoreData.NameValkyrie3), "VALKYRIE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie4), ByteArrayToString(hiscoreData.NameValkyrie4), "VALKYRIE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie5), ByteArrayToString(hiscoreData.NameValkyrie5), "VALKYRIE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 6, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie6), ByteArrayToString(hiscoreData.NameValkyrie6), "VALKYRIE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 7, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie7), ByteArrayToString(hiscoreData.NameValkyrie7), "VALKYRIE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 8, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie8), ByteArrayToString(hiscoreData.NameValkyrie8), "VALKYRIE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 9, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie9), ByteArrayToString(hiscoreData.NameValkyrie9), "VALKYRIE") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 10, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreValkyrie10), ByteArrayToString(hiscoreData.NameValkyrie10), "VALKYRIE") + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard1), ByteArrayToString(hiscoreData.NameWizard1), "WIZARD") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard2), ByteArrayToString(hiscoreData.NameWizard2), "WIZARD") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard3), ByteArrayToString(hiscoreData.NameWizard3), "WIZARD") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard4), ByteArrayToString(hiscoreData.NameWizard4), "WIZARD") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard5), ByteArrayToString(hiscoreData.NameWizard5), "WIZARD") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 6, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard6), ByteArrayToString(hiscoreData.NameWizard6), "WIZARD") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 7, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard7), ByteArrayToString(hiscoreData.NameWizard7), "WIZARD") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 8, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard8), ByteArrayToString(hiscoreData.NameWizard8), "WIZARD") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 9, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard9), ByteArrayToString(hiscoreData.NameWizard9), "WIZARD") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 10, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreWizard10), ByteArrayToString(hiscoreData.NameWizard10), "WIZARD") + Environment.NewLine;

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf1), ByteArrayToString(hiscoreData.NameElf1), "ELF") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf2), ByteArrayToString(hiscoreData.NameElf2), "ELF") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf3), ByteArrayToString(hiscoreData.NameElf3), "ELF") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf4), ByteArrayToString(hiscoreData.NameElf4), "ELF") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf5), ByteArrayToString(hiscoreData.NameElf5), "ELF") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 6, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf6), ByteArrayToString(hiscoreData.NameElf6), "ELF") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 7, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf7), ByteArrayToString(hiscoreData.NameElf7), "ELF") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 8, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf8), ByteArrayToString(hiscoreData.NameElf8), "ELF") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 9, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf9), ByteArrayToString(hiscoreData.NameElf9), "ELF") + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 10, HiConvert.ByteArrayHexAsHexToInt(hiscoreData.ScoreElf10), ByteArrayToString(hiscoreData.NameElf10), "ELF") + Environment.NewLine;

            return retString;
        }

        public override String[] OptimizeScoresForGame(String[] webScores)
        {
            List<String[]> Warrior = new List<String[]>();
            List<String[]> Valkyrie = new List<String[]>();
            List<String[]> Wizard = new List<String[]>();
            List<String[]> Elf = new List<String[]>();

            for (int i = 0; i < webScores.Length; i++)
            {
                String[] webScore = webScores[i].Split(new char[] { '|' });
                switch (webScore[3].ToUpper())
                {
                    case "WARRIOR":
                        Warrior.Add(webScore);
                        break;
                    case "VALKYRIE":
                        Valkyrie.Add(webScore);
                        break;
                    case "WIZARD":
                        Wizard.Add(webScore);
                        break;
                    case "ELF":
                        Elf.Add(webScore);
                        break;
                }
            }

            Warrior.Sort(new GauntletComparator());
            Valkyrie.Sort(new GauntletComparator());
            Wizard.Sort(new GauntletComparator());
            Elf.Sort(new GauntletComparator());

            String[] toReturn = new String[NumEntries];

            for (int i = 0; i < NumEntries; i++)
            {
                switch (i / 10)
                {
                    case 0:
                        toReturn[i] = String.Join("|", Warrior[i % 10]);
                        break;
                    case 1:
                        toReturn[i] = String.Join("|", Valkyrie[i % 10]);
                        break;
                    case 2:
                        toReturn[i] = String.Join("|", Wizard[i % 10]);
                        break;
                    case 3:
                        toReturn[i] = String.Join("|", Elf[i % 10]);
                        break;
                }
            }
            return toReturn;
        }
    }

    class GauntletComparator : IComparer<String[]>
    {

        #region IComparer<string[]> Members

        int IComparer<string[]>.Compare(string[] x, string[] y)
        {
            return Convert.ToInt32(y[1]).CompareTo(Convert.ToInt32(x[1]));
        }

        #endregion
    }
}