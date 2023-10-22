using QuadraticEquation.Views;
using QuadraticEquation.Models;
using Task = QuadraticEquation.Models.Task;

namespace QuadraticEquation.Presenters
{
    public class Presenter
    {
        private IView view;
        private Task task;
        private Solver solver;
        private Answer answer;
        public Presenter(IView view)
        {
            this.view = view;
            InitPresenter();
            view.ConsoleEventHandlerInitCoeficients += View_ConsoleEventHandlerInitCoeficients;
            view.ConsoleEventHandlerChoiceMethodSolution += View_ConsoleEventHandlerChoiceMethodSolution;
        }

        private void InitPresenter()
        {
            this.task = new Task(view.CoefficientA, view.CoefficientB, view.CoefficientC);
            this.answer = new Answer();
            this.solver = new Solver(task, answer);
        }

        private void View_ConsoleEventHandlerChoiceMethodSolution(object? sender, EventArgs e)
        {
            if (sender != null && sender is IView && e is ViewEventArgs)
            {
                view.ShowSolutionAlgorithm = solver.ChoiseMethod((e as ViewEventArgs).GetNumbers[0]); 
            }
        }

        private void View_ConsoleEventHandlerInitCoeficients(object? sender, EventArgs e)
        {
            solver.CheckСoefficients(task.GetA, task.GetB, task.GetC);
            if (sender != null && sender is IView)
            {
                view.CountSolutions = (int)answer.EnumSolutions;
                if ((int)answer.EnumSolutions == 0)   
                    view.ShowSolutionAlgorithm = solver.GetTextSolutionMethodWithOutRoots(task.GetA, task.GetB, task.GetC);
                else if ((int)answer.EnumSolutions == 1)
                    view.ShowSolutionAlgorithm = solver.GetTextSolutionMethodWithOneRoot(task.GetA, task.GetB, task.GetC);
            }
        }
    }
}
