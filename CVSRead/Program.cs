using System;
using System.IO;
using System.Transactions;

// read entire file
string filePath = "small_csv.csv";
double totalEng = 0.0;
double countEng = 0;
double avgEng = 0.0;

string[] lines = File.ReadAllLines(filePath);

foreach (string line in lines.Skip(1))
{
    string[] columns = line.Split(",");
    string empID = columns[0];
    string name = columns[1];
    string department = columns[2];
    double salary = double.Parse(columns[3]);
    string joinDate = columns[4];

    Console.WriteLine($"Employee ID: {empID}, Name: {name}, Department: {department}, Salary: {salary}, Joined Date: {joinDate}");

    if (department == "Engineering")
    {
        totalEng = totalEng + salary;
        countEng = countEng + 1;
    }
}

avgEng = totalEng / countEng;
Console.WriteLine($"Engineering Department Average Salary: {avgEng:C2}");

if (countEng != 0)
{
    avgEng = totalEng / countEng;
}

Console.WriteLine($"Engineering Department Average Salary: {avgEng:C2}");

// read line by line
totalEng = 0.0;
countEng = 0;
avgEng = 0.0;

using (StreamReader reader = new StreamReader(filePath))
{
    string header = reader.ReadLine();

    string line_by_line;

    while ((line_by_line = reader.ReadLine()) != null) // not at the end of the file
    {
        string[] columns = line_by_line.Split(",");
        string empID = columns[0];
        string name = columns[1];
        string department = columns[2];
        double salary = double.Parse(columns[3]);
        string joinDate = columns[4];

        Console.WriteLine($"Employee ID: {empID}, Name: {name}, Department: {department}, Salary: {salary}, Joined Date: {joinDate}");

        if (department == "Engineering")
        {
            totalEng = totalEng + salary;
            countEng = countEng + 1;
        }
    }
}

if (countEng != 0)
{
    avgEng = totalEng / countEng;
}

Console.WriteLine($"Engineering Department Average Salary: {avgEng:C2}");