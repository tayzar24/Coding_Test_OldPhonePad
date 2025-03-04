using OldPhonePad.Helper;

namespace OldPhonePad.UnitTest
{
    public class UnitTestOfGenerateText
    {
        [Test]
public  void Test_SingleKey()
{
    GenerateTextHelper.Initialize();

    Assert.AreEqual("E", GenerateTextHelper.Generate("33#"));
}

[Test]
public void Test_Backspace()
{
    GenerateTextHelper.Initialize();
    Assert.AreEqual("B", GenerateTextHelper.Generate("227*#"));
}

[Test]
public void Test_MultipleKeysAndWhiteSpace()
{
    GenerateTextHelper.Initialize();
    Assert.AreEqual("HELLO", GenerateTextHelper.Generate("4433555 555666#"));
}

[Test]
public void Test_WithDuplicateHash()
{
    GenerateTextHelper.Initialize();
    string result = GenerateTextHelper.Generate("33##");
    Assert.AreEqual("E", result);
}

[Test]
public void Test_WithNotEnterHashKey()
{
    GenerateTextHelper.Initialize();
    string result = GenerateTextHelper.Generate("33");
    Assert.AreEqual("33", result);
}

    }
}
