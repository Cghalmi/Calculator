

namespace Calculatrice.Model
{
    public abstract class SignOperation
    {
        public string Sign { get; set; }
        public int Priority { get; set; }
         
        public SignOperation(string _sign, int p)
        {
            Sign = _sign;
            Priority = p;
        } 
    }
}