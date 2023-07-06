using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculatrice
{
    public class Calculator2
    {
        public string Eval(string str)
        {
            var dic = new Dictionary<string, int>();
            dic.Add("(", 1);
            dic.Add("/", 2);
            dic.Add("*", 2);
            dic.Add("+", 3);
            dic.Add("-", 3);
            char[] chars = { '*', '+', '-', '/' };
            while (dic.Any(x => str.Contains(x.Key)))
            {
                int i = 0;
                while (dic.Count > 0)
                {
                    var key = dic.ElementAt(i).Key;
                    var index = str.IndexOf(key);
                    var Resultdouble = 0.0d;
                    var left = "";
                    var right = "";

                    var anyOperator = str.IndexOfAny(chars);
                    if (anyOperator == -1)
                        return str;

                    if (index != -1)
                    {
                        switch (key)
                        {
                            case "(":
                                var endPar = str.IndexOf(')', index);
                                var endlength = endPar != -1 ? endPar - index : str.Length;
                                var firstValue = str.Substring(index, endlength);
                                var betwenvalue = firstValue.Substring(1, firstValue.Length - 1);
                                var exitsIndex = betwenvalue.IndexOf("(");

                                if (exitsIndex != -1)
                                {
                                    exitsIndex = betwenvalue.LastIndexOf("(");
                                    endPar = betwenvalue.IndexOf(')', index);
                                    endlength = endPar != -1 ? endPar - exitsIndex - 1 : betwenvalue.Length - 1;
                                    betwenvalue = betwenvalue.Substring(exitsIndex + 1, endlength - exitsIndex);
                                }

                                var result = Eval(betwenvalue);
                                str = str.Replace("(" + betwenvalue + ")", result);
                                break;

                            case "/":
                                calculate(str, chars, index, out left, out right);

                                Resultdouble = Convert.ToDouble(left) / Convert.ToDouble(right);
                                str = str.Replace(left + "/" + right, Resultdouble.ToString());
                                break;

                            case "*":
                                calculate(str, chars, index, out left, out right);

                                Resultdouble = Convert.ToDouble(left) * Convert.ToDouble(right);
                                str = str.Replace(left + "*" + right, Resultdouble.ToString());
                                break;

                            case "+":
                                calculate(str, chars, index, out left, out right);

                                Resultdouble = Convert.ToDouble(left) + Convert.ToDouble(right);
                                str = str.Replace(left + "+" + right, Resultdouble.ToString());
                                break;
                            case "-":
                                calculate(str, chars, index, out left, out right);

                                Resultdouble = Convert.ToDouble(left) - Convert.ToDouble(right);
                                str = str.Replace(left + "-" + right, Resultdouble.ToString());
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        dic.Remove(key);
                    }
                }
            }

            return str;
        }

        private static void calculate(string str, char[] chars, int index, out string left, out string right)
        {
            var leftIndex = str.IndexOfAny(chars, 0);
            var leftStart = leftIndex == -1 || leftIndex == index ? 0 : leftIndex + 1;
            left = str.Substring(leftStart, Math.Abs(index - leftStart));
            var rightIndex = str.IndexOfAny(chars, index + 1);
            var rightStart = rightIndex == -1 ? str.Length - index : rightIndex - index;
            right = str.Substring(index + 1, rightStart - 1);
        }
    }
}
