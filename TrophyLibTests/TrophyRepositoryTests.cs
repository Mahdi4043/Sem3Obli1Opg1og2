using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrophyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TrophyLib.Tests
{
    [TestClass()]
    public class TrophyRepositoryTests
    {
        private TrophyRepository _repo;
        private readonly Trophy _badTrophy = new() { Competition = "Hoolahooping", Year = 1969 };

        [TestInitialize]
        public void Init()
        {
            _repo = new TrophyRepository();

            _repo.Add(new Trophy() { Competition = "Running", Year = 2000 });
            _repo.Add(new Trophy() { Competition = "Cycling", Year = 2001 });
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_repo.GetById(1));
            Assert.IsNull(_repo.GetById(100));
        }

        [TestMethod()]
        public void AddTest()
        {
            Trophy t = new() { Competition = "Dancing", Year = 2000 };
            Assert.AreEqual(3, _repo.Add(t).Id);
            Assert.AreEqual(3, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(_badTrophy));
        }

        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Trophy> trophies = _repo.Get();
            Assert.AreEqual(2, trophies.Count());
            Assert.AreEqual(trophies.First().Competition, "Running");

            IEnumerable<Trophy> sortedTrophies = _repo.Get(orderBy: "competition");
            Assert.AreEqual(sortedTrophies.First().Competition, "Cycling");

            IEnumerable<Trophy> sortedTrophies2 = _repo.Get(orderBy: "year");
            Assert.AreEqual(sortedTrophies2.First().Competition, "Running");
        }
    }
}