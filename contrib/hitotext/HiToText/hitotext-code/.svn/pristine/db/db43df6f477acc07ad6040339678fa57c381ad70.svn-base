using System;
using System.Collections.Generic;
using System.Text;

namespace HiToText.Utils
{
    public class Offset
    {
        private int _offset;
        private int _skipModifier;
        private FlagOffsets _flag;

        public enum FlagOffsets
        {
            Upper,
            Lower,
            Numbers,
            Invalid
        }

        public Offset(int offset, FlagOffsets flag)
        {
            _offset = offset;
            _flag = flag;
            _skipModifier = 1;
        }

        public Offset(int offset, int skipModifier, FlagOffsets flag)
        {
            _offset = offset;
            _flag = flag;
            _skipModifier = skipModifier;
        }

        public int ByteOffset
        {
            get
            {
                return _offset;
            }
        }

        public int SkipModifier
        {
            get
            {
                return _skipModifier;
            }
        }

        public FlagOffsets Flag
        {
            get
            {
                return _flag;
            }
        }
    }
}
