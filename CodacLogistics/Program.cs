using System;

/*
 Codac Logistics - Fuel Auditor
 Records weekly fuel expenses and calculates efficiency.
*/

namespace CodacLogistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CODAC LOGISTICS DELIVERY & FUEL AUDITOR ===\n");

            // Ask for driver's full name
            Console.Write("Enter Driver's Full Name: ");
            string driverName = Console.ReadLine();

            // Ask for weekly fuel budget (decimal for money accuracy)
            Console.Write("Enter Weekly Fuel Budget: ");
            decimal weeklyBudget = Convert.ToDecimal(Console.ReadLine());

            // Validate total distance (must be between 1 and 5000 km)
            double totalDistance;
            while (true)
            {
                Console.Write("Enter Total Distance Traveled this week (km): ");
                totalDistance = Convert.ToDouble(Console.ReadLine());

                if (totalDistance >= 1.0 && totalDistance <= 5000.0)
                    break;
                else
                    Console.WriteLine("Invalid input! Distance must be between 1 and 5000.\n");
            }

            // Store fuel expenses for 5 days
            decimal[] fuelExpenses = new decimal[5];
            decimal totalFuelSpent = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter fuel expense for Day {i + 1}: ");
                fuelExpenses[i] = Convert.ToDecimal(Console.ReadLine());

                // Add each day's expense to total
                totalFuelSpent += fuelExpenses[i];
            }

            // Calculate average daily fuel expense
            decimal averageExpense = totalFuelSpent / 5;

            // Calculate fuel efficiency
            double efficiency = (double)totalDistance / (double)totalFuelSpent;
            string efficiencyRating;

            if (efficiency > 15)
                efficiencyRating = "High Efficiency";
            else if (efficiency >= 10)
                efficiencyRating = "Standard Efficiency";
            else
                efficiencyRating = "Low Efficiency / Maintenance Required";

            // Check if driver stayed within budget
            bool isUnderBudget = totalFuelSpent <= weeklyBudget;

            // Display audit report
            Console.WriteLine("\n========== WEEKLY AUDIT REPORT ==========");
            Console.WriteLine($"Driver Name: {driverName}");
            Console.WriteLine($"Total Distance: {totalDistance} km");

            Console.WriteLine("\n--- 5 Day Fuel Expenses ---");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Day {i + 1}: {fuelExpenses[i]}");
            }

            Console.WriteLine($"\nTotal Fuel Spent: {totalFuelSpent}");
            Console.WriteLine($"Average Daily Expense: {averageExpense}");
            Console.WriteLine($"Efficiency Rating: {efficiencyRating}");
            Console.WriteLine($"Stayed Under Budget? {(isUnderBudget ? "YES" : "NO")}");

            Console.WriteLine("\n=========================================");
            Console.ReadLine();
        }
    }
}