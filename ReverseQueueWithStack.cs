using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//O(n) reverses a queue by using a stack
namespace HW4._2._1
{
    class Program
    {
        static void Main(string[] args) //O(n)
        {
            Queue<int> Q = new Queue<int>(); //create a queue
            Stack<int> S = new Stack<int>(); //create a stack
            Q.Enqueue(1); //enqueue the following values
            Q.Enqueue(2);
            Q.Enqueue(3);
            Q.Enqueue(4);
            foreach (int elem in Q) //O(n) print the values
            {
                Console.WriteLine(elem);
            }
            while (Q.Count != 0) //O(n) remove all of the values from the queue
            {
                S.Push(Q.Dequeue()); //push them onto the stack
            }
            while(S.Count != 0) //O(n) remove from the stack till it is empty
            {
                Q.Enqueue(S.Pop()); //enqueue the popped value
            }
            Console.WriteLine();
            Console.WriteLine("REVERSED");
            Console.WriteLine();
            foreach (int elem in Q) //O(n) print the values... now reversed
            {
                Console.WriteLine(elem);
            }
        }
    }
}
