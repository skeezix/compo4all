using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using HTTF = HiToText.Formatting;
using VBA = HiToText.Formatting.ConvertValueToByteArray;
using BAI = HiToText.Formatting.ConvertByteArrayToInt;
using HiToStr = HiToText.Formatting.ConvertByteArraysToStrings;
using TextParams = HiToText.Utils.TextDecodingParameters;
using HiToText.HXML;
using HiToText.Utils;

namespace HiToText.Generic
{
    public class HiscoreData
    {
        Dictionary<string, byte[]> dataMap = new Dictionary<string, byte[]>();
        HiToTextEntry _entry;

        public HiscoreData(HiToTextEntry entry)
        {
            _entry = entry;

            foreach (HiToTextEntryMapping mapping in entry.FileStructure)
            {
                int numBlocks = mapping.NumberOfBlocks;
                int start = 1;
                if (mapping.StartSpecified)
                    start = mapping.Start;

                Dictionary<string, int> entries = new Dictionary<string, int>();

                foreach (HiToTextEntryMappingEntry mapEntry in mapping.Entry)
                    entries.Add(mapEntry.Name, mapEntry.Length);

                switch (mapping.Ordering.ToUpper())
                {
                    case "ASCENDING":
                        for (int i = 0; i < numBlocks; i++)
                        {
                            foreach (string s in entries.Keys)
                                dataMap.Add(s + (start + i).ToString(), new byte[entries[s]]);
                        }
                        break;
                    case "DESCENDING":
                        for (int i = numBlocks - 1; i >= 0; i--)
                        {
                            foreach (string s in entries.Keys)
                                dataMap.Add(s + (start + i).ToString(), new byte[entries[s]]);
                        }
                        break;
                    case "NONE":
                        foreach (string s in entries.Keys)
                            dataMap.Add(s, new byte[entries[s]]);
                        break;
                }
            }
        }

        public void Populate(byte[] m_data)
        {
            int counter = 0;
            foreach (string s in dataMap.Keys)
            {
                for (int i = 0; i < dataMap[s].Length; i++)
                {
                    dataMap[s][i] = m_data[counter];
                    counter++;
                }
            }
        }

        public string HiToString(List<DisplayData> data)
        {
            string toReturn = string.Empty;

            //Create a list of lists, they should be the same size, if not we have a problem.
            List<List<string>> parsedFieldNames = new List<List<string>>();

            int baseLine = 0;

            foreach (DisplayData d in data)
            {
                List<string> parsedField = new List<string>();

                //Add all the fields
                parsedField.AddRange(dataMap.Keys);

                if (d.Pattern == null)
                    parsedField.Clear();
                else
                    //Remove any fields that do NOT match this pattern in data.
                    parsedField.RemoveAll(new NotMatching(d.Pattern).NotMatchStr);

                parsedField.Sort(new StringNameComparator(StringNameComparator.Ordering.Ascending));

                parsedFieldNames.Add(parsedField);

                if (parsedField.Count > baseLine)
                    baseLine = parsedField.Count;
            }

            for (int i = 0; i < baseLine; i++)
            {
                for (int j = 0; j < parsedFieldNames.Count; j++)
                {
                    if (parsedFieldNames[j].Count == 0)
                    {
                        if (data[j].CannedMethod.Equals(DisplayData.CannedDisplay.AscendingFrom1))
                            toReturn += (i + 1).ToString();
                        else if (data[j].CannedMethod.Equals(DisplayData.CannedDisplay.AscendingFrom1EndingInTotal))
                        {
                            if (i == baseLine - 1)
                                toReturn += data[j].ToDisplay;
                            else
                                toReturn += (i + 1).ToString();
                        }
                    }
                    else
                    {
                        byte[] b = new byte[1];
                        if (i < parsedFieldNames[j].Count)
                        {
                            b = (byte[])dataMap[parsedFieldNames[j][i]];

                            toReturn += data[j].CallingMethod(b);
                        }
                    }
                    if (j != parsedFieldNames.Count - 1)
                        toReturn += "|";
                }

                toReturn += Environment.NewLine;
            }

            return toReturn;
        }

        public int DetermineRank(int score, Regex pattern, BAI methodToCallOnData)
        {
            List<string> parsedField = new List<string>();

            //Add all the fields
            parsedField.AddRange(dataMap.Keys);

            //Remove any fields that do NOT match this pattern in adjusters.
            parsedField.RemoveAll(new NotMatching(pattern).NotMatchStr);

            //Sort by the numeric portion of the pattern in adjusters in ascending numerical order.
            //(i.e. Score1, Score2, ... Scoren or Name1, Name2, ... Namen)
            parsedField.Sort(new StringNameComparator(StringNameComparator.Ordering.Ascending));

            int rankCounter = 0;
            foreach (string parsed in parsedField)
            {
                //If we match our pattern, check against our GetValue method to determine if we have a larger
                //score.
                if (pattern.IsMatch(parsed))
                {
                    if (score > methodToCallOnData(dataMap[parsed]))
                        return rankCounter;
                }
                rankCounter++;
            }

            //If we don't have a larger score value, rankCounter will be equal to NumEntries.
            return rankCounter;
        }

        public void AdjustScores(int rank, List<Regex> adjusters)
        {
            //Create a list of FieldInfo for each Regex pattern in adjusters.
            foreach (Regex pattern in adjusters)
            {
                List<string> parsedField = new List<string>();

                //Add all the fields
                parsedField.AddRange(dataMap.Keys);

                //Remove any fields that do NOT match this pattern in adjusters.
                parsedField.RemoveAll(new NotMatching(pattern).NotMatchStr);

                //Sort by the numeric portion of the pattern in adjusters in descending numerical order.
                //(i.e. Score23, Score22, ... Score1 or Name23, Name22, ... Name1)
                parsedField.Sort(new StringNameComparator(StringNameComparator.Ordering.Descending));

                //Go through and move down data to the next lowest rank up until the rank we will replace with.
                for (int i = 0; i < parsedField.Count - (rank + 1); i++)
                {
                    byte[] b = new byte[dataMap[parsedField[i + 1]].Length];
                    HiConvert.ByteArrayCopy(b, dataMap[parsedField[i + 1]]);
                    dataMap[parsedField[i]] = b;
                }
            }
        }

        public void ReplaceNew(int rank, List<Placement> placements)
        {
            foreach (Placement p in placements)
            {
                if (p.IsTopScorePlacement && rank != 0)
                {
                }
                else
                {
                    List<string> parsedField = new List<string>();

                    //Add all the fields
                    parsedField.AddRange(dataMap.Keys);

                    //Remove any fields that do NOT match this pattern in adjusters.
                    parsedField.RemoveAll(new NotMatching(p.Pattern).NotMatchStr);

                    //Sort by the numeric portion of the pattern in adjusters in descending numerical order.
                    //(i.e. Score23, Score22, ... Score1 or Name23, Name22, ... Name1)
                    parsedField.Sort(new StringNameComparator(StringNameComparator.Ordering.Ascending));

                    if (rank < parsedField.Count)
                        HiConvert.ByteArrayCopy(dataMap[parsedField[rank]], p.CallingMethod(p.Value));
                }
            }
        }

        public void EmptyScores(List<Regex> patterns, List<VBA> methodsToCall)
        {
            int patternCounter = 0;
            foreach (Regex pattern in patterns)
            {
                List<string> parsedField = new List<string>();

                //Add all the fields
                parsedField.AddRange(dataMap.Keys);

                //Remove any fields that do NOT match this pattern in adjusters.
                parsedField.RemoveAll(new NotMatching(pattern).NotMatchStr);

                foreach (string field in parsedField)
                    HiConvert.ByteArrayCopy(dataMap[field], methodsToCall[patternCounter]("0"));

                patternCounter++;
            }
        }

        public HiToTextEntry Entry
        {
            get
            {
                return _entry;
            }
            set
            {
                _entry = value;
            }
        }

        //TODO: Try to make this method more modular.
        public List<DisplayData> GetDisplay(TextParams tParams, Dictionary<string, OneToManyMap<byte[], string>> switchMaps)
        {
            List<DisplayData> display = new List<DisplayData>();

            int displayedEntries = -1;
            if (_entry.DisplayStructure.NumOfDisplayedEntriesSpecified)
                displayedEntries = Convert.ToInt32(_entry.DisplayStructure.NumOfDisplayedEntries);

            foreach (HiToTextEntryDisplayStructureFieldName fieldName in _entry.DisplayStructure.FieldName)
            {
                DisplayData toDisplay = null;
                HTTF.ConvertByteArrayToString cbas = null;

                string methodName = fieldName.ConversionType.ToUpper();
                if (fieldName.ConversionType.ToUpper().IndexOf('(') >= 0)
                    methodName = fieldName.ConversionType.ToUpper().Substring(0, fieldName.ConversionType.ToUpper().IndexOf('('));

                switch (methodName)
                {
                    case "CANNEDDISPLAY.ASCENDINGFROM1":
                        toDisplay = new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1);
                        break;
                    case "CANNEDDISPLAY.ASCENDINGFROM1ENDINGINTOTAL":
                        toDisplay = new DisplayData(null, DisplayData.CannedDisplay.AscendingFrom1EndingInTotal);
                        break;
                    case "NAME":
                        if (fieldName.CustomName != null && !fieldName.CustomName.Equals(string.Empty))
                        {
                            MethodInfo[] mInfos = 
                                typeof(HiToStr).GetMethods(BindingFlags.Public | BindingFlags.Static);
                            for (int i = 0; i < mInfos.Length; i++)
                            {
                                if (mInfos[i].Name.ToUpper().Equals(fieldName.CustomName.ToUpper()))
                                {
                                    cbas = (HTTF.ConvertByteArrayToString)mInfos[i].Invoke(
                                        null, 
                                        new object[] { tParams });
                                    break;
                                }
                            }
                        }
                        else
                            cbas = HiToStr.ConvertName(tParams);
                        break;
                    case "STANDARD":
                        cbas = HiToStr.Standard;
                        break;
                    case "REVERSED":
                        cbas = HiToStr.Reversed;
                        break;
                    case "HEX":
                        cbas = HiToStr.Hex;
                        break;
                    case "HEXREVERSED":
                        cbas = HiToStr.HexReversed;
                        break;
                    case "BCD":
                        cbas = HiToStr.BCD;
                        break;
                    case "BCDREVERSED":
                        cbas = HiToStr.BCDReversed;
                        break;
                    case "SWITCH":
                        cbas = HiToStr.ConvertSwitch(switchMaps[fieldName.Name]);
                        break;
                    case "TWOTOTHREEENCODING":
                        cbas = HiToStr.TwoToThreeEncoding(
                            tParams,
                            Convert.ToInt32(fieldName.ConversionType.Substring(fieldName.ConversionType.IndexOf('(') + 1,
                                fieldName.ConversionType.IndexOf(')') - (fieldName.ConversionType.IndexOf('(') + 1)).Trim()));
                        break;
                    default:
                        MethodInfo[] methodInfos = typeof(HiToStr).GetMethods(
                            BindingFlags.Public | BindingFlags.Static);
                        for (int i = 0; i < methodInfos.Length; i++)
                        {
                            if (methodInfos[i].Name.ToUpper().Equals(methodName))
                            {
                                cbas = (HTTF.ConvertByteArrayToString)Delegate.CreateDelegate(
                                    typeof(HTTF.ConvertByteArrayToString), methodInfos[i]);
                                break;
                            }
                        }

                        //Will look for custom ByteArrayToInts that already exist and just tostring them, if we
                        //still don't have a cbas.
                        if (cbas == null)
                        {
                            methodInfos = typeof(HTTF.ByteArrayToInt).GetMethods(
                                BindingFlags.Public | BindingFlags.Static);
                            for (int i = 0; i < methodInfos.Length; i++)
                            {
                                if (methodInfos[i].Name.ToUpper().Equals(methodName))
                                {
                                    BAI bai = (BAI)Delegate.CreateDelegate(typeof(BAI), methodInfos[i]);
                                    cbas = delegate(byte[] score) { return bai(score).ToString(); };
                                    break;
                                }
                            }
                        }

                        //ConvertByteArraysToStrings
                        break;
                }

                if (fieldName.Operator != null && !fieldName.Operator.Equals(string.Empty))
                {
                    switch (fieldName.Operator.Substring(0, 1))
                    {
                        case "*":
                            cbas = HiToStr.MultiplyDisplayed(cbas, Convert.ToInt32(fieldName.Operator.Substring(1)));
                            break;
                        case "+":
                            cbas = HiToStr.AddToDisplayed(cbas, Convert.ToInt32(fieldName.Operator.Substring(1)));
                            break;
                    }
                }

                if (toDisplay == null)
                {
                    string reg = string.Empty;
                    string[] fns =
                        fieldName.Name.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    if (fns.Length > 1)
                        CreateNewField(fns, fieldName.ConversionType);

                    if (displayedEntries == -1)
                    {
                        if (fns.Length > 1)
                            toDisplay = new DisplayData(new Regex("^" + fieldName.ConversionType + ".*$"), cbas);
                        else
                            toDisplay = new DisplayData(new Regex("^" + fieldName.Name + ".*$"), cbas);
                    }
                    else
                    {
                        for (int i = 1; i <= displayedEntries; i++)
                        {
                            if (fns.Length > 1)
                                reg += "|^" + fieldName.ConversionType + i.ToString() + "$";
                            else
                                reg += "|^" + fieldName.Name + i.ToString() + "$";
                        }

                        toDisplay = new DisplayData(new Regex(reg.Substring(1)), cbas);
                    }
                }

                display.Add(toDisplay);
            }

            return display;
        }

        private void CreateNewField(string[] fieldNames, string fieldName)
        {
            List<List<string>> parsedFieldNames = new List<List<string>>();
            int baseLine = 0;

            foreach (string s in fieldNames)
            {
                List<string> parsedField = new List<string>();

                //Add all the fields
                parsedField.AddRange(dataMap.Keys);

                //Remove any fields that do NOT match this pattern in data.
                parsedField.RemoveAll(new NotMatching(new Regex("^" + s + ".*$")).NotMatchStr);

                parsedField.Sort(new StringNameComparator(StringNameComparator.Ordering.Ascending));

                parsedFieldNames.Add(parsedField);

                if (parsedField.Count > baseLine)
                    baseLine = parsedField.Count;
            }

            for (int i = 0; i < baseLine; i++)
            {
                List<byte> newFieldVal = new List<byte>();
                for (int j = 0; j < parsedFieldNames.Count; j++)
                {
                    byte[] b = new byte[1];
                    b = (byte[])dataMap[parsedFieldNames[j][i]];
                    
                    foreach (byte by in b)
                        newFieldVal.Add(by);
                }

                dataMap.Add(fieldName + (i + 1).ToString(), newFieldVal.ToArray());
            }
        }

        public int GetLength(Regex pattern)
        {
            List<string> parsedField = new List<string>();

            //Add all the fields
            parsedField.AddRange(dataMap.Keys);

            //Remove any fields that do NOT match this pattern in adjusters.
            parsedField.RemoveAll(new NotMatching(pattern).NotMatchStr);

            //Sort by the numeric portion of the pattern in adjusters in ascending numerical order.
            //(i.e. Score1, Score2, ... Scoren or Name1, Name2, ... Namen)
            parsedField.Sort(new StringNameComparator(StringNameComparator.Ordering.Ascending));

            int baseline = -1;
            foreach (string field in parsedField)
            {
                if (baseline == -1)
                    baseline = dataMap[field].Length;
                else
                {
                    if (baseline != dataMap[field].Length)
                        return -1;
                }
            }

            return baseline;
        }

        public byte[] Flatten()
        {
            List<byte> data = new List<byte>();

            foreach (byte[] b in dataMap.Values)
                data.AddRange(b);

            return data.ToArray();
        }
    }
}
