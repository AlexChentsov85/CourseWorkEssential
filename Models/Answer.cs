namespace QuadraticEquation.Models
{
    public class Answer
    {
        private double? x1;
        private double? x2;
        private EnumSolutions enumSolutions;

        public double? X1 { get => x1; set => x1 = value; }
        public double? X2 { get => x2; set => x2 = value; }
        public EnumSolutions EnumSolutions { get => enumSolutions; set => enumSolutions = value; }
    }
}
