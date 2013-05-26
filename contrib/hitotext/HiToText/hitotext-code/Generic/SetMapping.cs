using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using HTTF = HiToText.Formatting;
using VBA = HiToText.Formatting.ConvertValueToByteArray;
using SetScore = HiToText.Formatting.ConvertValuesToBytes;
using HiToText.Utils;
using HiToText.HXML;

namespace HiToText.Generic
{
    class SetMapping
    {
        private HTTF.WrapperString _incomingModifiedFunction;
        private string _name;
        private bool _isAdjusted;
        private Type _fieldType;
        private string _conversionType;
        private VBA _conversionMethod;
        private HTTF.WrapperByteArray _conversionWrapper;
        private int[] _positions;
        private object _data;
        private int _convertedFieldLength;
        private Regex _regEx;
        private SpecialUtilization _SUflags;
        private HTTF.ConvertByteArrayToInt _determineRankFunction;

        public SetMapping()
        {
            _conversionWrapper = delegate(byte[] data) { return data; };
        }

        public SetMapping(string name)
        {
            Name = name;
            _conversionWrapper = delegate(byte[] data) { return data; };
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                CreateRegex(value);
            }
        }

        public bool IsAdjusted
        {
            get
            {
                return _isAdjusted;
            }
            set
            {
                _isAdjusted = value;
            }
        }

        public Type FieldType
        {
            get
            {
                return _fieldType;
            }
            set
            {
                _fieldType = value;
            }
        }

        public string ConversionType
        {
            get
            {
                return _conversionType;
            }
            set
            {
                _conversionType = value;
            }
        }

        public VBA ConversionMethod
        {
            get
            {
                if (_conversionMethod == null)
                    SetConversionMethod();

                return _conversionMethod;
            }
            set
            {
                _conversionMethod = value;
            }
        }

        public HTTF.WrapperByteArray ExternalWrapper
        {
            get
            {
                return _conversionWrapper;
            }
            set
            {
                _conversionWrapper = value;
            }
        }

        public int[] Positions
        {
            get
            {
                return _positions;
            }
            set
            {
                _positions = value;
            }
        }

        public object Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }

        public int ConvertedFieldLength
        {
            get
            {
                return _convertedFieldLength;
            }
            set
            {
                _convertedFieldLength = value;
            }
        }

        public Regex RegExpr
        {
            get
            {
                return _regEx;
            }
            set
            {
                _regEx = value;
            }
        }

        public SpecialUtilization SpecialUtilizations
        {
            get
            {
                return _SUflags;
            }
            set
            {
                _SUflags = value;
                if (this.HasSpecialUtilization(SpecialUtilization.IsAdjusted))
                    _isAdjusted = true;
            }
        }

        public HTTF.ConvertByteArrayToInt DetermineRank
        {
            get
            {
                return _determineRankFunction;
            }
            set
            {
                if (this.HasSpecialUtilization(SpecialUtilization.DetermineRank))
                    _determineRankFunction = value;
                else
                    throw new Exception("Error: Cannot set the DetermineRank function when the DetermineRank flag is not set.");
            }
        }

        public HTTF.WrapperString IncomingModifiedFunction
        {
            get
            {
                return _incomingModifiedFunction;
            }
            set
            {
                _incomingModifiedFunction = value;
            }
        }

        public bool HasSpecialUtilization(SpecialUtilization specialUtilization)
        {
            if ((_SUflags & specialUtilization) == specialUtilization)
                return true;
            else
                return false;
        }

        private void CreateRegex(string name)
        {
            _regEx = new Regex("^" + name + ".*$");
        }

        private void SetConversionMethod()
        {
            string methodName = _conversionType.ToUpper();
            if (methodName.IndexOf('(') >= 0)
                methodName = methodName.Substring(0, methodName.IndexOf('('));

            switch (methodName)
            {
                case "INTTOBYTEARRAYHEX":
                    _conversionMethod = SetScore.ConvertData(
                        Convert.ToInt32(Data),
                        _convertedFieldLength,
                        HiConvert.IntToByteArrayHex,
                        _conversionWrapper);
                    break;
                case "INTTOBYTEARRAYHEXASHEX":
                    _conversionMethod = SetScore.ConvertData(
                        Convert.ToInt32(Data),
                        _convertedFieldLength,
                        HiConvert.IntToByteArrayHexAsHex,
                        _conversionWrapper);
                    break;
                case "INTTOBYTEARRAYSINGLEBCD":
                    _conversionMethod = SetScore.ConvertData(
                        Convert.ToInt32(Data),
                        _convertedFieldLength,
                        HiConvert.IntToByteArraySingleBCD,
                        _conversionWrapper);
                    break;
                case "TWOTOTHREEENCODING":
                    try
                    {
                        _conversionMethod = SetScore.TwoToThreeEncoding(
                            Convert.ToString(Data),
                            Convert.ToInt32(_conversionType.Substring(_conversionType.IndexOf('(') + 1,
                                _conversionType.IndexOf(')') - (_conversionType.IndexOf('(') + 1)).Trim()));
                    }
                    catch
                    {
                        throw new Exception("Conversion method format for TwoToThreeEncoding was incorrect. Correct format is: \"TwoToThreeEncoding(x)\"");
                    }
                    break;
                case "PADDATA":
                    try
                    {
                        _conversionMethod = SetScore.PadData(
                            Convert.ToString(Data),
                            _convertedFieldLength,
                            _conversionType.Substring(_conversionType.IndexOf('(') + 1,
                                _conversionType.IndexOf(',') - (_conversionType.IndexOf('(') + 1)).Trim(),
                            _conversionType.Substring(_conversionType.IndexOf(',') + 1,
                                _conversionType.IndexOf(')') - (_conversionType.IndexOf(',') + 1)).Trim());
                    }
                    catch
                    {
                        throw new Exception("Conversion method format for PadData was incorrect. Correct format is: \"PadData(x,y)\"");
                    }
                    break;
                case "PADDATAREVERSE":
                    try
                    {
                        _conversionMethod = SetScore.PadDataReverse(
                            Convert.ToString(Data),
                            _convertedFieldLength,
                            _conversionType.Substring(_conversionType.IndexOf('(') + 1,
                                _conversionType.IndexOf(',') - (_conversionType.IndexOf('(') + 1)).Trim(),
                            _conversionType.Substring(_conversionType.IndexOf(',') + 1,
                                _conversionType.IndexOf(')') - (_conversionType.IndexOf(',') + 1)).Trim());
                    }
                    catch
                    {
                        throw new Exception("Conversion method format for PadDataReverse was incorrect. Correct format is: \"PadDataReverse(x,y)\"");
                    }
                    break;
                default:
                    MethodInfo[] methodInfos = typeof(HTTF.ConvertValuesToBytes).GetMethods(
                        BindingFlags.Public | BindingFlags.Static);
                    for (int i = 0; i < methodInfos.Length; i++)
                    {
                        if (methodInfos[i].Name.ToUpper().Equals(_conversionType.ToUpper()))
                        {
                            _conversionMethod = (HTTF.ConvertValueToByteArray)Delegate.CreateDelegate(
                                typeof(HTTF.ConvertValueToByteArray), methodInfos[i]);
                            break;
                        }
                    }

                    if (_conversionMethod == null)
                    {
                        throw new Exception("Conversion method not found for \"" + _conversionType + "\"." +
                            Environment.NewLine + "If this is a custom conversion method please implement it " +
                            "in the Formatting.ConvertValuesToBytes. Otherwise, check your spelling and/or formatting.");
                    }

                    break;

                //case "CUSTOMNAME" is already taken care of in SetHiScore since it requires the tParams variable, and data.
                //case "NAME" is already taken care of in SetupMappings since it requires the tParams variable.
                //case "SWITCH" is also already taken care of in SetupMappings since it requires the switchMaps variable.
            }
        }

        [Flags]
        public enum SpecialUtilization
        {
            None = 0x01,                        //0000001
            EmptyScores = None << 1,            //0000010
            ModifyName = EmptyScores << 1,      //0000100
            IsHiScore = ModifyName << 1,        //0001000
            DetermineRank = IsHiScore << 1,     //0010000
            IsAdjusted = DetermineRank << 1,    //0100000
            IncomingModified = IsAdjusted << 1  //1000000
        }

        public static List<SetMapping> GetSetMapping(List<SetMapping> listOfSetMappings, SpecialUtilization specialUtilization)
        {
            List<SetMapping> toReturn = new List<SetMapping>();

            foreach (SetMapping map in listOfSetMappings)
            {
                if ((map.SpecialUtilizations & specialUtilization) == specialUtilization)
                    toReturn.Add(map);
            }

            return toReturn;
        }

        public static SetMapping.SpecialUtilization GetSpecialUtilizations(HiToTextEntryFieldNameSpecialUtilization[] specialUtilizations)
        {
            SetMapping.SpecialUtilization toReturn = SetMapping.SpecialUtilization.None;

            if (specialUtilizations == null)
                return SetMapping.SpecialUtilization.None;

            foreach (HiToTextEntryFieldNameSpecialUtilization su in specialUtilizations)
            {
                switch (su.Value.ToUpper())
                {
                    case "EMPTYSCORES":
                        if (toReturn.Equals(SetMapping.SpecialUtilization.None))
                            toReturn = SetMapping.SpecialUtilization.EmptyScores;
                        else
                            toReturn |= SetMapping.SpecialUtilization.EmptyScores;
                        break;
                    case "MODIFYNAME":
                        if (toReturn.Equals(SetMapping.SpecialUtilization.None))
                            toReturn = SetMapping.SpecialUtilization.ModifyName;
                        else
                            toReturn |= SetMapping.SpecialUtilization.ModifyName;
                        break;
                    case "ISHISCORE":
                        if (toReturn.Equals(SetMapping.SpecialUtilization.None))
                            toReturn = SetMapping.SpecialUtilization.IsHiScore;
                        else
                            toReturn |= SetMapping.SpecialUtilization.IsHiScore;
                        break;
                    case "DETERMINERANK":
                        if (toReturn.Equals(SetMapping.SpecialUtilization.None))
                            toReturn = SetMapping.SpecialUtilization.DetermineRank;
                        else
                            toReturn |= SetMapping.SpecialUtilization.DetermineRank;
                        break;
                    case "ISADJUSTED":
                        if (toReturn.Equals(SetMapping.SpecialUtilization.None))
                            toReturn = SetMapping.SpecialUtilization.IsAdjusted;
                        else
                            toReturn |= SetMapping.SpecialUtilization.IsAdjusted;
                        break;
                    case "INCOMINGMODIFIED":
                        if (toReturn.Equals(SetMapping.SpecialUtilization.None))
                            toReturn = SetMapping.SpecialUtilization.IncomingModified;
                        else
                            toReturn |= SetMapping.SpecialUtilization.IncomingModified;
                        break;
                }
            }

            return toReturn;
        }
    }
}
