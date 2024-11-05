// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;

Console.WriteLine("*******Student Database Lab*******!");

//create three arrays for name, category and Favorite food

string[] studentNames = new string[]
{

    "Daniel",
    "Andy",
    "Taj",
    "Min",
    "Adam",
    "Benia",
    "Michael",
    "Devipriya",
    "Syeda"
};

string[] hometowns = new string[]
{
    "Rome",
    "Traverse City",
    "India",
    "Troy",
    "Hamtramak",
    "Austin",
    "Paris",
    "Akron",
    "Birmingham"
};

string[] favoriteFood = new string[]
{
     "sushi",
    "thai",
    "thai",
    "french fries",
    "pizza",
    "pasta",
    "banana pudding",
    "pizza",
    "burgers"
};
//promt the user for student no
Console.WriteLine($"Welcome! Which student would you like to learn more about? " );
int studentNo = 0;
bool isValidOutput = false;

//loop continues till the user want to look for student details
do
{
    isValidOutput = false;
    //check the user enter valid no
    while (isValidOutput == false)
    {
        Console.Write($"Enter a number 1-{studentNames.Length} \t");
        isValidOutput = int.TryParse(Console.ReadLine(), out studentNo);
        if (isValidOutput == false)
        {
            Console.WriteLine("Invalid Number");

        }
        else
        {
            if (studentNo >= 1 && studentNo <= studentNames.Length)
            {
                break;
            }
            else
            {
                Console.WriteLine("Number does not exist");
                isValidOutput = false;
            }

        }
    }
    Console.WriteLine($"Student {studentNo} is {studentNames[studentNo - 1]}. What would you like to know? Enter \"hometown\" or \"favorite food\":");

    isValidOutput = false;
    string userCategory = "";
    //check the user enter valid category and display the details if is valid else promt the user to enter valid data
    while (isValidOutput == false)
    {
        userCategory = Console.ReadLine().ToLower().Trim();

        /* if (userCategory == "hometown" || userCategory == "favorite food")
         {
             isValidOutput = true;
         }
        */
        switch (userCategory)
        {
            case "hometown":
            case "home":
            case "town":
                Console.WriteLine($"{studentNames[studentNo - 1]} is from {hometowns[studentNo - 1]}");
                break;
            case "favorite food":
            case "favorite":
            case "food":
                Console.WriteLine($"{studentNames[studentNo - 1]}'s favorite food is {favoriteFood[studentNo - 1]}");
                break;
            default:
                Console.WriteLine("That Category does not exist. Enter \"hometown\" or \"favorite food\" :");
                continue;
        }
        isValidOutput = true;
    }
    // option to display the studetails
    Console.WriteLine("If you want to see the Student list, Press 1");
    if (int.TryParse(Console.ReadLine().Trim(), out int answer) == true) 
    {
        if (answer == 1)
        {
            int studentCounter = 1;
            foreach (string student in studentNames)
            {
                Console.WriteLine($"{studentCounter} - {student}");
                studentCounter++;
            }
        }
    }

    //search Student ByName
    Console.WriteLine("Enter the Student Name you would like to search for \t");
    string searchStudentByName = Console.ReadLine().ToLower().Trim();
    int searchIndex = -1;
    for (int i = 0; i < studentNames.Length; i++)
    {
        if (studentNames[i].ToLower() == searchStudentByName)
        {
            searchIndex = i;
            Console.WriteLine($"{searchStudentByName}'s Student No {i + 1}, is from {hometowns[i]} and favorite food is {favoriteFood[i]}");
            break;      
        }
        
    }
    if (searchIndex == -1)
    {
        Console.WriteLine($"Student Names {searchStudentByName} not found in the List");
    }


} while (GetPlayAgainAnswer() == true);

bool GetPlayAgainAnswer(string strMessage = "Would you like to learn about another student? Enter \"y\" or \"n\": ")
{
    Console.WriteLine(strMessage);
    string userAnswer = Console.ReadLine();
    if (userAnswer.ToLower() != "y")
    {
        Console.WriteLine("Thanks");
        return false;
    }
    return true;
}




