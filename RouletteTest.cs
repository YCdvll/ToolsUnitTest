using ToolsUnitTest.Models;
using Type = ToolsUnitTest.Models.Type;

namespace ToolsUnitTest;

[TestClass]
public class RouletteTest
{
    [TestMethod]
    public void CrackRoulette()
    {
        int money = 100;
        int random = new Random().Next(0, 36);
        int numPlay = 25;

        var play = new List<CasinoModel> {
            new CasinoModel{
                Type = Type.Color,
                TypeDetail = TypeDetail.Red,
                Mise = 5
            },
            new CasinoModel{
                Type = Type.Column,
                TypeDetail = TypeDetail.MiddleLine,
                Mise = 5
            }
        };

        var result = Play(play, money, random, numPlay);
    }

    private int Play(List<CasinoModel> playList, int money, int random, int numPlay)
    {
        for (int i = 0; i < numPlay; i++)
        {
            foreach (var play in playList)
            {
                money -= play.Mise;
                switch (play.Type)
                {
                    case Type.Color: money += Color(play, random); continue;
                    case Type.Column: money += Column(play, random); continue;
                    case Type.OddEven: money += OddEven(play, random); continue;
                    case Type.MinMax: money += MinMax(play, random); continue;
                }
            }
        }

        return money;
    }

    private int Number(CasinoModel play, int random)
    {
        if (play.Type == Type.Number && random == play.Number)
            return play.Mise * 36;
        else
            return 0;
    }

    private int Color(CasinoModel play, int random)
    {
        int[] redNumber = { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
        int[] blackNumber = { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };

        if (redNumber.Contains(random) && play.TypeDetail == TypeDetail.Red)
            return play.Mise * 2;
        if (blackNumber.Contains(random) && play.TypeDetail == TypeDetail.Black)
            return play.Mise * 2;
        else
            return 0;
    }

    private int OddEven(CasinoModel play, int random)
    {
        if (random % 2 == 0 && play.TypeDetail == TypeDetail.Even)
            return play.Mise * 2;
        if (random % 2 != 0 && play.TypeDetail == TypeDetail.Odd)
            return play.Mise * 2;
        else
            return 0;
    }

    private int MinMax(CasinoModel play, int random)
    {
        if (random > 0 && random <= 18 && play.TypeDetail == TypeDetail.Min)
            return play.Mise * 2;
        if (random > 18 && random <= 36 && play.TypeDetail == TypeDetail.Max)
            return play.Mise * 2;
        else
            return 0;
    }

    private int Column(CasinoModel play, int random)
    {
        int[] topLine = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
        int[] middelLine = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
        int[] botLine = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };

        if (topLine.Contains(random) && play.TypeDetail == TypeDetail.TopLine)
            return play.Mise * 3;
        if (middelLine.Contains(random) && play.TypeDetail == TypeDetail.MiddleLine)
            return play.Mise * 3;
        if (botLine.Contains(random) && play.TypeDetail == TypeDetail.BotLine)
            return play.Mise * 3;
        else
            return 0;
    }
}