using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW6
{
    class Student
    {
        public string sName; //create attributes for the name, major, and state of origin
        public string sMajor;
        public string originState;
        public Student left, right; //create the connections for the BST
        public Student(string Name, string Major, string Origin) //constructor that assigns the attributes
        {
            sName = Name;
            sMajor = Major;
            originState = Origin;
        }
    }
    class BST //the BST object
    {
        Student root; //create the root
        public Boolean IsEmpty() //O(1) checks to see if the tree is empty
        {
            return root == null;
        }   
        public void Insert(string Name, string Major, string Origin) //O(n) inserts a new node into the BST, alphabetized by major
        {
            Student newStudent = new Student(Name, Major, Origin); //creates a new student node with the inforamtion from the parameters
            Insert(newStudent);
        }
        public void Insert(Student newStudent) //O(n) same as the other insert, but uses a seperate student class instead of making one
        {
            if (IsEmpty()) //checks the tree to see if its empty
            {
                root = newStudent; //set the new student to the root of the tree
            }
            else //if there is something in the tree
            {
                Student finger = root; //make a new node, finger
                while (true) //create a loop
                {
                    if (newStudent.sMajor.CompareTo(finger.sMajor) < 1) //if the new students major is before the finger major
                    {
                        if (finger.left != null) //go left and check to see if its empty
                        {
                            finger = finger.left; //if its not empty restart the loop
                        }
                        else //if it is empty
                        {
                            finger.left = newStudent; //make the new student node the node left of the finger
                            return; //end the loop
                        }
                    }
                    else //if the new student major is after the finger major
                    {
                        if (finger.right != null) //if the right is not empty
                        {
                            finger = finger.right; //go down the list
                        }
                        else //if it is empty
                        {
                            finger.right = newStudent; //make the right node to the finger the new student
                            return; //end the loop 
                        }
                    }
                }
            }

        }
        public Boolean Search(string NameKey) //O(n) searches the BST looking for the key from the parameters
        {
            Student finger = root; //create a new node to be used as the searching system
            while(finger != null) //while the list is not empty and the end if the list hasn't been reached
            {
                if (NameKey == finger.sName) //if the fingers name is the same as the keys name
                {
                    return true; //the key has been found
                }
                else if (NameKey.CompareTo(finger.sName) > 1) //if the key comes before the name on the finger 
                {
                    finger = finger.left; //move left
                }
                else //if the key comes after
                {
                    finger = finger.right; //move right
                }
            }
            return false; //if the list is empty or the name never appeared, return false
        }
        public int Height() //O(log(n)) calls the helper to do the actual work
        {
            int height = HeightHelper(root) - 1; //convert the number of leaves to the number of edges
            if (height < 0) //if the amount of edges is negative, the tree is empty 
            {
                return 0;
            }
            else 
            {
                return height;
            }
        }
        public int HeightHelper(Student current) //O(log(n)) goes through the tree recrusively and finds the tallest branch by counting the nodes in it
        {
            if(current == null) //if the tree/branch is empty, the height is O
            {
                return 0;
            }
            else //if the tree/branch has a node in it
            {
                int leftH = HeightHelper(current.left); //recursively call the left side
                int rightH = HeightHelper(current.right); //recrusively call the right side
                if (leftH > rightH) //if the left side is larger then the right
                {
                    return (leftH + 1); 
                }
                else
                {
                    return (rightH + 1);
                }
            }
        }
        public int numLeafNodes() //O(n) set up for counting the number of leaves on the tree
        {
            return numLeafNodesHelper(root); //calls and returns the helperfunction
        }
        public int numLeafNodesHelper(Student current) //O(n) recursively goes down the branches to find leaves
        {
            if(current == null) //if there is no tree
            {
                return 0; //no leaves
            }
            if(current.left == null && current.right == null) //if the node has no children
            {
                return 1; //it is a leaf so return a value of 1
            }
            else //if the node has on eor two children
            {
                return numLeafNodesHelper(current.left) + numLeafNodesHelper(current.right); //recursively move down the tree left and right
            }
        }
        public void PreOrderPrint() //O(n) set up for the printing of the tre in preorder format
        {
            Console.WriteLine("Displaying PREORDER ...");
            PreOrderHelper(root); //call the helper
            Console.WriteLine();
        }
        public void PreOrderHelper(Student finger) //O(n)
        {
            if (finger != null) //if the finger exists
            {
                Console.WriteLine(finger.sName + ": " + finger.sMajor);//N
                PreOrderHelper(finger.left);//L recrusively call on the left
                PreOrderHelper(finger.right);//R recrusively call on the right
            }
        }
        public void InOrderPrint() //O(n)
        {
            Console.WriteLine("Displaying INORDER ...");
            InOrderHelper(root); //call the helper on the base of the tree
            Console.WriteLine();
        }
        public void InOrderHelper(Student finger) //O(n)
        {
            if (finger != null)
            {
                InOrderHelper(finger.left);//L
                Console.WriteLine(finger.sName + ": " + finger.sMajor);//N
                InOrderHelper(finger.right);//R
            }
        }
        public void PostOrderPrint() //O(n)
        {
            Console.WriteLine("Displaying POSTORDER ...");
            PostOrderHelper(root);
            Console.WriteLine();
        }
        public void PostOrderHelper(Student finger) //O(n)
        {
            if (finger != null)
            {
                PostOrderHelper(finger.left);//L
                PostOrderHelper(finger.right);//R
                Console.WriteLine(finger.sName + ": " + finger.sMajor);//N
            }
        }
        public BST() //constructor
        {

        }
    }
    class Program
    {
        static void Main(string[] args) //O(n)
        {
            BST myTree = new BST();
            myTree.Insert("Jack McCarthy", "Computer Science", "Washington");
            myTree.Insert("Jay Bang", "Computer Science", "Washington");
            myTree.Insert("Julia Cutright", "Math", "West Virginia");
            myTree.Insert("Gabi Koppin", "Sociology", "Colorado");
            Student Esteban = new Student("Esteban Quiyono", "Biology", "Washington");
            myTree.Insert(Esteban); //utilizes the alternative insert
            myTree.Insert("Frank Jonas", "Computer Engineering", "Hawaii");
            myTree.Insert("Joe Boris", "Arts", "Oregon");
            myTree.Insert("Chauncey Holck", "Business", "Hawaii");
            myTree.Insert("Kennedy McCarthy", "Zoology", "Washington");
            myTree.Insert("Christina McCarthy", "Sociology", "Alaska");
            myTree.InOrderPrint();
            myTree.PreOrderPrint();
            myTree.PostOrderPrint();
            Console.WriteLine("Gabi Koppin is in the tree: {0}", myTree.Search("Gabi Koppin"));
            Console.WriteLine("The height of the tree is {0}", myTree.Height());
            Console.WriteLine("The number of leaves is {0}", myTree.numLeafNodes());
        }
    }
}
