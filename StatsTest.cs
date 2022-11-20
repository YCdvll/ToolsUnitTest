namespace ToolsUnitTest
{
    [TestClass]
    public class StatsTest
    {
        [TestMethod]
        public void IsRandomPerfect()
        {
            int min = 0;
            int max = 100;
            int boucle = 1000;

            var result = BoucleRandom(min, max, boucle);
        }


        private Tuple<int, int> BoucleRandom(int min, int max, int boucle)
        {
            var randFunc = new Random();
            var listNum = new List<int> { };

            for (var i = 0; i < boucle; i++)
            {
                int random = randFunc.Next(min, max);
                listNum.Add(random);
            }

            var occuranceNum = listNum.GroupBy(i => i).OrderByDescending(grp => grp.Count()).First();
            return Tuple.Create(occuranceNum.Key, occuranceNum.Count());
        }
    }
}