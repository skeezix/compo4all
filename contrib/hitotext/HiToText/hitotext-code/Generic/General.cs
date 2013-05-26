using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using HTTF = HiToText.Formatting;
using VBA = HiToText.Formatting.ConvertValueToByteArray;
using SetScore = HiToText.Formatting.ConvertValuesToBytes;
using TextParams = HiToText.Utils.TextDecodingParameters;
using HiToText.HXML;
using HiToText.Utils;
using System.IO;

namespace HiToText.Generic
{
    class General : Hiscore
    {
        private TextParams tParams = new TextParams();
        List<SetMapping> listOfSetMappings;
        Dictionary<string, OneToManyMap<byte[], string>> switchMaps = 
            new Dictionary<string, OneToManyMap<byte[], string>>();

        private HiscoreData hiscoreData;

        public General(HiToTextEntry entry)
        {
            m_format = string.Join("|", entry.Header.Fields);
            m_gamesSupported = string.Join(",", entry.Header.Games);
            foreach(HiToTextEntryHeaderName name in entry.Header.Extensions)
                m_extensionsRequired += name.Value + ",";
            m_extensionsRequired = m_extensionsRequired.TrimEnd(new char[] { ',' });

            tParams = GetTextParameters(entry);

            switchMaps = GetSwitchMaps(entry);

            hiscoreData = new HiscoreData(entry);

            listOfSetMappings = SetupMappings(entry);
        }

        private TextParams GetTextParameters(HiToTextEntry entry)
        {
            TextParams tParams = new TextParams();
            if (entry.Header.TextParameters == null)
                return tParams;

            tParams.Format = GetFormat(entry);

            if (entry.Header.TextParameters.ByteSkipAmountSpecified)
                tParams.ByteSkipAmount = entry.Header.TextParameters.ByteSkipAmount;

            if (entry.Header.TextParameters.ByteStartSpecified)
                tParams.ByteStart = entry.Header.TextParameters.ByteStart;

            if (entry.Header.TextParameters.ByteSkipData == null)
                tParams.ByteSkipData = 0x00;
            else
            {
                string sBSD = entry.Header.TextParameters.ByteSkipData;
                if (sBSD.Substring(0, 2).Equals("0x"))
                    sBSD = sBSD.Substring(2);
                if (!sBSD.Equals(string.Empty))
                {
                    try
                    {
                        tParams.ByteSkipData = HiConvert.IntToByteArrayHexAsHex(Convert.ToInt32(sBSD), 1)[0];
                    }
                    catch { }
                }
            }

            if (entry.Header.TextParameters.Offsets != null)
            {
                foreach (HiToTextEntryHeaderTextParametersOffsetsOffset o in entry.Header.TextParameters.Offsets.Offset)
                {
                    Offset.FlagOffsets offsetFlag = GetOffsetFlag(o.Type);

                    string sByte = o.StartByte;
                    if (sByte.Substring(0, 2).Equals("0x"))
                        sByte = sByte.Substring(2);

                    int skipMod = 1;
                    if (o.SkipModifierSpecified)
                        skipMod = Convert.ToInt32(o.SkipModifier);

                    tParams.AddOffset(new Offset(
                        HiConvert.ByteArrayHexAsHexToInt(HiConvert.HexStringToByteArray(sByte)), skipMod, offsetFlag));
                }
            }
            if (entry.Header.TextParameters.SpecialMapping != null)
            {
                foreach (HiToTextEntryHeaderTextParametersSpecialMappingMap map in entry.Header.TextParameters.SpecialMapping.Map)
                {
                    char c = map.Char[0];
                    string sByte = map.Byte;
                    if (sByte.Substring(0, 2).Equals("0x"))
                        sByte = sByte.Substring(2);
                    byte b = HiConvert.HexStringToByteArray(sByte)[0];
                    tParams.AddMapping(c, b);
                }
            }

            return tParams;
        }

        private Dictionary<string, OneToManyMap<byte[], string>> GetSwitchMaps(HiToTextEntry entry)
        {
            Dictionary<string, OneToManyMap<byte[], string>> toReturn =
                new Dictionary<string, OneToManyMap<byte[], string>>();

            if (entry.Header.TextParameters == null)
                return toReturn;

            if (entry.Header.TextParameters.SwitchMaps == null)
                return toReturn;

            foreach (HiToTextEntryHeaderTextParametersSwitchMapsSwitchMap sMap in entry.Header.TextParameters.SwitchMaps.SwitchMap)
            {
                string sDefaultOne = sMap.DefaultOne;
                string[] sDefaultOnes =
                    sDefaultOne.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < sDefaultOnes.Length; i++)
                {
                    if (sDefaultOnes[i].Substring(0, 2).Equals("0x"))
                        sDefaultOnes[i] = sDefaultOnes[i].Substring(2);
                }

                sDefaultOne = String.Join(string.Empty, sDefaultOnes);
                byte[] defaultOne = HiConvert.HexStringToByteArray(sDefaultOne);

                string defaultMany = sMap.DefaultMany;
                OneToManyMap<byte[], string> map = new OneToManyMap<byte[], string>();
                map.AddDefault(defaultOne, defaultMany);

                foreach (HiToTextEntryHeaderTextParametersSwitchMapsSwitchMapMapping sMapping in sMap.Mapping)
                {
                    string sOne = sMapping.One;
                    string[] sOnes = sOne.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < sOnes.Length; i++)
                    {
                        if (sOnes[i].Substring(0, 2).Equals("0x"))
                            sOnes[i] = sOnes[i].Substring(2);
                    }

                    sOne = String.Join(string.Empty, sOnes);
                    byte[] bOne = HiConvert.HexStringToByteArray(sOne);

                    map.AddMapping(bOne, sMapping.Many);
                }

                toReturn.Add(sMap.Name, map);
            }

            return toReturn;
        }

        private Offset.FlagOffsets GetOffsetFlag(string flag)
        {
            switch (flag.ToUpper())
            {
                case "UPPER":
                    return Offset.FlagOffsets.Upper;
                case "LOWER":
                    return Offset.FlagOffsets.Lower;
                case "NUMBERS":
                    return Offset.FlagOffsets.Numbers;
                default:
                    return Offset.FlagOffsets.Invalid;
            }
        }

        private List<SetMapping> SetupMappings(HiToTextEntry entry)
        {
            List<SetMapping> toReturn = new List<SetMapping>();

            foreach (HiToTextEntryFieldName fieldName in entry.SetStructure)
            {
                SetMapping mapping = new SetMapping(fieldName.Name);
                mapping.FieldType = Type.GetType(GetValidFieldType(fieldName.FieldType));
                mapping.ConversionType = fieldName.ConversionType;

                if (fieldName.ConstantSpecified)
                    mapping.Data = fieldName.Constant;
                if (fieldName.ExternalWrapper != null)
                    mapping.ExternalWrapper = GetWrapper(fieldName.ExternalWrapper);

                if (fieldName.ConversionType.ToUpper().Equals("NAME"))
                {
                    if (mapping.ExternalWrapper != null)
                        mapping.ConversionMethod = SetScore.ConvertName(tParams, mapping.ExternalWrapper);
                    else
                        mapping.ConversionMethod = SetScore.ConvertName(tParams);
                }
                else if (fieldName.ConversionType.ToUpper().Equals("SWITCH"))
                    mapping.ConversionMethod = SetScore.ConvertSwitch(switchMaps[fieldName.Name]);

                string[] sPositions = fieldName.Position.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                mapping.Positions = new int[sPositions.Length];
                for (int i = 0; i < sPositions.Length; i++)
                    mapping.Positions[i] = Convert.ToInt32(sPositions[i]);

                SetupSpecialUtilizations(ref mapping, fieldName.SpecialUtilization);

                toReturn.Add(mapping);
            }

            return toReturn;
        }

        private VBA GetCustomName(string gName, TextDecodingParameters tParams, string data, string fName)
        {
            MethodInfo[] mInfos = typeof(HTTF.ConvertValuesToBytes).GetMethods(
                BindingFlags.Public | BindingFlags.Static);
            for (int i = 0; i < mInfos.Length; i++)
            {
                if (mInfos[i].Name.ToUpper().Equals(gName.ToUpper()))
                    return (VBA)mInfos[i].Invoke(null, new object[] { data, tParams, fName });
            }

            return null;
        }

        private void SetupSpecialUtilizations(ref SetMapping mapping, HiToTextEntryFieldNameSpecialUtilization[] specialUtilizations)
        {
            mapping.SpecialUtilizations = SetMapping.GetSpecialUtilizations(specialUtilizations);

            if (mapping.HasSpecialUtilization(SetMapping.SpecialUtilization.DetermineRank))
                mapping.DetermineRank = GetRankFunction(specialUtilizations);
            if (mapping.HasSpecialUtilization(SetMapping.SpecialUtilization.IncomingModified))
                mapping.IncomingModifiedFunction = GetIMF(specialUtilizations);
        }

        private HTTF.WrapperByteArray GetWrapper(string externalFunction)
        {
            string methodName = externalFunction.ToUpper();
            if (methodName.IndexOf('(') >= 0)
                methodName = methodName.Substring(0, methodName.IndexOf('('));

            switch (methodName.ToUpper())
            {
                case "REVERSEBYTEARRAY":
                    return HiConvert.ReverseByteArray;
                case "PADRIGHT":
                    return HTTF.PadRight(Convert.ToInt32(
                        externalFunction.Substring(externalFunction.IndexOf('(') + 1, 
                            externalFunction.IndexOf(',') - (externalFunction.IndexOf('(') + 1)).Trim()),
                        externalFunction.Substring(externalFunction.IndexOf(',') + 1,
                            externalFunction.IndexOf(')') - (externalFunction.IndexOf(',') + 1)).Trim());
                case "PADLEFT":
                    return HTTF.PadLeft(Convert.ToInt32(
                        externalFunction.Substring(externalFunction.IndexOf('(') + 1,
                            externalFunction.IndexOf(',') - (externalFunction.IndexOf('(') + 1)).Trim()),
                        externalFunction.Substring(externalFunction.IndexOf(',') + 1,
                            externalFunction.IndexOf(')') - (externalFunction.IndexOf(',') + 1)).Trim());
                default:
                    return delegate(byte[] data) { return data; };
            }
        }

        private HTTF.WrapperString GetIMF(HiToTextEntryFieldNameSpecialUtilization[] specialUtilizations)
        {
            string fnName = string.Empty;

            foreach (HiToTextEntryFieldNameSpecialUtilization su in specialUtilizations)
            {
                if (su.Value.ToUpper().Equals("INCOMINGMODIFIED"))
                {
                    fnName = su.Function;
                    break;
                }
            }

            switch (fnName.ToUpper().Substring(0, 1))
            {
                case "/":
                    return delegate(string s) { return (Convert.ToInt32(s) / Convert.ToInt32(fnName.Substring(1))).ToString(); };
                case "+":
                    return delegate(string s) { return (Convert.ToInt32(s) + Convert.ToInt32(fnName.Substring(1))).ToString(); };
                case "*":
                    return delegate(string s) { return (Convert.ToInt32(s) * Convert.ToInt32(fnName.Substring(1))).ToString(); };
                case "-":
                    return delegate(string s) { return (Convert.ToInt32(s) - Convert.ToInt32(fnName.Substring(1))).ToString(); };
                case "%":
                    return delegate(string s) { return (Convert.ToInt32(s) % Convert.ToInt32(fnName.Substring(1))).ToString(); };
                default: //Mostly for string.empty.
                    return null;
            }
        }

        private HTTF.ConvertByteArrayToInt GetRankFunction(HiToTextEntryFieldNameSpecialUtilization[] specialUtilizations)
        {
            string fnName = string.Empty;

            foreach (HiToTextEntryFieldNameSpecialUtilization su in specialUtilizations)
            {
                if (su.Value.ToUpper().Equals("DETERMINERANK"))
                {
                    fnName = su.Function;
                    break;
                }
            }

            switch (fnName.ToUpper())
            {
                case "STANDARD":
                    return HTTF.ByteArrayToInt.Standard;
                case "REVERSED":
                    return HTTF.ByteArrayToInt.Reversed;
                case "HEX":
                    return HTTF.ByteArrayToInt.Hex;
                case "HEXREVERSED":
                    return HTTF.ByteArrayToInt.HexReversed;
                case "BCD":
                    return HTTF.ByteArrayToInt.BCD;
                case "BCDREVERSED":
                    return HTTF.ByteArrayToInt.BCDReversed;
                case "INVERSEBCD":
                    return HTTF.ByteArrayToInt.InverseBCD;
                default: //For methods not described above.
                    MethodInfo[] methodInfos = typeof(HTTF.ByteArrayToInt).GetMethods(
                        BindingFlags.Public | BindingFlags.Static);
                    for (int i = 0; i < methodInfos.Length; i++)
                    {
                        if (methodInfos[i].Name.ToUpper().Equals(fnName.ToUpper()))
                        {
                            return (HTTF.ConvertByteArrayToInt)Delegate.CreateDelegate(
                                typeof(HTTF.ConvertByteArrayToInt), methodInfos[i]);
                        }
                    }

                    //If we still don't have a method, look to see if there's a CBAS function, 
                    //and just convert that to an int.
                    MethodInfo[] methodInfos2 = typeof(HTTF.ConvertByteArraysToStrings).GetMethods(
                        BindingFlags.Public | BindingFlags.Static);
                    for (int i = 0; i < methodInfos2.Length; i++)
                    {
                        if (methodInfos2[i].Name.ToUpper().Equals(fnName.ToUpper()))
                        {
                            HTTF.ConvertByteArrayToString cbas =
                                (HTTF.ConvertByteArrayToString)Delegate.CreateDelegate(
                                    typeof(HTTF.ConvertByteArrayToString), methodInfos2[i]);
                            
                            return delegate(byte[] score) { return Convert.ToInt32(cbas(score)); };
                        }
                    }

                    throw new Exception("Error: No known DetermineRank function for \"" + fnName + "\" was found.");
            }
        }

        private string GetValidFieldType(string fieldType)
        {
            switch (fieldType.ToUpper())
            {
                case "INT":
                    return "System.Int32";
                case "LONG":
                    return "System.Int64";
                case "STRING":
                    return "System.String";
                default:
                    return fieldType;
            }
        }

        private StringFormatFlag GetFormat(HiToTextEntry entry)
        {
            if (entry.Header.TextParameters.Formats == null)
                return new StringFormatFlag();

            StringFormatFlag toReturn = new StringFormatFlag();

            HiToTextEntryHeaderTextParametersFormats formats = new HiToTextEntryHeaderTextParametersFormats();
            foreach (string f in entry.Header.TextParameters.Formats.Name)
            {
                switch (f.ToUpper())
                {
                    case "ASCIILOWER":
                        toReturn |= StringFormatFlag.ASCIILower;
                        break;
                    case "ASCIINUMBERS":
                        toReturn |= StringFormatFlag.ASCIINumbers;
                        break;
                    case "ASCIISTANDARD":
                        toReturn |= StringFormatFlag.ASCIIStandard;
                        break;
                    case "ASCIIUPPER":
                        toReturn |= StringFormatFlag.ASCIIUpper;
                        break;
                    case "NEEDSSPECIALMAPPING":
                        toReturn |= StringFormatFlag.NeedsSpecialMapping;
                        break;
                }
            }

            return toReturn;
        }

        private string[] ModifyIncomingData(string[] args)
        {
            int numOfSettableArgs = args.Length;
            foreach (SetMapping map in listOfSetMappings)
            {
                foreach (int p in map.Positions)
                {
                    if (p >= numOfSettableArgs)
                        numOfSettableArgs = p + 1;
                }
            }

            string[] toReturn = new string[numOfSettableArgs];
            for (int i = 0; i < args.Length; i++)
                toReturn[i] = args[i];

            List<SetMapping> modifiedMappings =
                SetMapping.GetSetMapping(listOfSetMappings, SetMapping.SpecialUtilization.IncomingModified);

            foreach (SetMapping map in modifiedMappings)
            {
                foreach (int p in map.Positions)
                    toReturn[p] = map.IncomingModifiedFunction(args[p]);
            }

            return toReturn;
        }

        public override void ModifyName(int rank, string name)
        {
            hiscoreData.Populate(m_data);

            List<Placement> placements = new List<Placement>();
            foreach (SetMapping map in listOfSetMappings)
            {
                if (map.HasSpecialUtilization(SetMapping.SpecialUtilization.ModifyName))
                {
                    map.Data = name;
                    map.ConvertedFieldLength = hiscoreData.GetLength(map.RegExpr);

                    placements.Add(new Placement(
                        Convert.ToString(map.Data),
                        map.RegExpr,
                        map.HasSpecialUtilization(SetMapping.SpecialUtilization.IsHiScore),
                        map.ConversionMethod));
                }
            }

            hiscoreData.ReplaceNew(rank - 1, placements);

            HiConvert.ByteArrayCopy(m_data, hiscoreData.Flatten());

            SaveData();
        }

        public override void EmptyScores()
        {
            hiscoreData.Populate(m_data);

            List<Regex> adjusters = new List<Regex>();
            List<VBA> VBAs = new List<VBA>();
            foreach (SetMapping map in listOfSetMappings)
            {
                if (map.HasSpecialUtilization(SetMapping.SpecialUtilization.EmptyScores))
                {
                    map.Data = "0";
                    map.ConvertedFieldLength = hiscoreData.GetLength(map.RegExpr);

                    adjusters.Add(map.RegExpr);
                    VBAs.Add(map.ConversionMethod);
                }
            }

            hiscoreData.EmptyScores(adjusters, VBAs);

            HiConvert.ByteArrayCopy(m_data, hiscoreData.Flatten());

            SaveData();
        }

        public override void SetHiScore(string[] args)
        {
            string[] modifiedArgs = ModifyIncomingData(args);
            hiscoreData.Populate(m_data);

            //Determining rank.
            List<SetMapping> determineRankMap =
                SetMapping.GetSetMapping(listOfSetMappings, SetMapping.SpecialUtilization.DetermineRank);
            int rank = Int32.MaxValue;

            //Only works with one field right now.
            //TODO: Make it work with more.
            if (determineRankMap.Count == 1)
            {
                //Only used modified argument for that SetMapping.
                int valToDetermine = Convert.ToInt32(args[determineRankMap[0].Positions[0]]);
                if (determineRankMap[0].HasSpecialUtilization(SetMapping.SpecialUtilization.IncomingModified))
                    valToDetermine = Convert.ToInt32(modifiedArgs[determineRankMap[0].Positions[0]]);

                rank = hiscoreData.DetermineRank(
                    valToDetermine,
                    determineRankMap[0].RegExpr,
                    determineRankMap[0].DetermineRank);
            }

            //Setting up adjusters.
            List<Regex> adjusters = new List<Regex>();
            foreach (SetMapping map in listOfSetMappings)
            {
                if (map.IsAdjusted)
                    adjusters.Add(map.RegExpr);
            }

            //Adjusting scores down based on rank.
            hiscoreData.AdjustScores(rank, adjusters);

            //Replacing new scores.
            List<Placement> placements = new List<Placement>();
            foreach (SetMapping map in listOfSetMappings)
            {
                //Constants will have the data filled already, any other set field names will not.
                if (map.Data == null)
                {
                    string d = string.Empty;
                    foreach (int p in map.Positions)
                    {
                        //Only used modified argument for that SetMapping.
                        string dArg = args[p];
                        if (map.HasSpecialUtilization(SetMapping.SpecialUtilization.IncomingModified))
                            dArg = modifiedArgs[p];
                        d += dArg + "|";
                    }
                    map.Data = d.TrimEnd(new char[] { '|' });
                }

                map.ConvertedFieldLength = hiscoreData.GetLength(map.RegExpr);

                //Custom name fields require additional data than just the name functions, so we have
                //to have this here.
                if (map.ConversionType.ToUpper().Equals("CUSTOMNAME"))
                {
                    //Look for a function that is based on the parent.
                    map.ConversionMethod = GetCustomName(
                        m_gamesSupported.Split(new char[] { ',' })[0], 
                        tParams, 
                        Convert.ToString(map.Data),
                        map.Name);
                }

                placements.Add(new Placement(
                    Convert.ToString(map.Data),
                    map.RegExpr,
                    map.HasSpecialUtilization(SetMapping.SpecialUtilization.IsHiScore),
                    map.ConversionMethod));
            }

            //Replacing the new score.
            hiscoreData.ReplaceNew(rank, placements);

            HiConvert.ByteArrayCopy(m_data, hiscoreData.Flatten());
        }

        public override string HiToString()
        {
            string retString = m_format + Environment.NewLine;

            hiscoreData.Populate(m_data);

            List<DisplayData> formatting = hiscoreData.GetDisplay(tParams, switchMaps);

            retString += hiscoreData.HiToString(formatting);

            return retString;
        }

        public override void SaveData()
        {
            if (m_fileNames.Length == 1)
                base.SaveData();
            else
            {
                int counter = 0;

                for (int i = 0; i < m_fileNames.Length; i++)
                {
                    byte[] toWrite = new byte[hiscoreData.Entry.Header.Extensions[i].NumberOfBytes];
                    for (int j = 0; j < toWrite.Length; j++)
                        toWrite[j] = m_data[counter++];

                    File.WriteAllBytes(m_fileNames[i], toWrite);
                }
            }
        }
    }
}
