using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace HiToText.HXML
{
    public partial class HiToTextEntry
    {
        public HiToTextEntry(XPathNavigator path)
        {
            this.Header = new HiToTextEntryHeader(path);
            
            XPathNodeIterator ni = path.Select("FileStructure/Mapping");
            this.FileStructure = new HiToTextEntryMapping[ni.Count];
            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.FileStructure[i] = new HiToTextEntryMapping(ni.Current);
            }

            ni = path.Select("SetStructure/FieldName");
            this.SetStructure = new HiToTextEntryFieldName[ni.Count];
            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.SetStructure[i] = new HiToTextEntryFieldName(ni.Current);
            }

            this.DisplayStructure = new HiToTextEntryDisplayStructure(path);
        }
    }

    public partial class HiToTextEntryHeader
    {
        public HiToTextEntryHeader(XPathNavigator path)
        {
            XPathNodeIterator ni = path.Select("Header/Extensions/Name");
            this.Extensions = new HiToTextEntryHeaderName[ni.Count];

            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.Extensions[i] = new HiToTextEntryHeaderName(ni.Current);
            }

            ni = path.Select("Header/Fields/Name");
            this.Fields = new string[ni.Count];
            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.Fields[i] = ni.Current.Value;
            }

            ni = path.Select("Header/Games/Name");
            this.Games = new string[ni.Count];
            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.Games[i] = ni.Current.Value;
            }

            ni = path.Select("Header/TextParameters");
            ni.MoveNext();
            this.TextParameters = new HiToTextEntryHeaderTextParameters(ni.Current);
        }
    }

    public partial class HiToTextEntryHeaderName
    {
        public HiToTextEntryHeaderName(XPathNavigator path)
        {
            XPathNodeIterator ni = path.Select("Name");
            this.Value = ni.Current.Value;
            if (ni.Current.HasAttributes)
            {
                this.NumberOfBytesSpecified = true;
                this.NumberOfBytes = Convert.ToInt32(ni.Current.GetAttribute("NumberOfBytes", string.Empty));
            }
        }
    }

    public partial class HiToTextEntryHeaderTextParameters
    {
        public HiToTextEntryHeaderTextParameters(XPathNavigator path)
        {
            if (!path.GetAttribute("ByteSkipAmount", string.Empty).Equals(string.Empty))
            {
                this.ByteSkipAmountSpecified = true;
                this.ByteSkipAmount = Convert.ToInt32(path.GetAttribute("ByteSkipAmount", string.Empty));
            }

            if (!path.GetAttribute("ByteStart", string.Empty).Equals(string.Empty))
            {
                this.ByteStartSpecified = true;
                this.ByteStart = Convert.ToInt32(path.GetAttribute("ByteStart", string.Empty));
            }

            if (!path.GetAttribute("ByteSkipData", string.Empty).Equals(string.Empty))
                this.ByteSkipData = path.GetAttribute("ByteSkipData", string.Empty);

            XPathNodeIterator ni = path.Select("Formats");
            ni.MoveNext();
            this.Formats = new HiToTextEntryHeaderTextParametersFormats(ni.Current);

            ni = path.Select("Offsets");
            ni.MoveNext();
            this.Offsets = new HiToTextEntryHeaderTextParametersOffsets(ni.Current);

            ni = path.Select("SpecialMapping");
            ni.MoveNext();
            this.SpecialMapping = new HiToTextEntryHeaderTextParametersSpecialMapping(ni.Current);

            ni = path.Select("SwitchMaps");
            ni.MoveNext();
            this.SwitchMaps = new HiToTextEntryHeaderTextParametersSwitchMaps(ni.Current);
        }
    }

    public partial class HiToTextEntryHeaderTextParametersFormats
    {
        public HiToTextEntryHeaderTextParametersFormats(XPathNavigator path)
        {
            XPathNodeIterator ni = path.Select("Name");
            this.Name = new string[ni.Count];

            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.Name[i] = ni.Current.Value;
            }
        }
    }

    public partial class HiToTextEntryHeaderTextParametersOffsets
    {
        public HiToTextEntryHeaderTextParametersOffsets(XPathNavigator path)
        {
            XPathNodeIterator ni = path.Select("Offset");
            this.Offset = new HiToTextEntryHeaderTextParametersOffsetsOffset[ni.Count];

            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.Offset[i] = new HiToTextEntryHeaderTextParametersOffsetsOffset(ni.Current);
            }
        }
    }

    public partial class HiToTextEntryHeaderTextParametersOffsetsOffset
    {
        public HiToTextEntryHeaderTextParametersOffsetsOffset(XPathNavigator path)
        {
            this.Type = path.GetAttribute("Type", string.Empty);
            this.StartByte = path.GetAttribute("StartByte", string.Empty);
            if (!path.GetAttribute("SkipModifier", string.Empty).Equals(string.Empty))
            {
                this.SkipModifier = Convert.ToByte(path.GetAttribute("SkipModifier", string.Empty));
                this.SkipModifierSpecified = true;
            }
        }
    }

    public partial class HiToTextEntryHeaderTextParametersSpecialMapping
    {
        public HiToTextEntryHeaderTextParametersSpecialMapping(XPathNavigator path)
        {
            XPathNodeIterator ni = path.Select("Map");
            this.Map = new HiToTextEntryHeaderTextParametersSpecialMappingMap[ni.Count];
            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.Map[i] = new HiToTextEntryHeaderTextParametersSpecialMappingMap(ni.Current);
            }
        }
    }

    public partial class HiToTextEntryHeaderTextParametersSpecialMappingMap
    {
        public HiToTextEntryHeaderTextParametersSpecialMappingMap(XPathNavigator path)
        {
            this.Byte = path.GetAttribute("Byte", string.Empty);
            this.Char = path.GetAttribute("Char", string.Empty);
            if (!path.GetAttribute("Comments", string.Empty).Equals(string.Empty))
                this.Comments = path.GetAttribute("Comments", string.Empty);
        }
    }

    public partial class HiToTextEntryHeaderTextParametersSwitchMaps
    {
        public HiToTextEntryHeaderTextParametersSwitchMaps(XPathNavigator path)
        {
            XPathNodeIterator ni = path.Select("SwitchMap");
            this.SwitchMap = new HiToTextEntryHeaderTextParametersSwitchMapsSwitchMap[ni.Count];
            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.SwitchMap[i] = new HiToTextEntryHeaderTextParametersSwitchMapsSwitchMap(ni.Current);
            }
        }
    }

    public partial class HiToTextEntryHeaderTextParametersSwitchMapsSwitchMap
    {
        public HiToTextEntryHeaderTextParametersSwitchMapsSwitchMap(XPathNavigator path)
        {
            this.DefaultMany = path.GetAttribute("DefaultMany", string.Empty);
            this.DefaultOne = path.GetAttribute("DefaultOne", string.Empty);
            this.Name = path.GetAttribute("Name", string.Empty);

            XPathNodeIterator ni = path.Select("Mapping");
            this.Mapping = new HiToTextEntryHeaderTextParametersSwitchMapsSwitchMapMapping[ni.Count];
            for (int i = 0; i < ni.Count; i++)
            {    
                ni.MoveNext();
                this.Mapping[i] = new HiToTextEntryHeaderTextParametersSwitchMapsSwitchMapMapping(ni.Current);
            }
        }
    }

    public partial class HiToTextEntryHeaderTextParametersSwitchMapsSwitchMapMapping
    {
        public HiToTextEntryHeaderTextParametersSwitchMapsSwitchMapMapping(XPathNavigator path)
        {
            this.Many = path.GetAttribute("Many", string.Empty);
            this.One = path.GetAttribute("One", string.Empty);
        }
    }

    public partial class HiToTextEntryMapping
    {
        public HiToTextEntryMapping(XPathNavigator path)
        {
            this.NumberOfBlocks = Convert.ToInt32(path.GetAttribute("NumberOfBlocks", string.Empty));
            this.Ordering = path.GetAttribute("Ordering", string.Empty);

            if (!path.GetAttribute("Start", string.Empty).Equals(string.Empty))
            {
                this.StartSpecified = true;
                this.Start = Convert.ToInt32(path.GetAttribute("Start", string.Empty));
            }

            XPathNodeIterator ni = path.Select("Entry");
            this.Entry = new HiToTextEntryMappingEntry[ni.Count];
            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.Entry[i] = new HiToTextEntryMappingEntry(ni.Current);
            }
        }
    }

    public partial class HiToTextEntryMappingEntry
    {
        public HiToTextEntryMappingEntry(XPathNavigator path)
        {
            this.Length = Convert.ToInt32(path.GetAttribute("Length", string.Empty));
            this.Name = path.GetAttribute("Name", string.Empty);
            if (!path.GetAttribute("ScatterPattern", string.Empty).Equals(string.Empty))
                this.ScatterPattern = path.GetAttribute("ScatterPattern", string.Empty);
        }
    }

    public partial class HiToTextEntryFieldName
    {
        public HiToTextEntryFieldName(XPathNavigator path)
        {
            this.Name = path.GetAttribute("Name", string.Empty);
            this.FieldType = path.GetAttribute("FieldType", string.Empty);
            this.ConversionType = path.GetAttribute("ConversionType", string.Empty);
            this.Position = path.GetAttribute("Position", string.Empty);

            if (!path.GetAttribute("Constant", string.Empty).Equals(string.Empty))
            {
                this.ConstantSpecified = true;
                this.Constant = Convert.ToByte(path.GetAttribute("Constant", string.Empty));
            }

            if (!path.GetAttribute("ExternalWrapper", string.Empty).Equals(string.Empty))
                this.ExternalWrapper = path.GetAttribute("ExternalWrapper", string.Empty);

            XPathNodeIterator ni = path.Select("SpecialUtilization");
            this.SpecialUtilization = new HiToTextEntryFieldNameSpecialUtilization[ni.Count];
            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.SpecialUtilization[i] = new HiToTextEntryFieldNameSpecialUtilization(ni.Current);
            }
        }
    }

    public partial class HiToTextEntryFieldNameSpecialUtilization
    {
        public HiToTextEntryFieldNameSpecialUtilization(XPathNavigator path)
        {
            if (!path.GetAttribute("Function", string.Empty).Equals(string.Empty))
                this.Function = path.GetAttribute("Function", string.Empty);

            XPathNodeIterator ni = path.Select("SpecialUtilization");
            this.Value = ni.Current.Value;
        }
    }

    public partial class HiToTextEntryDisplayStructure
    {
        public HiToTextEntryDisplayStructure(XPathNavigator path)
        {
            XPathNodeIterator ni = path.Select("DisplayStructure/FieldName");
            this.FieldName = new HiToTextEntryDisplayStructureFieldName[ni.Count];

            for (int i = 0; i < ni.Count; i++)
            {
                ni.MoveNext();
                this.FieldName[i] = new HiToTextEntryDisplayStructureFieldName(ni.Current);
            }
        }
    }

    public partial class HiToTextEntryDisplayStructureFieldName
    {
        public HiToTextEntryDisplayStructureFieldName(XPathNavigator path)
        {
            this.Name = path.GetAttribute("Name", string.Empty);
            this.ConversionType = path.GetAttribute("ConversionType", string.Empty);
            
            if (!path.GetAttribute("Operator", string.Empty).Equals(string.Empty))
                this.Operator = path.GetAttribute("Operator", string.Empty);

            if (!path.GetAttribute("CustomName", string.Empty).Equals(string.Empty))
                this.CustomName = path.GetAttribute("CustomName", string.Empty);
        }
    }
}
