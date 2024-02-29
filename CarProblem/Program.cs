using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace CarProblem
{
    internal class Program
    {
        static void Main(string[] args)
        { 

            DisplaySalesInfo(new DateTime(2024, 4, 1), new DateTime(2024, 9, 30));
            DisplayRetailAndCorporateSales(new DateTime(2024, 4, 1), new DateTime(2024, 9, 30));
            DisplaySalesInRange(new DateTime(2024, 8, 15), new DateTime(2024, 9, 15));
        }

        static void DisplaySalesInfo(DateTime startDate, DateTime endDate)
        {
            DateTime s = startDate;
            int total = 0;
            int retail = 0;
            int corporate = 0;

            while (startDate <= endDate)
            {
                int vehiclesSold = GetVehiclesSoldOnDay(startDate);
                total += vehiclesSold;

                if (IsRetailDay(startDate))
                    retail += vehiclesSold;
                else
                    corporate += vehiclesSold;

                startDate = startDate.AddDays(1);
            }

            Console.WriteLine($"No. of Vehicles sold from {s} to {endDate}: {total}");
            Console.WriteLine($"No. of Venices sold to retail customers: {retail}");
            Console.WriteLine($"No. of Venices sold to corporate customers: {corporate}");
        }

        static void DisplayRetailAndCorporateSales(DateTime startDate, DateTime endDate)
        {
            int retail = 0;
            int corporate = 0;

            while (startDate <= endDate)
            {
                int vehiclesSold = GetVehiclesSoldOnDay(startDate);

                if (IsRetailDay(startDate))
                    retail += vehiclesSold;
                else
                    corporate += vehiclesSold;

                startDate = startDate.AddDays(1);
            }

            Console.WriteLine($"Venices sold to retail customers: {retail}");
            Console.WriteLine($"Venices sold to corporate customers: {corporate}");
        }

        static void DisplaySalesInRange(DateTime startDate, DateTime endDate)
        {
            int totalSales = 0;
            

            while (startDate <= endDate)
            {
                totalSales += GetVehiclesSoldOnDay(startDate);
                startDate = startDate.AddDays(1);
            }

            Console.WriteLine($"Number of Vehicles sold from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}: {totalSales}");
        }

        static int GetVehiclesSoldOnDay(DateTime date)
        {
            int day = date.Day;

            if (day == 1)
                return 1;
            else if (day % 5 == 0)
                return (day - 1) * 2; 
            else
                return (day - 1) * 2 + 2; 
        }

        static bool IsRetailDay(DateTime date)
        {
            return date.Day % 5 != 0;
        }
    }
}
