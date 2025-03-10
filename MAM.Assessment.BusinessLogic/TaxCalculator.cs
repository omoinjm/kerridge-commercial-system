using MAM.Assessment.BusinessLogic.Models;

namespace MAM.Assessment.BusinessLogic.Service
{
    // Class to calculate taxes on receipt items
    public class TaxCalculator
    {
        private const double BasicTaxRate = 0.10;
        private const double ImportDutyRate = 0.05;

        // Method to calculate basic tax on a receipt item
        public static double CalculateBasicTax(ReceiptItemModel item)
        {
            if (item.IsExempt) return 0;

            return RoundUpToNearestFiveCents(item.Price * BasicTaxRate);
        }

        // Method to calculate import duty on a receipt item
        public static double CalculateImportDuty(ReceiptItemModel item)
        {
            if (!item.IsImported) return 0;

            return RoundUpToNearestFiveCents(item.Price * ImportDutyRate);
        }

        // Helper method to round up an amount to the nearest 5 cents
        // https://stackoverflow.com/questions/2235814/rounding-a-decimal-to-the-nearest-0-05
        private static double RoundUpToNearestFiveCents(double amount)
        {
            var ceiling = Math.Ceiling(amount * 20);
            
            if (ceiling == 0) 
                return 0;
            
            return ceiling / 20;
        }
    }
}
