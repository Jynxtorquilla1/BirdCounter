using BirdCounter;

namespace BridCounter.Tests
{
    public class Tests
    {

        [Test]
        public void Test1()
        {
            //arrange
            var bird = new BirdInMemory("Go³¹b");
            bird.AddNumber(1);
            bird.AddNumber(30);
            bird.AddNumber(300);

            //act

            var statistics = bird.GetStatistics();

            //assert

            Assert.AreEqual(331, statistics.Sum);


        }
    }
}