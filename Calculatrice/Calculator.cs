using Calculatrice.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculatrice
{
    public class Calculator
    {
        private const string ErrorMessage = "Erreur*";

        List<SignOperation> listOperator;

        public Calculator()
        {
            listOperator = new List<SignOperation>();

            var LeftParenthesis = new LeftParenthesis(4);
            listOperator.Add(LeftParenthesis);

            var RightParenthesis = new RightParenthesis(4);
            listOperator.Add(RightParenthesis);

            var Power = new Power(3);
            listOperator.Add(Power);

            var Multiplication = new Multiplication(2);
            listOperator.Add(Multiplication);

            var Division = new Division(2);
            listOperator.Add(Division);

            var adddition = new Addition(1);
            listOperator.Add(adddition);

            var Subtraction = new Subtraction(1);
            listOperator.Add(Subtraction);

            var sqrt = new Sqrt(0);
            listOperator.Add(sqrt);

            listOperator = listOperator.OrderByDescending(x => x.Priority).ToList();
        }
        public double CalculeWithOperator(string exp)
        {
            double result = 0.0;
            var left = "";
            var right = "";
            var operationResult = 0.0;

            foreach (var op in listOperator)
            {
                var indexOperator = exp.IndexOf(op.Sign);
                if (indexOperator > -1)
                {
                    switch (op.Sign)
                    {
                        case "(":
                            var indexRight = exp.IndexOf(")");//TODO add if not exist  
                            var contientOperation = exp.Substring(indexOperator + 1, indexRight - indexOperator - 1);
                            operationResult = CalculeWithOperator(contientOperation);
                            exp = exp.Replace(contientOperation, operationResult.ToString()).Replace("(", "").Replace(")", "");
                            break;
                        case ")":
                            break;
                        case "^":
                            break;
                        case "*":
                            left = exp.Substring(0, indexOperator);
                            var rightSection = exp.Substring(indexOperator + 1);
                            var opIndex = listOperator.Select(x => x.Sign).FirstOrDefault(x => rightSection.Contains(x));
                            if (opIndex.Count() > 0)
                            {
                                rightSection = rightSection.Substring(0, rightSection.IndexOf(opIndex));
                            }
                            result = ((Operator)op).CalculeOp(left, rightSection);
                            break;
                        case "/":
                            break;
                        case "+":
                            left = exp.Substring(0, indexOperator);
                            right = exp.Substring(indexOperator + 1);
                            result = ((Operator)op).CalculeOp(left, right);
                            break;
                        case "-":
                            left = exp.Substring(0, indexOperator);
                            right = exp.Substring(indexOperator + 1);
                            result = ((Operator)op).CalculeOp(left, right);
                            break;
                        case "sqrt":
                            break;
                        default:
                            break;
                    }
                }
            }
            return result;
        }

        public string CalculeWithExp(string exp)
        {
            double result = 0.0;

            var cleanExp = CleanFormulat(exp);

            if (IsNonValid(cleanExp))
                return ErrorMessage;

            var expTable = cleanExp.ToCharArray();

            result = CalculeWithExp(expTable); 

            return ParseResult(result);

        }

        private bool IsNonValid(string exp)
        {
            return exp.Contains("/0");
        }

        private static string ParseResult(double result)
        {
            if (result % 1 != 0)
            {
                result = Math.Round(result, 2);
            }

            return result.ToString();
        }

        private static string CleanFormulat(string exp)
        {
            return exp.Replace(" ", "").Replace("++", "+").Replace("-+", "-").Replace("+-", "-").Replace("--", "+");
        }

        public double CalculeWithExp(char[] exp)
        {
            List<double> resultArray = new List<double>();

            var iterSum = 0.0;
            var lastOperation = "+";
            var lastOperationIndex = 0;
            var hadDecimal = false;

            for (int i = 0; i < exp.Length; i++)
            {
                var item = exp[i];

                if (char.IsDigit(item))
                {
                    if (hadDecimal)
                    {
                        iterSum = iterSum * 10 + int.Parse(item.ToString()) * 0.1;
                    }
                    else
                    {
                        iterSum = iterSum * 10 + int.Parse(item.ToString());
                    }
                }
                else if (item == '.')
                {
                    iterSum = iterSum * 0.1;
                    hadDecimal = true;
                }
                else
                {
                    if ((new string[] { "^", "/", "(", "*", "+", "-" , "s","r" }).Any(x => x == item.ToString()))
                    {
                        switch (lastOperation)
                        {
                            case "(":
                                List<char> contentParentese = new List<char>();
                                int j;
                                for (j = lastOperationIndex + 1; j < exp.Length; j++)
                                {
                                    if (exp[j] != ')')
                                    {
                                        contentParentese.Add(exp[j]);
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }
                                var ParenteseResult = CalculeWithExp(contentParentese.ToArray());
                                resultArray.Add(ParenteseResult);
                                i = j;
                                item = exp[j];
                                break;
                            case ")":
                                break;
                            case "^":
                                if (iterSum > 0 && resultArray.Count == 0)
                                {
                                    resultArray.Add(iterSum);
                                }
                                else if (resultArray.Count >= 1)
                                {
                                    resultArray[resultArray.Count - 1] = Math.Pow(resultArray[resultArray.Count - 1],iterSum);
                                }
                                break;
                            case "*":
                                if (iterSum > 0 && resultArray.Count == 0)
                                {
                                    resultArray.Add(iterSum);
                                }
                                else if (resultArray.Count >= 1)
                                {
                                    resultArray[resultArray.Count - 1] = resultArray[resultArray.Count - 1] * iterSum;
                                }
                                break;

                            case "/":
                                if (iterSum > 0 && resultArray.Count == 0)
                                {
                                    resultArray.Add(iterSum);
                                }
                                else if (resultArray.Count >= 1)
                                {
                                    resultArray[resultArray.Count - 1] = resultArray[resultArray.Count - 1] * iterSum;
                                }
                                break;
                            case "+":
                                resultArray.Add(iterSum);
                                break;
                            case "-":
                                resultArray.Add((-1 * iterSum));
                                break;
                            case "s":
                                List<char> contentsqrt = new List<char>();
                                int s;
                                for (s = lastOperationIndex; s < exp.Length; s++)
                                {
                                    if (exp[s] != ')')
                                    {
                                        contentsqrt.Add(exp[s]);
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }

                                if (string.Join("", contentsqrt).Contains("sqrt("))
                                {
                                    var calculesqrt = string.Join("", contentsqrt).Replace("sqrt(", ""); 
                                    var sqrtResult = Math.Sqrt(CalculeWithExp(calculesqrt.ToArray()));
                                    resultArray.Add(sqrtResult);
                                }
                                i = s;
                                item = exp[s];
                                break;
                            default:
                                break;
                        }

                        lastOperation = item.ToString();
                        lastOperationIndex = i;
                        iterSum = 0;
                        hadDecimal = false;
                    }
                }
            }

            if (iterSum > 0)
            {
                switch (lastOperation)
                {
                    case "(":
                    case ")":
                        break;
                    case "^":
                        if (iterSum > 0 && resultArray.Count == 0)
                        {
                            resultArray.Add(iterSum);
                        }
                        else if (resultArray.Count >= 1)
                        {
                            resultArray[resultArray.Count - 1] = Math.Pow(resultArray[resultArray.Count - 1], iterSum);
                        }
                        break;
                    case "*":
                        if (iterSum > 0 && resultArray.Count == 0)
                        {
                            resultArray.Add(iterSum);
                        }
                        else if (resultArray.Count >= 1)
                        {
                            resultArray[resultArray.Count - 1] = resultArray[resultArray.Count - 1] * iterSum;
                        }
                        break;
                    case "/":
                        if (iterSum > 0 && resultArray.Count == 0)
                        {
                            resultArray.Add(iterSum);
                        }
                        else if (resultArray.Count >= 1)
                        {
                            resultArray[resultArray.Count - 1] = resultArray[resultArray.Count - 1] / iterSum;
                        }
                        break;
                    case "+":
                        resultArray.Add(iterSum); 
                        break;
                    case "-":
                        resultArray.Add((-1 * iterSum));
                        break;
                    case "sqrt":
                        break;
                    default:
                        break;

                }

            }
            return resultArray.Sum();
        }


        //public List<Operations> Fragmate(string formulat)
        //{
        //    var indexRight = 0;
        //    var contientOperation = "";
        //    var operatorInstring = 0;
        //    var operations = new List<Operations>();
        //    for (int i =0; i < listOperator.Count();i++)
        //    {
        //        var op = listOperator[i];
        //        var indexOperator = formulat.IndexOf(op.Sign);
        //        if (indexOperator > -1)
        //        {
        //            switch (op.Sign)
        //            {
        //                case "(":
        //                    indexRight = formulat.IndexOf(")");//TODO add if not exist  
        //                    contientOperation = formulat.Substring(indexOperator + 1, indexRight - indexOperator - 1);
        //                    operatorInstring = listOperator.Select(x => x.Sign).Where(x => contientOperation.Contains(x)).Count();
        //                    if (operatorInstring > 1)
        //                    {
        //                        operations.AddRange(Fragmate(contientOperation));
        //                    }
        //                    else if(operatorInstring == 1)
        //                    {
        //                        operations.Add(new Operations(contientOperation, operations.FirstOrDefault(x => x.input == contientOperation)));
        //                    }//TODO don't have operator 
        //                    i = 0;
        //                    break;
        //                case ")":
        //                    break;
        //                case "^":
        //                    break;
        //                case "*":
        //                    operatorInstring = listOperator.Select(x => x.Sign).Where(x => formulat.Contains(x)).Count();
        //                    if (operatorInstring > 1)
        //                    {
        //                        operations.AddRange(Fragmate(contientOperation));
        //                    }
        //                    else if (operatorInstring == 1)
        //                    {
        //                        operations.Add(new Operations(formulat, operations.FirstOrDefault(x => x.input == formulat)));
        //                    }//TODO don't have operator 
        //                    i = 0;
        //                    break;
        //                case "/":
        //                    break;
        //                case "+":
        //                    operatorInstring = listOperator.Select(x => x.Sign).Where(x => formulat.Contains(x)).Count(); 
        //                    if (operatorInstring > 1)
        //                    {
        //                        operations.AddRange(Fragmate(contientOperation));
        //                    }
        //                    else if (operatorInstring == 1)
        //                    {
        //                        operations.Add(new Operations(formulat, operations.FirstOrDefault(x => x.input == formulat)));
        //                    }//TODO don't have operator 
        //                    i = 0;
        //                    break;
        //                case "-":

        //                    break;
        //                case "sqrt":
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //    }
        //    return operations;
        //}
    }
}
