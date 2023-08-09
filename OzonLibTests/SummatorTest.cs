using OzonLib;

namespace OzonLibTests
{
    public class SummatorTest
    {
        [Fact]
        public void Test1()
        {
            var summator = Summator.SetValues(4, 5);
            var sum = summator.Sum();
            Assert.Equal(9, sum);
        }
    }
}