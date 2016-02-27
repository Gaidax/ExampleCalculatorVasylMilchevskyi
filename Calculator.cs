using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Calculator
    {
        //Declare Delegate
        public delegate int CalculatorDelegate(float x, float y);

        //Create Delegate Reference
        CalculatorDelegate delegateObj = null;
       
        public float Add(float a, float b) { return a + b; }
        public float Sub(float  x, float y) { return x - y; }
        public float Multi(float x, float y) { return x * y; }
        public float Div(float x, float y) { return x / y; }
    }
}
