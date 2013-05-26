using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class klax : Hiscore
    // There is a bug in the 8th score in Hi-Score table in the arcade game. The score is 15000, but
    // but it should be 16000 points. It was not fixed in next versions of klax, so all sets
    // have this bug.
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Score10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Name10;            
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct AlternateData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentScore1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] PercentName1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentScore2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] PercentName2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentScore3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] PercentName3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentScore4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] PercentName4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentScore5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] PercentName5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentScore6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] PercentName6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentScore7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] PercentName7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentScore8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] PercentName8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentScore9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] PercentName9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] PercentScore10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] PercentName10;
        }

        public klax()
        {
            m_numEntries = 10;
            m_format = "RANK|NAME|SCORE";
            m_altFormat = new string[1];
            m_altFormat[0] = "BEST PER CREDIT AVERAGE" + Environment.NewLine + "RANK|NAME|SCORE";
            m_numAltEntries = new int[] { 10 };
            m_gamesSupported = "klax,klaxd,klaxj,klaxp1,klaxp2,klax2,klax3";
            m_extensionsRequired = ".nv";
        }
        // There is more than 5 checksums to verify that the data of two scores with their names
        // are not corrupted (hacked). The routine starts at 0x4536 (or 0x451e). The begining is
        // at 0x44a2). The nvram data is stored in 0x0e0001, and the decrypted data in 0x3f3e74.
        // The 'offset' data necessary to avoid the checksum data in the nvram file are stored in
        // 0x437c.
        public byte[] DecryptArray(byte[] data, string typeofdata)
        {
            byte[] temp = new byte[50];
            int offset_block;
            if (typeofdata =="Main Data") offset_block = 120;
            else offset_block = 270;
            byte[] position = { 6, 10, 12, 14, 18, 20, 22, 24, 26, 28 };            
            int count = 0;
            int block = 0;
            do
            {
            for (int i = 0; i < 10; i++)
               {
                temp[count] = data[offset_block + position[i]];
                count++;                
               }              
                block++;
                offset_block = offset_block + 30;
            } while (block < 5);
           return temp;
        }

        public static void EncryptArray(byte[] maindata, byte[] data, string typeofdata)
        {
            int offset_block;
            if (typeofdata == "Main Data") offset_block = 120;
            else offset_block = 270;
            byte[] position = { 6, 10, 12, 14, 18, 20, 22, 24, 26, 28 };            
            int count = 0;
            int block = 0;
            do
            {
                byte D2 = 0, D3 = 0, D4 = 0, D5 = 0, D6 = 0;
                for (int i = 0; i < 10; i++)
                {
                    maindata[offset_block + position[i]] = data [count];
                    D6 = (byte)((int)D6 ^ (int)data[count]);
                    switch (position[i])
                    {
                        case 6:
                            D2 = (byte)((int)D2 ^ (int)data[count]); 
                            D3 = (byte)((int)D3 ^ (int)data[count]); 
                            break;
                        case 10:
                            D2 = (byte)((int)D2 ^ (int)data[count]); 
                            D4 = (byte)((int)D4 ^ (int)data[count]); 
                            break;
                        case 12:
                            D3 = (byte)((int)D3 ^ (int)data[count]); 
                            D4 = (byte)((int)D4 ^ (int)data[count]); 
                            break;
                        case 14:
                            D2 = (byte)((int)D2 ^ (int)data[count]);
                            D3 = (byte)((int)D3 ^ (int)data[count]); 
                            D4 = (byte)((int)D4 ^ (int)data[count]); 
                            break;
                        case 18:
                            D2 = (byte)((int)D2 ^ (int)data[count]); 
                            D5 = (byte)((int)D5 ^ (int)data[count]); 
                            break;
                        case 20:
                            D3 = (byte)((int)D3 ^ (int)data[count]); 
                            D5 = (byte)((int)D5 ^ (int)data[count]); 
                            break;
                        case 22:
                            D2 = (byte)((int)D2 ^ (int)data[count]); 
                            D3 = (byte)((int)D3 ^ (int)data[count]); 
                            D5 = (byte)((int)D5 ^ (int)data[count]); 
                            break;
                        case 24:
                            D4 = (byte)((int)D4 ^ (int)data[count]); 
                            D5 = (byte)((int)D5 ^ (int)data[count]); 
                            break;
                        case 26:
                            D2 = (byte)((int)D2 ^ (int)data[count]); 
                            D4 = (byte)((int)D4 ^ (int)data[count]); 
                            D5 = (byte)((int)D5 ^ (int)data[count]); 
                            break;
                        case 28:
                            D3 = (byte)((int)D3 ^ (int)data[count]); 
                            D4 = (byte)((int)D4 ^ (int)data[count]); 
                            D5 = (byte)((int)D5 ^ (int)data[count]); 
                            break;
                    }
                    count++;
                }
                D6 = (byte)((int)D6 ^ (int)D2);
                D6 = (byte)((int)D6 ^ (int)D3);
                D6 = (byte)((int)D6 ^ (int)D4);
                D6 = (byte)((int)D6 ^ (int)D5);
                D6 = (byte)(0xFF - (int)D6);
                // Calculate Checksums
                maindata[offset_block] = D6;
                maindata[offset_block + 2] = D2;
                maindata[offset_block + 4] = D3;
                maindata[offset_block + 8] = D4;
                maindata[offset_block + 16] = D5;
                block++;
                offset_block = offset_block + 30;
            } while (block < 5);
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            int number = (int)(data[0]*256)+ (int)data[1]; // The number to split
            byte[] newdata = new byte[3];                  // into 3 bytes

            // 1 number, 3 characters
            newdata[0] = (byte)(number / 1600);
            newdata[1] = (byte)((number - (1600 * newdata[0])) / 40);
            newdata[2] = (byte)((number - (1600* newdata[0]) - (40 * newdata[1])) / 1);

            for (int i = 0; i < newdata.Length; i++)
            {
                if (newdata[i] >= 0x01 && newdata[i] <= 0x1a)
                    sb.Append(((char)((((int)newdata[i])) + 65 - 0x01)));                
                else if (newdata[i] == 0x00)
                    sb.Append(' ');
                sb.Append('.'); // Cosmetic add-on
            }
            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            int data = 0; //3 Letters, 2 bytes
                        
            if (str[0] >= 'A' && str[0] <= 'Z')
               data = (((int)str[0] - 65 + 0x01)* 1600);
            if (str[1] >= 'A' && str[1] <= 'Z')
                data = data + (((int)str[1] - 65 + 0x01) * 40);
            if (str[2] >= 'A' && str[2] <= 'Z')
                data = data + (((int)str[2] - 65 + 0x01) * 1);

            return HiConvert.IntToByteArrayHexAsHex(data, 2); //3 Letters, 2 bytes
        }

        private int GetAlternateName(string altName)
        {
            switch (altName)
            {
                case "BEST PER CREDIT AVERAGE":
                    return 0;                
            }
            return -1;
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            string name = args[1].ToUpper().Replace(".","");
            int score = System.Convert.ToInt32(args[2]);

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(DecryptArray(m_data, "Main Data"), 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5))
                rank = 4;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6))
                rank = 5;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7))
                rank = 6;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8))
                rank = 7;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9))
                rank = 8;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10))
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
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
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
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score8.Length));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score9.Length));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score10.Length));
                    break;             
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);
            
            EncryptArray(m_data, byteArray, "Main Data");
        }

        public override void SetAlternateScore(string[] args)
        {
            int alternateName = GetAlternateName(args[0]);
            int rankGiven = Convert.ToInt32(args[1]);
            string name = args[2].ToUpper().Replace(".", "");
            int score = System.Convert.ToInt32(args[3]);

            AlternateData altData = new AlternateData();
            altData = (AlternateData)HiConvert.RawDeserialize(DecryptArray(m_data, "Alternate Data"), 0, typeof(AlternateData));

            #region DETERMINE_RANK
            // We don't need to check is score > PercentScore (rankgiven+1), because
            // it can be possible lower scores in upper ranks
            int rank = rankGiven-1;    
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(altData.PercentScore2, altData.PercentScore1);
                    HiConvert.ByteArrayCopy(altData.PercentName2, altData.PercentName1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(altData.PercentScore3, altData.PercentScore2);
                    HiConvert.ByteArrayCopy(altData.PercentName3, altData.PercentName2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(altData.PercentScore4, altData.PercentScore3);
                    HiConvert.ByteArrayCopy(altData.PercentName4, altData.PercentName3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(altData.PercentScore5, altData.PercentScore4);
                    HiConvert.ByteArrayCopy(altData.PercentName5, altData.PercentName4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(altData.PercentScore6, altData.PercentScore5);
                    HiConvert.ByteArrayCopy(altData.PercentName6, altData.PercentName5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(altData.PercentScore7, altData.PercentScore6);
                    HiConvert.ByteArrayCopy(altData.PercentName7, altData.PercentName6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(altData.PercentScore8, altData.PercentScore7);
                    HiConvert.ByteArrayCopy(altData.PercentName8, altData.PercentName7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(altData.PercentScore9, altData.PercentScore8);
                    HiConvert.ByteArrayCopy(altData.PercentName9, altData.PercentName8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(altData.PercentScore10, altData.PercentScore9);
                    HiConvert.ByteArrayCopy(altData.PercentName10, altData.PercentName9);
                    if (rank < 8)
                        goto case 7;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(altData.PercentName1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(altData.PercentScore1, HiConvert.IntToByteArrayHexAsHex(score, altData.PercentScore1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(altData.PercentName2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(altData.PercentScore2, HiConvert.IntToByteArrayHexAsHex(score, altData.PercentScore2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(altData.PercentName3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(altData.PercentScore3, HiConvert.IntToByteArrayHexAsHex(score, altData.PercentScore3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(altData.PercentName4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(altData.PercentScore4, HiConvert.IntToByteArrayHexAsHex(score, altData.PercentScore4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(altData.PercentName5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(altData.PercentScore5, HiConvert.IntToByteArrayHexAsHex(score, altData.PercentScore5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(altData.PercentName6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(altData.PercentScore6, HiConvert.IntToByteArrayHexAsHex(score, altData.PercentScore6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(altData.PercentName7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(altData.PercentScore7, HiConvert.IntToByteArrayHexAsHex(score, altData.PercentScore7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(altData.PercentName8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(altData.PercentScore8, HiConvert.IntToByteArrayHexAsHex(score, altData.PercentScore8.Length));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(altData.PercentName9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(altData.PercentScore9, HiConvert.IntToByteArrayHexAsHex(score, altData.PercentScore9.Length));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(altData.PercentName10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(altData.PercentScore10, HiConvert.IntToByteArrayHexAsHex(score, altData.PercentScore10.Length));
                    break;
            }
            #endregion
                       
            byte[] byteArrayAlt = HiConvert.RawSerialize(altData);

            EncryptArray(m_data, byteArrayAlt, "Alternate Data");
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score5.Length));
           
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            AlternateData altData = new AlternateData();

   
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(DecryptArray(m_data, "Main Data"), 0, typeof(HiscoreData));            
            altData = (AlternateData)HiConvert.RawDeserialize(DecryptArray(m_data, "Alternate Data"), 0, typeof(AlternateData));

            retString += String.Format("{0}|{1}|{2}", 1, ByteArrayToString(hiscoreData.Name1), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, ByteArrayToString(hiscoreData.Name2), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, ByteArrayToString(hiscoreData.Name3), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, ByteArrayToString(hiscoreData.Name4), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, ByteArrayToString(hiscoreData.Name5), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 6, ByteArrayToString(hiscoreData.Name6), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 7, ByteArrayToString(hiscoreData.Name7), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 8, ByteArrayToString(hiscoreData.Name8), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 9, ByteArrayToString(hiscoreData.Name9), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 10, ByteArrayToString(hiscoreData.Name10), HiConvert.ByteArrayHexAsHexToInt(hiscoreData.Score10)) + Environment.NewLine;
            
            retString += Environment.NewLine + Environment.NewLine + AltFormat[0] + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 1, ByteArrayToString(altData.PercentName1), HiConvert.ByteArrayHexAsHexToInt(altData.PercentScore1)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, ByteArrayToString(altData.PercentName2), HiConvert.ByteArrayHexAsHexToInt(altData.PercentScore2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, ByteArrayToString(altData.PercentName3), HiConvert.ByteArrayHexAsHexToInt(altData.PercentScore3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, ByteArrayToString(altData.PercentName4), HiConvert.ByteArrayHexAsHexToInt(altData.PercentScore4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, ByteArrayToString(altData.PercentName5), HiConvert.ByteArrayHexAsHexToInt(altData.PercentScore5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 6, ByteArrayToString(altData.PercentName6), HiConvert.ByteArrayHexAsHexToInt(altData.PercentScore6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 7, ByteArrayToString(altData.PercentName7), HiConvert.ByteArrayHexAsHexToInt(altData.PercentScore7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 8, ByteArrayToString(altData.PercentName8), HiConvert.ByteArrayHexAsHexToInt(altData.PercentScore8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 9, ByteArrayToString(altData.PercentName9), HiConvert.ByteArrayHexAsHexToInt(altData.PercentScore9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 10, ByteArrayToString(altData.PercentName10), HiConvert.ByteArrayHexAsHexToInt(altData.PercentScore10)) + Environment.NewLine;
            

            return retString;
        }
    }
}