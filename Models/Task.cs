using QuadraticEquation.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation.Models
{
    public class Task
    {
        readonly double a, b, c;

        public Task(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double GetA => a;

        public double GetB => b;

        public double GetC => c;

    }
}
