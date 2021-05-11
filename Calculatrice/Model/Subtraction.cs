

namespace Calculatrice.Model
{
    public class Subtraction : Operator
    {
        public Subtraction(int p)
            : base("-", p)
        {

        }
        public override float CalculeOp(string left, string right)
        {
            float leftFloat = 0;
            float RightFloat = 0;

            if (!float.TryParse(left, out leftFloat))
            {
                throw new System.Exception("Subtraction : left isn't number ");
            }
            if (!float.TryParse(right, out RightFloat))
            {
                throw new System.Exception("Subtraction : right isn't number ");
            }

            return leftFloat - RightFloat;
        }
    }
}