using MAM.Assessment.BusinessLogic.Service;
using MAM.Assessment.BusinessLogic.Helper;

namespace MAM.Assessment.BusinessLogic.Models
{
    // Model for individual items on the receipt
    public class ReceiptItemModel
    {
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public bool IsImported { get; set; }
        public bool IsExempt { get; set; }
    }

    // Model for the receipt
    public class ReceiptModel
    {
        public List<ReceiptItemModel> Items { get; set; } = [];
        public double TotalSalesTax { get; set; }
        public double TotalPrice { get; set; }

        public ReceiptModel() {}

        public ReceiptModel(List<string> items)
        {
            // Parse the items and calculate totals
            Items = StringHelper.ExtractValueFromString(items);

            CalculateTotals();
        }

        // Method to calculate the total sales tax and total price of the receipt
        private void CalculateTotals()
        {
            foreach (var item in Items)
            {
                var basicTax = TaxCalculator.CalculateBasicTax(item);
                var importDuty = TaxCalculator.CalculateImportDuty(item);
                var totalTax = basicTax + importDuty;

                item.Price += totalTax;
                TotalSalesTax += totalTax;
                TotalPrice += item.Price;
            }
        }

        // Method to print the receipt to the console
        public void PrintReceipt()
        {
            foreach (var item in Items) Console.WriteLine($"{item.Quantity} {item.Name}: {item.Price:F2}");
            
            Console.WriteLine($"Sales Taxes: {TotalSalesTax:F2}");
            Console.WriteLine($"Total: {TotalPrice:F2}");
        }
    }
}