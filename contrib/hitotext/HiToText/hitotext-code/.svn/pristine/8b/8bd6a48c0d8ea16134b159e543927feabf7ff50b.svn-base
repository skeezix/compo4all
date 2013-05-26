using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace HiToText.HXML
{
    class HXMLReader
    {
        HiToText xHTT = new HiToText();

        public HXMLReader()
        {
        }

        public HXMLReader(XPathNavigator path)
        {
            xHTT.Entry = new HiToTextEntry[1]; 
            xHTT.Entry[0] = new HiToTextEntry(path);
        }

        public HXMLReader(string fileName)
        {
            try
            {
                XmlSerializer xSerial = new XmlSerializer(typeof(HiToText));

                using (XmlReader reader = XmlReader.Create(fileName))
                {
                    xHTT = (HiToText)xSerial.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (XmlException xex)
            {
                throw new Exception("Error: Invalid HXML format.", xex);
            }
        }

        public List<string> GetSupportedGames()
        {
            //If no file, no supported games! (For the XML games)
            if (xHTT.Entry == null)
                return new List<string>();

            List<string> supportedGames = new List<string>();
            foreach (HiToTextEntry e in xHTT.Entry)
                supportedGames.AddRange(e.Header.Games);

            return supportedGames;
        }

        public HiToTextEntry GetEntry(string name)
        {
            foreach (HiToTextEntry e in xHTT.Entry)
            {
                foreach (string gName in e.Header.Games)
                {
                    if (gName.Equals(name))
                        return e;
                }
            }

            return null;
        }
    }
}