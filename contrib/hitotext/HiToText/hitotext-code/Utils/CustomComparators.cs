using System;
using System.Text;
using System.Collections.Generic;
using System.Reflection;

namespace HiToText.Utils
{
    public class FieldInfoNameComparator : IComparer<FieldInfo>
    {
        private Ordering _order;

        public FieldInfoNameComparator(Ordering orderStyle)
        {
            _order = orderStyle;
        }

        public enum Ordering
        {
            Ascending,
            Descending
        }

        #region IComparer<FieldInfo> Members

        int IComparer<FieldInfo>.Compare(FieldInfo x, FieldInfo y)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < x.Name.Length; i++)
            {
                if (char.IsDigit(x.Name[i]))
                    sb.Append(x.Name[i]);
            }
            int iX = Int32.MaxValue;
            try
            {
                iX = Convert.ToInt32(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sb = new StringBuilder();
            for (int i = 0; i < y.Name.Length; i++)
            {
                if (char.IsDigit(y.Name[i]))
                    sb.Append(y.Name[i]);
            }
            int iY = Int32.MaxValue;
            try
            {
                iY = Convert.ToInt32(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (_order.Equals(Ordering.Ascending))
                return iX.CompareTo(iY);
            else if (_order.Equals(Ordering.Descending))
                return iY.CompareTo(iX);
            else //Default to ascending.
                return iX.CompareTo(iY);
        }

        #endregion
    }

    public class StringNameComparator : IComparer<string>
    {
        private Ordering _order;

        public StringNameComparator(Ordering orderStyle)
        {
            _order = orderStyle;
        }

        public enum Ordering
        {
            Ascending,
            Descending
        }

        #region IComparer<string> Members

        int IComparer<string>.Compare(string x, string y)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < x.Length; i++)
            {
                if (char.IsDigit(x[i]))
                    sb.Append(x[i]);
            }
            int iX = Int32.MaxValue;
            try
            {
                iX = Convert.ToInt32(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            sb = new StringBuilder();
            for (int i = 0; i < y.Length; i++)
            {
                if (char.IsDigit(y[i]))
                    sb.Append(y[i]);
            }
            int iY = Int32.MaxValue;
            try
            {
                iY = Convert.ToInt32(sb.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (_order.Equals(Ordering.Ascending))
                return iX.CompareTo(iY);
            else if (_order.Equals(Ordering.Descending))
                return iY.CompareTo(iX);
            else //Default to ascending.
                return iX.CompareTo(iY);
        }

        #endregion
    }
}
