using System;
using System.Collections.Generic;

// Exercise - 7
public class ForecastEngine
{
    private Dictionary<string, double> memo;

    public ForecastEngine()
    {
        memo = new Dictionary<string, double>();
        Console.WriteLine("Initialized Forecasting Engine");
        DescribeRecursion();
    }

    public void DescribeRecursion()
    {
        Console.WriteLine("\nWhat is Recursion?");
        Console.WriteLine("Recursion occurs when a method calls itself repeatedly.");
        Console.WriteLine("Used to break down repetitive, structured calculations.");
        Console.WriteLine("Three must-haves:");
        Console.WriteLine("- A stopping condition (base case)");
        Console.WriteLine("- A self-referencing call with a smaller input");
        Console.WriteLine("- A step closer to termination");
    }

    public double FutureValueRecursive(double amount, double rate, int period)
    {
        Console.WriteLine("Year: " + period + ", Value: $" + amount.ToString("F2"));
        
        if (period == 0)
        {
            return amount;
        }
        
        return FutureValueRecursive(amount * (1 + rate), rate, period - 1);
    }

    public double ForecastUsingGrowthRates(double baseValue, double[] rateList, int index)
    {
        if (index == rateList.Length)
        {
            Console.WriteLine("Forecast complete. Final amount: $" + baseValue.ToString("F2"));
            return baseValue;
        }

        double updated = baseValue * (1 + rateList[index]);
        Console.WriteLine("Year " + (index + 1) + ": Growth " + (rateList[index] * 100) + "% -> $" + updated.ToString("F2"));

        return ForecastUsingGrowthRates(updated, rateList, index + 1);
    }

    public double OptimizedFutureValue(double value, double rate, int time)
    {
        string memoKey = value + "_" + rate + "_" + time;

        if (memo.ContainsKey(memoKey))
        {
            Console.WriteLine("Cache hit for " + time + " years");
            return memo[memoKey];
        }

        double result;
        if (time == 0)
        {
            result = value;
        }
        else
        {
            result = OptimizedFutureValue(value * (1 + rate), rate, time - 1);
        }

        memo[memoKey] = result;
        return result;
    }

    public void ShowTimeComplexityInsights()
    {
        Console.WriteLine("\nTime & Space Analysis");
        Console.WriteLine("Recursive model has:");
        Console.WriteLine("- Time: O(n) where n = number of periods");
        Console.WriteLine("- Space: O(n) due to call stack");
        Console.WriteLine("Risks:");
        Console.WriteLine("- Stack overflow if recursion too deep");
        Console.WriteLine("- Repeating calculations without optimization");
        Console.WriteLine("\nOptimizing Recursion:");
        Console.WriteLine("1. Use memoization");
        Console.WriteLine("2. Use tail recursion if possible");
        Console.WriteLine("3. Convert to iteration");
        Console.WriteLine("4. Apply formulas for predictable calculations");
    }
}

public class ForecastDemo
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Recursive Financial Forecast");
        ForecastEngine engine = new ForecastEngine();

        Console.WriteLine("\nBasic Recursive Forecast");
        double startAmount = 12000;
        double rate = 0.06;
        int duration = 6;
        double result = engine.FutureValueRecursive(startAmount, rate, duration);
        Console.WriteLine("Future Value: $" + result.ToString("F2"));

        Console.WriteLine("\nGrowth Rate-Based Forecast");
        double[] yearlyRates = { 0.09, 0.05, 0.08, 0.07, 0.04 };
        double forecasted = engine.ForecastUsingGrowthRates(10000, yearlyRates, 0);
        Console.WriteLine("Predicted Total: $" + forecasted.ToString("F2"));

        engine.ShowTimeComplexityInsights();
    }
}
