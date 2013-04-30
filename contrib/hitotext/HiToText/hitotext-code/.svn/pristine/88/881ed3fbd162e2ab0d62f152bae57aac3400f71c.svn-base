using System;
using System.Collections.Generic;
using System.Text;
using HTTF = HiToText.Formatting;
using HiToText;

namespace HiToText.Utils
{
    public class TextDecodingParameters
    {
        private StringFormatFlag _format;
        private List<Offset> _offsets;
        private OneToManyMap<char, byte> _specialMapping;
        private int _byteStart;
        private int _byteSkipAmt;
        private byte _byteSkipData;

        private bool _isValidParameters;

        public TextDecodingParameters()
        {
            _offsets = new List<Offset>();
            _specialMapping = new OneToManyMap<char, byte>();
            _byteSkipAmt = 1;
            _byteStart = 0;
            _isValidParameters = false;
        }

        public void Validate()
        {
            if (_format.Equals(null))
                throw new FormatException("Error: Format not set.");

            if (((_format & StringFormatFlag.ASCIIUpper) == StringFormatFlag.ASCIIUpper ||
                 (_format & StringFormatFlag.ASCIILower) == StringFormatFlag.ASCIILower ||
                 (_format & StringFormatFlag.ASCIINumbers) == StringFormatFlag.ASCIINumbers) &&
                     _offsets.Count == 0)
            {
                throw new FormatException("Error: Format for ASCIIUpper, ASCIILower, and ASCIINumbers requires an offset.");
            }

            if ((_format & StringFormatFlag.NeedsSpecialMapping) == StringFormatFlag.NeedsSpecialMapping &&
                    _specialMapping.Equals(new OneToManyMap<byte, char>()))
            {
                throw new FormatException("Error: Format for NeedsSpecialMapping requires a at least one mapping.");
            }

            _isValidParameters = true;
        }

        public StringFormatFlag Format
        {
            get
            {
                if (_isValidParameters)
                    return _format;
                else
                {
                    Validate();
                    return Format;
                }
            }
            set
            {
                _isValidParameters = false;
                _format = value;
            }
        }

        public List<Offset> Offsets
        {
            get
            {
                if (_isValidParameters)
                    return _offsets;
                else
                {
                    Validate();
                    return Offsets;
                }
            }
            set
            {
                _isValidParameters = false;
                _offsets = value;
            }
        }

        public OneToManyMap<char, byte> SpecialMapping
        {
            get
            {
                if (_isValidParameters)
                    return _specialMapping;
                else
                {
                    Validate();
                    return SpecialMapping;
                }
            }
            set
            {
                _isValidParameters = false;
                _specialMapping = value;
            }
        }

        public int ByteSkipAmount
        {
            get
            {
                if (_isValidParameters)
                    return _byteSkipAmt;
                else
                {
                    Validate();
                    return ByteSkipAmount;
                }
            }
            set
            {
                _isValidParameters = false;
                _byteSkipAmt = value;
            }
        }

        public int ByteStart
        {
            get
            {
                if (_isValidParameters)
                    return _byteStart;
                else
                {
                    Validate();
                    return ByteStart;
                }
            }
            set
            {
                _isValidParameters = false;
                _byteStart = value;
            }
        }

        public byte ByteSkipData
        {
            get
            {
                if (_isValidParameters)
                    return _byteSkipData;
                else
                {
                    Validate();
                    return ByteSkipData;
                }
            }
            set
            {
                _isValidParameters = false;
                _byteSkipData = value;
            }
        }

        public void AddOffset(Offset offset)
        {
            _offsets.Add(offset);
            _isValidParameters = false;
        }

        public void AddMapping(char charToMap, byte byteToMap)
        {
            _specialMapping.AddMapping(charToMap, byteToMap);
        }
    }
}
