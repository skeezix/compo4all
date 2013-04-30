using System;
using System.Collections.Generic;
//using System.Text;
using System.Text.RegularExpressions;
using HTTF = HiToText.Formatting;
using HiToStr = HiToText.Formatting.ConvertByteArraysToStrings;

namespace HiToText.Utils
{
    public class DisplayData
    {
        private string _tp;
        private Regex _pattern;
        private HiToText.Formatting.ConvertByteArrayToString _func;
        private CannedDisplay _canned;

        public enum CannedDisplay
        {
            None,
            AscendingFrom1,
            AscendingFrom1EndingInTotal
        }

        public DisplayData(Regex pattern, HTTF.ConvertByteArrayToString methodForConversion)
        {
            _pattern = pattern;
            _canned = CannedDisplay.None;
            _func = methodForConversion;
            _tp = string.Empty;
        }

        public DisplayData(Regex pattern, CannedDisplay display)
        {
            _pattern = pattern;
            _canned = display;
            _func = null;
            _tp = string.Empty;
        }

        public DisplayData(Regex pattern, CannedDisplay display, string toPrint)
        {
            _pattern = pattern;
            _canned = display;
            _func = null;
            _tp = toPrint;
        }

        public Regex Pattern
        {
            get
            {
                return _pattern;
            }
        }

        public HTTF.ConvertByteArrayToString CallingMethod
        {
            get
            {
                return _func;
            }
        }

        public CannedDisplay CannedMethod
        {
            get
            {
                return _canned;
            }
        }

        public string ToDisplay
        {
            get
            {
                return _tp;
            }
        }
    }
}
