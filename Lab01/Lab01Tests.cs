using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab01
{
    [TestClass]
    public class Lab01Tests
    {
        [TestMethod]
        public void A()
        {
            var lab = new Lab();
            var actual = lab.Joey("A");
            Assert.AreEqual("A", actual);
        }
    }
}