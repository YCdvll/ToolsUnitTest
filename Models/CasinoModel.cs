namespace ToolsUnitTest.Models
{
    public class CasinoModel
    {
        public Type Type { get; set; }
        public TypeDetail TypeDetail { get; set; }
        public int Number { get; set; }
        public int Mise { get; set; }
    }

    public enum Type
    {
        Color,
        OddEven,
        MinMax,
        Column,
        Number,
    }

    public enum TypeDetail
    {
        Red,
        Black,
        Odd,
        Even,
        Min,
        Max,
        TopLine,
        MiddleLine,
        BotLine
    }
}