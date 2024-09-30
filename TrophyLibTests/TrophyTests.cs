using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib.Tests
{
    [TestClass()]
    public class TrophyTests
    {
        private readonly Trophy trophyNegativeId = new Trophy(-1, "Cycling", 2000);
        private readonly Trophy trophyNullComp = new Trophy(2, null, 2000);
        private readonly Trophy trophyShortComp = new Trophy(3, "Ro", 2000);
        private readonly Trophy trophyTooEarly = new Trophy(4, "Cycling", 1969);

        private readonly Trophy trophy = new Trophy(5, "Cycling", 2000);

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Trophy info: 5, Cycling, 2000", trophy.ToString());
        }

        [TestMethod()]
        public void ValidateIdTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyNegativeId.ValidateId());
        }

        [TestMethod()]
        public void ValidateNullCompTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => trophyNullComp.ValidateComp());
        }

        [TestMethod()]
        public void ValidateCompTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyShortComp.ValidateComp());
        }

        [TestMethod()]
        public void ValidateYearTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => trophyTooEarly.ValidateYear());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            trophy.Validate();
        }
    }
}
