
namespace QuadraticEquation.Models
{
    public class Solver
    {
        private Task task;
        private Answer answer;
        public Solver(Task task, Answer answer)
        {
            this.task = task;
            this.answer = answer;
        }

        private double Discriminator(double a, double b, double c) => Math.Pow(b, 2) - 4 * a * c;

        public void CheckСoefficients(double a, double b, double c)
        {
            double discriminator = Discriminator(a, b, c);
            if (a == 0 && b == 0 && c == 0)
            {
                answer.EnumSolutions = EnumSolutions.Infinity;
                answer.X1 = answer.X2 = null;
            }
            else if (a == 0 && b == 0 && c != 0 || discriminator < 0)
            {
                answer.EnumSolutions = EnumSolutions.None;
                answer.X1 = answer.X2 = null;
            }
            else if (discriminator == 0)
            {
                answer.EnumSolutions = EnumSolutions.One;
                MethodWithOneRoot(a, b);
            }
            else
            {
                answer.EnumSolutions = EnumSolutions.Two;
                if (a + b + c == 0)
                    MethodWithTwoRootsSumCoefficientEqualsZero(a, c);
                else if (a + c == b)
                    MethodWithTwoRootsAPlusCEqualsB(a,c);
                else
                    MethodWithTwoRoots(a, b, discriminator);
            }
        }

        private void MethodWithOneRoot(double a, double b)
        {
            answer.X1 = answer.X2 = (-0.5) * b / a;
        }

        private void MethodWithTwoRoots(double a, double b, double discriminator)
        {
            answer.X1 = Math.Round((-1 * b - Math.Sqrt(discriminator)) / (2 * a),3);
            answer.X2 = Math.Round((-1 * b + Math.Sqrt(discriminator)) / (2 * a),3);
        }

        /// <summary>
        /// when a + c = b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        private void MethodWithTwoRootsSumCoefficientEqualsZero(double a, double c)
        {
            answer.X1 = 1;
            answer.X2 = c / a;
        }

        /// <summary>
        /// when a + b + c = 0
        /// </summary>
        /// <param name="a"></param>
        /// <param name="c"></param>
        private void MethodWithTwoRootsAPlusCEqualsB(double a, double c)
        {
            answer.X1 = -1;
            answer.X2 = -1 * c / a;
        }

        /// <summary>
        /// Найбільший спільний дільник
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private double GCD(double n, double m)
        {
            while (m != 0)
            {
                var temp = m;
                m = n % m;
                n = temp;
            }
            return n;
        }

        public string GetTextSolutionMethodWithOutRoots(double a, double b, double c)
        {
            string powSumbol, xSumbol, aEqualsOne, multSumbol, result;
            GetPartTextResultSolution(ref a, ref b, ref c, out powSumbol, out xSumbol, out aEqualsOne, out multSumbol, out result);
            result += ExstendEnumSolutions.GetEnumDescription(answer.EnumSolutions);
            return result;
        }

        public string GetTextSolutionMethodWithOneRoot(double a, double b, double c)
        {
            string powSumbol, xSumbol, aEqualsOne, multSumbol, result;
            GetPartTextResultSolution(ref a, ref b, ref c, out powSumbol, out xSumbol, out aEqualsOne, out multSumbol, out result);
            aEqualsOne = a == 1 ? "" : Math.Sqrt(a) + multSumbol;
            result += "(" + aEqualsOne + xSumbol + (answer.X1 < 0 ? "+" : "") + (-1)*answer.X1 * Math.Sqrt(a) + ")" + powSumbol + " = 0\n";
            result += aEqualsOne + xSumbol + (answer.X1 < 0 ? "+" : "") + (-1)*answer.X1 * Math.Sqrt(a) + " = 0\n";
            result += aEqualsOne + xSumbol + " = " + answer.X1 * Math.Sqrt(a) + "\n";
            if (a != 1) result += xSumbol + " = " + answer.X1 + "\n";


            return ExstendEnumSolutions.GetEnumDescription(answer.EnumSolutions) + "\n" + result;
        }

        public string GetTextSolutionMethodWithTwoRootsVieta(double a, double b, double c)
        {
            string powSumbol, xSumbol, aEqualsOne, multSumbol, result;
            GetPartTextResultSolution(ref a, ref b, ref c, out powSumbol, out xSumbol, out aEqualsOne, out multSumbol, out result);
            aEqualsOne = a == 1 ? "" : a + multSumbol;
            result += "(" + aEqualsOne + xSumbol + (answer.X1 >= 0 ? "" : "+") + (-1)*answer.X1 * a + ")" + multSumbol + "(" + xSumbol + (answer.X2 >= 0 ? "" : "+") + (-1)*answer.X2 + ") = 0\n";
            result += aEqualsOne + xSumbol + 1 + (answer.X1 >= 0 ? "" : "+") + (-1)*answer.X1 * a + " = 0\t\t" + xSumbol + 2 + (answer.X2 >= 0 ? "" : "+") + (-1)*answer.X2 + " = 0\n";
            result += aEqualsOne + xSumbol + 1 + " = " + answer.X1 * a + "\t\t" + xSumbol + 2 + " = " + answer.X2 + "\n";
            if (a != 1) result += xSumbol + 1 + " = " + answer.X1 + "\n";


            return result;
        }

        public string GetTextSolutionMethodWithTwoRootsDiscriminator(double a, double b, double c)
        {
            string powSumbol, xSumbol, aEqualsOne, multSumbol, result;
            GetPartTextResultSolution(ref a, ref b, ref c, out powSumbol, out xSumbol, out aEqualsOne, out multSumbol, out result);

            string squareRoot = "\u221A";
            result += "D = (" + b + ")" + powSumbol + "-4" + multSumbol + (a < 0 ? "(":"") + a + (a < 0 ? ")" : "") + multSumbol + (c < 0 ? "(" : "") + c + (c < 0 ? ")" : "") + "\n";
            double discriminator = Discriminator(a, b, c);
            result += "D = " + discriminator + "\n";
            result += "x1 = (" + (-1)*b + "-" + squareRoot + discriminator + ")/(" + a + multSumbol + "2) = " + answer.X1 + "\n";
            result += "x2 = (" + (-1)*b + "+" + squareRoot + discriminator + ")/(" + a + multSumbol + "2) = " + answer.X2 + "\n";

            return result;
        }

        public string GetTextSolutionMethodWithTwoRootsAPlusCEqualsB(double a, double b, double c)
        {
            string powSumbol, xSumbol, aEqualsOne, multSumbol, result;
            GetPartTextResultSolution(ref a, ref b, ref c, out powSumbol, out xSumbol, out aEqualsOne, out multSumbol, out result);
            result += "Сума a + c доівнює b: ";
            result += a + (b >=0 ? "+": "") + c + " = " + b + "\n";
            result += "x1 = " + answer.X1 + "\n";
            result += "x2 = -c / a = -1" + multSumbol + (c >=0 ? c: $"(-{c})") + "/" + a + " = " + answer.X2 + "\n";
            
            return result;
        }

        public string GetTextSolutionMethodWithTwoRootsSumCoefficientEqualsZero(double a, double b, double c)
        {
            string powSumbol, xSumbol, aEqualsOne, multSumbol, result;
            GetPartTextResultSolution(ref a, ref b, ref c, out powSumbol, out xSumbol, out aEqualsOne, out multSumbol, out result);
            result += "Сума коефіцієнтів доівнює нулю: ";
            result += a + (b >= 0 ? "+" : "") + b + (c >= 0 ? "+" : "") + c + " = 0\n";
            result += "x1 = " + answer.X1 + "\n";
            result += "x2 = " + answer.X2 + "\n";

            return result;
        }

        private void GetPartTextResultSolution(ref double a, ref double b, ref double c, out string powSumbol, out string xSumbol, out string aEqualsOne, out string multSumbol, out string result)
        {
            string signB = b >= 0 ? "+" : "";
            string signC = c >= 0 ? "+" : "";
            powSumbol = "\u00B2";
            multSumbol = "\u00B7";
            xSumbol = "x";
            aEqualsOne = a == 1 ? "" : a + multSumbol;
            result = string.Empty;
            result = aEqualsOne + xSumbol + powSumbol + signB + b + multSumbol + xSumbol + signC + c + " = 0\n";

            double gcd = GCD(GCD(a, b), c);
            if (gcd != 1 && gcd != -1)
            {
                if (gcd < 0)
                {
                    gcd *= -1;
                }
                a /= gcd;
                b /= gcd;
                c /= gcd;
                aEqualsOne = a == 1 ? "" : a + multSumbol;
                result += aEqualsOne + xSumbol + powSumbol + signB + b + multSumbol + xSumbol + signC + c + " = 0\n";
            }
            if (a < 0)
            {
                a = -1 * a;
                b = -1 * b;
                c = -1 * c;
                signB = b >= 0 ? "+" : "";
                signC = c >= 0 ? "+" : "";
                aEqualsOne = a == 1 ? "" : a + multSumbol;
                result += aEqualsOne + xSumbol + powSumbol + signB + b + multSumbol + xSumbol + signC + c + " = 0\n";
            }

            
        }

        public string ChoiseMethod(double v)
        {
            switch (v)
            {
                case 1:
                    return GetTextSolutionMethodWithTwoRootsVieta(task.GetA, task.GetB, task.GetC);
                case 2:
                    return GetTextSolutionMethodWithTwoRootsDiscriminator(task.GetA, task.GetB, task.GetC);
                case 3:
                    if (task.GetA + task.GetC == task.GetB)
                    {
                        return GetTextSolutionMethodWithTwoRootsAPlusCEqualsB(task.GetA, task.GetB, task.GetC);
                    }
                    return "Цей метод не підходить, бо a + c не дорівнює b";
                case 4:
                    if (task.GetA + task.GetC + task.GetB == 0)
                    {
                        return GetTextSolutionMethodWithTwoRootsSumCoefficientEqualsZero(task.GetA, task.GetB, task.GetC);
                    }
                    return "Цей метод не підходить, бо a + b + c не дорівнює нулю";
                default:
                    return "Невірний номер метода";
            }
        }
    }
}
