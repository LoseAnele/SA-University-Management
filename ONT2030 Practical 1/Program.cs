using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ONT2030_Practical_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "University.txt"; bool exit = false, validInput = false; int count = 1;
            string converted_students = "", converted_year = "";
            List<int> numOfStudents = new List<int>();
            List<int> listOfYears = new List<int>();
            List<string> listOfCities = new List<string>();

            // Prompt the user for university information
            Console.WriteLine("Enter university information ..... ");
            while (!exit)
            {
                Console.Write("University Name: ");
                string name = Console.ReadLine();
                Console.Write("Year Established: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("City situated in: ");
                string city = Console.ReadLine();
                Console.Write("Number of Students: ");
                int students = int.Parse(Console.ReadLine());

                //Write to file using streamwriter
                using (StreamWriter writer = new StreamWriter(filePath,true))
                {
                    writer.WriteLine($"{name}#{year}#{city}#{students}");
                }

                //Ask user to continue or exit 
                Console.Write("\nTo add more enter Y/y, to exit enter N/n: ");
                char input = char.Parse(Console.ReadLine().ToLower());

                //Validate input of the user
                while (!validInput)
                {
                    if (input == 'y')
                        break;
                    else if (input == 'n')
                    {
                        validInput = true;
                        exit = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, try again.");
                        Console.Write("\nTo add more enter Y/y, to exit enter N/n: ");
                        input = char.Parse(Console.ReadLine().ToLower());
                    }
                }
            }

            //Define a list to hold all the lines in file 
            List<string> lines = File.ReadAllLines(filePath).ToList();
            //Populate listOfYears, listOfCities and numOfStudents using lines on the list with splitter function and temp array.
            foreach (string line in lines)
            {
                string[] temp = line.Split('#');
                listOfYears.Add(int.Parse(temp[1]));
                listOfCities.Add(temp[2]);
                numOfStudents.Add(int.Parse(temp[3]));
            }

            //Create dictionary to count how many times a city appears on the list of cities, store data in key/value pairs
            Dictionary<string, int> timesAppears = new Dictionary<string, int>();
            //Iterate through list using foreach
            foreach (string city in listOfCities)
            {
                //check if dictionary already contains city
                if (timesAppears.ContainsKey(city))
                {
                    //increment value by 1
                    timesAppears[city]++;
                }
                else
                {
                    //add city and initialise value to 1
                    timesAppears[city] = 1;
                }
            }

            // Display university information from the file
            Console.WriteLine("\nUniversity Information:");
            //Iterate trough lines list again
            foreach (string line in lines)
            {
                //split data according to delimeter and assign every value to an appropriate variable.
                string[] temp = line.Split('#');
                string name = temp[0];
                int year = int.Parse(temp[1]);
                string city = temp[2];
                int numOfstudents = int.Parse(temp[3]);

                //Check if year is equal to the minimum value in listOfYears. Which will make the year the oldestYear 
                if (year == listOfYears.Min())
                {
                    //append the asterikMarkings
                    converted_year = $"{year}*";
                }

                //Check if numOfStudents is equal to the maximum value in numOfStudents list. Which will make the numOfStudents the Highest 
                if (numOfstudents == numOfStudents.Max())
                {
                    //append the asterikMarkings
                    converted_students = $"{numOfstudents}**";
                }

                
                //Use foreach iterate through the dictionary
                foreach (KeyValuePair<string, int> timesAppear in timesAppears)
                {
                    //check if the key == city and value is greater tha 1
                    if (timesAppear.Key == city && timesAppear.Value > 1)
                        //append the asterikMarkings
                        city += "***";
                }
                

                if(converted_students != "" && converted_year != "")
                    //Write data to console window
                    Console.Write($"{count}. University Name: {name}\n   Year Established: {converted_year}\n   City: {city}\n   Number of Students: {converted_students}\n");
                else if(converted_students != "")
                    //Write data to console window
                    Console.Write($"{count}. University Name: {name}\n   Year Established: {year}\n   City: {city}\n   Number of Students: {converted_students}\n");
                else if(converted_year != "")
                    //Write data to console window
                    Console.Write($"{count}. University Name: {name}\n   Year Established: {converted_year}\n   City: {city}\n   Number of Students: {numOfstudents}\n");
                else
                    //Write data to console window
                    Console.Write($"{count}. University Name: {name}\n   Year Established: {year}\n   City: {city}\n   Number of Students: {numOfstudents}\n");

                //Create a space between the printed data and increment count by 1
                Console.WriteLine();
                count++;
                converted_year = ""; converted_students = "";
            }
            Console.ReadLine();
        }
    }
}
