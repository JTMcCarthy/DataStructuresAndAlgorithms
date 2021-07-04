using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Doubly Linked List Integers
//entire program is O(n)
namespace HW4._1._2
{
    class Node
    {
        public int value; //declares the variable value which will serve many functions
        public Node next; //declares the node next
        public Node back; //declares the back node which is unique to the doubly linked list
        public Node(int newValue) //constructor
        {
            value = newValue; //assigns the new value to the value varible
            next = null; //sets its next to null
            back = null; //sets its back to null
        }
    }
    class DoublyLinkedList
    {
        Node head; //creates a node to serve as the head of the list
        Node tail; //creates a node to serve as the ending of the list
        public DoublyLinkedList() //constructor
        {
            head = null; //makes the head for a new list null
            tail = null; //makes the tail of a new list null
        }
        public void Print() //O(n) prints the nodes in the order of the linked list
        {
            Console.WriteLine(); //empty line
            Node finger = head; //sents the finger to the front
            while (finger != null)
            {
                Console.WriteLine(finger.value + " ");
                finger = finger.next;
            } //goes throught the linked list and prints the value stored in each
        }
        public bool IsEmpty() //O(1) checks to see if the header is null therefore empty 
        {
            return head == null;
        }
        public void AddFront(int value) //O(1) adds a new node to the front of the linked list
        {
            Node newNode = new Node(value); //creates a new node for the new value
            if (head == null) //if the list is empty
            {
                head = newNode; //the new node is then the head and the tail of the new list
                tail = head;
            }
            else //if there is any other node in the list
            {
                newNode.next = head; //set the newNodes next to the current head
                newNode.back = null; //set the back of the new node to null
                newNode.next.back = newNode; //sets the previous heads back to the new node
                head = newNode; //sets the newNode as the head
            }
        }
        public void AddBack(int value) //O(1) adds a new node to the back of the list
        {
            Append(value); //same function as append()
        }
        public void Append(int value) //O(1) adds a new node to the back of the list
        {
            if(IsEmpty()) //checks to see if the list is empty
            {
                AddFront(value); //if the list is empty, just addfront()
            }
            else //if there is at least 1 other node in the list
            {
                Node newNode = new Node(value); //create a new node
                tail.next = newNode; //set the tails next to the new node
                newNode.back = tail; //set the new nodes back to the tail
                tail = newNode;//set the tail as the new node
            }
        }
        public void Insert(int value) //O(n) inserts a new node with its value being placed as if the list was a ascending sorted list
        {
            if(IsEmpty()) //checks to see if the list is empty
            {
                AddFront(value); //if it is empty, just ad the new value to the front
            }
            else if(head.value > value) //checks to see if the head value is greater then the new value
            {
                AddFront(value); //if it is, then it will add the new value to the front
            }
            else if (tail.value < value) //checks to see if the tail is smaller then the new value
            {
                AddBack(value); //if the tail is smaller, that means that the new node belongs at the end of this list
            }
            else //if it belongs somewhere in the middle
            {
                Node newNode = new Node(value); //create a new node
                Node finger = head; //set a finger
                while (finger.next != null && finger.next.value < value) //go down the list checking to see if the next value is greater then the new value
                {
                    finger = finger.next;
                }
                newNode.next = finger.next; //when the next value is greater set the new nodes next to the fingers next
                finger.next.back = newNode; //set the finger.nexts back to the new node
                finger.next = newNode; //set the finger.next to the new node
                newNode.back = finger; //set the newNodes back to the finger
            }
        }
        public void DeleteFront() //O(1) deletes that first node in the linked list
        {
            if(head != null) //if the list has atleast one value
            {
                head = head.next; //set the head.next to the new head
                head.back = null; //set the new head.back to null
            }
            else //if the list is empty
            {
                throw new Exception("You cannot delete the head of an empty list...");
            }
        }
        public void DeleteBack() //O(1) deletes the final node from the linked list
        {
            if (IsEmpty()) //checks to see if the list is empty
            {
                throw new Exception("You cannot delete the end of an empty list...");
            }
            else if(head.next == null) //checks to see if there is just one node in the list
            {
                DeleteFront(); //runs deletefront
            }
            else //if there is more than 1 value in the linked list
            {
                tail = tail.back; //set the tail node to the node behind it
                tail.next.back = null; //set the old tail nodes back to null
                tail.next = null; //set the new tail nodes next to null
            }
        }
        public void Delete(int value) //O(n) deletes the first encountered instance of a inputed value
        {
            if(IsEmpty()) //checks to see if the list is empty
            {
                return; //if it is, there is nothing to delete
            }
            else if(head.value == value) //if the first nodes value is the value
            {
                DeleteFront(); //delete the front
            }
            else //if the required value is not in the first node
            {
                Node finger = head; //set the finger
                while(finger.next != null && finger.next.value != value) //check down the list looking for the value
                {
                    finger = finger.next;
                }
                if (finger.next.next == null && finger.next.value == value) //if you reach the end and the value matches
                {
                    DeleteBack(); //delete the value at the end
                }
                else if (finger.next != null && finger.next.value == value) //if you find the the value but have not reached the end
                {
                    finger.next = finger.next.next; //jump the list over the value
                    finger.next.back = finger; //set the ne finger.nexts back to the current finger, removing what was finger.next AKA the node with the required value
                }
            }
        }
        public void Reverse() //O(n) reverse the current nodes in the linked list
        {
            if (IsEmpty()) //check to see if the list is empty
            {
                throw new Exception("Cannot reverse a empty list...");
            }
            else if (head.next == null) //checks to see if there is only one node
            {
                return; //ends function, cannot reverse a list consisting of 1 node
            }
            else
            {
                Node finger = head; //set a finger
                Node temp = null; //set a temporary node
                while (finger != null) //go down the list 
                {
                    temp = finger.back; //set the temp node to the node behind the head
                    finger.back = finger.next; //set the node behind the head to the node after the finger
                    finger.next = temp; //set the node after the finger to the temp node
                    finger = finger.back; // set the figure to the finger.back node , moving it forward
                }
                head = tail; //move the head marker to the new head
                tail = head;
            }
        }
        public void printReverse() //O(n) prints a reverse of the current linked list
        {
            Console.WriteLine(); //empty line
            Node finger = tail; //sents the finger to the tail
            while (finger != null)
            {
                Console.WriteLine(finger.value + " ");
                finger = finger.back;
            } //goes throught the linked list backwards and prints the value stored in each
        }
    }
    class Program
    {
        static void Main(string[] args) //O(n)
        {
            DoublyLinkedList list = new DoublyLinkedList(); //creates a new instance of the list class
            Console.WriteLine("Empty List : {0}", list.IsEmpty());
            list.AddFront(3);
            list.Reverse();
            list.AddFront(2);
            list.AddFront(1);
            list.Append(8);
            list.AddBack(9);
            list.Insert(4);
            list.Insert(7);
            list.DeleteFront();
            list.Insert(10);
            list.AddBack(11);
            list.Append(6);
            list.DeleteBack();
            list.Delete(4);
            list.Delete(11);
            list.Delete(2);
            list.Print();
            list.printReverse();
            list.Reverse();
            list.printReverse();
            list.Print();
            Console.WriteLine("Empty List : {0}", list.IsEmpty());
        }
    }
}
