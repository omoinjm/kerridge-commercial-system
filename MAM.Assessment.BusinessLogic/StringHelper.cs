using MAM.Assessment.BusinessLogic.Models;
using System.Text.RegularExpressions;
using System.Globalization;

namespace MAM.Assessment.BusinessLogic.Helper;

public class StringHelper
{
    // Method to parse item strings into ReceiptItemModel objects
        public static List<ReceiptItemModel> ExtractValueFromString(List<string> items)
        {
            // List of items that are exempt from certain taxes or conditions
            var exemptedItems = new List<string> { "book", "chocolate", "pill", "paracetamol" };
            
            var receipt = new ReceiptModel();

            foreach (var item in items)
            {
                // Use a regular expression to match the format "<quantity> <item> at <price>"
                var match = Regex.Match(item, @"(\d+) (.+) at (\d+\.\d+)");

                // Check if the regular expression match was successful
                if (match.Success)
                {
                    // Extract the quantity from the first capture group and convert to an integer
                    int quantity = int.Parse(match.Groups[1].Value);
                    // Extract the item name from the second capture group as a string
                    string itemName = match.Groups[2].Value;
                    // Extract the price from the third capture group and convert to a double
                     double price = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);

                    // Check if the item name contains any of the exempted items (case insensitive)
                    bool isExempt = exemptedItems.Any(exempt => itemName.ToLower().Contains(exempt));
                    // Check if the item name contains the word "imported" (case insensitive)
                    bool isImported = itemName.ToLower().Contains("imported");

                    receipt.Items.Add(new ReceiptItemModel
                    {
                        Quantity = quantity,
                        Name = itemName,
                        Price = price,
                        IsExempt = isExempt,
                        IsImported = isImported
                    });
                }
            }

            // Return the list of receipt items
            return receipt.Items;
        }

}