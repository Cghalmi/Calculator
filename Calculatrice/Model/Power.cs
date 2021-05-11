

using System;

namespace Calculatrice.Model
{
    public class Power : Operator
    {
        public Power(int p)
            : base("^", p)
        {

        }
        public override float CalculeOp(string left, string right)
        {

            if (!float.TryParse(left, out float leftFloat))
            {
                throw new System.Exception("Power : left isn't number ");
            }
            if (!float.TryParse(right, out float RightFloat))
            {
                throw new System.Exception("Power : right isn't number ");
            } 

            return (float)Math.Pow(leftFloat,RightFloat);
        }
    }
}