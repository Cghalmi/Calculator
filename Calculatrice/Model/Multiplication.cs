

namespace Calculatrice.Model
{
    public class Multiplication : Operator
    {
        public Multiplication(int p)
            : base("*", p)
        {

        }
        public override float CalculeOp(string left, string right)
        {
            float leftFloat = 0;
            float RightFloat = 0;

            if(!float.TryParse(left, out leftFloat))
            {
                throw new System.Exception("Multiplication : left isn't number ");
            }
            if (!float.TryParse(right, out RightFloat))
            {
                throw new System.Exception("Multiplication : right isn't number ");
            }

            return leftFloat * RightFloat;
        }
    }
}