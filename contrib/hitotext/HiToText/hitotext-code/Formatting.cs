using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Text.RegularExpressions;
using HiToText.Utils;

namespace HiToText
{
    public static class Formatting
    {
        #region Wrappers
        public delegate byte[] WrapperByteArray(byte[] data);
        public delegate string WrapperString(string data);

        public static WrapperByteArray PadRight(int length, string byteValue)
        {
            return delegate(byte[] data) 
            {
                byte[] toReturn = new byte[length];
                for (int i = 0; i < data.Length; i++)
                    toReturn[i] = data[i];
                for (int i = data.Length; i < length; i++)
                    toReturn[i] = HiConvert.HexStringToByteArray(byteValue)[0];

                return toReturn;
            };
        }

        public static WrapperByteArray PadLeft(int length, string byteValue)
        {
            return delegate(byte[] data)
            {
                byte[] toReturn = new byte[length];
                for (int i = 0; i < length; i++)
                    toReturn[i] = HiConvert.HexStringToByteArray(byteValue)[0];

                int counter = 0;
                for (int i = length - data.Length; i < length; i++)
                {
                    toReturn[i] = data[counter];
                    counter++;
                }

                return toReturn;
            };
        }

        #endregion

        #region StringToByte()
        public static byte[] StringToByte(string str, TextDecodingParameters tParams)
        {
            byte[] data = new byte[str.Length * tParams.ByteSkipAmount];
            for (int i = 0; i < data.Length; i++)
                data[i] = tParams.ByteSkipData;

            for (int i = 0; i < str.Length; i++)
            {
                bool keyFound = false;

                //Needs to be first, as it can be ASCII standard and some special mappings.
                #region SPECIAL MAPPING
                if ((tParams.Format & StringFormatFlag.NeedsSpecialMapping) == StringFormatFlag.NeedsSpecialMapping)
                {
                    if (tParams.SpecialMapping.ContainsOne(str[i]))
                    {
                        data[(i * tParams.ByteSkipAmount) + tParams.ByteStart] = tParams.SpecialMapping.FindMany(str[i]);
                        keyFound = true;
                    }
                }
                #endregion

                #region ASCII STANDARD
                if (!keyFound)
                {
                    if ((tParams.Format & StringFormatFlag.ASCIIStandard) == StringFormatFlag.ASCIIStandard)
                    {
                        data[(i * tParams.ByteSkipAmount) + tParams.ByteStart] = (byte)((int)str[i]);
                        keyFound = true;
                    }
                }
                #endregion

                #region ASCII UPPERCASE
                if (!keyFound)
                {
                    if ((tParams.Format & StringFormatFlag.ASCIIUpper) == StringFormatFlag.ASCIIUpper)
                    {
                        foreach (Offset o in tParams.Offsets)
                        {
                            if (o.Flag.Equals(Offset.FlagOffsets.Upper))
                            {
                                if (str[i] >= 'A' && str[i] <= 'Z')
                                {
                                    data[(i * tParams.ByteSkipAmount) + tParams.ByteStart] = (byte)(((((int)str[i]) - 65) + o.ByteOffset) * o.SkipModifier);
                                    keyFound = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region ASCII LOWERCASE
                if (!keyFound)
                {
                    if ((tParams.Format & StringFormatFlag.ASCIILower) == StringFormatFlag.ASCIILower)
                    {
                        foreach (Offset o in tParams.Offsets)
                        {
                            if (o.Flag.Equals(Offset.FlagOffsets.Lower))
                            {
                                if (str[i] >= 'a' && str[i] <= 'z')
                                {
                                    data[(i * tParams.ByteSkipAmount) + tParams.ByteStart] = (byte)(((((int)str[i]) - 71) + o.ByteOffset) * o.SkipModifier);
                                    keyFound = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region ASCII NUMBERS
                if (!keyFound)
                {
                    if ((tParams.Format & StringFormatFlag.ASCIINumbers) == StringFormatFlag.ASCIINumbers)
                    {
                        foreach (Offset o in tParams.Offsets)
                        {
                            if (o.Flag.Equals(Offset.FlagOffsets.Numbers))
                            {
                                if (str[i] >= '0' && str[i] <= '9')
                                {
                                    data[(i * tParams.ByteSkipAmount) + tParams.ByteStart] = (byte)(((((int)str[i]) - 48) + o.ByteOffset) * o.SkipModifier);
                                    keyFound = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion

                if (!keyFound)
                    throw new Exception("Error: \"" + str[i].ToString() + "\" not found in StringToByte setup.");
            }

            return data;
        }
        #endregion

        #region ByteToString()
        public static string ByteToString(byte[] data, TextDecodingParameters tParams)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = tParams.ByteStart; i < data.Length; i = i + tParams.ByteSkipAmount)
            {
                bool keyFound = false;

                //Needs to be first, as it can be ASCII standard and some special mappings.
                #region SPECIAL MAPPING
                if ((tParams.Format & StringFormatFlag.NeedsSpecialMapping) == StringFormatFlag.NeedsSpecialMapping)
                {
                    if (tParams.SpecialMapping.ContainsMany(data[i]))
                    {
                        sb.Append(tParams.SpecialMapping.FindOne(data[i]));
                        keyFound = true;
                    }
                }
                #endregion

                #region ASCII STANDARD
                if (!keyFound)
                {
                    if ((tParams.Format & StringFormatFlag.ASCIIStandard) == StringFormatFlag.ASCIIStandard)
                    {
                        sb.Append((char)(int)data[i]);
                        keyFound = true;
                    }
                }
                #endregion

                #region ASCII UPPERCASE
                if (!keyFound)
                {
                    if ((tParams.Format & StringFormatFlag.ASCIIUpper) == StringFormatFlag.ASCIIUpper)
                    {
                        foreach (Offset o in tParams.Offsets)
                        {
                            if (o.Flag.Equals(Offset.FlagOffsets.Upper))
                            {
                                if (Convert.ToInt32(data[i]) >= o.ByteOffset && Convert.ToInt32(data[i]) <= (o.ByteOffset + (26 * o.SkipModifier)))
                                {
                                    sb.Append(((char)(((((int)data[i]) / o.SkipModifier) + 65) - o.ByteOffset)));
                                    keyFound = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region ASCII LOWERCASE
                if (!keyFound)
                {
                    if ((tParams.Format & StringFormatFlag.ASCIILower) == StringFormatFlag.ASCIILower)
                    {
                        foreach (Offset o in tParams.Offsets)
                        {
                            if (o.Flag.Equals(Offset.FlagOffsets.Lower))
                            {
                                if (Convert.ToInt32(data[i]) >= o.ByteOffset && Convert.ToInt32(data[i]) <= (o.ByteOffset + (26 * o.SkipModifier)))
                                {
                                    sb.Append(((char)(((((int)data[i]) / o.SkipModifier) + 71) - o.ByteOffset)));
                                    keyFound = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion

                #region ASCII NUMBERS
                if (!keyFound)
                {
                    if ((tParams.Format & StringFormatFlag.ASCIINumbers) == StringFormatFlag.ASCIINumbers)
                    {
                        foreach (Offset o in tParams.Offsets)
                        {
                            if (o.Flag.Equals(Offset.FlagOffsets.Numbers))
                            {
                                if (Convert.ToInt32(data[i]) >= o.ByteOffset && Convert.ToInt32(data[i]) <= (o.ByteOffset + (10 * o.SkipModifier)))
                                {
                                    sb.Append(((char)(((((int)data[i]) / o.SkipModifier) + 48) - o.ByteOffset)));
                                    keyFound = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion

                if (!keyFound)
                    throw new Exception("Error: \"0x" + data[i].ToString("X2") + "\" not found in ByteToString setup.");
            }

            return sb.ToString();
        }
        #endregion

        #region DetermineRank()
        public delegate int ConvertByteArrayToInt(byte[] val);

        public static class ByteArrayToInt
        {
            public static int Standard(byte[] score)
            {
                return HiConvert.ByteArrayHexToInt(score);
            }

            public static int Reversed(byte[] score)
            {
                return HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(score));
            }

            public static int Hex(byte[] score)
            {
                return HiConvert.ByteArrayHexAsHexToInt(score);
            }

            public static int HexReversed(byte[] score)
            {
                return HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(score));
            }

            public static int BCD(byte[] score)
            {
                return HiConvert.ByteArraySingleBCDToInt(score);
            }

            public static int InverseBCD(byte[] score)
            {
                return -HiConvert.ByteArraySingleBCDToInt(score);
            }

            public static int BCDReversed(byte[] score)
            {
                return HiConvert.ByteArraySingleBCDToInt(HiConvert.ReverseByteArray(score));
            }

            //Custom methods, used only for one parent and its clones. Naming is based on the parent's name.
            #region Custom
            public static int _8ballact(byte[] score)
            {
                int toReturn = 0;
                for (int i = 0; i < score.Length; i++)
                {
                    if (score[i] == 0x1c)
                        toReturn += (int)Math.Pow(10.0, (double)(score.Length - i - 1));
                    else if (score[i] == 0x1d)
                        toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 2;
                    else if (score[i] == 0x1e)
                        toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 3;
                    else if (score[i] == 0x1f)
                        toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 4;
                    else if (score[i] == 0x20)
                        toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 5;
                    else if (score[i] == 0x21)
                        toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 6;
                    else if (score[i] == 0x22)
                        toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 7;
                    else if (score[i] == 0x23)
                        toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 8;
                    else if (score[i] == 0x24)
                        toReturn += ((int)Math.Pow(10.0, (double)(score.Length - i - 1))) * 9;
                }

                return toReturn;
            }
            #endregion

            public static ConvertByteArrayToInt CustomInternal(ConvertByteArrayToInt conversionFunction, WrapperByteArray internalFunction)
            {
                return delegate(byte[] data) { return conversionFunction(internalFunction(data)); };
            }
        }

        public static int DetermineRank(int score, Regex pattern, object hiscoreData, ConvertByteArrayToInt methodToCallOnData)
        {
            //Get all the fields into a FieldInfo array.
            FieldInfo[] info = hiscoreData.GetType().GetFields();

            List<FieldInfo> sortedInfo = new List<FieldInfo>();

            //Add all the fields
            sortedInfo.AddRange(info);

            //Remove any fields that do NOT match this pattern in adjusters.
            sortedInfo.RemoveAll(new NotMatching(pattern).NotMatch);

            //Sort by the numeric portion of the pattern in adjusters in ascending numerical order.
            //(i.e. Score1, Score2, ... Scoren or Name1, Name2, ... Namen)
            sortedInfo.Sort(new FieldInfoNameComparator(FieldInfoNameComparator.Ordering.Ascending));

            int rankCounter = 0;
            foreach (FieldInfo fi in sortedInfo)
            {
                //If we match our pattern, check against our GetValue method to determine if we have a larger
                //score.
                if (pattern.IsMatch(fi.Name))
                {
                    if (score > methodToCallOnData((byte[])fi.GetValue(hiscoreData)))
                        return rankCounter;
                }
                rankCounter++;
            }

            //If we don't have a larger score value, rankCounter will be equal to NumEntries.
            return rankCounter;
        }
        #endregion

        #region AdjustScores()
        public static object AdjustScores(int rank, object hiscoreData, List<Regex> adjusters)
        {
            //Get all the fields into a FieldInfo array.
            FieldInfo[] info = hiscoreData.GetType().GetFields();

            //Create a list of FieldInfo for each Regex pattern in adjusters.
            foreach (Regex pattern in adjusters)
            {
                List<FieldInfo> sortedInfo = new List<FieldInfo>();
                //Add all the fields
                sortedInfo.AddRange(info);

                //Remove any fields that do NOT match this pattern in adjusters.
                sortedInfo.RemoveAll(new NotMatching(pattern).NotMatch);

                //Sort by the numeric portion of the pattern in adjusters in descending numerical order.
                //(i.e. Score23, Score22, ... Score1 or Name23, Name22, ... Name1)
                sortedInfo.Sort(new FieldInfoNameComparator(FieldInfoNameComparator.Ordering.Descending));

                //Go through and move down data to the next lowest rank up until the rank we will replace with.
                for (int i = 0; i < sortedInfo.Count - (rank + 1); i++)
                {
                    object o = sortedInfo[i + 1].GetValue(hiscoreData);

                    //Byte arrays need to be set as a new value as it would pass by reference.
                    if (o is byte[])
                    {
                        byte[] b = new byte[((byte[])o).Length];
                        HiConvert.ByteArrayCopy(b, (byte[])o);
                        sortedInfo[i].SetValue(hiscoreData, b);
                    }
                    else if (o is byte)
                    {
                        sortedInfo[i].SetValue(hiscoreData, o);
                    }
                }
            }

            return hiscoreData;
        }
        #endregion

        #region ReplaceNew()
        public delegate byte[] ConvertValueToByteArray(string val);
        public delegate byte[] ConvertScore(int score, int length);

        public static class ConvertValuesToBytes
        {
            public static byte[] ConvertByte(string data)
            {
                return new byte[] { (byte)Convert.ToInt32(data) };
            }

            public static ConvertValueToByteArray ConvertData(int data, int length, ConvertScore func)
            {
                return delegate(string d) { return func(data, length); };
            }

            public static ConvertValueToByteArray ConvertData(int data, int length, ConvertScore func, WrapperByteArray externalFunction)
            {
                return delegate(string d) { return externalFunction(func(data, length)); };
            }

            public static ConvertValueToByteArray ConvertSwitch(OneToManyMap<byte[], string> dict)
            {
                return delegate(string d) { return dict.FindOne(d); };
            }

            public static ConvertValueToByteArray PadDataReverse(string data, int dataLength, string paddedValue, string numberValue)
            {
                StringBuilder sb = new StringBuilder();
                String strScore = data.ToString().PadLeft(dataLength, 'F');

                for (int i = 0; i < dataLength; i++)
                {
                    if (strScore[i].Equals('F'))
                        sb.Insert(0, paddedValue);
                    else
                        sb.Insert(0, numberValue + strScore[i].ToString());
                }

                return delegate(string d) { return HiConvert.HexStringToByteArray(sb.ToString()); };
            }

            public static ConvertValueToByteArray PadData(string data, int dataLength, string paddedValue, string numberValue)
            {
                StringBuilder sb = new StringBuilder();
                String strScore = data.ToString().PadLeft(dataLength, 'F');

                for (int i = 0; i < dataLength; i++)
                {
                    if (strScore[i].Equals('F'))
                        sb.Append(paddedValue);
                    else
                        sb.Append(numberValue + strScore[i].ToString());
                }

                return delegate(string d) { return HiConvert.HexStringToByteArray(sb.ToString()); };
            }

            public static ConvertValueToByteArray TwoToThreeEncoding(string data, int numberOfCharacters)
            {
                int val = 0;

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] >= 'A' && data[i] <= 'Z')
                        val += ((int)data[i] - (65 - 0x01)) * System.Convert.ToInt32(Math.Pow(numberOfCharacters, data.Length - 1 - i));
                }

                return delegate(string d) { return HiConvert.HexStringToByteArray(val.ToString("X").PadLeft(4, '0')); };
            }

            //Custom methods, used only for one parent and its clones. Naming is based on the parent's name.
            #region Custom

            public static byte[] _8ballact(string data)
            {
                byte[] toReturn = new byte[6];
                string scoreStr = data.PadLeft(toReturn.Length, '0');
                bool isPad = true;
                for (int i = 0; i < scoreStr.Length; i++)
                {
                    //Convert to switch.
                    switch (scoreStr[i])
                    {
                        case '0':
                            if (isPad)
                                toReturn[i] = 0x00;
                            else
                                toReturn[i] = 0x1b;
                            break;
                        case '1':
                            toReturn[i] = 0x1c;
                            isPad = false;
                            break;
                        case '2':
                            toReturn[i] = 0x1d;
                            isPad = false;
                            break;
                        case '3':
                            toReturn[i] = 0x1e;
                            isPad = false;
                            break;
                        case '4':
                            toReturn[i] = 0x1f;
                            isPad = false;
                            break;
                        case '5':
                            toReturn[i] = 0x20;
                            isPad = false;
                            break;
                        case '6':
                            toReturn[i] = 0x21;
                            isPad = false;
                            break;
                        case '7':
                            toReturn[i] = 0x22;
                            isPad = false;
                            break;
                        case '8':
                            toReturn[i] = 0x23;
                            isPad = false;
                            break;
                        case '9':
                            toReturn[i] = 0x24;
                            isPad = false;
                            break;
                    }
                }
                return toReturn;
            }

            public static byte[] _1943(string data)
            {
                byte[] toReturn = new byte[8];
                byte[] originalScore = HiConvert.IntToByteArraySingleBCD(Convert.ToInt32(data), 8);
                bool isPad = true;

                for (int i = 0; i < toReturn.Length; i++)
                {
                    if (originalScore[i] == 0x00 && isPad)
                        toReturn[i] = 0x24;
                    else
                    {
                        isPad = false;
                        toReturn[i] = originalScore[i];
                    }
                }

                return toReturn;
            }

            public static byte[] _1944(string data)
            {
                return HiConvert.IntToByteArraySingleBCD(Convert.ToInt32(data.Replace("%", String.Empty)), 3);
            }

            public static byte[] actionhw(string data)
            {
                return HiConvert.IntToByteArraySingleBCD(Convert.ToInt32(data.Replace(".", string.Empty)), 2);
            }

            public static byte[] airwolf(string data)
            {
                StringBuilder sb = new StringBuilder();
                String strScore = data.ToString().PadLeft(7, 'F');

                for (int i = 0; i < 7; i++)
                {
                    if (strScore[i].Equals('F'))
                        sb.Append("00");
                    else
                        sb.Append((Convert.ToInt32(strScore[i].ToString()) + 1).ToString("X2"));
                }

                return HiConvert.HexStringToByteArray(sb.ToString());
            }

            public static ConvertValueToByteArray astdelux(string data, TextDecodingParameters tParams, string fName)
            {
                //fName is not used here, but is the default custom name.
                string[] sVals = data.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                int score = Convert.ToInt32(sVals[0]);
                string name = sVals[1];

                byte checksum8 = 0x00;
                byte[] datascore =
                    ConvertData(score, 3, HiConvert.IntToByteArrayHex, HiConvert.ReverseByteArray)(sVals[0]);

                byte[] dataname = ConvertName(tParams)(sVals[1]);

                for (int i = 0; i < datascore.Length; i++)
                    checksum8 += datascore[i];

                for (int i = 0; i < dataname.Length; i++)
                    checksum8 += dataname[i];

                return delegate(string d) { return new byte[] { checksum8 }; };
            }

            public static ConvertValueToByteArray apb(string data, TextDecodingParameters tParams, string fName)
            {
                byte[] dataname = ConvertName(tParams)(data);

                switch (fName.ToUpper())
                {
                    case "FIRSTNAME":
                        return delegate(string d) { return new byte[] { dataname[0] }; };
                    case "MIDDLENAME":
                        return delegate(string d) { return new byte[] { dataname[1] }; };
                    case "LASTNAME":
                        return delegate(string d) { return new byte[] { dataname[2] }; };
                }

                return delegate(string d) { return new byte[] { 0 }; };
            }

            public static byte[] bankp(string data)
            {
                string[] saTime = data.Split(new char[] { ':' });
                return HiConvert.ReverseByteArray(HiConvert.IntToByteArrayHexAsHex(
                    ((Convert.ToInt32(saTime[0]) * 60) + Convert.ToInt32(saTime[1])), 2));
            }

            public static byte[] barrier(string data)
            {
                int score1 = System.Convert.ToInt32(data.PadLeft(5, '0').Substring(0, 2));
                int score2 = System.Convert.ToInt32(data.PadLeft(5, '0').Substring(2, 3));

                byte[] b1 = HiConvert.IntToByteArrayHexAsHex(score1, 2);
                byte[] b2 = HiConvert.IntToByteArrayHexAsHex(score2, 2);

                return new byte[] { b1[0], b1[1], b2[0], b2[1] };
            }

            public static byte[] bloodbroHi(string data)
            {
                string full = data.PadLeft(8, '0');
                string filled = string.Empty;
                for (int i = 0; i < full.Length; i++)
                    filled += "003" + full[i].ToString();

                return HiConvert.HexStringToByteArray(filled);
            }

            public static byte[] brkthru(string data)
            {
                return new byte[] { HiConvert.IntToByteArrayHex(Convert.ToInt32(data), 4)[1] };
            }

            public static byte[] bloodbroArea(string data)
            {
                return HiConvert.IntToByteArrayHex(Convert.ToInt32(data.Replace("-", "")), 1);
            }

            public static byte[] cabal(string data)
            {
                if (data.Equals("ALL"))
                    return new byte[] { (byte)20 };
                else
                {
                    int first = Convert.ToInt32(data.Substring(0, 1));
                    int second = Convert.ToInt32(data.Substring(2, 1));

                    return new byte[] { (byte)(((first - 1) * 4) + (second - 1)) };
                }
            }

            public static byte[] cleopatr(string data)
            {
                if (data == "ALL" || Convert.ToByte(data) >= 0x64)
                    return new byte[] { 0x64 }; // Level 100 (ALL)

                return new byte[] { Convert.ToByte(data) };
            }

            //TODO: Figure this out.
            public static byte[] dariusg(string data)
            {
                return HiConvert.IntToByteArrayHex(Convert.ToInt32(data), 2);
            }

            public static byte[] ddribble_date(string data)
            {
                string[] dataArray = data.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                return new byte[] {
                    HiConvert.IntToByteArrayHex(Convert.ToInt32(dataArray[0]), 1)[0], 
                    HiConvert.IntToByteArrayHex(Convert.ToInt32(dataArray[1]), 1)[0]};
            }

            public static byte[] ddribble_percent(string data)
            {
                // if you have 100% in FG or FT the program set the AAAA bytes.
                int val;
                if (data == "1" || data == "Perfect")
                {
                    val = 0xAAAA;
                    return HiConvert.HexStringToByteArray(val.ToString("X4"));
                }
                else if (data.Substring(0, 1) == ".")
                    val = System.Convert.ToInt16(data.Substring(1, data.Length - 1));
                else if (data.Substring(0, 2) == "0.")
                    val = System.Convert.ToInt16(data.Substring(2, data.Length - 2));
                else
                    val = System.Convert.ToInt16(data);

                return HiConvert.HexStringToByteArray(val.ToString("D4"));
            }

            public static byte[] digdug2(string data)
            {
                StringBuilder sb = new StringBuilder();
                String strScore = data.PadLeft(6, '0');

                for (int i = 0; i < strScore.Length; i++)
                    sb.Insert(0, "0" + strScore[i].ToString());

                return HiConvert.ReverseByteArray(HiConvert.HexStringToByteArray(sb.ToString()));
            }

            //TODO: Deal with this: dkong3 are reversed PadDatas.
            public static byte[] dkong3(string data)
            {
                StringBuilder sb = new StringBuilder();
                byte[] byteArray = HiConvert.IntToByteArrayHex(Convert.ToInt32(data), 4);

                for (int i = 1; i < byteArray.Length; i++)
                {
                    string byteStr = byteArray[i].ToString("X2");
                    sb.Append("3" + byteStr[0]);
                    sb.Append("3" + byteStr[1]);
                }

                return HiConvert.HexStringToByteArray(sb.ToString());
            }

            public static byte[] esprade_ls(string lastScore)
            {
                return new byte[] { 0x00, Convert.ToByte(Convert.ToInt32(lastScore) + 0x88) };
            }

            public static byte[] extrmatn(string round)
            {
                if (round.Equals("ALL"))
                    return new byte[] { 0x08 };
                else
                    return new byte[] { Convert.ToByte(Convert.ToInt32(round) - 1) };
            }

            #endregion

            //For names.
            public static ConvertValueToByteArray ConvertName(TextDecodingParameters decodingParameters)
            {
                return delegate(string str) { return StringToByte(str, decodingParameters); };
            }

            public static ConvertValueToByteArray ConvertName(TextDecodingParameters decodingParameters, WrapperByteArray externalFunction)
            {
                return delegate(string str) { return externalFunction(StringToByte(str, decodingParameters)); };
            }
        }

        public static object ReplaceNew(int rank, object hiscoreData, List<Placement> placements)
        {
            //Get all the fields into a FieldInfo array.
            FieldInfo[] info = hiscoreData.GetType().GetFields();

            foreach (Placement p in placements)
            {
                if (p.IsTopScorePlacement && rank != 0)
                {
                }
                else
                {
                    List<FieldInfo> sortedInfo = new List<FieldInfo>();
                    //Add all the fields
                    sortedInfo.AddRange(info);

                    //Remove any fields that do NOT match this pattern in adjusters.
                    sortedInfo.RemoveAll(new NotMatching(p.Pattern).NotMatch);

                    //Sort by the numeric portion of the pattern in adjusters in ascending numerical order.
                    //(i.e. Score1, Score2, ... Scoren or Name1, Name2, ... Namen)
                    sortedInfo.Sort(new FieldInfoNameComparator(FieldInfoNameComparator.Ordering.Ascending));

                    object o = sortedInfo[rank].GetValue(hiscoreData);

                    //Byte arrays need to be set as a new value as it would pass by reference.
                    if (o is byte[])
                    {
                        byte[] b = new byte[((byte[])o).Length];
                        HiConvert.ByteArrayCopy(b, p.CallingMethod(p.Value));
                        sortedInfo[rank].SetValue(hiscoreData, b);
                    }
                    else if (o is byte)
                    {
                        byte[] b = new byte[1];
                        HiConvert.ByteArrayCopy(b, p.CallingMethod(p.Value));
                        sortedInfo[rank].SetValue(hiscoreData, b[0]);
                    }
                }
            }

            return hiscoreData;
        }
        #endregion

        #region EmptyScores()
        public static object EmptyScores(object hiscoreData, Regex pattern, ConvertValueToByteArray methodToCall)
        {
            //Get all the fields into a FieldInfo array.
            FieldInfo[] info = hiscoreData.GetType().GetFields();

            List<FieldInfo> parsedInfo = new List<FieldInfo>();
            //Add all the fields
            parsedInfo.AddRange(info);

            //Remove any fields that do NOT match this pattern in adjusters.
            parsedInfo.RemoveAll(new NotMatching(pattern).NotMatch);

            foreach (FieldInfo fi in parsedInfo)
            {
                object o = fi.GetValue(hiscoreData);

                //Byte arrays need to be set as a new value as it would pass by reference.
                if (o is byte[])
                {
                    byte[] b = new byte[((byte[])o).Length];
                    HiConvert.ByteArrayCopy(b, methodToCall("0"));
                    fi.SetValue(hiscoreData, b);
                }
                else if (o is byte)
                {
                    byte[] b = new byte[1];
                    HiConvert.ByteArrayCopy(b, methodToCall("0"));
                    fi.SetValue(hiscoreData, b[0]);
                }
            }

            return hiscoreData;
        }
        #endregion

        #region HiToString()
        public delegate string ConvertByteArrayToString(byte[] val);

        public static class ConvertByteArraysToStrings
        {
            public static string Standard(byte[] score)
            {
                return HiConvert.ByteArrayHexToInt(score).ToString();
            }

            public static string Reversed(byte[] score)
            {
                return HiConvert.ByteArrayHexToInt(HiConvert.ReverseByteArray(score)).ToString();
            }

            public static string Hex(byte[] score)
            {
                return HiConvert.ByteArrayHexAsHexToInt(score).ToString();
            }

            public static string HexReversed(byte[] score)
            {
                return HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(score)).ToString();
            }

            public static string BCD(byte[] score)
            {
                return HiConvert.ByteArraySingleBCDToInt(score).ToString();
            }

            public static string BCDReversed(byte[] score)
            {
                return HiConvert.ByteArraySingleBCDToInt(HiConvert.ReverseByteArray(score)).ToString();
            }

            //Custom methods, used only for one parent and its clones. Naming is based on the parent's name.
            #region Custom

            //TODO: Perhaps allow for rules for appending and prepending other text to displayed?
            public static string _1944(byte[] score)
            {
                return HiConvert.ByteArraySingleBCDToInt(score).ToString() + "%";
            }

            public static string actionhw(byte[] stage)
            {
                string sStage = HiConvert.ByteArraySingleBCDToInt(stage).ToString();
                return sStage.Substring(0, 1) + "." + sStage.Substring(1, 1);
            }

            public static string airwolf(byte[] score)
            {
                byte[] normalized = new byte[score.Length];
                for (int i = 0; i < normalized.Length; i++)
                {
                    if (score[i] == 0)
                        normalized[i] = 0x01;
                    else
                        normalized[i] = score[i];
                }
                return HiConvert.ByteArraySingleBCDToInt(HiConvert.IncrementByteArray(normalized, -1)).ToString();
            }

            //This is an example of a PadData ToString.
            //TODO: Should make this a default function for PadData.
            public static string arkarea(byte[] data)
            {
                StringBuilder sb = new StringBuilder();

                //The second digit of the byte is the score value.
                for (int i = 0; i < data.Length; i++)
                    sb.Append(data[i].ToString("X2").Substring(1, 1));

                return Convert.ToInt32(sb.ToString()).ToString();
            }

            public static string athena(byte[] data)
            {
                StringBuilder sb = new StringBuilder();

                //The second digit of the byte is the score value.
                for (int i = 0; i < data.Length; i++)
                    sb.Append(data[i].ToString("X2").Substring(1, 1));

                return Convert.ToInt32(sb.ToString()).ToString();
            }

            public static string bankp(byte[] time)
            {
                int iTime = HiConvert.ByteArrayHexAsHexToInt(HiConvert.ReverseByteArray(time));

                //Format mmm:ss
                int mins = iTime / 60;
                int secs = iTime % 60;
                return mins.ToString() + ":" + secs.ToString().PadLeft(2, '0');
            }

            public static string bloodbroArea(byte[] area)
            {
                int iArea = Int32.Parse(area[0].ToString("X2"));
                return (iArea / 10).ToString() + "-" + (iArea % 10).ToString();
            }

            public static string cabal(byte[] round)
            {
                int iRound = (int)round[0];
                if (iRound == 20)
                    return "ALL";
                else
                {
                    int first = (iRound / 4) + 1;
                    int second = (iRound % 4) + 1;
                    return first.ToString() + "-" + second.ToString();
                }
            }

            public static ConvertByteArrayToString cclimber(TextDecodingParameters decodingParameters)
            {
                return delegate(byte[] data)
                {
                    if (IsNichibutsu(data))
                        return "Nichibutsu";
                    else
                        return ByteToString(data, decodingParameters);
                };
            }

            public static string cleopatr(byte[] level)
            {
                if (level[0] == 0x64)
                    return "ALL";
                return level[0].ToString();
            }

            //TODO: Figure this out.
            public static string dariusg(byte[] zone)
            {
                return HiConvert.ByteArrayHexToInt(zone).ToString();
            }

            public static string ddribble_date(byte[] date)
            {
                return date[0].ToString("X2").TrimStart(new char[] { '0' }) +
                    "/" + date[1].ToString("X2").TrimStart(new char[] { '0' });
            }

            public static string ddribble_percent(byte[] data)
            {
                StringBuilder str = new StringBuilder();
                if (data[0] == 0xaa)
                    str.Append("Perfect");
                else
                {
                    str.Append(".");
                    str.Append(HiConvert.ByteArrayHexToInt(data));
                }

                return str.ToString();
            }

            public static string digdug2(byte[] data)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    if ((byte)data[i] == 0x20) //Empty byte for display purposes.
                        sb.Append("0");
                    else
                        sb.Append((byte)data[i]);
                }

                return sb.ToString();
            }

            public static string dkong3(byte[] data)
            {
                StringBuilder sb = new StringBuilder();

                //The second digit of the byte is the score value.
                for (int i = 0; i < data.Length; i++)
                    sb.Append(data[i].ToString("X2").Substring(1, 1));

                return Convert.ToInt32(sb.ToString()).ToString();
            }

            //public static string esprade_score(byte[] score)
            //{

            //}

            public static string extrmatn(byte[] round)
            {
                if (Convert.ToInt32(round[0]) >= 8)
                    return "ALL";
                else
                    return (Convert.ToInt32(round[0]) + 1).ToString();
            }

            public static string galaga(byte[] data)
            {
                StringBuilder sb = new StringBuilder();

                //The second digit of the byte is the score value.
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].Equals(0x24))
                        sb.Insert(0, 0);
                    else
                        sb.Insert(0, data[i].ToString("X2").Substring(1, 1));
                }

                return Convert.ToInt32(sb.ToString()).ToString();
            }

            private static bool IsNichibutsu(byte[] data)
            {
                byte[] nichi = new byte[] { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x52, 0x52 };

                if (data.Length != nichi.Length)
                    return false;

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] != nichi[i])
                        return false;
                }

                return true;
            }

            #endregion

            public static ConvertByteArrayToString MultiplyDisplayed(ConvertByteArrayToString conversionFunction, int multiplier)
            {
                return delegate(byte[] data) { return (Convert.ToInt32(conversionFunction(data)) * multiplier).ToString(); };
            }

            public static ConvertByteArrayToString AddToDisplayed(ConvertByteArrayToString conversionFunction, int valueToAdd)
            {
                return delegate(byte[] data) { return (Convert.ToInt32(conversionFunction(data)) + valueToAdd).ToString(); };
            }

            public static ConvertByteArrayToString CustomInternal(ConvertByteArrayToString conversionFunction, WrapperByteArray internalFunction)
            {
                return delegate(byte[] data) { return conversionFunction(internalFunction(data)); };
            }

            public static ConvertByteArrayToString ConvertSwitch(OneToManyMap<byte[], string> dict)
            {
                return delegate(byte[] data) { return dict.FindMany(data); };
            }

            public static ConvertByteArrayToString TwoToThreeEncoding(TextDecodingParameters decodingParameters, int numberOfCharacters)
            {
                return delegate(byte[] data)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < data.Length; i++)
                        sb.Append(data[i].ToString("X2"));

                    string name = sb.ToString();

                    int val = System.Convert.ToInt32(name, 16);

                    int everySecond = numberOfCharacters;
                    int everyFirst = everySecond * everySecond;

                    byte[] decodedData = new byte[3];

                    decodedData[0] = (byte)(System.Convert.ToInt32((val / everyFirst).ToString("X2"), 16) + 64);
                    int restOfLastTwo = val - ((val / everyFirst) * everyFirst);

                    decodedData[1] = (byte)(System.Convert.ToInt32((restOfLastTwo / everySecond).ToString("X2"), 16) + 64);
                    int last = restOfLastTwo - ((restOfLastTwo / everySecond) * everySecond);

                    decodedData[2] = (byte)(System.Convert.ToInt32(last.ToString("X2"), 16) + 64);

                    return ByteToString(decodedData, decodingParameters);
                };
            }

            //For converting names.
            public static ConvertByteArrayToString ConvertName(TextDecodingParameters decodingParameters)
            {
                return delegate(byte[] data) { return ByteToString(data, decodingParameters); };
            }

            public static ConvertByteArrayToString ConvertName(TextDecodingParameters decodingParameters, WrapperByteArray internalFunction)
            {
                return delegate(byte[] data) { return ByteToString(internalFunction(data), decodingParameters); };
            }
        }

        public static string HiToString(object hiscoreData, List<DisplayData> data)
        {
            string toReturn = string.Empty;

            //Get all the fields into a FieldInfo array.
            FieldInfo[] info = hiscoreData.GetType().GetFields();

            //Create a list of lists, they should be the same size, if not we have a problem.
            List<List<FieldInfo>> parsedInfoLists = new List<List<FieldInfo>>();

            int baseLine = 0;

            foreach (DisplayData d in data)
            {
                List<FieldInfo> parsedInfo = new List<FieldInfo>();
                //Add all the fields
                parsedInfo.AddRange(info);

                if (d.Pattern == null)
                    parsedInfo.Clear();
                else
                    //Remove any fields that do NOT match this pattern in data.
                    parsedInfo.RemoveAll(new NotMatching(d.Pattern).NotMatch);

                parsedInfo.Sort(new FieldInfoNameComparator(FieldInfoNameComparator.Ordering.Ascending));

                parsedInfoLists.Add(parsedInfo);

                if (parsedInfo.Count > baseLine)
                    baseLine = parsedInfo.Count;
            }

            for (int i = 0; i < baseLine; i++)
            {
                for (int j = 0; j < parsedInfoLists.Count; j++)
                {
                    if (parsedInfoLists[j].Count == 0)
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
                        object o = parsedInfoLists[j][i].GetValue(hiscoreData);

                        byte[] b = new byte[1];
                        if (o is byte[])
                            b = (byte[])o;
                        else if (o is byte)
                            b = new byte[] { (byte)o };

                        toReturn += data[j].CallingMethod(b);
                    }
                    if (j != parsedInfoLists.Count - 1)
                        toReturn += "|";
                }

                toReturn += Environment.NewLine;
            }

            return toReturn;
        }
        #endregion
    }
}