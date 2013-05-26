using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class shadoww : Hiscore
    {
        public byte[] refConversion = new byte[] { 0x2e, 0x34 };

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FirstScoreRef;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] FirstSpareRef;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreP1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreP2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreA;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameA;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreB;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameB;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameC;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreD;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameD;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreE;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameE;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreF;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameF;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreG;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameG;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreH;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameH;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefI;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankI;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreI;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameI;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefJ;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankJ;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreJ;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameJ;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefK;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankK;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreK;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameK;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] NextRefL;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] RankL;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreL;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] NameL;
        }

        public shadoww()
        {
            m_numEntries = 10;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "shadoww,shadowwa,gaiden,ryukendn,ryukenda";
            m_extensionsRequired = ".hi";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0x5b)
                    sb.Append(' ');
                else if (data[i] == 0x5c)
                    sb.Append('.');
                else
                    sb.Append((char)(int)data[i]);
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    data[i] = 0x5b;
                else if (str[i] == '.')
                    data[i] = 0x5c;
                else
                    data[i] = (byte)((int)str[i]);
            }

            return data;
        }

        public byte[] GetScoreFromRef(byte[] reference)
        {
            int refPointer = HiConvert.ByteArrayHexAsHexToInt(reference) - HiConvert.ByteArrayHexAsHexToInt(refConversion);

            return new byte[] { 
                m_data[refPointer + 4], 
                m_data[refPointer + 5], 
                m_data[refPointer + 6],
                m_data[refPointer + 7], 
                m_data[refPointer + 8], 
                m_data[refPointer + 9] };
        }

        public byte[] GetNameFromRef(byte[] reference)
        {
            int refPointer = HiConvert.ByteArrayHexAsHexToInt(reference) - HiConvert.ByteArrayHexAsHexToInt(refConversion);

            return new byte[] { 
                m_data[refPointer + 10], 
                m_data[refPointer + 11], 
                m_data[refPointer + 12],
                m_data[refPointer + 13], 
                m_data[refPointer + 14], 
                m_data[refPointer + 15] };
        }

        public byte[] GetRankFromRef(byte[] reference)
        {
            int refPointer = HiConvert.ByteArrayHexAsHexToInt(reference) - HiConvert.ByteArrayHexAsHexToInt(refConversion);

            return new byte[] { 
                m_data[refPointer + 2], 
                m_data[refPointer + 3] };
        }

        public byte[] GetNextRefFromRef(byte[] reference)
        {
            int refPointer = HiConvert.ByteArrayHexAsHexToInt(reference) - HiConvert.ByteArrayHexAsHexToInt(refConversion);

            return new byte[] { 
                m_data[refPointer], 
                m_data[refPointer + 1] };
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2];

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region FOLLOW POINTERS
            List<MemorySlot> memorySlots = new List<MemorySlot>();
            byte[] currentRef = new byte[hiscoreData.FirstScoreRef.Length];
            HiConvert.ByteArrayCopy(currentRef, hiscoreData.FirstScoreRef);

            for (int i = 0; i < NumEntries; i++)
            {
                byte[] nextRef = GetNextRefFromRef(currentRef);
                memorySlots.Add(new MemorySlot(
                    currentRef,
                    nextRef,
                    GetRankFromRef(currentRef),
                    GetScoreFromRef(currentRef),
                    GetNameFromRef(currentRef)));
                HiConvert.ByteArrayCopy(currentRef, nextRef);
            }
            #endregion

            #region DETERMINE RANK
            int rank = NumEntries;
            for (int i = 0; i < NumEntries; i++)
            {
                if (score > HiConvert.ByteArraySingleBCDToInt(memorySlots[i].Score))
                {
                    rank = i;
                    break;
                }
            }
            #endregion

            #region REPLACE_NEW
            if (rank < NumEntries)
            {
                MemorySlot newMem = new MemorySlot(
                    hiscoreData.FirstSpareRef, 
                    new byte[] { 0x00, 0x00 },
                    memorySlots[rank].Rank, 
                    HiConvert.IntToByteArraySingleBCD(score, hiscoreData.ScoreA.Length),
                    StringToByteArray(name));

                if (rank != NumEntries - 1)
                    HiConvert.ByteArrayCopy(newMem.NextRef, memorySlots[rank].CurrentRef);

                memorySlots.Insert(rank, newMem);

                //Set the next rank for the memory slot before this one.
                if (rank != 0)
                    HiConvert.ByteArrayCopy(memorySlots[rank - 1].NextRef, hiscoreData.FirstSpareRef);
                else
                    HiConvert.ByteArrayCopy(hiscoreData.FirstScoreRef, hiscoreData.FirstSpareRef);

                //The new first spare reference is now the 11th score, or the next reference from the 10th score.
                HiConvert.ByteArrayCopy(hiscoreData.FirstSpareRef, memorySlots[NumEntries - 1].NextRef);

                //Set the new spare's rank to 0x00, 0x10.
                memorySlots[NumEntries].Rank = new byte[] { 0x00, 0x10 };

                //Make the last score's next reference 0x0000.
                memorySlots[NumEntries - 1].NextRef = new byte[] { 0x00, 0x00 };

                #region WRITE FROM MEMORY SLOTS
                foreach (MemorySlot mem in memorySlots)
                {
                    int refPointer =
                        HiConvert.ByteArrayHexAsHexToInt(mem.CurrentRef) - HiConvert.ByteArrayHexAsHexToInt(refConversion);

                    switch (refPointer)
                    {
                        //16 - 192 every 16.
                        case 16:
                            HiConvert.ByteArrayCopy(hiscoreData.NameA, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreA, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankA, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefA, mem.NextRef);
                            break;
                        case 32:
                            HiConvert.ByteArrayCopy(hiscoreData.NameB, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreB, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankB, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefB, mem.NextRef);
                            break;
                        case 48:
                            HiConvert.ByteArrayCopy(hiscoreData.NameC, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreC, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankC, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefC, mem.NextRef);
                            break;
                        case 64:
                            HiConvert.ByteArrayCopy(hiscoreData.NameD, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreD, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankD, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefD, mem.NextRef);
                            break;
                        case 80:
                            HiConvert.ByteArrayCopy(hiscoreData.NameE, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreE, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankE, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefE, mem.NextRef);
                            break;
                        case 96:
                            HiConvert.ByteArrayCopy(hiscoreData.NameF, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreF, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankF, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefF, mem.NextRef);
                            break;
                        case 112:
                            HiConvert.ByteArrayCopy(hiscoreData.NameG, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreG, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankG, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefG, mem.NextRef);
                            break;
                        case 128:
                            HiConvert.ByteArrayCopy(hiscoreData.NameH, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreH, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankH, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefH, mem.NextRef);
                            break;
                        case 144:
                            HiConvert.ByteArrayCopy(hiscoreData.NameI, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreI, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankI, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefI, mem.NextRef);
                            break;
                        case 160:
                            HiConvert.ByteArrayCopy(hiscoreData.NameJ, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankJ, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefJ, mem.NextRef);
                            break;
                        case 176:
                            HiConvert.ByteArrayCopy(hiscoreData.NameK, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreK, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankK, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefK, mem.NextRef);
                            break;
                        case 192:
                            HiConvert.ByteArrayCopy(hiscoreData.NameL, mem.Name);
                            HiConvert.ByteArrayCopy(hiscoreData.ScoreL, mem.Score);
                            HiConvert.ByteArrayCopy(hiscoreData.RankL, mem.Rank);
                            HiConvert.ByteArrayCopy(hiscoreData.NextRefL, mem.NextRef);
                            break;
                    }
                }
                #endregion
            }
            #endregion

            //Write the new byte array, fix the ranks after, and then rewrite again.
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region RANK RE-ADJUST
            currentRef = new byte[hiscoreData.FirstScoreRef.Length];
            HiConvert.ByteArrayCopy(currentRef, hiscoreData.FirstScoreRef);

            for (int i = 0; i < NumEntries; i++)
            {
                byte[] nextRef = GetNextRefFromRef(currentRef);
                switch (HiConvert.ByteArrayHexAsHexToInt(currentRef) - HiConvert.ByteArrayHexAsHexToInt(refConversion))
                {
                    case 16:
                        HiConvert.ByteArrayCopy(hiscoreData.RankA, new byte[] { 0xd0, (byte)i });
                        break;
                    case 32:
                        HiConvert.ByteArrayCopy(hiscoreData.RankB, new byte[] { 0xd0, (byte)i });
                        break;
                    case 48:
                        HiConvert.ByteArrayCopy(hiscoreData.RankC, new byte[] { 0xd0, (byte)i });
                        break;
                    case 64:
                        HiConvert.ByteArrayCopy(hiscoreData.RankD, new byte[] { 0xd0, (byte)i });
                        break;
                    case 80:
                        HiConvert.ByteArrayCopy(hiscoreData.RankE, new byte[] { 0xd0, (byte)i });
                        break;
                    case 96:
                        HiConvert.ByteArrayCopy(hiscoreData.RankF, new byte[] { 0xd0, (byte)i });
                        break;
                    case 112:
                        HiConvert.ByteArrayCopy(hiscoreData.RankG, new byte[] { 0xd0, (byte)i });
                        break;
                    case 128:
                        HiConvert.ByteArrayCopy(hiscoreData.RankH, new byte[] { 0xd0, (byte)i });
                        break;
                    case 144:
                        HiConvert.ByteArrayCopy(hiscoreData.RankI, new byte[] { 0xd0, (byte)i });
                        break;
                    case 160:
                        HiConvert.ByteArrayCopy(hiscoreData.RankJ, new byte[] { 0xd0, (byte)i });
                        break;
                    case 176:
                        HiConvert.ByteArrayCopy(hiscoreData.RankK, new byte[] { 0xd0, (byte)i });
                        break;
                    case 192:
                        HiConvert.ByteArrayCopy(hiscoreData.RankL, new byte[] { 0xd0, (byte)i });
                        break;
                }
                HiConvert.ByteArrayCopy(currentRef, nextRef);
            }

            byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
            #endregion
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreA, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreA.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreB, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreB.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreC, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreC.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreD, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreD.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreE, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreE.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreF, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreF.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreG, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreG.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreH, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreH.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreI, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreI.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreJ, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreJ.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreK, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreK.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreL, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreL.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            byte[] currentRef = new byte[hiscoreData.FirstScoreRef.Length];
            HiConvert.ByteArrayCopy(currentRef, hiscoreData.FirstScoreRef);

            for (int i = 0; i < NumEntries; i++)
            {
                byte[] nextRef = GetNextRefFromRef(currentRef);
                
                retString += String.Format(
                            "{0}|{1}|{2}",
                            i + 1,
                            HiConvert.ByteArraySingleBCDToInt(GetScoreFromRef(currentRef)),
                            ByteArrayToString(GetNameFromRef(currentRef))) + Environment.NewLine;

                HiConvert.ByteArrayCopy(currentRef, nextRef);
            }

            return retString;
        }
    }

    public class MemorySlot
    {
        private byte[] refConversion = new byte[] { 0x2e, 0x34 };

        private byte[] _currentRef = new byte[2];
        private byte[] _nextRef = new byte[2];
        private byte[] _rank = new byte[2];
        private byte[] _score = new byte[6];
        private byte[] _name = new byte[6];

        public MemorySlot(byte[] currentRef, byte[] nextRef, byte[] rank, byte[] score, byte[] name)
        {
            HiConvert.ByteArrayCopy(_currentRef, currentRef);
            HiConvert.ByteArrayCopy(_nextRef, nextRef);
            HiConvert.ByteArrayCopy(_rank, rank);
            HiConvert.ByteArrayCopy(_score, score);
            HiConvert.ByteArrayCopy(_name, name);
        }

        public byte[] CurrentRef
        {
            get
            {
                return _currentRef;
            }
            set
            {
                HiConvert.ByteArrayCopy(_currentRef, value);
            }
        }

        public byte[] NextRef
        {
            get
            {
                return _nextRef;
            }
            set
            {
                HiConvert.ByteArrayCopy(_nextRef, value);
            }
        }

        public byte[] Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                HiConvert.ByteArrayCopy(_rank, value);
            }
        }

        public byte[] Score
        {
            get
            {
                return _score;
            }
            set
            {
                HiConvert.ByteArrayCopy(_score, value);
            }
        }

        public byte[] Name
        {
            get
            {
                return _name;
            }
            set
            {
                HiConvert.ByteArrayCopy(_name, value);
            }
        }

        public int CurrentRefAsInt
        {
            get
            {
                return HiConvert.ByteArrayHexAsHexToInt(CurrentRef) - 
                    HiConvert.ByteArrayHexAsHexToInt(refConversion);
            }
        }

        public int NextRefAsInt
        {
            get
            {
                return HiConvert.ByteArrayHexAsHexToInt(NextRef) -
                    HiConvert.ByteArrayHexAsHexToInt(refConversion);
            }
        }

        public int RankAsInt
        {
            get
            {
                return (int)Rank[1];
            }
        }

        public int ScoreAsInt
        {
            get
            {
                return HiConvert.ByteArraySingleBCDToInt(Score);
            }
        }
    }
}

