using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EncodeDecode.Tests
{
    [TestClass]
    public class EncodeDecodeTest
    {
        [TestMethod]
        public void EqualsEncodeDecode()
        {
            string message = "1234567890-abcdefghiklmn-ABCDEFGHIKLMN-!?=+";

            Program program = new Program();
            byte[] encodeBytes = program.Encode(message);

            string decodeMessage = program.Decode(encodeBytes);

            Assert.AreEqual(message, decodeMessage);

        }

        [TestMethod]
        public void FinalByteSize()
        {
            string message = "1234567890-abcdefghiklmn-ABCDEFGHIKLMN-!?=+";
            int bytesArraySize = message.Length;
            int expectedBytesSize =(int)Math.Ceiling((double)(bytesArraySize) * 7 / 8);


            Program program = new Program();
            byte[] encodeBytes = program.Encode(message);          

            Assert.AreEqual(encodeBytes.Length, expectedBytesSize);

        }
    }
}
