using OldPhonePad.Helper;

namespace OldPhonePad.UnitTest
{
    public class UnitTestOfGenerateText
    {
        [Test]
        public  void Test_SingleKeyPress()
        {
            GenerateTextHelper.Initialize();

            Assert.AreEqual("E", GenerateTextHelper.Generate("33#"));
        }

        [Test]
        public void Test_MultipleKeys_Pauses()
        {
            GenerateTextHelper.Initialize();
            Assert.AreEqual("HELLO", GenerateTextHelper.Generate("4433555 555666#"));
        }

        [Test]
        public void Test_WithBackspace()
        {
            GenerateTextHelper.Initialize();
            string result = GenerateTextHelper.Generate("8 2 999 9999 2 777 6 999 2 8 66 666 33#");
            Assert.AreEqual("TAYZARMYATNOE", result);
        }

    }
}