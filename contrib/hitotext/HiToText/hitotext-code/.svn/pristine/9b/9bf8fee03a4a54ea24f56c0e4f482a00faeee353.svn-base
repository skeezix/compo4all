using System;
using System.Collections.Generic;
//using System.Text;
using System.Text.RegularExpressions;
using HTTF = HiToText.Formatting;
using VBA = HiToText.Formatting.ConvertValueToByteArray;
using HiToStr = HiToText.Formatting.ConvertByteArraysToStrings;

namespace HiToText.Utils
{
    public class Placement
    {
        private string _val;
        private Regex _pat;
        private VBA _func;

        private bool _isTopScore;

        public Placement(string valueToPlace, Regex pattern, VBA methodToCall)
        {
            _val = valueToPlace;
            _pat = pattern;
            _func = methodToCall;
            _isTopScore = false;
        }

        public Placement(string valueToPlace, Regex pattern, bool isTopScorePlacement, VBA methodToCall)
        {
            _val = valueToPlace;
            _pat = pattern;
            _func = methodToCall;
            _isTopScore = isTopScorePlacement;
        }

        public string Value
        {
            get
            {
                return _val;
            }
        }

        public Regex Pattern
        {
            get
            {
                return _pat;
            }
        }

        public VBA CallingMethod
        {
            get
            {
                return _func;
            }
        }

        public bool IsTopScorePlacement
        {
            get
            {
                return _isTopScore;
            }
        }
    }
}
