namespace UI.Base
{
    public class Knife : IUnit
    {
        public float Size { get; set; }
        public override string ToString() => Size.ToString();
    }
}
