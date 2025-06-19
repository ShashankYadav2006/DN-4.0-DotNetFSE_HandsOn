import java.util.*;
//Excercise - 7
class ForecastEngine {
    private Map<String, Double> memo;
    public ForecastEngine() {
        memo = new HashMap<>();
        System.out.println("Initialized Forecasting Engine");
        describeRecursion();
    }
    public void describeRecursion() {
        System.out.println("\nWhat is Recursion?");
        System.out.println("Recursion occurs when a method calls itself repeatedly.");
        System.out.println("Used to break down repetitive, structured calculations.");
        System.out.println("Three must-haves:");
        System.out.println("- A stopping condition (base case)");
        System.out.println("- A self-referencing call with a smaller input");
        System.out.println("- A step closer to termination");
    }
    public double futureValueRecursive(double amount, double rate, int period) {
        System.out.println("Year: " + period + ", Value: $" + String.format("%.2f", amount));
        if (period == 0) {
            return amount;
        }
        return futureValueRecursive(amount * (1 + rate), rate, period - 1);
    }
    public double forecastUsingGrowthRates(double baseValue, double[] rateList, int index) {
        if (index == rateList.length) {
            System.out.println("Forecast complete. Final amount: $" + String.format("%.2f", baseValue));
            return baseValue;
        }

        double updated = baseValue * (1 + rateList[index]);
        System.out.println("Year " + (index + 1) + ": Growth " + (rateList[index] * 100) + "% -> $" + String.format("%.2f", updated));

        return forecastUsingGrowthRates(updated, rateList, index + 1);
    }
    public double optimizedFutureValue(double value, double rate, int time) {
        String memoKey = value + "_" + rate + "_" + time;

        if (memo.containsKey(memoKey)) {
            System.out.println("Cache hit for " + time + " years");
            return memo.get(memoKey);
        }
        double result;
        if (time == 0) {
            result = value;
        } else {
            result = optimizedFutureValue(value * (1 + rate), rate, time - 1);
        }
        memo.put(memoKey, result);
        return result;
    }
    public void showTimeComplexityInsights() {
        System.out.println("\nTime & Space Analysis");
        System.out.println("Recursive model has:");
        System.out.println("- Time: O(n) where n = number of periods");
        System.out.println("- Space: O(n) due to call stack");
        System.out.println("Risks:");
        System.out.println("- Stack overflow if recursion too deep");
        System.out.println("- Repeating calculations without optimization");
        System.out.println("\nOptimizing Recursion:");
        System.out.println("1. Use memoization");
        System.out.println("2. Use tail recursion if possible");
        System.out.println("3. Convert to iteration");
        System.out.println("4. Apply formulas for predictable calculations");
    }
}

public class ForecastDemo {
    public static void main(String[] args) {
        System.out.println("Recursive Financial Forecast");
        ForecastEngine engine = new ForecastEngine();
        System.out.println("\nBasic Recursive Forecast");
        double startAmount = 12000;
        double rate = 0.06;
        int duration = 6;
        double result = engine.futureValueRecursive(startAmount, rate, duration);
        System.out.println("Future Value: $" + String.format("%.2f", result));
        System.out.println("\nGrowth Rate-Based Forecast");
        double[] yearlyRates = {0.09, 0.05, 0.08, 0.07, 0.04};
        double forecasted = engine.forecastUsingGrowthRates(10000, yearlyRates, 0);
        System.out.println("Predicted Total: $" + String.format("%.2f", forecasted));
        engine.showTimeComplexityInsights();
    }
}
