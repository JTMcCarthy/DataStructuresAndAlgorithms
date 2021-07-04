using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Singly Linked List Strings
//the entire program is O(n)
namespace HW4._1._1
{
    class Node //creates a class to uses as the "storage" for strings
    {
        public string word; //specifies that the linked list will be of strings
        public Node next; //makes a Node object to be used as a connection
        public Node(string newWord) //O(1) constructor made to create a new node
        {
            word = newWord; //creates a word for the node
            next = null; //makes the new word its own list before being inputed
        }
    }
    class SinglyLinkedList
    {
        Node head; //uses the Node class to make a object 
        public SinglyLinkedList() //O(1) Constructor made to create a empty list
        {
            head = null;
        }
        public void Print() //O(n) prints the nodes in the order of the linked list
        {
            Console.WriteLine(); //empty line
            Node finger = head; //sents the finger to the front
            while (finger != null)
            {
                Console.WriteLine(finger.word + " ");
                finger = finger.next;
            } //goes throught the linked list and prints the value stored in each
        }
        public bool IsEmpty() //O(1) checks to see if the header is null therefore empty 
        {
            return head == null;
        }
        public void Insert(string word) //O(n) inserts a string in alphabetically into the linked list
        {
            if (IsEmpty()) //checks to see if the list is empty
            {
                AddFront(word); //put word in the front if the list is empty
            }
            else if (head.word.CompareTo(word) > 0) //checks the first word in the list to see alphabetical order
            {
                AddFront(word); //if the new word is earlier then the current head it is added to the front
            }
            else
            {
                Node newNode = new Node(word); //create a new node to hold the string
                Node finger = head;
                while (finger.next != null && finger.next.word.CompareTo(word) < 0) //go down the list and check the alphabetical relationship with the new node
                {
                    finger = finger.next;
                }
                newNode.next = finger.next; //when the newNode is aphabetically before it will connect the newNode's next to the fingers next
                finger.next = newNode; //sets the finger next to the new node; effectivly implementing the new node
            }
        }
        public void AddFront(string word) //O(1) puts a node at the front of the linked list
        {
            Node newNode = new Node(word); //creates a new node with the new word
            newNode.next = head; //sets it next to the current head
            head = newNode; //makes the new node the head
        }
        public void AddBack(string word) //adds a new node to the end of the linked list
        {
            Append(word); //same function as append
        }
        public void Append(string word) //O(n) adds a new node to the end of the linked list
        {
            if(IsEmpty()) //checks to see of the list is empty
            {
                AddFront(word); //if the list is empty just run the AddFront function
            }
            else
            {
                Node newNode = new Node(word); //create a new node to hold the new word
                Node finger = head; //sent the finger to the start of the list 
                while(finger.next != null) //when the next node is not null
                {
                    finger = finger.next; //continue forward down the list
                }
                finger.next = newNode; //when the next node is null, implement the new node into the null space making it the new ending
            }
        }
        public void DeleteFront() //O(1) removes the first node in the list
        {
            if (head != null) //if the head is not null, make the next node the new header
            {
                head = head.next;
            }
            else //else, therefore Head = null, means the list is empty
            {
                throw new Exception("You cannot delete the head of" +
                    " an empty list...");
            }
        }
        public void DeleteBack() //O(n) removes the last node from the list
        {
            if(IsEmpty()) //checks to see if the list is empty
            {
                throw new Exception("You cannot delete the end of an empty list...");
            }
            else if(head.next == null) //checks to see if the list has only one node
            {
                DeleteFront(); //runs the DeleteFront function
            }
            else //when there are 2 or more nodes in the list
            {
                Node finger = head; //set the finger to the head
                while (finger.next.next != null) //while the the node 2 nodes infront of the finger is not null
                {
                    finger = finger.next; //continue down the list
                }
                finger.next = null; //when finger.next.next = null then we can remove finger.next.next by setting this line
            }
        }
        public void Delete(string word) //O(n) removes the first found instance of a certain string
        {
            if(IsEmpty()) //checks to see if the list is empty
            {
                return;
            }
            else if (head.word == word) //checks to see if the heads word is the word 
            {
                DeleteFront(); //if so, deletes the front
            }
            else if (head.next == null) //checks to see if there is only one value in the array
            {
                if (head.word == word) //if the first nodes word is the word
                {
                    head = null; //empty the list
                }
            }
            else
            {
                Node finger = head; //makes a finger to go down the list
                while (finger.next != null && finger.next.word != word) //goes down the list and checks the finger.next to see if that is the word
                {
                    finger = finger.next; //moves down the list
                }
                if (finger.next != null) //if the finger is not on the end of the list
                {
                    finger.next = finger.next.next; //skip over the removed node
                }
            }
        }
        public void Reverse() //O(n) reverses the Linked list
        {
            Node prev = null; //sets a node named prev
            Node finger = head; //creates the finger to go down the list
            Node next = null; //creates a next node
            while (finger != null) //while the finger isnt on the end of the list
            {
                next = finger.next; //next is set to finger.next
                finger.next = prev; //finger.next is set to prev, flipping the order
                prev = finger; //prev is set to finger
                finger = next; //finger is set to next
            }
            head = prev; //finally set the new head of the reversed list
        }
    }
    class Program
    {
        static void Main(string[] args) //O(n)
        {
            SinglyLinkedList list = new SinglyLinkedList(); //create a object to be used as the list
            Console.WriteLine("Empty List : {0}", list.IsEmpty()); //check to see if the list is empty
            list.Insert("c");
            list.Reverse();
            list.Insert("a");
            list.Insert("b");
            list.Print();
            list.Delete("a");
            list.DeleteFront();
            list.DeleteBack();
            list.Append("jack");
            list.Delete("kack");
            list.Print();
            list.DeleteBack();
            list.AddFront("Hello");
            list.AddBack("CSC 340");
            list.AddBack("Class");
            list.Append("at 5:30");
            list.Print();
            list.Reverse();
            list.Print();
            Console.WriteLine("Empty List : {0}", list.IsEmpty());
        }
    }
}
