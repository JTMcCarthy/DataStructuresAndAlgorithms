using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        public static void start() //this function is used to start the program and ask the user for a positive integer
        {
            Console.WriteLine("Please input a postive integer...");
            int b = Convert.ToInt32(Console.ReadLine()); //reads in a user's input and converts it to a integer and assigns it to the varible b
            validate(b); //sends the varible b to the next function
        }
        public static void validate (int b) //this function is used to process the user inputed value and see if it is a positive integer 
        {
            if (b <= 0)
            {
                Console.WriteLine("Thats not a positive number.");
                start(); //if 'b' is not a positive integer, restart the program
            }
            else
            {
                divide(b); //if 'b' is a positive integer, plug it into the next function
            }
        }
        public static void divide(int b) //this function will divide 'b' and see if it is cleanly divisible by 3
        {
            if (b % 3 == 0) //uses the % function to calculate a remainder of 'b' divide by 3
            {
                Console.WriteLine("Your number is divisible by 3"); // if the remainder is 0 
            }
            else
            {
                Console.WriteLine("Your number is not divisible by 3"); //if the remainder is anything except 0
            }
        }
        static void Main(string[] args)
        {
            start(); //calls the start() fucntion to start the program
        }
    }
}
