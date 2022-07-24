using GeekSeatWitchSaga.Models;
using GeekSeatWitchSaga.Data;
using GeekSeatWitchSaga.Data.Services;

namespace WitchSagaTest
{
    

    public class Tests
    {
        private decimal _avgTest;
        private WitchSagaService _witchSagaService;
        private List<Villager> _villagers;
        
        [SetUp]
        public void Setup()
        {
            _avgTest = 4.5m;
            _witchSagaService = new WitchSagaService();
            _villagers = new List<Villager>();

            Villager villager = new Villager();
            villager.Name = "Dummy 1";
            villager.AgeOfDeath = 10;
            villager.YearOfDeath = 12;
            villager.YearKilled = villager.YearOfDeath - villager.AgeOfDeath;
            villager.NumberKilled = _witchSagaService.GenerateNumberOfKilled(villager.YearKilled);
            _villagers.Add(villager);

            villager = new Villager();
            villager.Name = "Dummy 2";
            villager.AgeOfDeath = 13;
            villager.YearOfDeath = 17;
            villager.YearKilled = villager.YearOfDeath - villager.AgeOfDeath;
            villager.NumberKilled = _witchSagaService.GenerateNumberOfKilled(villager.YearKilled);
            _villagers.Add(villager);
        }

        [Test]
        public void Test1()
        {
            int iSumData = _villagers.Select(a => a.NumberKilled).Sum();
            int iCountData = _villagers.Count();
             //avgTest = _avgTest.ToString("#.##");
            decimal avgToTest = _witchSagaService.AverageData(iSumData, iCountData);
            Assert.AreEqual(_avgTest, avgToTest);
        }
    }
}