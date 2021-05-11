

using System;

namespace Calculatrice.Model
{
    public class Sqrt : Operator
    {
        public Sqrt(int p)
            : base("Sqrt", p)
        {

        }
        public override float CalculeOp(string left, string right = "")
        {

            if (!float.TryParse(left, out float leftFloat))
            {
                throw new System.Exception("Sqrt : left isn't number ");
            }
            return (float)Math.Sqrt(leftFloat);
        }
    }
}