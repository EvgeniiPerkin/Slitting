using System.Collections.Generic;

namespace UI.Base
{
    public class Head
    {
        public Stack<IUnit> Structure { get; set; } = new Stack<IUnit>();
        public float Lenght { get; set; }
    }
}
