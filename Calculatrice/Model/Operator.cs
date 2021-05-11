

namespace Calculatrice.Model
{
    public abstract class Operator : SignOperation
    {
        public Operator(string _sign, int p)
            : base(_sign, p)
        {
        }
        public abstract float CalculeOp(string left, string right);
    }
}