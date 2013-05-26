using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;
using HTTF = HiToText.Formatting;
using VBA = HiToText.Formatting.ConvertValueToByteArray;
using SetScore = HiToText.Formatting.ConvertValuesToBytes;
using HiToStr = HiToText.Formatting.ConvertByteArraysToStrings;
using TextParams = HiToText.Utils.TextDecodingParameters;

namespace HiGames
{
    class sprint1 : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] HiScore;
            public byte Checkbyte; // Use to tell hiscore.c when overwrite the data      
        }

        public TextParams tParams = new TextParams();

        public sprint1()
        {
            // MAX. SCORE = 999
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "sprint1";
            m_extensionsRequired = ".hi";

            tParams.Format = StringFormatFlag.ASCIIStandard;
        }

        public string ConvertScore(byte[] score)
        {
            return HTTF.ByteToString(HiConvert.ReverseByteArray(score), tParams);
        }

        public byte[] ConvertScore(string score)
        {
            return HiConvert.ReverseByteArray(HTTF.StringToByte(score, tParams));
        }
        
        public override void SetHiScore(string[] args)
        {
            string strscore = args[0].PadLeft(3, '0').Substring(0, 3);
            int score = Convert.ToInt32(strscore);
           
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            #region DETERMINE_RANK
            int rank = NumEntries;
            if (score > Convert.ToInt32(ConvertScore(hiscoreData.HiScore)))
                rank = 0;          
            #endregion

            #region REPLACE_NEW
            switch (rank)
            {
                case 0:
                    HiConvert.ByteArrayCopy(hiscoreData.HiScore, ConvertScore(strscore));
                    break;      
            }
            #endregion

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }
        
        //No name, so no modify name.
        public override void ModifyName(int rank, string name)
        {
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.HiScore, ConvertScore("000"));
          
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}", ConvertScore(hiscoreData.HiScore)) + Environment.NewLine;

            return retString;
        }
    }
}