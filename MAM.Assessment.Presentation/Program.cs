using MAM.Assessment.BusinessLogic.Models;


class Program
{
    static void Main(string[] args)
    {
        // List<string> input1 = new List<string>
        // {
        //     "1 Book at 12.49",
        //     "1 Music CD at 14.99",
        //     "1 Chocolate bar at 0.85"
        // };

        // List<string> input2 = new List<string>
        // {
        //     "1 Imported box of chocolates at 10.00",
        //     "1 Imported bottle of perfume at 47.50"
        // };

        // List<string> input3 = new List<string>
        // {
        //     "1 Imported bottle of perfume at 27.99",
        //     "1 Bottle of perfume at 18.99",
        //     "1 Packet of paracetamol at 9.75",
        //     "1 Box of imported chocolates at 11.25"
        // };

        List<string> input = new List<string>();
        string line;

        Console.WriteLine("Enter receipt items (press Enter twice to finish):");

        try
        {
            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
                input.Add(line);

            // Remove the last empty string from the list
            input.RemoveAt(input.Count - 1);

            var receipt = new ReceiptModel(input);
            receipt.PrintReceipt();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

