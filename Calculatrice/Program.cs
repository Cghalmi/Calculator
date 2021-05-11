using Calculatrice.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculatrice
{
    public class Program
    {

        public static void Main(string[] args)
        { 
            var toCalcule = "(2+5)*3"; //21  
            var calculator = new Calculator();
            var result = calculator.CalculeWithExp(toCalcule); 
                 
            Console.WriteLine($"resutlt of {toCalcule} : {result.ToString()}");
        }
    

    }
}
