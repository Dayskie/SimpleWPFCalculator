using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    public class Calculate
    {
        public static string CalculateString(string input)
        {
            if(input.Length == 0) { return ""; }
            string[] splitInput = input.Split(' ');

            float output = 0;
            float leftInput = float.Parse(splitInput[0]);
            float rightInput = float.Parse(splitInput[2]);

            switch (splitInput[1])
            {
                case "+":
                    output = leftInput + rightInput;
                    break;
                case "-":
                    output = leftInput - rightInput;
                    break;
                case "*":
                    output = leftInput * rightInput;
                    break;
                case "/":
                    output = leftInput / rightInput;
                    break;
            }

            return output.ToString();
        }
    }
}
