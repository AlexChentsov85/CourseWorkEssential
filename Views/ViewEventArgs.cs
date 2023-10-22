namespace QuadraticEquation.Views
{
    public class ViewEventArgs: EventArgs
    {
        double[] numbers;

        public ViewEventArgs(params double[] numbers)
        {
            this.numbers = numbers;
        }

        public double[] GetNumbers => numbers;
    }
}