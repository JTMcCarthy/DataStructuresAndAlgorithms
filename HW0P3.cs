using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW0P3
{
    class Program
    {
        static void Main(string[] args)
        {
            int vowelCount = 0; //sets a counter to keep track of the number of vowels
            using (StreamReader file = new StreamReader("input.txt")) //reads in a file titled input.txt
            {
                string input = file.ReadToEnd(); //reads the whole file till the and and assigns it to the string input
                for (int i = 0; i < input.Length; i++) //a for loop to read in the characters from input 
                {
                    if (input[i] == 'A' || input[i] == 'E' || input[i] == 'I' || input[i] == 'O' || input[i] == 'U' || input[i] == 'a' || input[i] == 'e' || input[i] == 'i' || input[i] == 'o' || input[i] == 'u')
                    {
                        vowelCount++; //if the read in character is a vowel it will and one to the vowelCount varible
                    }
                }
                Console.WriteLine("There is {0} vowels in the text file", vowelCount); //displays the total amount of vowels in the text file entitled input.txt
            }
        }
    }
}
