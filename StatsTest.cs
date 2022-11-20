using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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


        private int BoucleRandom(int min, int max, int boucle)
        {
            var randFunc = new Random();
            var listNum = new List<int> { };
            var result = 0;
            var resultNum = new List<int>();

            for (var i = 0; i < boucle; i++)
            {
                int random = randFunc.Next(min, max);
                listNum.Add(random);
            }

            var listGroupe = listNum.GroupBy(x => x).OrderByDescending(x => x.Key);
            var mostOccuranceNum = listNum.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
            Debug.WriteLine(listGroupe);

            return result;
        }
    }
}