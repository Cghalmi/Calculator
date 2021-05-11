

namespace Calculatrice.Model
{
    public class Addition : Operator
    {
        public Addition(int p)
            : base("+", p)
        {

        }
        public override float CalculeOp(string left, string right)
        {
            float leftFloat = 0;
            float RightFloat = 0;

            if(!float.TryParse(left, out leftFloat))
            {
                throw new System.Exception("Addition : left isn't number ");
            }
            if (!float.TryParse(right, out RightFloat))
            {
                throw new System.Exception("Addition : right isn't number ");
            }

            return leftFloat + RightFloat;
        }
    }
}