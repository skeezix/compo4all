using System;
using System.Collections.Generic;
using System.Text;

namespace HiToText.Utils
{
    [Flags]
    public enum StringFormatFlag
    {
        ASCIIStandard = 0x01,                   //00001
        ASCIIUpper = ASCIIStandard << 1,        //00010
        ASCIILower = ASCIIUpper << 1,           //00100
        ASCIINumbers = ASCIILower << 1,         //01000
        NeedsSpecialMapping = ASCIINumbers << 1 //10000
    }

    public enum ConsoleFlags
    {
        None,
        Read,
        ReadAll,
        Write,
        WriteAlternate,
        Format,
        FormatAlternate,
        List,
        ListParents,
        Update,
        Version,
        Erase,
        Modify,
        Help
    }
}
