using System;
using System.IO;

string filePath = "small_csv.csv";     
string updatedPath = "writer.csv";     

double engSalary = 0.0;
int engCount = 0;

double marketSalary = 0.0;
int marketCount = 0;

double allSalary = 0.0;
int allCount = 0;

Console.WriteLine();

using (StreamWriter writer = new StreamWriter(updatedPath, false))
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line_by_line;

        while ((line_by_line = reader.ReadLine()) != null)
        {
            writer.WriteLine(line_by_line);
        }
    }

writer.WriteLine("106,Andrew Burton,Marketing,100000,2025-04-21");

}

string[] lines = File.ReadAllLines(updatedPath);

foreach (string line in lines.Skip(1))
{
    string[] columns = line.Split(",");
    Console.WriteLine($"Column 0: {columns[0]} Column 1:{columns[1]} Column 2:{columns[2]} Column 3:{columns[3]} Column 4:{columns[4]}");
}

Console.WriteLine();
Console.WriteLine();

using (StreamReader reader = new StreamReader(updatedPath))
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
        string joiningDate = columns[4];

        if (department == "Engineering")
        {
            Console.WriteLine($"Engineer: {name} Salary:{salary:C2}");
            engSalary += salary;
            engCount++;
        }

        if (department == "Marketing")
        {
            Console.WriteLine($"  Marketer: {name} Salary:{salary:C2}");
            marketSalary += salary;
            marketCount++;
        }

        allSalary += salary;
        allCount++;
    }
}

Console.WriteLine();

if (engCount != 0)
{
    double avgEng = engSalary / engCount;
    Console.WriteLine($"Engineering dept avg salary: {avgEng:C2}");
}

if (marketCount != 0)
{
    double avgMarket = marketSalary / marketCount;
    Console.WriteLine($"Marketing dept avg salary: {avgMarket:C2}");
}

if (allCount != 0)
{
    double avgAll = allSalary / allCount;
    Console.WriteLine($"All employees avg salary: {avgAll:C2}");
}
