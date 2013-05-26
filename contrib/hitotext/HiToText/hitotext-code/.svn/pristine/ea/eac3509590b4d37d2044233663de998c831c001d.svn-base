using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;

namespace HiToText.Utils
{
    public class NotMatching
    {
        private Regex _pattern;

        public NotMatching(Regex pattern)
        {
            _pattern = pattern;
        }

        public Regex Pattern
        {
            get
            {
                return _pattern;
            }
            set
            {
                _pattern = value;
            }
        }

        public Predicate<FieldInfo> NotMatch
        {
            get
            {
                return IsNotMatch;
            }
        }

        public Predicate<string> NotMatchStr
        {
            get
            {
                return IsNotMatchStr;
            }
        }

        private bool IsNotMatch(FieldInfo f)
        {
            return !_pattern.IsMatch(f.Name);
        }

        private bool IsNotMatchStr(string s)
        {
            return !_pattern.IsMatch(s);
        }
    }
}
