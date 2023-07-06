using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Calculatrice
{
    public static class Program
    {

        public static void Main(string[] args)
        {
            var toCalcule1 = "6*(4/2)+3*1"; //15  
            var toCalcule2 = "6/3-1"; //1  
            var toCalcule3 = "((3+5)-6)"; //1  
            var toCalcule4 = "6*(4/2)+(3*1)"; //15   
            var cal = new Calculator2();
            var result = cal.Eval(toCalcule1);
            Console.WriteLine($"resutlt of {toCalcule1} : {result.ToString()}");

            var result2 = cal.Eval(toCalcule2);
            Console.WriteLine($"resutlt of {toCalcule2} : {result2.ToString()}");
            var result4 = cal.Eval(toCalcule4);
            Console.WriteLine($"resutlt of {toCalcule4} : {result4.ToString()}");

            var result3 = cal.Eval(toCalcule3);
            Console.WriteLine($"resutlt of {toCalcule3} : {result3.ToString()}");
        }

      
    }
}
