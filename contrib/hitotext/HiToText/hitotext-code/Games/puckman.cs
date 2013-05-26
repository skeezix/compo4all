using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using HiToText;
using HiToText.Utils;

namespace HiGames
{
    class puckman : Hiscore
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public struct HiscoreData
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] ScoreV1;

            public byte UnknownByte3;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] ScoreV2;

            public byte UnknownByte11;
        }

        public puckman()
        {
            m_numEntries = 1;
            m_format = "SCORE";
            m_gamesSupported = "hangly3,zolamaze,mspatkx,mspacx,msmini,mspacat2,msatk2ad,msatkad,mspacatk,chtmsatk,fastplus,mspacatb,mshearts,mssilad,fstmsatk,mspac6m,msminia,chtmspa,fastmspa,msrumble,msindy,fasthear,heartbrn,mshangly,msf1pac,mselton,faststrm,msdstorm,msbaby1,msbaby,mrpacman,pacmanf,puckmanf,pacmini2,pacmini,mazeman,hangly2x,hanglyx,hanglyad,fasthang,chthang,eltonpac,dizzy,pacstrm,crazypac,caterpil,baby2,baby3,pacman,pacmanm,pacmanjp,npacmod,pacmod,hangly,hangly2,puckman,piranha,piranhah,pacplus,mspacman,mspacmnf,mschamp,newpuc2,newpuc2b,joyman,mspacpls,pacgal,newpuckx,mspacmat,puckmod,puckmana,ctrpllrp,puckmanh,abscam,mspacmbe";
            m_extensionsRequired = ".hi";
        }

        public int ByteArrayToScore(byte[] byteData)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < byteData.Length; i++)
            {
                string newData = byteData[i].ToString("X2");
                if (newData.Equals("40")) //Empty byte for display purposes.
                    sb.Insert(0, "0");
                else
                    sb.Insert(0, newData[1]);
            }

            return Int32.Parse(sb.ToString());
        }

        public byte[] ScoreToByteArray(int score)
        {
            int numDigitsInScore = 6;
            StringBuilder sb = new StringBuilder();
            String strScore = score.ToString();
            strScore = strScore.PadLeft(numDigitsInScore, 'F');

            for (int i = 0; i < numDigitsInScore; i++)
            {
                if (strScore[i].Equals('F'))
                    sb.Insert(0, "40");
                else
                    sb.Insert(0, "0" + strScore[i].ToString());
            }

            return HiConvert.HexStringToByteArray(sb.ToString());
        }

        public override void SetHiScore(string[] args)
        {
            int score = System.Convert.ToInt32(args[0]);

            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreV1, HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHex(score, hiscoreData.ScoreV1.Length)));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreV2, ScoreToByteArray(score));
            
            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);
        }

        public override void EmptyScores()
        {
            HiscoreData hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            HiConvert.ByteArrayCopy(hiscoreData.ScoreV1, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreV1.Length));
            HiConvert.ByteArrayCopy(hiscoreData.ScoreV2, HiConvert.IntToByteArrayHex(0, hiscoreData.ScoreV2.Length));

            byte[] byteArray = HiConvert.RawSerialize(hiscoreData);

            HiConvert.ByteArrayCopy(m_data, byteArray);

            SaveData();
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            HiscoreData hiscoreData = new HiscoreData();
            hiscoreData = (HiscoreData)HiConvert.RawDeserialize(m_data, 0, typeof(HiscoreData));

            retString += String.Format("{0}", ByteArrayToScore(hiscoreData.ScoreV2)) + Environment.NewLine;

            return retString;
        }
    }
}

