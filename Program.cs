using System;
using System.Collections.Generic;
using System.IO;

namespace ClassmatesRevisited
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goOn = true;
            while (goOn == true)
            {
                bool wrongInput = true;
                while (wrongInput == true)
                {

                    string filePath = @"Students.txt";
                    StreamReader reader = new StreamReader(filePath);
                    string output = reader.ReadToEnd();


                    string[] lines = output.Split('\n');
                    List<Students> students = new List<Students>();

                    foreach (string line in lines)
                    {
                        Students s = ConvertToStudents(line);
                        if (s != null)
                        {
                            students.Add(s);
                        }
                    }
                    int index = 0;
                    if (index < students.Count)
                    {

                        foreach (Students s in students)

                        {
                            Console.WriteLine($"{index++} : {s.Name}");
                        }
                    }
                    int inputStudent = GetuserInput($"Please a pick a student (0 - { students.Count - 1}):");
                    if (inputStudent > students.Count - 1 || inputStudent <= -1)
                    {
                        Console.WriteLine($"Please pick a student, (0 - { students.Count - 1}):");
                        wrongInput = true;
                    }
                    else
                    {
                        wrongInput = false;
                        Students s = students[inputStudent];
                        GetOutput(s);
                        reader.Close();
                        continue;
                    }
                }
                Console.WriteLine("Now, lets add a new student");
                AddStudent();
                goOn = GetContinue();
            }

        }

        public static string StudentToString(Students s)
        {
            string output = $"{s.Name}, {s.HomeTown}, {s.FavoriteFood} \n";
            return output;
        }
        public static Students ConvertToStudents(string line)
        {
            string[] properties = line.Split(',');
            Students s = new Students();

            if (properties.Length == 3)
            {
                s.Name = properties[0];
                s.HomeTown = properties[1];
                s.FavoriteFood = (properties[2]);
                return s;
            }
            else
            {
                return null;
            }


        }
        public static int GetuserInput(string inputType)
        {
            int input;
            Console.WriteLine(inputType);
            input = int.Parse(Console.ReadLine());
            return input;
        }

        public static void PrintWholeList(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {items[i]}");
            }
        }
        public static void AddStudent()
        {
            string filePath = "Students.txt";
            Students s = new Students();
            Console.WriteLine("Please input a name");
            s.Name = Console.ReadLine();

            Console.WriteLine("Please input a hometown");
            s.HomeTown = Console.ReadLine();

            Console.WriteLine("Please insert a favorite food");
            s.FavoriteFood = Console.ReadLine();

            string line = StudentToString(s);
            Console.WriteLine(line);

            StreamReader reader = new StreamReader(filePath);
            string original = reader.ReadToEnd();
            reader.Close();

            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(original + line);

            writer.Close();
        }
        static bool GetContinue()
        {
            Console.WriteLine("Would you like to learn about another student? (y/n)");
            string answer = Console.ReadLine().ToUpper();

            if (answer == "Y")
            {
                return true;
            }
            else if (answer == "N")
            {
                Console.WriteLine("Goodbye!");
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand that, please try again");
                return GetContinue();

            }
        }
        public static bool GetOutput(Students student)
        {

            Console.WriteLine($"That student is {student.Name}");
            bool repeat = true;
            while (repeat == true)
            {
                Console.WriteLine("Would you like to learn about their hometown or favorite food? ");
                string learn = Console.ReadLine();

                if (learn.ToLower() == "hometown" || learn.ToLower().Contains("home"))
                {
                    bool another = true;
                    Console.WriteLine($"{student.Name}'s hometown is {student.HomeTown}");

                    while (another == true)
                    {
                        Console.WriteLine("Would you like to learn more? (y/n)");
                        string more = Console.ReadLine();

                        if (more.ToLower() == "yes" || more.ToLower().Contains("y"))
                        {
                            Console.WriteLine($"{student.Name}'s favorite food is {student.FavoriteFood}");
                            another = false;
                            repeat = false;
                            continue;
                        }
                        else if (more.ToLower() == "no" || more.ToLower().Contains("n"))
                        {
                            Console.WriteLine("okay then");
                            Console.WriteLine();
                            another = false;
                            repeat = false;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Not valid");
                        }
                    }
                }
                else if (learn.ToLower() == "favoritefood" || learn.ToLower().Contains("food"))
                {
                    bool another = true;
                    Console.WriteLine($"{student.Name}'s favorite food is {student.FavoriteFood}");

                    while (another == true)
                    {
                        Console.WriteLine("Would you like to learn more? (y/n)");
                        string more = Console.ReadLine();

                        if (more.ToLower() == "yes" || more.ToLower().Contains("y"))
                        {
                            Console.WriteLine($"{student.Name}'s hometown is {student.HomeTown}");
                            another = false;
                            repeat = false;
                            continue;
                        }
                        else if (more.ToLower() == "no" || more.ToLower().Contains("n"))
                        {
                            Console.WriteLine("okay then");
                            Console.WriteLine();
                            another = false;
                            repeat = false;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Not valid");
                            another = true;
                        }
                    }
                }
                else
                {
                    repeat = true;
                }
            }
            return false;
        }
    }
}
