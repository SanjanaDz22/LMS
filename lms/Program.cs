// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

class Student
{
    public int IndexNumber { get; set; }
    public string Name { get; set; }
    public double GPA { get; set; }
    public int AdmissionYear { get; set; }
    public string NIC { get; set; }
    public Student Next { get; set; }

    public Student(int indexNumber, string name, double gpa, int admissionYear, string nic)
    {
        IndexNumber = indexNumber;
        Name = name;
        GPA = gpa;
        AdmissionYear = admissionYear;
        NIC = nic;
        Next = null;
    }

    public void Display()
    {
        Console.WriteLine($"Index: {IndexNumber}, Name: {Name}, GPA: {GPA}, Year: {AdmissionYear}, NIC: {NIC}");
    }
}

class StudentLinkedList
{
    private Student head;

    public void Insert(Student newStudent)
    {
        if (Search(newStudent.IndexNumber) != null)
        {
            Console.WriteLine("Student with this index already exists!");
            return;
        }

        if (head == null || newStudent.IndexNumber < head.IndexNumber)
        {
            newStudent.Next = head;
            head = newStudent;
        }
        else
        {
            Student current = head;
            while (current.Next != null && current.Next.IndexNumber < newStudent.IndexNumber)
            {
                current = current.Next;
            }
            newStudent.Next = current.Next;
            current.Next = newStudent;
        }

        Console.WriteLine(" Inserted successfully.");
    }

    public Student Search(int index)
    {
        Student current = head;
        while (current != null)
        {
            if (current.IndexNumber == index)
                return current;
            current = current.Next;
        }
        return null;
    }

    public void Remove(int index)
    {
        if (head == null)
        {
            Console.WriteLine("No students in the list.");
            return;
        }

        if (head.IndexNumber == index)
        {
            head = head.Next;
            Console.WriteLine("emoved successfully.");
            return;
        }

        Student current = head;
        while (current.Next != null && current.Next.IndexNumber != index)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            Console.WriteLine("Student not found.");
        }
        else
        {
            current.Next = current.Next.Next;
            Console.WriteLine("Student removed successfully.");
        }
    }

    public void PrintAll()
    {
        if (head == null)
        {
            Console.WriteLine("No students in the list.");
            return;
        }

        Student current = head;
        while (current != null)
        {
            current.Display();
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        StudentLinkedList studentList = new StudentLinkedList();
        while (true)
        {
            Console.WriteLine("\n--- Student Linked List Menu ---");
            Console.WriteLine("1. Insert Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Print All Students");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Index Number: ");
                    int index = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter GPA: ");
                    double gpa = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Admission Year: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter NIC: ");
                    string nic = Console.ReadLine();

                    studentList.Insert(new Student(index, name, gpa, year, nic));
                    break;

                case 2:
                    Console.Write("Enter Index Number to Search: ");
                    int searchIndex = Convert.ToInt32(Console.ReadLine());
                    Student found = studentList.Search(searchIndex);
                    if (found != null)
                        found.Display();
                    else
                        Console.WriteLine("Student not found.");
                    break;

                case 3:
                    Console.Write("Enter Index Number to Remove: ");
                    int removeIndex = Convert.ToInt32(Console.ReadLine());
                    studentList.Remove(removeIndex);
                    break;

                case 4:
                    studentList.PrintAll();
                    break;

                case 5:
                    Console.WriteLine("Exit");
                    return;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}
