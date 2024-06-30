using MAM.Assessment.BusinessLogic.Models;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        var input = ReadValidInputLines();

        // If there is no valid input, exit the program
        if (input.Count == 0) { Console.WriteLine("No valid input provided. Exiting."); return; }

        try
        {
            var receipt = new ReceiptModel(input);
            
            receipt.PrintReceipt();
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}. Please check your input format and try again.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // Method to read and validate input lines
    static List<string> ReadValidInputLines()
    {
        var input = new List<string>(); string line;

        Console.WriteLine("Enter receipt items (press Enter twice to finish):");

        // Continue reading lines of input until a blank line is entered
        while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()!))
        {
            // If valid, add the line to the input list
            if (IsValidInputLine(line)) input.Add(line);
            else Console.WriteLine($"Invalid input format: '{line}'. Please use the format '<quantity> <item> at <price>'.");
        }

        return input;
    }

    // Method to validate input line format
    static bool IsValidInputLine(string line)
    {
        var match = Regex.Match(line, @"(\d+) (.+) at (\d+\.\d+)");

        return match.Success;
    }
}