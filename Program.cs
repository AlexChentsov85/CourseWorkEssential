using QuadraticEquation.Models;
using QuadraticEquation.Views;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace QuadraticEquation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            double a, b, c;
            Console.WriteLine("Вас вітає програма розв'язку квадратних рівняннь!");
            Console.WriteLine(View.InfoMethodsSolution());
        Start:
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Введіть коєфіцієнти квадратного рівняння");
                try
                {
                    a = Convert.ToDouble(Console.ReadLine());
                    b = Convert.ToDouble(Console.ReadLine());
                    c = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Введіть корректні занчкння коефіцієнтів");
                    Console.WriteLine("Введіть будь ласка числа");
                }
            }


            View view = new View(a,b,c);

            if (view.CountSolutions == 0 || view.CountSolutions == 1)
            {
                Console.WriteLine(view.ShowSolutionAlgorithm);
                goto EndSolution;
            }
            else 
            {
                Console.WriteLine(ExstendEnumSolutions.GetEnumDescription((EnumSolutions)view.CountSolutions));
                Console.WriteLine("Введіть номер методу розв'язку рівняння");
                int indexMethodEquation;
                while (true)
                {
                    try
                    {
                        indexMethodEquation = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Введіть корректні занчкння коефіцієнтів");
                        Console.WriteLine("Введіть будь ласка числа");
                    }
                }

                view.ChoiceMethodSolution(indexMethodEquation);
                Console.WriteLine(view.ShowSolutionAlgorithm);

            }
        EndSolution:
            Console.WriteLine();
            Console.WriteLine("Бажаєте ще вирішити рівняння - введіть 'Yes'. Якщо ні - будь-яку кнопку");
            if (Console.ReadLine().ToLower() == "yes")
            {
                goto Start;
            }

            Console.ReadKey();  
        }
    }

    

}