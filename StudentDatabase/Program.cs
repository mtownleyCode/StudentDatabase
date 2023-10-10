using StudentDatabase.Helpers;
using StudentDatabase.Models;

bool continueStudentInformation = true;

UserInput userInput = new UserInput();
User user = new User();

String[] studentNames = { "Steve Smith", "Sara Wiles", "Bonnie Wilson" };
String[] homeTowns = { "Dallas", "Orlando", "New York" };
String[] favoriteFoods = { "Steak", "Hamburger", "Chicken" };
String[] categories = { "Hometown", "Favorite Food" };
Student[] students = new Student[studentNames.Length];



for (int i = 0; i < studentNames.Length; i++)
{
    String[] nameSplit = studentNames[i].Split(" ");

    Student student = new Student();

    student.id = i + 1;
    student.firstName = nameSplit[0];
    student.lastName = nameSplit[1];
    student.hometown = homeTowns[i];
    student.favoritefood = favoriteFoods[i];

    students[i] = student;

}

do
{
    userInput.GetStudent(user, students);
    userInput.GetCategory(user, categories);
    continueStudentInformation = userInput.ContinueStudentInformation(user);

} while (continueStudentInformation);

