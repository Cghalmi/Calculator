namespace Calculatrice.Model
{
    public class Operations
    {
        public string input { get; set; }
        public Operations? related { get; set; }
        public double result { get; set; }

        public Operations(string _input, Operations? _related)
        {
            input = _input;
            related = _related;
        } 
    }
}