namespace AlternateCapsTests;

public class AlternateCapsMethodTests
{
    [Test]
    public void GivenStringOfAllLowercaseLetters_ReturnsAlternatingCapitalization()
    {
        string toUse = "abcdefghijklmnopqrstuvwxyz";
        string expected = "aBcDeFgHiJkLmNoPqRsTuVwXyZ";

        string result = Program.AlternateCaps(toUse);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GivenStringOfAllLowercaseLetters_StartWithCaps_ReturnsAlternatingCapitalizationStartingWithCaps()
    {
        string toUse = "abcdefghijklmnopqrstuvwxyz";
        string expected = "AbCdEfGhIjKlMnOpQrStUvWxYz";

        string result = Program.AlternateCaps(toUse, true);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GivenStringOfNumbers_ReturnsTheSameString()
    {
        string toUse = "0123456789";
        string expected = "0123456789";

        string result = Program.AlternateCaps(toUse);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void GivenStringOfSymbols_ReturnsTheSameString()
    {
        string toUse = "!@#$%^&*()_+-=`~";
        string expected = "!@#$%^&*()_+-=`~";

        string result = Program.AlternateCaps(toUse);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    [TestCase(false, "aBcDeFg1234567!@#$%^&")]
    [TestCase(true, "AbCdEfG1234567!@#$%^&")]
    public void GivenStringOfLettersNumbersAndSymbols_ReturnStringWhereOnlyLettersAreModified(bool startWithCaps, string expected)
    {
        string toUse = "abcdefg1234567!@#$%^&";

        string result = Program.AlternateCaps(toUse, startWithCaps);

        Assert.That(result, Is.EqualTo(expected));
    }
}
