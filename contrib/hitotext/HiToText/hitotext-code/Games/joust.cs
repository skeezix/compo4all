using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class joust : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 318)]
            public byte[] UnusedA;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
            public byte[] Name1Long;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score11;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score12;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score13;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score14;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score15;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum16;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score16;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum17;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score17;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum18;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score18;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum19;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score19;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name20;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum20;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score20;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name21;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum21;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score21;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name22;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum22;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score22;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name23;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum23;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score23;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name24;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum24;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score24;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name25;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum25;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score25;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name26;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum26;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score26;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name27;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum27;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score27;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name28;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum28;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score28;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name29;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum29;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score29;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name30;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum30;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score30;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name31;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum31;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score31;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name32;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum32;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score32;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name33;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum33;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score33;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name34;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum34;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score34;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name35;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum35;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score35;
            
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name36;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum36;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score36;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name37;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum37;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score37;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name38;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum38;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score38;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name39;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum39;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score39;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] Name40;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] Checksum40;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public byte[] Score40;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 106)]
            public byte[] UnusedB;
        }

        public joust()
        {
            m_numEntries = 40;
            m_format = "RANK|SCORE|NAME";
            m_gamesSupported = "joust,joustr,joustwr";
            m_extensionsRequired = ".nv";
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            String tmp = HiConvert.ByteArrayToHexString(data);

        
            for (int i = 0; i < data.Length / 2; i++)
            {
                int tmpvalue = Convert.ToInt32("0x" + tmp.Substring((i * 4) + 1, 1) + tmp.Substring((i * 4) + 3, 1), 16);
                if (tmpvalue == 0x0a) // If there is an 0x0a (0xf0, 0xfa) an space must be displayed.
                    sb.Append(' ');
                else
                    sb.Append((char)(tmpvalue + 0x36));
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str, int length)
        {
            byte[] data = new byte[length];
            if (str.Length > length / 2)
                str = str.Substring(0, length / 2);
            else str = str.PadRight(length / 2, ' '); // Be careful, with shorts names
               
            for (int i = 0; i < str.Length; i++)
            {
                data[i * 2] = Byte.Parse("F" + ((int)str[i] - 0x36).ToString("X2").Substring(0, 1), System.Globalization.NumberStyles.AllowHexSpecifier);
                data[(i * 2) + 1] = Byte.Parse("F" + ((int)str[i] - 0x36).ToString("X2").Substring(1, 1), System.Globalization.NumberStyles.AllowHexSpecifier);
                if (str[i] == ' ') // An space must be coded like 0xf0, 0xfa
                  {
                    data[i * 2] = 0xf0;
                    data[(i * 2) + 1] = 0xfa;
                  }               
            } 

            return data;
        }

        public int ByteArrayToScore(byte[] data)
        {
            int score = 0;
            
            for (int i = 0; i < data.Length; i++)
                score += ((int)(data[i] - 0xF0)) * Convert.ToInt32(Math.Pow(10, ((data.Length - i) - 1)));

            return score;
        }

        public byte[] ScoreToByteArray(int score, int numBytes)
        {
            // We must format the byte array properly, because the score must have 8 numbers.
            // always "f0 f0 f0 f0 f0 f0 f0 f0"            // 
            StringBuilder sb = new StringBuilder();           
            String valAsStr = score.ToString().PadLeft(numBytes,'0');

            for (int i = 0; i < numBytes; i++)
            {
              sb.Append("F"+valAsStr[i]);
            }
            return HiConvert.HexStringToByteArray(sb.ToString());
        }

        // We start with two bytes arrays, datascore and dataname.
        // We make an AND with 0x0f byte to byte with bith arrays.
        // We sum the resulting bytes all together and we make another AND with 0x0f
        // and the result of this sum. Finally we add 0xf0 to the result.
        // To sum up, there is a checksum of the 4 firts bits of each bytes.
        public byte[] GetChecksum(byte[] datascore, byte[] dataname, int length)
        {
            byte[] checksum = new byte[length];

            for (int i = 0; i < datascore.Length; i++)
            {
                checksum[0] += (byte)(int)(datascore[i] & 0x0f);
            }
            for (int i = 0; i < dataname.Length; i++)
            {
                checksum[0] += (byte)(int)((dataname[i]) & 0x0f);
            }

            checksum[0] = (byte)(int)((checksum[0] & 0x0f) + 0xf0);
                
            return checksum;
        }

        public static void ByteArrayCopy(byte[] dest, byte[] src)
        {
            for (int i = 0; i < dest.Length; i++)
            {
                if (i < src.Length)
                    dest[i] = src[i];
                else
                {
                    dest[i] = 0xf0;
                    dest[i + 1] = 0xfa;
                    i++;
                }
            }
        }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = Convert.ToInt32(args[1]);
            string name = args[2].ToUpper();

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > ByteArrayToScore(hiscoreData.Score1))
                rank = 0;
            else if (score > ByteArrayToScore(hiscoreData.Score2))
                rank = 1;
            else if (score > ByteArrayToScore(hiscoreData.Score3))
                rank = 2;
            else if (score > ByteArrayToScore(hiscoreData.Score4))
                rank = 3;
            else if (score > ByteArrayToScore(hiscoreData.Score5))
                rank = 4;
            else if (score > ByteArrayToScore(hiscoreData.Score6))
                rank = 5;
            else if (score > ByteArrayToScore(hiscoreData.Score7))
                rank = 6;
            else if (score > ByteArrayToScore(hiscoreData.Score8))
                rank = 7;
            else if (score > ByteArrayToScore(hiscoreData.Score9))
                rank = 8;
            else if (score > ByteArrayToScore(hiscoreData.Score10))
                rank = 9;
            else if (score > ByteArrayToScore(hiscoreData.Score11))
                rank = 10;
            else if (score > ByteArrayToScore(hiscoreData.Score12))
                rank = 11;
            else if (score > ByteArrayToScore(hiscoreData.Score13))
                rank = 12;
            else if (score > ByteArrayToScore(hiscoreData.Score14))
                rank = 13;
            else if (score > ByteArrayToScore(hiscoreData.Score15))
                rank = 14;
            else if (score > ByteArrayToScore(hiscoreData.Score16))
                rank = 15;
            else if (score > ByteArrayToScore(hiscoreData.Score17))
                rank = 16;
            else if (score > ByteArrayToScore(hiscoreData.Score18))
                rank = 17;
            else if (score > ByteArrayToScore(hiscoreData.Score19))
                rank = 18;
            else if (score > ByteArrayToScore(hiscoreData.Score20))
                rank = 19;
            else if (score > ByteArrayToScore(hiscoreData.Score21))
                rank = 20;
            else if (score > ByteArrayToScore(hiscoreData.Score22))
                rank = 21;
            else if (score > ByteArrayToScore(hiscoreData.Score23))
                rank = 22;
            else if (score > ByteArrayToScore(hiscoreData.Score24))
                rank = 23;
            else if (score > ByteArrayToScore(hiscoreData.Score25))
                rank = 24;
            else if (score > ByteArrayToScore(hiscoreData.Score26))
                rank = 25;
            else if (score > ByteArrayToScore(hiscoreData.Score27))
                rank = 26;
            else if (score > ByteArrayToScore(hiscoreData.Score28))
                rank = 27;
            else if (score > ByteArrayToScore(hiscoreData.Score29))
                rank = 28;
            else if (score > ByteArrayToScore(hiscoreData.Score30))
                rank = 29;
            else if (score > ByteArrayToScore(hiscoreData.Score31))
                rank = 30;
            else if (score > ByteArrayToScore(hiscoreData.Score32))
                rank = 31;
            else if (score > ByteArrayToScore(hiscoreData.Score33))
                rank = 32;
            else if (score > ByteArrayToScore(hiscoreData.Score34))
                rank = 33;
            else if (score > ByteArrayToScore(hiscoreData.Score35))
                rank = 34;
            else if (score > ByteArrayToScore(hiscoreData.Score36))
                rank = 35;
            else if (score > ByteArrayToScore(hiscoreData.Score37))
                rank = 36;
            else if (score > ByteArrayToScore(hiscoreData.Score38))
                rank = 37;
            else if (score > ByteArrayToScore(hiscoreData.Score39))
                rank = 38;
            else if (score > ByteArrayToScore(hiscoreData.Score40))
                rank = 39;
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
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum2, hiscoreData.Checksum1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum3, hiscoreData.Checksum2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum4, hiscoreData.Checksum3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum5, hiscoreData.Checksum4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum6, hiscoreData.Checksum5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum7, hiscoreData.Checksum6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum8, hiscoreData.Checksum7);
                    if (rank < 6)
                        goto case 5;
                    break;                
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum9, hiscoreData.Checksum8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum10, hiscoreData.Checksum9);
                    if (rank < 8)
                        goto case 7;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Score11, hiscoreData.Score10);
                    HiConvert.ByteArrayCopy(hiscoreData.Name11, hiscoreData.Name10);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum11, hiscoreData.Checksum10);
                    if (rank < 9)
                        goto case 8;
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.Score12, hiscoreData.Score11);
                    HiConvert.ByteArrayCopy(hiscoreData.Name12, hiscoreData.Name11);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum12, hiscoreData.Checksum11);
                    if (rank < 10)
                        goto case 9;
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.Score13, hiscoreData.Score12);
                    HiConvert.ByteArrayCopy(hiscoreData.Name13, hiscoreData.Name12);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum13, hiscoreData.Checksum12);
                    if (rank < 11)
                        goto case 10;
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.Score14, hiscoreData.Score13);
                    HiConvert.ByteArrayCopy(hiscoreData.Name14, hiscoreData.Name13);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum14, hiscoreData.Checksum13);
                    if (rank < 12)
                        goto case 11;
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.Score15, hiscoreData.Score14);
                    HiConvert.ByteArrayCopy(hiscoreData.Name15, hiscoreData.Name14);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum15, hiscoreData.Checksum14);
                    if (rank < 13)
                        goto case 12;
                    break;
                case 14:
                    HiConvert.ByteArrayCopy(hiscoreData.Score16, hiscoreData.Score15);
                    HiConvert.ByteArrayCopy(hiscoreData.Name16, hiscoreData.Name15);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum16, hiscoreData.Checksum15);
                    if (rank < 14)
                        goto case 13;
                    break;
                case 15:
                    HiConvert.ByteArrayCopy(hiscoreData.Score17, hiscoreData.Score16);
                    HiConvert.ByteArrayCopy(hiscoreData.Name17, hiscoreData.Name16);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum17, hiscoreData.Checksum16);
                    if (rank < 15)
                        goto case 14;
                    break;
                case 16:
                    HiConvert.ByteArrayCopy(hiscoreData.Score18, hiscoreData.Score17);
                    HiConvert.ByteArrayCopy(hiscoreData.Name18, hiscoreData.Name17);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum18, hiscoreData.Checksum17);
                    if (rank < 16)
                        goto case 15;
                    break;
                case 17:
                    HiConvert.ByteArrayCopy(hiscoreData.Score19, hiscoreData.Score18);
                    HiConvert.ByteArrayCopy(hiscoreData.Name19, hiscoreData.Name18);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum19, hiscoreData.Checksum18);
                    if (rank < 17)
                        goto case 16;
                    break;
                case 18:
                    HiConvert.ByteArrayCopy(hiscoreData.Score20, hiscoreData.Score19);
                    HiConvert.ByteArrayCopy(hiscoreData.Name20, hiscoreData.Name19);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum20, hiscoreData.Checksum19);
                    if (rank < 18)
                        goto case 17;
                    break;
                case 19:
                    HiConvert.ByteArrayCopy(hiscoreData.Score21, hiscoreData.Score20);
                    HiConvert.ByteArrayCopy(hiscoreData.Name21, hiscoreData.Name20);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum21, hiscoreData.Checksum20);
                    if (rank < 19)
                        goto case 18;
                    break;
                case 20:
                    HiConvert.ByteArrayCopy(hiscoreData.Score22, hiscoreData.Score21);
                    HiConvert.ByteArrayCopy(hiscoreData.Name22, hiscoreData.Name21);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum22, hiscoreData.Checksum21);
                    if (rank < 20)
                        goto case 19;
                    break;
                case 21:
                    HiConvert.ByteArrayCopy(hiscoreData.Score23, hiscoreData.Score22);
                    HiConvert.ByteArrayCopy(hiscoreData.Name23, hiscoreData.Name22);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum23, hiscoreData.Checksum22);
                    if (rank < 21)
                        goto case 20;
                    break;
                case 22:
                    HiConvert.ByteArrayCopy(hiscoreData.Score24, hiscoreData.Score23);
                    HiConvert.ByteArrayCopy(hiscoreData.Name24, hiscoreData.Name23);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum24, hiscoreData.Checksum23);
                    if (rank < 22)
                        goto case 21;
                    break;
                case 23:
                    HiConvert.ByteArrayCopy(hiscoreData.Score25, hiscoreData.Score24);
                    HiConvert.ByteArrayCopy(hiscoreData.Name25, hiscoreData.Name24);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum25, hiscoreData.Checksum24);
                    if (rank < 23)
                        goto case 22;
                    break;
                case 24:
                    HiConvert.ByteArrayCopy(hiscoreData.Score26, hiscoreData.Score25);
                    HiConvert.ByteArrayCopy(hiscoreData.Name26, hiscoreData.Name25);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum26, hiscoreData.Checksum25);
                    if (rank < 24)
                        goto case 23;
                    break;
                case 25:
                    HiConvert.ByteArrayCopy(hiscoreData.Score27, hiscoreData.Score26);
                    HiConvert.ByteArrayCopy(hiscoreData.Name27, hiscoreData.Name26);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum27, hiscoreData.Checksum26);
                    if (rank < 25)
                        goto case 24;
                    break;
                case 26:
                    HiConvert.ByteArrayCopy(hiscoreData.Score28, hiscoreData.Score27);
                    HiConvert.ByteArrayCopy(hiscoreData.Name28, hiscoreData.Name27);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum28, hiscoreData.Checksum27);
                    if (rank < 26)
                        goto case 25;
                    break;
                case 27:
                    HiConvert.ByteArrayCopy(hiscoreData.Score29, hiscoreData.Score28);
                    HiConvert.ByteArrayCopy(hiscoreData.Name29, hiscoreData.Name28);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum29, hiscoreData.Checksum28);
                    if (rank < 27)
                        goto case 26;
                    break;
                case 28:
                    HiConvert.ByteArrayCopy(hiscoreData.Score30, hiscoreData.Score29);
                    HiConvert.ByteArrayCopy(hiscoreData.Name30, hiscoreData.Name29);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum30, hiscoreData.Checksum29);
                    if (rank < 28)
                        goto case 27;
                    break;
                case 29:
                    HiConvert.ByteArrayCopy(hiscoreData.Score31, hiscoreData.Score30);
                    HiConvert.ByteArrayCopy(hiscoreData.Name31, hiscoreData.Name30);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum31, hiscoreData.Checksum30);
                    if (rank < 29)
                        goto case 28;
                    break;
                case 30:
                    HiConvert.ByteArrayCopy(hiscoreData.Score32, hiscoreData.Score31);
                    HiConvert.ByteArrayCopy(hiscoreData.Name32, hiscoreData.Name31);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum32, hiscoreData.Checksum31);
                    if (rank < 30)
                        goto case 29;
                    break;
                case 31:
                    HiConvert.ByteArrayCopy(hiscoreData.Score33, hiscoreData.Score32);
                    HiConvert.ByteArrayCopy(hiscoreData.Name33, hiscoreData.Name32);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum33, hiscoreData.Checksum32);
                    if (rank < 31)
                        goto case 30;
                    break;
                case 32:
                    HiConvert.ByteArrayCopy(hiscoreData.Score34, hiscoreData.Score33);
                    HiConvert.ByteArrayCopy(hiscoreData.Name34, hiscoreData.Name33);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum34, hiscoreData.Checksum33);
                    if (rank < 32)
                        goto case 31;
                    break;
                case 33:
                    HiConvert.ByteArrayCopy(hiscoreData.Score35, hiscoreData.Score34);
                    HiConvert.ByteArrayCopy(hiscoreData.Name35, hiscoreData.Name34);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum35, hiscoreData.Checksum34);
                    if (rank < 33)
                        goto case 32;
                    break;
                case 34:
                    HiConvert.ByteArrayCopy(hiscoreData.Score36, hiscoreData.Score35);
                    HiConvert.ByteArrayCopy(hiscoreData.Name36, hiscoreData.Name35);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum36, hiscoreData.Checksum35);
                    if (rank < 34)
                        goto case 33;
                    break;
                case 35:
                    HiConvert.ByteArrayCopy(hiscoreData.Score37, hiscoreData.Score36);
                    HiConvert.ByteArrayCopy(hiscoreData.Name37, hiscoreData.Name36);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum37, hiscoreData.Checksum36);
                    if (rank < 35)
                        goto case 34;
                    break;
                case 36:
                    HiConvert.ByteArrayCopy(hiscoreData.Score38, hiscoreData.Score37);
                    HiConvert.ByteArrayCopy(hiscoreData.Name38, hiscoreData.Name37);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum38, hiscoreData.Checksum37);
                    if (rank < 36)
                        goto case 35;
                    break;
                case 37:
                    HiConvert.ByteArrayCopy(hiscoreData.Score39, hiscoreData.Score38);
                    HiConvert.ByteArrayCopy(hiscoreData.Name39, hiscoreData.Name38);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum39, hiscoreData.Checksum38);
                    if (rank < 37)
                        goto case 36;
                    break;
                case 38:
                    HiConvert.ByteArrayCopy(hiscoreData.Score40, hiscoreData.Score39);
                    HiConvert.ByteArrayCopy(hiscoreData.Name40, hiscoreData.Name39);
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum40, hiscoreData.Checksum39);
                    if (rank < 38)
                        goto case 37;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name,hiscoreData.Name1.Length));
                    ByteArrayCopy(hiscoreData.Name1Long, StringToByteArray(name, hiscoreData.Name1Long.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, ScoreToByteArray(score, hiscoreData.Score1.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum1, GetChecksum(hiscoreData.Score1, HiConvert.HexStringToByteArray(HiConvert.ByteArrayToHexString(hiscoreData.Name1)+HiConvert.ByteArrayToHexString(hiscoreData.Name1Long)), hiscoreData.Checksum1.Length));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name, hiscoreData.Name2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, ScoreToByteArray(score, hiscoreData.Score2.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum2, GetChecksum(hiscoreData.Score2, hiscoreData.Name2, hiscoreData.Checksum2.Length));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name, hiscoreData.Name3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, ScoreToByteArray(score, hiscoreData.Score3.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum3, GetChecksum(hiscoreData.Score3, hiscoreData.Name3, hiscoreData.Checksum3.Length));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name, hiscoreData.Name4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, ScoreToByteArray(score, hiscoreData.Score4.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum4, GetChecksum(hiscoreData.Score4, hiscoreData.Name4, hiscoreData.Checksum4.Length));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name, hiscoreData.Name5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, ScoreToByteArray(score, hiscoreData.Score5.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum5, GetChecksum(hiscoreData.Score5, hiscoreData.Name5, hiscoreData.Checksum5.Length));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name, hiscoreData.Name6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, ScoreToByteArray(score, hiscoreData.Score6.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum6, GetChecksum(hiscoreData.Score6, hiscoreData.Name6, hiscoreData.Checksum6.Length));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name, hiscoreData.Name7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, ScoreToByteArray(score, hiscoreData.Score7.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum7, GetChecksum(hiscoreData.Score7, hiscoreData.Name7, hiscoreData.Checksum7.Length));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name, hiscoreData.Name8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, ScoreToByteArray(score, hiscoreData.Score8.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum8, GetChecksum(hiscoreData.Score8, hiscoreData.Name8, hiscoreData.Checksum8.Length));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name, hiscoreData.Name9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, ScoreToByteArray(score, hiscoreData.Score9.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum9, GetChecksum(hiscoreData.Score9, hiscoreData.Name9, hiscoreData.Checksum9.Length));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name, hiscoreData.Name10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, ScoreToByteArray(score, hiscoreData.Score10.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum10, GetChecksum(hiscoreData.Score10, hiscoreData.Name10, hiscoreData.Checksum10.Length));
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.Name11, StringToByteArray(name, hiscoreData.Name11.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score11, ScoreToByteArray(score, hiscoreData.Score11.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum11, GetChecksum(hiscoreData.Score11, hiscoreData.Name11, hiscoreData.Checksum11.Length));
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.Name12, StringToByteArray(name, hiscoreData.Name12.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score12, ScoreToByteArray(score, hiscoreData.Score12.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum12, GetChecksum(hiscoreData.Score12, hiscoreData.Name12, hiscoreData.Checksum12.Length));
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.Name13, StringToByteArray(name, hiscoreData.Name13.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score13, ScoreToByteArray(score, hiscoreData.Score13.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum13, GetChecksum(hiscoreData.Score13, hiscoreData.Name13, hiscoreData.Checksum13.Length));
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.Name14, StringToByteArray(name, hiscoreData.Name14.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score14, ScoreToByteArray(score, hiscoreData.Score14.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum14, GetChecksum(hiscoreData.Score14, hiscoreData.Name14, hiscoreData.Checksum14.Length));
                    break;
                case 14:
                    HiConvert.ByteArrayCopy(hiscoreData.Name15, StringToByteArray(name, hiscoreData.Name15.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score15, ScoreToByteArray(score, hiscoreData.Score15.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum15, GetChecksum(hiscoreData.Score15, hiscoreData.Name15, hiscoreData.Checksum15.Length));
                    break;
                case 15:
                    HiConvert.ByteArrayCopy(hiscoreData.Name16, StringToByteArray(name, hiscoreData.Name16.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score16, ScoreToByteArray(score, hiscoreData.Score16.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum16, GetChecksum(hiscoreData.Score16, hiscoreData.Name16, hiscoreData.Checksum16.Length));
                    break;
                case 16:
                    HiConvert.ByteArrayCopy(hiscoreData.Name17, StringToByteArray(name, hiscoreData.Name17.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score17, ScoreToByteArray(score, hiscoreData.Score17.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum17, GetChecksum(hiscoreData.Score17, hiscoreData.Name17, hiscoreData.Checksum17.Length));
                    break;
                case 17:
                    HiConvert.ByteArrayCopy(hiscoreData.Name18, StringToByteArray(name, hiscoreData.Name18.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score18, ScoreToByteArray(score, hiscoreData.Score18.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum18, GetChecksum(hiscoreData.Score18, hiscoreData.Name18, hiscoreData.Checksum18.Length));
                    break;
                case 18:
                    HiConvert.ByteArrayCopy(hiscoreData.Name19, StringToByteArray(name, hiscoreData.Name19.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score19, ScoreToByteArray(score, hiscoreData.Score19.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum19, GetChecksum(hiscoreData.Score19, hiscoreData.Name19, hiscoreData.Checksum19.Length));
                    break;
                case 19:
                    HiConvert.ByteArrayCopy(hiscoreData.Name20, StringToByteArray(name, hiscoreData.Name20.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score20, ScoreToByteArray(score, hiscoreData.Score20.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum20, GetChecksum(hiscoreData.Score20, hiscoreData.Name20, hiscoreData.Checksum20.Length));
                    break;
                case 20:
                    HiConvert.ByteArrayCopy(hiscoreData.Name21, StringToByteArray(name, hiscoreData.Name21.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score21, ScoreToByteArray(score, hiscoreData.Score21.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum21, GetChecksum(hiscoreData.Score21, hiscoreData.Name21, hiscoreData.Checksum21.Length));
                    break;
                case 21:
                    HiConvert.ByteArrayCopy(hiscoreData.Name22, StringToByteArray(name, hiscoreData.Name22.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score22, ScoreToByteArray(score, hiscoreData.Score22.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum22, GetChecksum(hiscoreData.Score22, hiscoreData.Name22, hiscoreData.Checksum22.Length));
                    break;
                case 22:
                    HiConvert.ByteArrayCopy(hiscoreData.Name23, StringToByteArray(name, hiscoreData.Name23.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score23, ScoreToByteArray(score, hiscoreData.Score23.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum23, GetChecksum(hiscoreData.Score23, hiscoreData.Name23, hiscoreData.Checksum23.Length));
                    break;
                case 23:
                    HiConvert.ByteArrayCopy(hiscoreData.Name24, StringToByteArray(name, hiscoreData.Name24.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score24, ScoreToByteArray(score, hiscoreData.Score24.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum24, GetChecksum(hiscoreData.Score24, hiscoreData.Name24, hiscoreData.Checksum24.Length));
                    break;
                case 24:
                    HiConvert.ByteArrayCopy(hiscoreData.Name25, StringToByteArray(name, hiscoreData.Name25.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score25, ScoreToByteArray(score, hiscoreData.Score25.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum25, GetChecksum(hiscoreData.Score25, hiscoreData.Name25, hiscoreData.Checksum25.Length));
                    break;
                case 25:
                    HiConvert.ByteArrayCopy(hiscoreData.Name26, StringToByteArray(name, hiscoreData.Name26.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score26, ScoreToByteArray(score, hiscoreData.Score26.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum26, GetChecksum(hiscoreData.Score26, hiscoreData.Name26, hiscoreData.Checksum26.Length));
                    break;
                case 26:
                    HiConvert.ByteArrayCopy(hiscoreData.Name27, StringToByteArray(name, hiscoreData.Name27.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score27, ScoreToByteArray(score, hiscoreData.Score27.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum27, GetChecksum(hiscoreData.Score27, hiscoreData.Name27, hiscoreData.Checksum27.Length));
                    break;
                case 27:
                    HiConvert.ByteArrayCopy(hiscoreData.Name28, StringToByteArray(name, hiscoreData.Name28.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score28, ScoreToByteArray(score, hiscoreData.Score28.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum28, GetChecksum(hiscoreData.Score28, hiscoreData.Name28, hiscoreData.Checksum28.Length));
                    break;
                case 28:
                    HiConvert.ByteArrayCopy(hiscoreData.Name29, StringToByteArray(name, hiscoreData.Name29.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score29, ScoreToByteArray(score, hiscoreData.Score29.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum29, GetChecksum(hiscoreData.Score29, hiscoreData.Name29, hiscoreData.Checksum29.Length));
                    break;
                case 29:
                    HiConvert.ByteArrayCopy(hiscoreData.Name30, StringToByteArray(name, hiscoreData.Name30.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score30, ScoreToByteArray(score, hiscoreData.Score30.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum30, GetChecksum(hiscoreData.Score30, hiscoreData.Name30, hiscoreData.Checksum30.Length));
                    break;
                case 30:
                    HiConvert.ByteArrayCopy(hiscoreData.Name31, StringToByteArray(name, hiscoreData.Name31.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score31, ScoreToByteArray(score, hiscoreData.Score31.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum31, GetChecksum(hiscoreData.Score31, hiscoreData.Name31, hiscoreData.Checksum31.Length));
                    break;
                case 31:
                    HiConvert.ByteArrayCopy(hiscoreData.Name32, StringToByteArray(name, hiscoreData.Name32.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score32, ScoreToByteArray(score, hiscoreData.Score32.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum32, GetChecksum(hiscoreData.Score32, hiscoreData.Name32, hiscoreData.Checksum32.Length));
                    break;
                case 32:
                    HiConvert.ByteArrayCopy(hiscoreData.Name33, StringToByteArray(name, hiscoreData.Name33.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score33, ScoreToByteArray(score, hiscoreData.Score33.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum33, GetChecksum(hiscoreData.Score33, hiscoreData.Name33, hiscoreData.Checksum33.Length));
                    break;
                case 33:
                    HiConvert.ByteArrayCopy(hiscoreData.Name34, StringToByteArray(name, hiscoreData.Name34.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score34, ScoreToByteArray(score, hiscoreData.Score34.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum34, GetChecksum(hiscoreData.Score34, hiscoreData.Name34, hiscoreData.Checksum34.Length));
                    break;
                case 34:
                    HiConvert.ByteArrayCopy(hiscoreData.Name35, StringToByteArray(name, hiscoreData.Name35.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score35, ScoreToByteArray(score, hiscoreData.Score35.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum35, GetChecksum(hiscoreData.Score35, hiscoreData.Name35, hiscoreData.Checksum35.Length));
                    break;
                case 35:
                    HiConvert.ByteArrayCopy(hiscoreData.Name36, StringToByteArray(name, hiscoreData.Name36.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score36, ScoreToByteArray(score, hiscoreData.Score36.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum36, GetChecksum(hiscoreData.Score36, hiscoreData.Name36, hiscoreData.Checksum36.Length));
                    break;
                case 36:
                    HiConvert.ByteArrayCopy(hiscoreData.Name37, StringToByteArray(name, hiscoreData.Name37.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score37, ScoreToByteArray(score, hiscoreData.Score37.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum37, GetChecksum(hiscoreData.Score37, hiscoreData.Name37, hiscoreData.Checksum37.Length));
                    break;
                case 37:
                    HiConvert.ByteArrayCopy(hiscoreData.Name38, StringToByteArray(name, hiscoreData.Name38.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score38, ScoreToByteArray(score, hiscoreData.Score38.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum38, GetChecksum(hiscoreData.Score38, hiscoreData.Name38, hiscoreData.Checksum38.Length));
                    break;
                case 38:
                    HiConvert.ByteArrayCopy(hiscoreData.Name39, StringToByteArray(name, hiscoreData.Name39.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score39, ScoreToByteArray(score, hiscoreData.Score39.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum39, GetChecksum(hiscoreData.Score39, hiscoreData.Name39, hiscoreData.Checksum39.Length));
                    break;
                case 39:
                    HiConvert.ByteArrayCopy(hiscoreData.Name40, StringToByteArray(name, hiscoreData.Name40.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Score40, ScoreToByteArray(score, hiscoreData.Score40.Length));
                    HiConvert.ByteArrayCopy(hiscoreData.Checksum40, GetChecksum(hiscoreData.Score40, hiscoreData.Name40, hiscoreData.Checksum40.Length));
                    break;
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {           
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, ScoreToByteArray(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, ScoreToByteArray(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, ScoreToByteArray(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, ScoreToByteArray(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, ScoreToByteArray(0, hiscoreData.Score5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score6, ScoreToByteArray(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, ScoreToByteArray(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, ScoreToByteArray(0, hiscoreData.Score8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9, ScoreToByteArray(0, hiscoreData.Score9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score10, ScoreToByteArray(0, hiscoreData.Score10.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score11, ScoreToByteArray(0, hiscoreData.Score11.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score12, ScoreToByteArray(0, hiscoreData.Score12.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score13, ScoreToByteArray(0, hiscoreData.Score13.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score14, ScoreToByteArray(0, hiscoreData.Score14.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score15, ScoreToByteArray(0, hiscoreData.Score15.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score16, ScoreToByteArray(0, hiscoreData.Score16.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score17, ScoreToByteArray(0, hiscoreData.Score17.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score18, ScoreToByteArray(0, hiscoreData.Score18.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score19, ScoreToByteArray(0, hiscoreData.Score19.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score20, ScoreToByteArray(0, hiscoreData.Score20.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score21, ScoreToByteArray(0, hiscoreData.Score21.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score22, ScoreToByteArray(0, hiscoreData.Score22.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score23, ScoreToByteArray(0, hiscoreData.Score23.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score24, ScoreToByteArray(0, hiscoreData.Score24.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score25, ScoreToByteArray(0, hiscoreData.Score25.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score26, ScoreToByteArray(0, hiscoreData.Score26.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score27, ScoreToByteArray(0, hiscoreData.Score27.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score28, ScoreToByteArray(0, hiscoreData.Score28.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score29, ScoreToByteArray(0, hiscoreData.Score29.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score30, ScoreToByteArray(0, hiscoreData.Score30.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score31, ScoreToByteArray(0, hiscoreData.Score31.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score32, ScoreToByteArray(0, hiscoreData.Score32.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score33, ScoreToByteArray(0, hiscoreData.Score33.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score34, ScoreToByteArray(0, hiscoreData.Score34.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score35, ScoreToByteArray(0, hiscoreData.Score35.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score36, ScoreToByteArray(0, hiscoreData.Score36.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score37, ScoreToByteArray(0, hiscoreData.Score37.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score38, ScoreToByteArray(0, hiscoreData.Score38.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score39, ScoreToByteArray(0, hiscoreData.Score39.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score40, ScoreToByteArray(0, hiscoreData.Score40.Length));

            HiConvert.ByteArrayCopy(hiscoreData.Checksum1, GetChecksum(hiscoreData.Score1, hiscoreData.Name1, hiscoreData.Checksum1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum2, GetChecksum(hiscoreData.Score2, hiscoreData.Name2, hiscoreData.Checksum2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum3, GetChecksum(hiscoreData.Score3, hiscoreData.Name3, hiscoreData.Checksum3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum4, GetChecksum(hiscoreData.Score4, hiscoreData.Name4, hiscoreData.Checksum4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum5, GetChecksum(hiscoreData.Score5, hiscoreData.Name5, hiscoreData.Checksum5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum6, GetChecksum(hiscoreData.Score6, hiscoreData.Name6, hiscoreData.Checksum6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum7, GetChecksum(hiscoreData.Score7, hiscoreData.Name7, hiscoreData.Checksum7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum8, GetChecksum(hiscoreData.Score8, hiscoreData.Name8, hiscoreData.Checksum8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum9, GetChecksum(hiscoreData.Score9, hiscoreData.Name9, hiscoreData.Checksum9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum10, GetChecksum(hiscoreData.Score10, hiscoreData.Name10, hiscoreData.Checksum10.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum11, GetChecksum(hiscoreData.Score11, hiscoreData.Name11, hiscoreData.Checksum11.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum12, GetChecksum(hiscoreData.Score12, hiscoreData.Name12, hiscoreData.Checksum12.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum13, GetChecksum(hiscoreData.Score13, hiscoreData.Name13, hiscoreData.Checksum13.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum14, GetChecksum(hiscoreData.Score14, hiscoreData.Name14, hiscoreData.Checksum14.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum15, GetChecksum(hiscoreData.Score15, hiscoreData.Name15, hiscoreData.Checksum15.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum16, GetChecksum(hiscoreData.Score16, hiscoreData.Name16, hiscoreData.Checksum16.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum17, GetChecksum(hiscoreData.Score17, hiscoreData.Name17, hiscoreData.Checksum17.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum18, GetChecksum(hiscoreData.Score18, hiscoreData.Name18, hiscoreData.Checksum18.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum19, GetChecksum(hiscoreData.Score19, hiscoreData.Name19, hiscoreData.Checksum19.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum20, GetChecksum(hiscoreData.Score20, hiscoreData.Name20, hiscoreData.Checksum20.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum21, GetChecksum(hiscoreData.Score21, hiscoreData.Name21, hiscoreData.Checksum21.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum22, GetChecksum(hiscoreData.Score22, hiscoreData.Name22, hiscoreData.Checksum22.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum23, GetChecksum(hiscoreData.Score23, hiscoreData.Name23, hiscoreData.Checksum23.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum24, GetChecksum(hiscoreData.Score24, hiscoreData.Name24, hiscoreData.Checksum24.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum25, GetChecksum(hiscoreData.Score25, hiscoreData.Name25, hiscoreData.Checksum25.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum26, GetChecksum(hiscoreData.Score26, hiscoreData.Name26, hiscoreData.Checksum26.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum27, GetChecksum(hiscoreData.Score27, hiscoreData.Name27, hiscoreData.Checksum27.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum28, GetChecksum(hiscoreData.Score28, hiscoreData.Name28, hiscoreData.Checksum28.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum29, GetChecksum(hiscoreData.Score29, hiscoreData.Name29, hiscoreData.Checksum29.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum30, GetChecksum(hiscoreData.Score30, hiscoreData.Name30, hiscoreData.Checksum30.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum31, GetChecksum(hiscoreData.Score31, hiscoreData.Name31, hiscoreData.Checksum31.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum32, GetChecksum(hiscoreData.Score32, hiscoreData.Name32, hiscoreData.Checksum32.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum33, GetChecksum(hiscoreData.Score33, hiscoreData.Name33, hiscoreData.Checksum33.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum34, GetChecksum(hiscoreData.Score34, hiscoreData.Name34, hiscoreData.Checksum34.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum35, GetChecksum(hiscoreData.Score35, hiscoreData.Name35, hiscoreData.Checksum35.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum36, GetChecksum(hiscoreData.Score36, hiscoreData.Name36, hiscoreData.Checksum36.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum37, GetChecksum(hiscoreData.Score37, hiscoreData.Name37, hiscoreData.Checksum37.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum38, GetChecksum(hiscoreData.Score38, hiscoreData.Name38, hiscoreData.Checksum38.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum39, GetChecksum(hiscoreData.Score39, hiscoreData.Name39, hiscoreData.Checksum39.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Checksum40, GetChecksum(hiscoreData.Score40, hiscoreData.Name40, hiscoreData.Checksum40.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}", 1, ByteArrayToScore(hiscoreData.Score1), ByteArrayToString(hiscoreData.Name1Long)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 2, ByteArrayToScore(hiscoreData.Score2), ByteArrayToString(hiscoreData.Name2)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 3, ByteArrayToScore(hiscoreData.Score3), ByteArrayToString(hiscoreData.Name3)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 4, ByteArrayToScore(hiscoreData.Score4), ByteArrayToString(hiscoreData.Name4)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 5, ByteArrayToScore(hiscoreData.Score5), ByteArrayToString(hiscoreData.Name5)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 6, ByteArrayToScore(hiscoreData.Score6), ByteArrayToString(hiscoreData.Name6)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 7, ByteArrayToScore(hiscoreData.Score7), ByteArrayToString(hiscoreData.Name7)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 8, ByteArrayToScore(hiscoreData.Score8), ByteArrayToString(hiscoreData.Name8)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 9, ByteArrayToScore(hiscoreData.Score9), ByteArrayToString(hiscoreData.Name9)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 10, ByteArrayToScore(hiscoreData.Score10), ByteArrayToString(hiscoreData.Name10)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 11, ByteArrayToScore(hiscoreData.Score11), ByteArrayToString(hiscoreData.Name11)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 12, ByteArrayToScore(hiscoreData.Score12), ByteArrayToString(hiscoreData.Name12)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 13, ByteArrayToScore(hiscoreData.Score13), ByteArrayToString(hiscoreData.Name13)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 14, ByteArrayToScore(hiscoreData.Score14), ByteArrayToString(hiscoreData.Name14)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 15, ByteArrayToScore(hiscoreData.Score15), ByteArrayToString(hiscoreData.Name15)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 16, ByteArrayToScore(hiscoreData.Score16), ByteArrayToString(hiscoreData.Name16)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 17, ByteArrayToScore(hiscoreData.Score17), ByteArrayToString(hiscoreData.Name17)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 18, ByteArrayToScore(hiscoreData.Score18), ByteArrayToString(hiscoreData.Name18)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 19, ByteArrayToScore(hiscoreData.Score19), ByteArrayToString(hiscoreData.Name19)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 20, ByteArrayToScore(hiscoreData.Score20), ByteArrayToString(hiscoreData.Name20)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 21, ByteArrayToScore(hiscoreData.Score21), ByteArrayToString(hiscoreData.Name21)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 22, ByteArrayToScore(hiscoreData.Score22), ByteArrayToString(hiscoreData.Name22)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 23, ByteArrayToScore(hiscoreData.Score23), ByteArrayToString(hiscoreData.Name23)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 24, ByteArrayToScore(hiscoreData.Score24), ByteArrayToString(hiscoreData.Name24)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 25, ByteArrayToScore(hiscoreData.Score25), ByteArrayToString(hiscoreData.Name25)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 26, ByteArrayToScore(hiscoreData.Score26), ByteArrayToString(hiscoreData.Name26)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 27, ByteArrayToScore(hiscoreData.Score27), ByteArrayToString(hiscoreData.Name27)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 28, ByteArrayToScore(hiscoreData.Score28), ByteArrayToString(hiscoreData.Name28)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 29, ByteArrayToScore(hiscoreData.Score29), ByteArrayToString(hiscoreData.Name29)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 30, ByteArrayToScore(hiscoreData.Score30), ByteArrayToString(hiscoreData.Name30)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 31, ByteArrayToScore(hiscoreData.Score31), ByteArrayToString(hiscoreData.Name31)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 32, ByteArrayToScore(hiscoreData.Score32), ByteArrayToString(hiscoreData.Name32)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 33, ByteArrayToScore(hiscoreData.Score33), ByteArrayToString(hiscoreData.Name33)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 34, ByteArrayToScore(hiscoreData.Score34), ByteArrayToString(hiscoreData.Name34)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 35, ByteArrayToScore(hiscoreData.Score35), ByteArrayToString(hiscoreData.Name35)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 36, ByteArrayToScore(hiscoreData.Score36), ByteArrayToString(hiscoreData.Name36)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 37, ByteArrayToScore(hiscoreData.Score37), ByteArrayToString(hiscoreData.Name37)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 38, ByteArrayToScore(hiscoreData.Score38), ByteArrayToString(hiscoreData.Name38)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 39, ByteArrayToScore(hiscoreData.Score39), ByteArrayToString(hiscoreData.Name39)) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}", 40, ByteArrayToScore(hiscoreData.Score40), ByteArrayToString(hiscoreData.Name40)) + Environment.NewLine;
            
            return retString;
        }
    }
}