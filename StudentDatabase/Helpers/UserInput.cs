using StudentDatabase.Models;


namespace StudentDatabase.Helpers
{
    public class UserInput
    {
        public void GetStudent(User user, Student[] students)
        {
            string validEntry = "";
            int convertedNumber;
            int iCNT = 1;

            bool redoLoop = true;

            Console.WriteLine("ID  Name");

            foreach (Student student in students)
            {
                Console.Write($"{iCNT}   ");
                Console.Write(student.firstName + " " + student.lastName);
                Console.WriteLine();
                iCNT++;
            }

            Console.WriteLine();

            while (redoLoop)
            {
                Console.WriteLine("Enter a student ID or last name:");

                validEntry = Console.ReadLine().ToLower();

                user.currentStudent = students.FirstOrDefault(item => item.lastName.ToLower() == validEntry);

                if ((!int.TryParse(validEntry, out convertedNumber) ||
                     convertedNumber < students[0].id ||
                     convertedNumber > students.Length) &&
                     ReferenceEquals(null, user.currentStudent))

                {
                    Console.WriteLine($"Enter a valid student ID between 1 and {students.Length} or a valid name.");
                    redoLoop = true;
                }

                else if (ReferenceEquals(null, user.currentStudent))
                {
                    user.currentStudent = students.FirstOrDefault(item => item.id == Convert.ToInt32(validEntry));
                    Console.WriteLine($"You have chosen to view the information for {user.currentStudent.firstName} {user.currentStudent.lastName}");
                    redoLoop = false;
                }

                else
                {
                    redoLoop = false;
                }

                Console.WriteLine();
            }

        }

        public void GetCategory(User user, String[] categories)
        {
            string? validWord;

            bool redoLoop = true;

            while (redoLoop)
            {
                Console.WriteLine($"The available information about {user.currentStudent.firstName} {user.currentStudent.lastName} is:");

                for (int i = 0; i < categories.Length; i++)
                {
                    Console.WriteLine($"{categories[i] }");                    
                }

                Console.WriteLine();
                Console.WriteLine("Which information would you like to view?:");
                
                validWord = Console.ReadLine();

                if (validWord != " ")
                {
                    foreach (string category in categories)
                    {
                        if (category.ToLower().Contains(validWord.ToLower()))
                        {
                            validWord = category.ToLower();
                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(validWord) ||
                    !categories.Contains(validWord, StringComparer.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine();

                    Console.WriteLine("Enter a valid category.");

                    Console.WriteLine();

                }
                else
                {

                    switch (validWord)
                    {
                        case "hometown":
                        {
                            Console.WriteLine($"{user.currentStudent.firstName} {user.currentStudent.lastName}'s home town is { user.currentStudent.hometown }");
                            break;
                        }

                        case "favorite food":
                        {
                            Console.WriteLine($"{user.currentStudent.firstName} {user.currentStudent.lastName}'s favorite food is { user.currentStudent.favoritefood }");
                            break;
                        }

                    }
                    Console.WriteLine();
                    redoLoop = false;
                }

            }

        }

        public bool ContinueStudentInformation(User user)
        {
            char validAnswer;

            bool redoLoop = true;
            bool continueExponent = false;

            while (redoLoop)
            {
                Console.WriteLine("Do you want to see another student's information? y/n");

                if (!char.TryParse(Console.ReadLine().ToLower(), out validAnswer) ||
                   validAnswer.CompareTo('y') != 0 &&
                   validAnswer.CompareTo('n') != 0)
                {
                    Console.WriteLine("Enter y or n only.");
                    redoLoop = true;
                }

                else
                {
                    if (validAnswer.CompareTo('y') == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You chose to continue with another student.");
                        Console.WriteLine();
                        continueExponent = true;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Have a nice day. Goodbye.");
                        continueExponent = false;
                    }

                    redoLoop = false;
                }

            }

            return continueExponent;

        }

    }

}
