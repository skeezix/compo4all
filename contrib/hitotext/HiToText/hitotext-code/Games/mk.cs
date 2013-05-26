using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class mk : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score2;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins5;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score5;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins6;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score6;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins7;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score7;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins8;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score8;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins9;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score9;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins10;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score10;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins11;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score11;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins12;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score12;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins13;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score13;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins14;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score14;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] Name15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Wins15;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Score15;
        }

        public mk()
        {
            m_numEntries = 15;
            m_format = "RANK|SCORE|NAME|WINS";
            m_gamesSupported = "mk,mkr4";
            m_extensionsRequired = ".nv";
        }

        public virtual int Offset_Scores()
        {
            return 0x1800;
        }

        public virtual int Offset_Checksum()
        {
            return 0x190e;
        }

        public string ByteArrayToString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i ++)
            {
                if (data[i] >= 0x00 && data[i] <= 0x19)
                    sb.Append((char)(((int)data[i]) + 0x41));
                else if (data[i] == 0x00)
                    sb.Append(' ');
            }

            return sb.ToString();
        }

        public byte[] StringToByteArray(string str)
        {
            byte[] data = new byte [str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    data[i] = (byte)(((int)str[i] - 0x41));
                }
                else if (str[i] == ' ')
                {
                    data[i] = 0x00;
                }
            }

            return data;
        }

        public byte[] DecryptArray(byte[] data)
        {
            // Deleting the 00s unused to make the work easy with the hiscore data stored in nvram
            byte[] toreturn = new byte[(Offset_Checksum() - Offset_Scores()) / 2];
            int j = 0;
            for (int i = Offset_Scores(); i < Offset_Checksum(); i+=2)
            {
                toreturn[j] = data[i];
                j++;
            }
            
            return toreturn;
        }

        public void EncryptArray(byte[] maindata, byte[] hiscoredata)
        {
            int checksum = 0x0000;

            byte[] tempdata = new byte[hiscoredata.Length * 2];

            for (int i = 0; i < hiscoredata.Length; i ++)
            {
                checksum += hiscoredata[i]; // calculate checksum
                maindata[Offset_Scores() + (i * 2)] = hiscoredata[i];             
                maindata[Offset_Scores() + (i * 2) + 1] = 0x00;
            }
            maindata[Offset_Checksum()] = Convert.ToByte(checksum.ToString("X2").PadLeft(4,'0').Substring(2,2),16);
            maindata[Offset_Checksum() + 2] = Convert.ToByte(checksum.ToString("X2").PadLeft(4, '0').Substring(0, 2), 16);
         }

        public override void SetHiScore(string[] args)
        {
            int rankGiven = Convert.ToInt32(args[0]);
            int score = System.Convert.ToInt32(args[1]);
            string name = args[2].ToUpper().Substring(0, 3);
            int wins = System.Convert.ToInt32(args[3]);

            HiscoreData hiscoreData = new HiscoreData();
            byte[] data_converted = DecryptArray(m_data);
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(data_converted, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)))
                rank = 0;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)))
                rank = 1;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)))
                rank = 2;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)))
                rank = 3;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)))
                rank = 4;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score6)))
                rank = 5;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score7)))
                rank = 6;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score8)))
                rank = 7;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score9)))
                rank = 8;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score10)))
                rank = 9;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score11)))
                rank = 10;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score12)))
                rank = 11;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score13)))
                rank = 12;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score14)))
                rank = 13;
            else if (score > HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score15)))
                rank = 14;
            #endregion

            #region ADJUST
            int adjust = NumEntries - 1;
            if (rank < NumEntries - 1)
                adjust = NumEntries - 2;
            switch (adjust)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, hiscoreData.Score1);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins2, hiscoreData.Wins1);
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, hiscoreData.Name1);
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, hiscoreData.Score2);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins3, hiscoreData.Wins2);
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, hiscoreData.Name2);
                    if (rank < 1)
                        goto case 0;
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, hiscoreData.Score3);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins4, hiscoreData.Wins3);
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, hiscoreData.Name3);
                    if (rank < 2)
                        goto case 1;
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, hiscoreData.Score4);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins5, hiscoreData.Wins4);
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, hiscoreData.Name4);
                    if (rank < 3)
                        goto case 2;
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, hiscoreData.Score5);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins6, hiscoreData.Wins5);
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, hiscoreData.Name5);
                    if (rank < 4)
                        goto case 3;
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, hiscoreData.Score6);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins7, hiscoreData.Wins6);
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, hiscoreData.Name6);
                    if (rank < 5)
                        goto case 4;
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, hiscoreData.Score7);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins8, hiscoreData.Wins7);
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, hiscoreData.Name7);
                    if (rank < 6)
                        goto case 5;
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, hiscoreData.Score8);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins9, hiscoreData.Wins8);
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, hiscoreData.Name8);
                    if (rank < 7)
                        goto case 6;
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, hiscoreData.Score9);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins10, hiscoreData.Wins9);
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, hiscoreData.Name9);
                    if (rank < 8)
                        goto case 7;
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Score11, hiscoreData.Score10);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins11, hiscoreData.Wins10);
                    HiConvert.ByteArrayCopy(hiscoreData.Name11, hiscoreData.Name10);
                    if (rank < 9)
                        goto case 8;
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.Score12, hiscoreData.Score11);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins12, hiscoreData.Wins11);
                    HiConvert.ByteArrayCopy(hiscoreData.Name12, hiscoreData.Name11);
                    if (rank < 10)
                        goto case 9;
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.Score13, hiscoreData.Score12);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins13, hiscoreData.Wins12);
                    HiConvert.ByteArrayCopy(hiscoreData.Name13, hiscoreData.Name12);
                    if (rank < 11)
                        goto case 10;
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.Score14, hiscoreData.Score13);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins14, hiscoreData.Wins13);
                    HiConvert.ByteArrayCopy(hiscoreData.Name14, hiscoreData.Name13);
                    if (rank < 12)
                        goto case 11;
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.Score15, hiscoreData.Score14);
                    HiConvert.ByteArrayCopy(hiscoreData.Wins15, hiscoreData.Wins14);
                    HiConvert.ByteArrayCopy(hiscoreData.Name15, hiscoreData.Name14);
                    if (rank < 13)
                        goto case 12;
                    break;
            }
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.Name1, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score1.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins1.Length)));
                    break;
                case 1:
                    HiConvert.ByteArrayCopy(hiscoreData.Name2, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score2.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins2, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins2.Length)));
                    break;
                case 2:
                    HiConvert.ByteArrayCopy(hiscoreData.Name3, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score3.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins3, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins3.Length)));
                    break;
                case 3:
                    HiConvert.ByteArrayCopy(hiscoreData.Name4, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score4.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins4, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins4.Length)));
                    break;
                case 4:
                    HiConvert.ByteArrayCopy(hiscoreData.Name5, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score5.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins5, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins5.Length)));
                    break;
                case 5:
                    HiConvert.ByteArrayCopy(hiscoreData.Name6, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score6.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins6, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins6.Length)));
                    break;
                case 6:
                    HiConvert.ByteArrayCopy(hiscoreData.Name7, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score7.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins7, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins7.Length)));
                    break;
                case 7:
                    HiConvert.ByteArrayCopy(hiscoreData.Name8, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score8.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins8, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins8.Length)));
                    break;
                case 8:
                    HiConvert.ByteArrayCopy(hiscoreData.Name9, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score9.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins9, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins9.Length)));
                    break;
                case 9:
                    HiConvert.ByteArrayCopy(hiscoreData.Name10, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score10.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins10, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins10.Length)));
                    break;
                case 10:
                    HiConvert.ByteArrayCopy(hiscoreData.Name11, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score11, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score11.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins11, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins11.Length)));
                    break;
                case 11:
                    HiConvert.ByteArrayCopy(hiscoreData.Name12, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score12, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score12.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins12, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins12.Length)));
                    break;
                case 12:
                    HiConvert.ByteArrayCopy(hiscoreData.Name13, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score13, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score13.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins13, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins13.Length)));
                    break;
                case 13:
                    HiConvert.ByteArrayCopy(hiscoreData.Name14, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score14, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score14.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins14, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins14.Length)));
                    break;
                case 14:
                    HiConvert.ByteArrayCopy(hiscoreData.Name15, StringToByteArray(name));
                    HiConvert.ByteArrayCopy(hiscoreData.Score15, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(score, hiscoreData.Score15.Length)));
                    HiConvert.ByteArrayCopy(hiscoreData.Wins15, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(wins, hiscoreData.Wins15.Length)));
                    break;
            }
            #endregion
            
            data_converted = HiConvert.RawSerialize(hiscoreData);

            EncryptArray(m_data, data_converted);
        }

        public override void EmptyScores()
        {
            byte[] data_converted = DecryptArray(m_data);
            
            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(data_converted, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score3, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score4, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score5, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score6, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score7, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score8, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score9, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score10, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score10.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score11, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score11.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score12, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score12.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score13, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score13.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score14, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score14.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Score15, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Score15.Length));

            HiConvert.ByteArrayCopy(hiscoreData.Wins1, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins2, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins2.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins3, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins3.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins4, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins4.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins5, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins5.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins6, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins6.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins7, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins7.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins8, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins8.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins9, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins9.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins10, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins10.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins11, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins11.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins12, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins12.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins13, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins13.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins14, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins14.Length));
            HiConvert.ByteArrayCopy(hiscoreData.Wins15, HiConvert.IntToByteArrayHexAsHex(0, hiscoreData.Wins15.Length));
 

            data_converted = HiConvert.RawSerialize(hiscoreData);

            EncryptArray(m_data, data_converted);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            byte[] data_converted = DecryptArray(m_data);
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(data_converted, 0, typeof(HiscoreData));

            retString += String.Format("{0}|{1}|{2}|{3}", 1, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score1)), ByteArrayToString(hiscoreData.Name1), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins1))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 2, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score2)), ByteArrayToString(hiscoreData.Name2), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins2))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 3, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score3)), ByteArrayToString(hiscoreData.Name3), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins3))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 4, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score4)), ByteArrayToString(hiscoreData.Name4), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins4))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 5, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score5)), ByteArrayToString(hiscoreData.Name5), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins5))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 6, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score6)), ByteArrayToString(hiscoreData.Name6), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins6))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 7, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score7)), ByteArrayToString(hiscoreData.Name7), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins7))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 8, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score8)), ByteArrayToString(hiscoreData.Name8), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins8))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 9, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score9)), ByteArrayToString(hiscoreData.Name9), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins9))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 10, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score10)), ByteArrayToString(hiscoreData.Name10), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins10))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 11, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score11)), ByteArrayToString(hiscoreData.Name11), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins11))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 12, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score12)), ByteArrayToString(hiscoreData.Name12), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins12))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 13, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score13)), ByteArrayToString(hiscoreData.Name13), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins13))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 14, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score14)), ByteArrayToString(hiscoreData.Name14), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins14))) + Environment.NewLine;
            retString += String.Format("{0}|{1}|{2}|{3}", 15, HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score15)), ByteArrayToString(hiscoreData.Name15), HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(hiscoreData.Wins15))) + Environment.NewLine;
   
            return retString;
        }
    }
}