using QuadraticEquation.Presenters;

namespace QuadraticEquation.Views
{
    internal class View : IView
    {
        private ViewEventArgs viewEventArgs;
        private double a, b, c;
        public event EventHandler ConsoleEventHandlerChoiceMethodSolution;
        public event EventHandler ConsoleEventHandlerInitCoeficients;

        public View(double a, double b, double c)
        {
            this.a = a; this.b = b; this.c = c;
            InitCoefficients();
        }

        private void InitCoefficients()
        {
            new Presenter(this);
            viewEventArgs = new ViewEventArgs(new double[] { a, b, c });
            ConsoleEventHandlerInitCoeficients.Invoke(this, viewEventArgs);
        }

        public static string InfoMethodsSolution()
        {
            return "Метод розв'язання, якщо рівняння має один корінь - виділення повного квадрату (метод за замовчуванням)\n" +
                   "Методи розв'язання, якщо рівнання має два корені: \n" +
                   "1 - Теорема Вієта - розклад на множники;\n" +
                   "2 - Розв'язання через Дискримінант. D = b² - 4 · a · c; x1,2 = (-b ± √D) / (2·a);  \n" +
                   "3 - Розв'язання через властивість a + c = b. x1 = 1, x2 = c / a;\n" +
                   "4 - Розв'язання через властивість a + b + c = 0. x1 = -1, x2 = - c / a.\n";
        }

        public void ChoiceMethodSolution(int indexMethodEquation)
        {
            viewEventArgs = new ViewEventArgs(indexMethodEquation);
            ConsoleEventHandlerChoiceMethodSolution.Invoke(this, viewEventArgs);
        }

        public double CoefficientA => a;
        public double CoefficientB => b;
        public double CoefficientC => c;

        public int CountSolutions { get; set; }

        public string ShowSolutionAlgorithm { get; set; }

    }
}
