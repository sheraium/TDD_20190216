using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab01
{
    [TestClass]
    public class Lab01Tests
    {
        private Lab _lab = new Lab();

        [TestMethod]
        public void A()
        {
            var actual = _lab.Joey("A");
            Assert.AreEqual("A", actual);
        }

        [TestMethod]
        public void ab()
        {
            var actual = _lab.Joey("ab");
            Assert.AreEqual("A-Bb", actual);
        }

        [TestMethod]
        public void Abc()
        {
            var actual = _lab.Joey("Abc");
            Assert.AreEqual("A-Bb-Ccc", actual);
        }
    }
}