using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW3
{
    class Program
    {
        //Bubble Sort run time = O(n^2)
        public static void bubbleReverseSort(string[] arr) //this method shows an example of a bubble sort
        {
            long count = 0; //creates a counter to count the amount of iterations that occur through sorting
            for (int i = 0; i < arr.Length; i++)
            {
                for (int pos = 0; pos < arr.Length - 1 - i; pos++)
                {
                    count++; //adds one to the counter
                    if (arr[pos].CompareTo(arr[pos + 1]) < 0) //compares the values and the value directly after it and checks there alphabetical placement
                    {
                        string tmp = arr[pos];
                        arr[pos] = arr[pos + 1];
                        arr[pos + 1] = tmp; //these three lines serve as a trade of values between the two values if they are not in reverse order
                    }
                }
            }
            Console.WriteLine("Bubble Reverse Sort preformed {0} comparisons.", count); //displays the counter
            Console.WriteLine(" ");
        }
        //Selection Sort run time = O(n^2)
        public static void selectionReverseSort(string[] arr) //this method is a example of a selection sort
        {
            long count = 0; //this creates a counter to be used to count the number of comparisons done
            for (int i = 0; i < arr.Length; i++) //for loop to go down each value of the array
            {
                int posMin = i; //sets a position to hold the min value
                for (int pos = i+1; pos < arr.Length; pos++)
                {
                    if (arr[pos].CompareTo(arr[posMin]) > 0)
                    {
                        posMin = pos; //this if statement will trigger if the min is less then the current position
                    }
                    string tmp = arr[i];
                    arr[i] = arr[posMin];
                    arr[posMin] = tmp; //these lines will flip the min and current positions values to make them reverse
                    count++; //adds one to the counter everytime a comparison is done
                }
            }
            Console.WriteLine("Selection Reverse Sort preformed {0} comparisons.", count); //displays the counter at the end of the method
            Console.WriteLine(" ");
        }
        //Merge Sort run time = O(nlogn)
        public static void mergeReverseSort(string[] arr) //serves as the base to preform a merge sort from.
        {
            long count = 0; //sets a counter
            string[] tmp = new string[arr.Length]; //creates a new array to serve as a holder for values from the array parameter
            mergeSortHelper(arr, 0, arr.Length - 1, tmp, ref count); //calls the helper function which will process the array
            Console.WriteLine("Merge Reverse Sort preformed {0} comparisons", count); //displays the counter at the end of the function
            Console.WriteLine(" ");
        }
        public static void mergeSortHelper(string[] arr, int start, int end, string[] tmp, ref long count) //sets up the sizes of the arrays and breaks them down.
        {
            if(start<end) //chekcs to see that there is more then one value in the array
            {
                int middle = (start + end) / 2; //creates a middle value based based off the start and end
                mergeSortHelper(arr, start, middle, tmp, ref count); //calls the same function to break down the first half of the array
                mergeSortHelper(arr, middle + 1, end, tmp, ref count); //calls the same function to break down the second half of the array
                mergeSubarrays(arr, start, middle, middle + 1, end, tmp, ref count); //calls the next function to process the arrays further and merge them
            }
        }
        public static void mergeSubarrays(string[] arr, int startA, int endA, int startB, int endB, string[] tmp, ref long count) //this method combines the arrays that hav been broken down
        {
            int i = startA;
            int j = startB;
            int k = startA; //these lines set variables based off the read in parameters

            while (i <= endA && j <= endB) //while the starts are in front of the ends
            {
                if (arr[i].CompareTo(arr[j]) > 0) //if the i value comes after the j value
                {
                    tmp[k] = arr[i]; //input i into the tmp array
                    i++; //increase i by one
                    k++; //increase k by one
                }
                else //if the j values comes after the i value
                {
                    tmp[k] = arr[j]; //input j into the tmp array
                    j++; //increase j by one
                    k++; //increase k by one
                }
                count++; //increase the counter by one for every comparison done
            }
            while (i <= endA) //pick the smallest of two arrays
            {
                tmp[k] = arr[i];
                i++;
                k++;
            }
            while (j <= endB) // pick the smallest of two arrays
            {
                tmp[k] = arr[j];
                j++;
                k++;
            }
            for (int h = startA; h <= endB; h++) //move the values from tmp back into the arr
            {
                arr[h] = tmp[h];
            }
        }
        public static void PrintArray(string[] arr) //this was just a Printing statment so i could see if my sorters where working
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        static void Main(string[] args)
        {
            var watch1 = new System.Diagnostics.Stopwatch();
            var watch2 = new System.Diagnostics.Stopwatch();
            var watch3 = new System.Diagnostics.Stopwatch(); //these lines create 3 stopwatches 
            string[] input1 = File.ReadAllLines("input.txt");
            string[] input2 = File.ReadAllLines("input.txt");
            string[] input3 = File.ReadAllLines("input.txt");//these lines read in three copies of the input file
            watch1.Start(); //starts the timer
            bubbleReverseSort(input1); //runs bubble sort
            watch1.Stop(); //stops the timer
            Console.WriteLine($"Execution Time: {watch1.ElapsedMilliseconds} ms"); //displays the time that bubble sort took
            Console.WriteLine(" ");
            watch2.Start();
            selectionReverseSort(input2); //runs selection sort
            watch2.Stop();
            Console.WriteLine($"Execution Time: {watch2.ElapsedMilliseconds} ms"); //displays the time that selection sort took
            Console.WriteLine(" ");
            watch3.Start();
            mergeReverseSort(input3); //runs merge sort
            watch3.Stop();
            Console.WriteLine($"Execution Time: {watch3.ElapsedMilliseconds} ms"); //displays the time that merge sort took
            Console.WriteLine(" ");
        }
    }
}
