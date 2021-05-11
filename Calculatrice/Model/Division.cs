

namespace Calculatrice.Model
{
    public class Division : Operator
    {
        public Division(int p)
            : base("/", p)
        {

        }
        public override float CalculeOp(string left, string right)
        {

            if (!float.TryParse(left, out float leftFloat))
            {
                throw new System.Exception("Division : left isn't number ");
            }
            if (!float.TryParse(right, out float RightFloat))
            {
                throw new System.Exception("Division : right isn't number ");
            }
            else if(RightFloat == 0)
            {
                throw new System.Exception("Division : right number can't be 0 ");
            }

            return leftFloat / RightFloat;
        }
    }
}