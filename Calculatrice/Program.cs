using System;

namespace Calculatrice
{
    public static class Program
    {

        public static void Main(string[] args)
        {
            var toCalcule = "(2+5)*3"; //21  
            var calculator = new Calculator();
            var result = calculator.CalculeWithExpFromString(toCalcule);

            Console.WriteLine($"resutlt of {toCalcule} : {result.ToString()}");
        }
    }
}
