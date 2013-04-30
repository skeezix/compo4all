using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;

namespace HiToText.Utils
{
    public class CsvParser
    {
        public bool hasHeaders = false;
        public bool useDoubleQuotes = true;
        public bool alwaysUseDoubleQuotes = false;
        public char separator = ',';
        public StringCollection fieldNames;
        public int numberOfFields = 0;

        const char q2 = '"';
        const string q2s = "\"";
        const string q2q2s = "\"\"";

        public ArrayList ParseCsv(StreamReader stream)
        {
            if (hasHeaders) fieldNames = ParseCsv(stream.ReadLine());

            ArrayList records = new ArrayList();
            for (string inbuff = stream.ReadLine(); inbuff != null; inbuff = stream.ReadLine())
                records.Add(ParseCsv(inbuff));
            
            return records;
        }

        public StringCollection ParseCsv(string buffer)
        {
            StringCollection items = new StringCollection();
            char[] ci = new char[buffer.Length + 1];
            buffer.CopyTo(0, ci, 0, buffer.Length);
            ci[buffer.Length] = separator;
            char[] co = new char[buffer.Length];
            char cc;
            int ix = 0, jx = 0;
            bool inQuotes = false;
            while (ix < ci.Length)
            {
                cc = ci[ix++];
                if (cc == q2)
                {
                    if (ix < ci.Length)
                        if (ci[ix] == q2 && inQuotes)
                            co[jx++] = ci[ix++];
                        else
                            inQuotes = (!inQuotes && useDoubleQuotes);
                    else
                        inQuotes = (!inQuotes && useDoubleQuotes);
                }
                else if (cc == separator)
                {
                    if (inQuotes)
                        co[jx++] = cc;
                    else
                    {
                        string s1 = new string(co, 0, jx);
                        items.Add(s1.Trim());
                        jx = 0;
                    }
                }
                else
                    co[jx++] = cc;
            }
            
            if (jx > 0)
            {
                string s1 = new string(co, 0, jx);
                items.Add(s1.Trim());
            }

            for (int n = items.Count; n < numberOfFields; n++) 
                items.Add(string.Empty);

            return items;
        }
    }
}
