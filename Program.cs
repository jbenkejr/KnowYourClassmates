using System;

namespace GetToKnowYourClassmates
{
    class Program
    {
        static bool goAgain = true;
        static void Main(string[] args)
        {
            string[] students = { "Jim", "Sam", "Sandra", "Emily", "Krystal" };
            string[] favFood = { "Pizza", "Cake", "Salad", "Tacos", "Hot Wings" };
            string[] homeTown = { "Brownstown", "Coldwater", "San Francisco", "LA", "Detroit" };

            do
            {
                PrintClassMates(students);
                Console.WriteLine();
                int index = ValidateRange("Welcome to our C# class! Which student would you like to learn more about? (enter a number 1 - 5): ", students);


                Console.Write($"\nStudent {index + 1} is: {students[index]}. \n");

                do
                {
                    string index1 = GetUserInput($"\nWhat would you like to know about {students[index]}? (enter hometown[home] or favorite food[food]): ");

                    if (index1 == "home")
                    {
                        Console.Write($"\n{students[index]} is from {homeTown[index]}. Would you like to know more about {students[index]}? (y/n): ");
                    }
                    else if (index1 == "food")
                    {
                        Console.Write($"\n{students[index]}'s favorite food is {favFood[index]}. Would you like to know more about {students[index]}? (y/n): ");
                    }

                    goAgain = GetContinue();

                } while (goAgain);

                Console.Write("\nKnow more about another student? (y/n): ");

                goAgain = GetContinue();
                Console.Clear();

            } while (goAgain);
        }

        public static bool GetContinue()
        {
            string doOver = Console.ReadLine();
            if (doOver.ToLower().Equals("y"))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        //public static int ValidateRange(string message, int min, int max)
        //{
        //    int number = ParseString(message);
        //    if (number > min && number <= max)
        //    {
        //        return number;
        //    }
        //    else if (number < min || number > max)
        //    {
        //        throw new IndexOutOfRangeException("You suck!");
        //    }
        //    else
        //    {
        //        return ValidateRange(message, min, max);
        //    }
        //}

        public static int ValidateRange(string message, string[] students)
        {
            try
            {
                int number = ParseString(message);
                number--;
                string student = students[number];
                return number;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return ValidateRange(message, students);
            }
        }

        public static string GetUserInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return input;
        }

        public static void PrintClassMates(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {array[i]}");
            }
        }

        public static int ParseString(string message)
        {
            try
            {
                string input = GetUserInput(message);
                int number = int.Parse(input);
                return number;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return ParseString(message);
            }
            catch
            {
                return ParseString(message);
            }
        }
    }
}
