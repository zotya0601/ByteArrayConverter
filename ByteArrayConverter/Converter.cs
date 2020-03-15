namespace ByteArrayConverter
{
    /// <summary>
    /// This class contains methods for converting byte arrays into hexadecimals strings and hexadecimal strings into byte arrays
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// Converts byte array into a hexadecimal string.
        /// </summary>
        /// <param name="arr">The byte array to convert</param>
        /// <param name="capitalLetters">If true, the function retruns with capital letters in the hexadecimal string. False by default</param>
        /// <returns></returns>
        public static string ByteArrayToHexString(byte[] arr, bool capitalLetters = false)
        {
            int len = arr.Length;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(len*2,len*2);
            if (capitalLetters) 
                for (int i = 0; i < len; i++) 
                    sb.Append(arr[i].ToString("X2"));
            else 
                for (int i = 0; i < len; i++) 
                    sb.Append(arr[i].ToString("x2"));
            return sb.ToString();
        }
        /// <summary>
        /// Converts hexadecimal string into a byte array
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static byte[] HexStringToByteArray(string hex)
        {
            if (hex.Length % 2 == 1) hex = string.Concat("0", hex);
            byte[] bytes = new byte[hex.Length / 2];
            uint index = 0;
            for (int i = 0; i < hex.Length; i += 2)
            {
                //first char, big
                byte byte1 = (byte)hex[i];
                if (byte1 < 58) byte1 -= 48;
                else if (byte1 > 64 && byte1 < 71) byte1 -= 55;
                else if (byte1 > 96) byte1 -= 87;
                byte1 *= 16;
                //second char, little
                byte byte2 = (byte)hex[i + 1];
                if (byte2 < 58) byte2 -= 48;
                else if (byte2 > 64 && byte2 < 71) byte2 -= 55;
                else if (byte2 > 96) byte2 -= 87;
                //add
                byte sum = (byte)(byte1 + byte2);
                bytes[index] = sum;
                index++;
            }
            return bytes;
        }
    }
}
