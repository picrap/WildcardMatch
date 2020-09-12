// A very simple wildcard match
// https://github.com/picrap/WildcardMatch

namespace WildcardMatchTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WildcardMatch;

    [TestClass]
    public class Test
    {
        [TestMethod]
        public void NoWildcardMatchTest()
        {
            Assert.IsTrue("a".WildcardMatch("a"));
        }

        [TestMethod]
        public void NoWildcardNoMatchTest()
        {
            Assert.IsFalse("a".WildcardMatch("b"));
        }

        [TestMethod]
        public void NoWildcardNoMatchConsiderCaseTest()
        {
            Assert.IsFalse("a".WildcardMatch("A", false));
        }

        [TestMethod]
        public void NoWildcardNoMatchMixedCaseTest()
        {
            Assert.IsTrue("a".WildcardMatch("A", true));
        }

        [TestMethod]
        public void QuestionMarkMatchTest()
        {
            Assert.IsTrue("a?".WildcardMatch("aa"));
        }

        [TestMethod]
        public void QuestionMarkNoMatchTest()
        {
            Assert.IsFalse("a?".WildcardMatch("ba"));
        }

        [TestMethod]
        public void AsteriskStartMatch1Test()
        {
            Assert.IsTrue("*bc".WildcardMatch("abc"));
        }

        [TestMethod]
        public void AsteriskStartNoMatchTest()
        {
            Assert.IsFalse("*bc".WildcardMatch("bd"));
        }

        [TestMethod]
        public void AsteriskStartMatch0Test()
        {
            Assert.IsTrue("*bc".WildcardMatch("bc"));
        }

        [TestMethod]
        public void AsteriskStartMatch2Test()
        {
            Assert.IsTrue("*bc".WildcardMatch("debc"));
        }

        [TestMethod]
        public void AsteriskMiddleNoMatchTest()
        {
            Assert.IsFalse("x*y".WildcardMatch("xz"));
        }

        [TestMethod]
        public void AsteriskMiddleMatch0Test()
        {
            Assert.IsTrue("x*z".WildcardMatch("xz"));
        }

        [TestMethod]
        public void AsteriskMiddleMatch1Test()
        {
            Assert.IsTrue("x*z".WildcardMatch("xyz"));
        }

        [TestMethod]
        public void AsteriskMiddleMatch2Test()
        {
            Assert.IsTrue("x*z".WildcardMatch("x12z"));
        }

        [TestMethod]
        public void AsteriskEndNoMatchTest()
        {
            Assert.IsFalse("i*".WildcardMatch("j"));
        }

        [TestMethod]
        public void AsteriskEndMatch0Test()
        {
            Assert.IsTrue("i*".WildcardMatch("i"));
        }

        [TestMethod]
        public void AsteriskEndMatch1Test()
        {
            Assert.IsTrue("i*".WildcardMatch("ij"));
        }

        [TestMethod]
        public void AsteriskEndMatch2Test()
        {
            Assert.IsTrue("i*".WildcardMatch("ijk"));
        }
        
        [TestMethod]
        public void AsteriskInMiddle()
        {
            Assert.IsFalse("abcdefgh.*.abcdefg.abcde".WildcardMatch("abcdefgh.50.abcdefg.abcdefg"));
        }
        
        
        [TestMethod]
        public void AsteriskInMiddleMatch()
        {
            Assert.IsTrue("abcdefgh.*.abcdefg.abcde".WildcardMatch("abcdefgh.50.abcdefg.abcde"));
        }
        
        
        [TestMethod]
        public void LongSameString()
        {
            Assert.IsTrue("abcdefghabcdefgabcde".WildcardMatch("abcdefghabcdefgabcde"));
        }
        
        
        [TestMethod]
        public void LongerText()
        {
            Assert.IsFalse("abcdefghabcdefgabcde".WildcardMatch("abcdefghabcdefgabcdeIJKLMNOP"));
        }
        
        [TestMethod]
        public void LongerPattern()
        {
            Assert.IsFalse("abcdefghabcdefgabcde*hfjdh*hfjdhf".WildcardMatch("abcdefghabcdefgabcde"));
        }
        
        [TestMethod]
        public void MoreThanOneStar()
        {
            Assert.IsTrue("abcde*fghabcde*fgabcde*".WildcardMatch("abcde123fghabcde456fgabcde789"));
        }
    }
}
