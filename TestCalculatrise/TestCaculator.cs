using Calculatrice.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestCalculatrise
{
    public class TestCaculator
    {
       
        [SetUp]
        public void Setup()
        {
            // list for first example 
            
        }



        //[Test]
        ////"(2+5)*3"
        //public void OperationTestFragment()
        //{
        //    List<Operations> fragmentResult = new List<Operations>();
        //    var op1 = new Operations("2+5", null);
        //    fragmentResult.Add(op1);
        //    fragmentResult.Add(new Operations("(2+5)*3", op1));
        //    var calcule = new Calculatrice.Calculator();
        //    var result = calcule.Fragmate("(2+5)*3");
        //    Assert.AreEqual(result, fragmentResult);
        //}

        [Test]
        [TestCase("1+1", "2")]
        [TestCase("1 + 2", "3")]
        [TestCase("1 + -1", "0")]
        [TestCase("-1 - -1", "0")]
        [TestCase("5-4", "1")]
        [TestCase("5*2", "10")]
        [TestCase("(2+5)*3", "21")]
        [TestCase("10/2", "5")]
        [TestCase("2+2*5+5", "17")]
        [TestCase("2.8*3-1", "7.4")]
        [TestCase("2^8", "256")]
        [TestCase("2^8*5-1", "1279")]
        [TestCase("sqrt(4)", "2")]
        [TestCase("1/0", "Erreur*")]

        public void OperationTestCalculator(string input, string output)
        {
            var calcule = new Calculatrice.Calculator();
            var result =  calcule.CalculeWithExp(input); 
            Assert.AreEqual(result, output); 
        }

    }
}