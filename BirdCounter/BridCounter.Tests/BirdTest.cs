using BirdCounter;

namespace BridCounter.Tests
{
    public class Tests
    {

        [Test]
        public void WhenNumbersAreProvided_ShouldReturnCorrectStatistics()
        {
            //arrange

            var bird = new BirdInMemory("Go³¹b");
            bird.AddNumber(3);
            bird.AddNumber(30);
            bird.AddNumber(300);

            //act

            var statistics = bird.GetStatistics();

            //assert

            Assert.AreEqual(333, statistics.Sum);
            Assert.AreEqual(3, statistics.Count);
            Assert.AreEqual(111, statistics.Avarage);
            Assert.AreEqual(3, statistics.Min);
            Assert.AreEqual(300, statistics.Max);

        }

        [Test]
        public void WhenCharsAreProvided_ShouldReturnCorrectStatistics()
        {
            //arrange

            var bird = new BirdInMemory("Go³¹b");
            bird.AddNumber("i");
            bird.AddNumber("E");
            bird.AddNumber("c");
            bird.AddNumber("A");

            //act

            var statistics = bird.GetStatistics();

            //assert

            Assert.AreEqual(1610, statistics.Sum);
            Assert.AreEqual(4, statistics.Count);
            Assert.AreEqual(402.5, statistics.Avarage);
            Assert.AreEqual(60, statistics.Min);
            Assert.AreEqual(850, statistics.Max);

        }
    }
}