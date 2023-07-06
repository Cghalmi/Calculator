using Calculatrice.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculatrice
{   
    //error with some calculation
    //public class Calculator
    //{
    //    private const string ErrorMessage = "Erreur*";

    //    List<SignOperation> listOperator;

    //    public Calculator()
    //    {
    //    }

    //    public string CalculeWithExpFromString(string exp)
    //    {
    //        double result = 0.0;

    //        var cleanExp = CleanFormulat(exp);

    //        if (IsNonValid(cleanExp))
    //            return ErrorMessage;

    //        var expTable = cleanExp.ToCharArray();

    //        result = CalculeWithExpTableChar(expTable);

    //        return ParseResult(result);

    //    }

    //    private bool IsNonValid(string exp)
    //    {
    //        return exp.Contains("/0");
    //    }

    //    private static string ParseResult(double result)
    //    {
    //        if (result % 1 != 0)
    //        {
    //            result = Math.Round(result, 2);
    //        }

    //        return result.ToString();
    //    }

    //    private static string CleanFormulat(string exp)
    //    {
    //        return exp.Replace(" ", "").Replace("++", "+").Replace("-+", "-").Replace("+-", "-").Replace("--", "+");
    //    }

    //    public double CalculeWithExpTableChar(char[] exp)
    //    {

    //        List<double> resultArray = new List<double>();//List for intermediate result

    //        var iterSum = 0.0;//Variable for read numbers 
    //        var lastOperation = "+";//Variable for last scanned Operation 
    //        var lastOperationIndex = 0;//Variable for last Operation index
    //        var hadDecimal = false;// Variable if is decimal

    //        for (int i = 0; i < exp.Length; i++)
    //        {
    //            var item = exp[i];

    //            if (char.IsDigit(item))
    //            {
    //                if (hadDecimal)
    //                {
    //                    iterSum = iterSum * 10 + int.Parse(item.ToString()) * 0.1;
    //                }
    //                else
    //                {
    //                    iterSum = iterSum * 10 + int.Parse(item.ToString());
    //                }
    //            }
    //            else if (item == '.')
    //            {
    //                iterSum = iterSum * 0.1;
    //                hadDecimal = true;
    //            }
    //            else
    //            {
    //                if ((new string[] { "^", "/", "(", "*", "+", "-", "s", "r" }).Any(x => x == item.ToString()))
    //                {
    //                    switch (lastOperation)
    //                    {
    //                        case "(":
    //                            List<char> contentParentheses = new List<char>();
    //                            int j;
    //                            for (j = lastOperationIndex + 1; j < exp.Length; j++)
    //                            {
    //                                if (exp[j] != ')')
    //                                {
    //                                    contentParentheses.Add(exp[j]);
    //                                }
    //                                else
    //                                {
    //                                    break;
    //                                }

    //                            }
    //                            var ParenthesesResult = CalculeWithExpTableChar(contentParentheses.ToArray());//recursive call to same method for calcule inside of parentheses
    //                            resultArray.Add(ParenthesesResult);//add result of parentese in intermediate list 
    //                            i = j; //continue after parentheses
    //                            item = exp[j];//continue after parentheses
    //                            break;
    //                        case ")":
    //                            break;
    //                        case "^":
    //                            if (iterSum > 0 && resultArray.Count == 0)
    //                            {
    //                                resultArray.Add(iterSum);
    //                            }
    //                            else if (resultArray.Count >= 1)
    //                            {
    //                                resultArray[resultArray.Count - 1] = Math.Pow(resultArray[resultArray.Count - 1], iterSum);
    //                            }
    //                            break;
    //                        case "*":
    //                            if (iterSum > 0 && resultArray.Count == 0)
    //                            {
    //                                resultArray.Add(iterSum);
    //                            }
    //                            else if (resultArray.Count >= 1)
    //                            {
    //                                resultArray[resultArray.Count - 1] = resultArray[resultArray.Count - 1] * iterSum;
    //                            }
    //                            break;

    //                        case "/":
    //                            if (iterSum > 0 && resultArray.Count == 0)
    //                            {
    //                                resultArray.Add(iterSum);
    //                            }
    //                            else if (resultArray.Count >= 1)
    //                            {
    //                                resultArray[resultArray.Count - 1] = resultArray[resultArray.Count - 1] * iterSum;
    //                            }
    //                            break;
    //                        case "+":
    //                            resultArray.Add(iterSum);
    //                            break;
    //                        case "-":
    //                            resultArray.Add((-1 * iterSum));
    //                            break;
    //                        case "s":
    //                            List<char> contentsqrt = new List<char>();
    //                            int s;
    //                            for (s = lastOperationIndex; s < exp.Length; s++)
    //                            {
    //                                if (exp[s] != ')')
    //                                {
    //                                    contentsqrt.Add(exp[s]);
    //                                }
    //                                else
    //                                {
    //                                    break;
    //                                }
    //                            }

    //                            if (string.Join("", contentsqrt).Contains("sqrt("))
    //                            {
    //                                var calculesqrt = string.Join("", contentsqrt).Replace("sqrt(", "");
    //                                var sqrtResult = Math.Sqrt(CalculeWithExpTableChar(calculesqrt.ToArray()));
    //                                resultArray.Add(sqrtResult);
    //                            }
    //                            i = s;
    //                            item = exp[s];
    //                            break;
    //                        default:
    //                            break;
    //                    }

    //                    lastOperation = item.ToString();
    //                    lastOperationIndex = i;
    //                    iterSum = 0;
    //                    hadDecimal = false;
    //                }
    //            }
    //        }

    //        if (iterSum > 0)
    //        {
    //            switch (lastOperation)
    //            {
    //                case "(":
    //                case ")":
    //                    break;
    //                case "^":
    //                    if (iterSum > 0 && resultArray.Count == 0)
    //                    {
    //                        resultArray.Add(iterSum);
    //                    }
    //                    else if (resultArray.Count >= 1)
    //                    {
    //                        resultArray[resultArray.Count - 1] = Math.Pow(resultArray[resultArray.Count - 1], iterSum);
    //                    }
    //                    break;
    //                case "*":
    //                    if (iterSum > 0 && resultArray.Count == 0)
    //                    {
    //                        resultArray.Add(iterSum);
    //                    }
    //                    else if (resultArray.Count >= 1)
    //                    {
    //                        resultArray[resultArray.Count - 1] = resultArray[resultArray.Count - 1] * iterSum;
    //                    }
    //                    break;
    //                case "/":
    //                    if (iterSum > 0 && resultArray.Count == 0)
    //                    {
    //                        resultArray.Add(iterSum);
    //                    }
    //                    else if (resultArray.Count >= 1)
    //                    {
    //                        resultArray[resultArray.Count - 1] = resultArray[resultArray.Count - 1] / iterSum;
    //                    }
    //                    break;
    //                case "+":
    //                    resultArray.Add(iterSum);
    //                    break;
    //                case "-":
    //                    resultArray.Add((-1 * iterSum));
    //                    break;
    //                case "sqrt":
    //                    List<char> contentsqrt = new List<char>();
    //                    int s;
    //                    for (s = lastOperationIndex; s < exp.Length; s++)
    //                    {
    //                        if (exp[s] != ')')
    //                        {
    //                            contentsqrt.Add(exp[s]);
    //                        }
    //                        else
    //                        {
    //                            break;
    //                        }

    //                    }
    //                    if (string.Join("", contentsqrt).Contains("sqrt("))
    //                    {
    //                        var calculesqrt = string.Join("", contentsqrt).Replace("sqrt(", "");
    //                        var sqrtResult = Math.Sqrt(CalculeWithExpTableChar(calculesqrt.ToArray()));
    //                        resultArray.Add(sqrtResult);
    //                    }
    //                    break;
    //                default:
    //                    break;

    //            }

    //        }
    //        return resultArray.Sum();
    //    }

    //}
}
