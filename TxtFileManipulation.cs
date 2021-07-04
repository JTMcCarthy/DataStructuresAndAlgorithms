using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//O(n) uses text files to reverse the inputed lines
namespace HW4._2._2
{
    class Program
    {
        static void Main(string[] args) //O(n)
        {
            Stack<string> S = new Stack<string>(); //create a stack that works with strings
            string[] input = File.ReadAllLines("input.txt"); //read in the lines from the input.txt file in the debug folder
            string[] output = new string[input.Length]; //create another array that is the same length as the input folder
            for (int i = 0; i < input.Length; i++) //O(n) create a for loop that places all of the lines from the input.txt file into a stack
            {
                S.Push(input[i]); //place the string on the stack
            }
            int j = 0; //set a varible to serve as a marker
            while(S.Count != 0) //O(n) while the stack is not empty
            {
                output[j] = S.Pop(); //pop the value from the stack and place it at output[j]
                j++; //add 1 to j
            }
            File.WriteAllLines("output.txt", output); //write out the new output array onto output.txt
        }
    }
}
