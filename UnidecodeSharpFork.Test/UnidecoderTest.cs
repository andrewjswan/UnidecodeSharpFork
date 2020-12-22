using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnidecodeSharpFork.Test
{
    /// <summary>
    ///This is a test class for UnidecoderTest and is intended
    ///to contain all UnidecoderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UnidecoderTest
    {
        [TestMethod]
        public void DocTest()
        {
            Assert.AreEqual("Bei Jing ", "\u5317\u4EB0".Unidecode());
        }

        [TestMethod]
        public void CustomTest()
        {
            Assert.AreEqual("Rabota s kirillitsey", "Работа с кириллицей".Unidecode());
            Assert.AreEqual("aouoAOUO", "äöűőÄÖŨŐ".Unidecode());
        }

        [TestMethod]
        public void PythonTest()
        {
            Assert.AreEqual("Hello, World!", "Hello, World!".Unidecode());

            Assert.AreEqual("'\"\r\n", "'\"\r\n".Unidecode());
            Assert.AreEqual("CZSczs", "ČŽŠčžš".Unidecode());
            Assert.AreEqual("a", "ア".Unidecode());
            Assert.AreEqual("a", "α".Unidecode());
            Assert.AreEqual("a", "а".Unidecode());
            Assert.AreEqual("chateau", "ch\u00e2teau".Unidecode());
            Assert.AreEqual("vinedos", "vi\u00f1edos".Unidecode());
        }

        /// <summary>
        /// According to http://en.wikipedia.org/wiki/Romanization_of_Russian BGN/PCGN.
        /// http://en.wikipedia.org/wiki/BGN/PCGN_romanization_of_Russian
        /// With converting "ё" to "yo".
        /// </summary>
        [TestMethod]
        public void RussianAlphabetTest()
        {
            string russianAlphabetLowercase = "а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я";
            string russianAlphabetUppercase = "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";

            string expectedLowercase = "a b v g d e yo zh z i y k l m n o p r s t u f kh ts ch sh shch \" y ' e yu ya";
            string expectedUppercase = "A B V G D E Yo Zh Z I Y K L M N O P R S T U F Kh Ts Ch Sh Shch \" Y ' E Yu Ya";

            Assert.AreEqual(expectedLowercase, russianAlphabetLowercase.Unidecode());
            Assert.AreEqual(expectedUppercase, russianAlphabetUppercase.Unidecode());
        }

        [TestMethod]
        public void CharUnidecodeTest()
        {
            string input = "а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";
            string expected = "a b v g d e yo zh z i y k l m n o p r s t u f kh ts ch sh shch \" y ' e yu ya A B V G D E Yo Zh Z I Y K L M N O P R S T U F Kh Ts Ch Sh Shch \" Y ' E Yu Ya";

            var sb = new StringBuilder(expected.Length);
            foreach (char c in input)
            {
                sb.Append(c.Unidecode());
            }
            string result = sb.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void UnidecodeOnNullShouldReturnEmptyString()
        {
            Assert.AreEqual("", ((string)null).Unidecode());
        }
    }
}
