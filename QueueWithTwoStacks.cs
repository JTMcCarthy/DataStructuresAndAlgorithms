using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Queue Using 2 Stacks O(n)
namespace HW4._2._3
{
    class myQueue
    {
        Stack<int> S1 = new Stack<int>(); //creates the first stack
        Stack<int> S2 = new Stack<int>(); //creates a second stack
        public void enqueue(int value) //O(n) will add new value to the queue by manipulating the two
        {
            while(S1.Count != 0) //while S1 is not empty
            {
                S2.Push(S1.Pop()); //move all values on S1 onto S2
            }
            S1.Push(value); //push the new value onto S1
            while(S2.Count != 0) //while S2 is not empty
            {
                S1.Push(S2.Pop()); //remove the newest value of S2 and place it in S1
            }
        }
        public int dequeue() //O(1) this removes the oldest inputed value from the queue
        {
            return S1.Pop(); //removes the top of S1
        }
        public void peek() //O(1) looks at the next to be removed from the queue
        {
            if(S1.Count > 0) //if the stack is not empty 
            {
                 Console.WriteLine(S1.Peek()); //look at and display the top value of S1
            }
            else
            {
                Console.WriteLine("The queue is empty"); //display if the count is empty
            }
        }
    }
    class Program
    {
        static void Main(string[] args) //O(n)
        {
            myQueue myQueue = new myQueue(); //creates a new queue
            myQueue.peek();
            myQueue.enqueue(1);
            myQueue.enqueue(2);
            myQueue.enqueue(3);
            myQueue.dequeue();
            myQueue.peek();
        }
    }
}
