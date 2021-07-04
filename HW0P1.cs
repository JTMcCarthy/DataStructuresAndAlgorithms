using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int VTotal = 0; //create a counter to keep track of the number of vowels
            Console.WriteLine("Please type out the phrase 'Welcome to Saint Martin's U!'");
            string phrase = Console.ReadLine().ToUpper(); //make a string from the users input and also convert it all to uppercase
            for (int i = 0; i < phrase.Length; i++) //loop that checks each character of the string to find vowels
            {
                if (phrase[i]=='A' || phrase[i] == 'E' || phrase[i] == 'I' || phrase[i] == 'O' || phrase[i] == 'U') //checks to see if the character at position 'i' is a vowel
                {
                    VTotal++;  //if vowels are found it adds 1 to the counter
                }
            }
            Console.WriteLine("The total number of vowels in the phrase is {0}", VTotal); //displays the amount of vowels that have been counted
        }
    }
}
