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
    }
}