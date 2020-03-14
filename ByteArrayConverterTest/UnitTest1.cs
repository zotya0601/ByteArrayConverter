using Microsoft.VisualStudio.TestTools.UnitTesting;
using ByteArrayConverter;

namespace ByteArrayConverterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ToByteArrEvenLength()
        {
            string hex = "fa";
            byte[] e = Converter.HexStringToByteArray(hex);
            Assert.AreEqual(250, e[0]);
        }

        [TestMethod]
        public void ToByteArrOddLength()
        {
            string hex = "f";
            byte[] e = Converter.HexStringToByteArray(hex);
            Assert.AreEqual(15, e[0]);
        }

        [TestMethod]
        public void ToByteArrOddLengthBig()
        {
            string hex = "F";
            byte[] e = Converter.HexStringToByteArray(hex);
            Assert.AreEqual(15, e[0]);
        }

        [TestMethod]
        public void RandomHexStringEvenLength()
        {
            string hex = "8F4eab4245AB";
            byte[] e = Converter.HexStringToByteArray(hex);
            int hexIndex = 0;
            for(int i = 0; i < e.Length; i++)
            {
                string hexpart = string.Concat(hex[hexIndex], hex[hexIndex + 1]);
                byte[] hexpartbyte = Converter.HexStringToByteArray(hexpart);
                Assert.AreEqual(hexpartbyte[0], e[i]);
                hexIndex += 2;
            }
        }

        [TestMethod]
        public void RandomHexStringOddLength()
        {
            string hex = "8F4eab4245A";
            byte[] e = Converter.HexStringToByteArray(hex);
            hex = string.Concat("0", hex);
            int hexIndex = 0;
            for (int i = 0; i < e.Length; i++)
            {
                string hexpart = string.Concat(hex[hexIndex], hex[hexIndex + 1]);
                byte[] hexpartbyte = Converter.HexStringToByteArray(hexpart);
                Assert.AreEqual(hexpartbyte[0], e[i]);
                hexIndex += 2;
            }
        }

        [TestMethod]
        public void RandomByteArr()
        {
            byte[] arr = { 232, 10, 4, 55 };
            string hex = Converter.ByteArrayToHexString(arr);
            Assert.AreEqual("e80a0437", hex);
        }

        [TestMethod]
        public void RandomByteArrCapitals()
        {
            byte[] arr = { 232, 10, 4, 55 };
            string hex = Converter.ByteArrayToHexString(arr, true);
            Assert.AreEqual("E80A0437", hex);
        }
    }
}
