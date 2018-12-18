using NUnit.Framework;

using SharpEcho.Recruiting.SpellChecker.Contracts;
using SharpEcho.Recruiting.SpellChecker.Core;

namespace SharpEcho.Recruiting.SpellChecker.Tests
{
    [TestFixture]
    class DictionaryDotComSpellCheckerTests
    {
        private ISpellChecker SpellChecker;

        [TestFixtureSetUp]
        public void TestFixureSetUp()
        {
            SpellChecker = new DictionaryDotComSpellChecker();
        }

        [Test]
        public void Check_That_SharpEcho_Is_Misspelled()
        {
            var word = "SharpEcho";
            var result = SpellChecker.Check(word);
            Assert.IsFalse(result, $"{word} is spelled incorrectly");
        }

        [Test]
        public void Check_That_South_Is_Not_Misspelled()
        {
            var word = "South";
            var result = SpellChecker.Check(word);
            Assert.IsTrue(result, $"{word} is spelled correctly");
        }
    }
}
