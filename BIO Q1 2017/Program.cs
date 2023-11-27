using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIOQ12017
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the starting row (1 to 10 uppercase letters, each R, G, or B): ");
            string startRow = Console.ReadLine().ToUpper();
            if (startRow.Length < 1 || startRow.Length > 10 || !startRow.All(color => "RGB".Contains(color)))
            {
                Console.WriteLine("Invalid input. Please enter a valid starting row.");
            }
            else
            {
                string finalColor = GenerateTriangle(startRow);
                Console.WriteLine($"The color of the square in the final row is: {finalColor}");
            }
        }
        static string GenerateTriangle(string startRow)
        {
            var triangle = new List<string> { startRow };

            while (triangle[triangle.Count - 1].Length > 1)
            {
                string currentRow = triangle[triangle.Count - 1];
                string newRow = "";

                for (int i = 0; i < currentRow.Length - 1; i++)
                {
                    if (currentRow[i] == currentRow[i + 1])
                    {
                        newRow += currentRow[i];
                    }
                    else
                    {
                        if ((currentRow[i] == 'R' && currentRow[i + 1] == 'G') ||
                            (currentRow[i] == 'G' && currentRow[i + 1] == 'R'))
                        {
                            newRow += 'B';
                        }
                        else if ((currentRow[i] == 'R' && currentRow[i + 1] == 'B') ||
                                 (currentRow[i] == 'B' && currentRow[i + 1] == 'R'))
                        {
                            newRow += 'G';
                        }
                        else if ((currentRow[i] == 'G' && currentRow[i + 1] == 'B') ||
                                 (currentRow[i] == 'B' && currentRow[i + 1] == 'G'))
                        {
                            newRow += 'R';
                        }
                    }
                }
                triangle.Add(newRow);
            }
            foreach (string a in triangle)
            {
                Console.WriteLine(a);
            }
            return triangle[triangle.Count - 1];
        }
    }
}