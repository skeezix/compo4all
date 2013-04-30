using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace HiToText
{
    abstract class Hiscore
    {
        protected string[] m_fileNames = null;
        protected byte[] m_data = null;

        protected int m_numEntries = 0;
        protected int[] m_numAltEntries = { 0 };
        protected string m_format = "";
        protected string[] m_altFormat = { "" };
        protected string m_gamesSupported = "";
        protected string m_extensionsRequired = "";
        protected DateTime m_versionDate = DateTime.MaxValue;

        public Hiscore()
        {
        }

        private void ReadData(string[] fileNames)
        {
            m_fileNames = new string[fileNames.Length];
            for (int i = 0; i < fileNames.Length; i++)
            {
                if (!String.IsNullOrEmpty(fileNames[i]))
                {
                    if (File.Exists(fileNames[i]))
                    {
                        m_fileNames[i] = fileNames[i];
                        AppendData(File.ReadAllBytes(fileNames[i]));
                    }
                }
            }
        }

        private void AppendData(byte[] data)
        {
            byte[] temp = m_data;
            m_data = new byte[data.Length];
            if (temp != null)
            {
                m_data = new byte[temp.Length + data.Length];
                for (int i = 0; i < temp.Length; i++)
                    m_data[i] = temp[i];
                for (int j = 0; j < data.Length; j++)
                    m_data[j + temp.Length] = data[j];
            }
            else
                m_data = data;
        }

        public abstract string HiToString();

        public abstract void EmptyScores();

        public abstract void SetHiScore(String[] args);

        public virtual void ModifyName(int rank, string score)
        {
            throw new NotImplementedException("ModifyName is not currently implemented for this game.");
        }

        public string[] FileNames
        {
            get { return m_fileNames; }
            set { ReadData(value); }
        }

        public int NumEntries
        {
            get { return m_numEntries; }
        }

        public int[] NumAltEntries
        {
            get { return m_numAltEntries; }
        }

        public string Format
        {
            get { return m_format; }
        }

        public string[] AltFormat
        {
            get { return m_altFormat; }
        }

        public string[] AltScoreName
        {
            get
            {
                string[] altScoreNames = new string[m_altFormat.Length];
                for (int i = 0; i < altScoreNames.Length; i++)
                {
                    int newLineLoc = m_altFormat[i].IndexOf(Environment.NewLine);
                    altScoreNames[i] = m_altFormat[i].Substring(0, newLineLoc);
                }

                return altScoreNames;
            }
        }

        public int FieldCount
        {
            get { return m_format.Split(new char[] { '|' }).Length; }
        }

        public int[] AltFieldCount
        {
            get
            {
                int[] altFieldCount = new int[m_altFormat.Length];
                for (int i = 0; i < altFieldCount.Length; i++)
                {
                    int newLineLoc = m_altFormat[i].IndexOf(Environment.NewLine);
                    altFieldCount[i] = m_altFormat[i].Substring(newLineLoc + Environment.NewLine.Length).Split(new char[] { '|' }).Length;
                }

                return altFieldCount;
            }
        }

        public int NumAltScores
        {
            get { return m_numAltEntries.Length; }
        }

        public DateTime GetVersionDate
        {
            get { return m_versionDate; }
        }

        public string[] GamesSupported
        {
            get { return m_gamesSupported.Split(new char[] { ',' }); }
        }

        public string[] ExtensionsRequired
        {
            get { return m_extensionsRequired.Split(new char[] { ',' }); }
        }

        public virtual void SaveData()
        {
            File.WriteAllBytes(m_fileNames[0], m_data);
        }

        public virtual String[] OptimizeScoresForGame(String[] scoreArray)
        {
            return scoreArray;
        }

        public virtual void SetAlternateScore(String[] args)
        {
        }
    }
}
