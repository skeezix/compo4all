using System;
using System.Text;
using System.Runtime.InteropServices;

namespace HiToText.Utils
{
    class HiConvert
    {
        public static void ByteArrayCopy(byte[] dest, byte[] src)
        {
            for (int i = 0; i < dest.Length; i++)
            {
                if (i < src.Length)
                    dest[i] = src[i];
                else
                    dest[i] = 0x0;
            }
        }

        public static string ByteArrayToHexString(byte[] byteArray)
        {
            StringBuilder sb = new StringBuilder();
            string hexString = "0123456789ABCDEF";

            foreach (byte b in byteArray)
            {
                sb.Append(hexString[(int)(b >> 4)]);
                sb.Append(hexString[(int)(b & 0xF)]);
            }

            return sb.ToString();
        }

        public static byte[] HexStringToByteArray(string hexString)
        {
            byte[] byteArray;
            int byteLength;
            string hexValue = "\x0\x1\x2\x3\x4\x5\x6\x7\x8\x9|||||||\xA\xB\xC\xD\xE\xF";

            byteLength = hexString.Length / 2;
            byteArray = new byte[byteLength];

            for (int x = 0, i = 0; i < hexString.Length; i += 2, x += 1)
            {
                byteArray[x] = (byte)(hexValue[Char.ToUpper(hexString[i + 0]) - '0'] << 4);
                byteArray[x] |= (byte)(hexValue[Char.ToUpper(hexString[i + 1]) - '0']);
            }

            return byteArray;
        }

        public static string ByteArrayToString(byte[] byteArray)
        {
            UTF8Encoding enc = new UTF8Encoding();
            return enc.GetString(byteArray);
        }

        public static int ByteArrayHexToInt(byte[] byteArray)
        {
            string valStr = null;

            for (int i = 0; i < byteArray.Length; i++)
                valStr += byteArray[i].ToString("X2");

            return Int32.Parse(valStr);
        }

        public static long ByteArrayHexToLong(byte[] byteArray)
        {
            string valStr = null;

            for (int i = 0; i < byteArray.Length; i++)
                valStr += byteArray[i].ToString("X2");

            return Int64.Parse(valStr);
        }

        public static int ByteArrayHexAsHexToInt(byte[] byteArray)
        {
            string valStr = null;

            for (int i = 0; i < byteArray.Length; i++)
                valStr += byteArray[i].ToString("X2");

            return System.Convert.ToInt32(valStr, 16);
        }
        
        public static int ByteArraySingleBCDToInt(byte[] byteArray)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < byteArray.Length; i++)
            {
                byte[] newData = HiConvert.HexStringToByteArray(byteArray[i].ToString("X2"));
                sb.Append(newData[0]);
            }

            return Int32.Parse(sb.ToString());
        }

        public static long ByteArraySingleBCDToLong(byte[] byteArray)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < byteArray.Length; i++)
            {
                byte[] newData = HiConvert.HexStringToByteArray(byteArray[i].ToString("X2"));
                sb.Append(newData[0]);
            }

            return Int64.Parse(sb.ToString());
        }

        public static byte[] ByteSwapArray(byte[] byteArray)
        {
            //Cannot be accurately swapped if odd.
            //May allow for special cases later.
            if ((byteArray.Length % 2) == 1)
                return byteArray;

            byte[] swapped = new byte[byteArray.Length];

            for (int i = 0; i < byteArray.Length; i = i + 2)
            {
                swapped[i] = byteArray[i + 1];
                swapped[i + 1] = byteArray[i];
            }

            return swapped;
        }

        public static byte[] ReverseByteArray(byte[] byteArray)
        {
            byte[] reversed = new byte[byteArray.Length];
            for (int i = 0; i < reversed.Length; i++)
                reversed[byteArray.Length - 1 - i] = byteArray[i];
            return reversed;
        }

        public static byte[] IncrementByteArray(byte[] byteArray, int valueToAdd)
        {
            byte[] incremented = new byte[byteArray.Length];
            for (int i = 0; i < incremented.Length; i++)
                incremented[i] = Convert.ToByte(Convert.ToInt32(byteArray[i]) + valueToAdd);
            return incremented;
        }

        public static byte[] IntToByteArrayHex(int value, int numBytes)
        {
            return HexStringToByteArray(value.ToString("D" + (numBytes * 2).ToString()));
        }
        
        public static byte[] IntToByteArrayHexAsHex(int value, int numBytes)
        {
            return HexStringToByteArray(value.ToString("X" + (numBytes * 2).ToString()));
        }

        public static byte[] IntToByteArraySingleBCD(int value, int numBytes)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byteArray = new byte[numBytes];
            String valAsStr = value.ToString().PadLeft(numBytes, '0');

            for (int i = 0; i < byteArray.Length; i++)
                sb.Append("0" + valAsStr[i]);

            return HiConvert.HexStringToByteArray(sb.ToString());
        }

        public static byte[] LongToByteArraySingleBCD(long value, int numBytes)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byteArray = new byte[numBytes];
            String valAsStr = value.ToString().PadLeft(numBytes, '0');

            for (int i = 0; i < byteArray.Length; i++)
                sb.Append("0" + valAsStr[i]);

            return HiConvert.HexStringToByteArray(sb.ToString());
        }

        public static byte[] RawSerialize(object obj)
        {
            int rawSize = Marshal.SizeOf(obj);
            IntPtr buffer = Marshal.AllocHGlobal(rawSize);

            Marshal.StructureToPtr(obj, buffer, false);

            byte[] rawData = new byte[rawSize];

            Marshal.Copy(buffer, rawData, 0, rawSize);
            Marshal.FreeHGlobal(buffer);

            return rawData;
        }

        public static object RawDeserialize(byte[] rawData, int position, Type anyType)
        {
            int rawsize = Marshal.SizeOf(anyType);

            if (rawsize > rawData.Length)
                throw new Exception("File size is smaller than expected");

            IntPtr buffer = Marshal.AllocHGlobal(rawsize);
            Marshal.Copy(rawData, position, buffer, rawsize);

            object retobj = Marshal.PtrToStructure(buffer, anyType);

            Marshal.FreeHGlobal(buffer);

            return retobj;
        }
    }
}
