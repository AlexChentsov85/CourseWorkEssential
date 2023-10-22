namespace QuadraticEquation.Views
{
    public interface IView
    {
        public event EventHandler ConsoleEventHandlerChoiceMethodSolution;
        public event EventHandler ConsoleEventHandlerInitCoeficients;

        public double CoefficientA { get; }
        public double CoefficientB { get; }
        public double CoefficientC { get; }
        public int CountSolutions { get; set; }
        public string ShowSolutionAlgorithm { get; set; }
        public static string InfoMethodsSolution { get; }
    }
}
