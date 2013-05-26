using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class invaders : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] Score;
        }

        public invaders()
        {
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "invaders,earthinv,spaceatt,sinvemag,sitv,sicv,sisv,sisv2,alieninv,spceking,spcewars,spacewr3,invader4,invadrmr,cosmicm2";
            m_extensionsRequired = ".hi";
        }

        public override void SetHiScore(string[] args)
        {
            int score = System.Convert.ToInt32(args[0]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.Score.Length)));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.Score, HiConvert.IntToByteArrayHex(0, hiscoreData.Score.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}", HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(hiscoreData.Score))) + Environment.NewLine;

            return retString;
        }
    }
}

