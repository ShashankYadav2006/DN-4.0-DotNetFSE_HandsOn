using System;
using System.Linq;

// Exercise - 2
public class Item
{
    private int id;
    private string name;
    private string type;

    public Item(int id, string name, string type)
    {
        this.id = id;
        this.name = name;
        this.type = type;
    }

    public int GetId() { return id; }
    public string GetName() { return name; }
    public string GetType() { return type; }

    public override string ToString()
    {
        return "[ID: " + id + ", Name: " + name + ", Type: " + type + "]";
    }
}

public class SearchEngine
{
    private Item[] unsortedItems;
    private Item[] sortedItems;
    private int itemCount;

    public SearchEngine()
    {
        Console.WriteLine("Initializing search functionality for platform...");
        LoadItems();
    }

    private void LoadItems()
    {
        itemCount = 8;
        unsortedItems = new Item[itemCount];
        unsortedItems[0] = new Item(101, "Samsung Galaxy", "Mobiles");
        unsortedItems[1] = new Item(205, "Running Shoes", "Footwear");
        unsortedItems[2] = new Item(84, "Microwave Oven", "Appliances");
        unsortedItems[3] = new Item(33, "Backpack", "Accessories");
        unsortedItems[4] = new Item(190, "Bluetooth Speaker", "Electronics");
        unsortedItems[5] = new Item(150, "LED Monitor", "Computers");
        unsortedItems[6] = new Item(98, "Smart Bulb", "Home");
        unsortedItems[7] = new Item(77, "Yoga Mat", "Fitness");

        sortedItems = new Item[itemCount];
        Array.Copy(unsortedItems, sortedItems, itemCount);
        Array.Sort(sortedItems, (x, y) => x.GetId().CompareTo(y.GetId()));
        Console.WriteLine("Items database loaded successfully.");
    }

    public Item LinearFind(int targetId)
    {
        Console.WriteLine("Performing linear search for item ID: " + targetId);
        for (int i = 0; i < itemCount; i++)
        {
            if (unsortedItems[i].GetId() == targetId)
            {
                Console.WriteLine("Item located at index " + i);
                return unsortedItems[i];
            }
        }
        Console.WriteLine("No item found with ID " + targetId);
        return null;
    }

    public Item BinaryFind(int targetId)
    {
        Console.WriteLine("Performing binary search for item ID: " + targetId);
        int start = 0;
        int end = itemCount - 1;

        while (start <= end)
        {
            int mid = (start + end) / 2;
            int midId = sortedItems[mid].GetId();

            if (midId == targetId)
            {
                Console.WriteLine("Item located at index " + mid + " in sorted array.");
                return sortedItems[mid];
            }

            if (targetId > midId)
            {
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }
        Console.WriteLine("No item found with ID " + targetId);
        return null;
    }

    public void ShowComplexityAnalysis()
    {
        Console.WriteLine("\nUnderstanding Algorithm Efficiency");
        Console.WriteLine("Big O notation indicates how runtime grows with input size.");
        Console.WriteLine("\nLinear Search->");
        Console.WriteLine("Best Case: O(1)");
        Console.WriteLine("Average Case: O(n/2)");
        Console.WriteLine("Worst Case: O(n)");
        Console.WriteLine("\nBinary Search->");
        Console.WriteLine("Best Case: O(1)");
        Console.WriteLine("Average/Worst Case: O(log n)");
        Console.WriteLine("Note: Binary search requires data to be sorted.");
        Console.WriteLine("\nPractical Advice->");
        Console.WriteLine("Use linear search for small or unsorted lists.");
        Console.WriteLine("Use binary search for performance in large sorted datasets.");
    }
}

public class EcommerceSearchMain
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to E-commerce Product Search");
        SearchEngine engine = new SearchEngine();

        Console.WriteLine("\nLinear Search Execution");
        Item found1 = engine.LinearFind(190);
        if (found1 != null) Console.WriteLine("Result: " + found1);

        Console.WriteLine("\nBinary Search Execution");
        Item found2 = engine.BinaryFind(190);
        if (found2 != null) Console.WriteLine("Result: " + found2);

        Console.WriteLine("\n Search for Non-Existent Item ");
        engine.LinearFind(999);
        engine.BinaryFind(999);

        engine.ShowComplexityAnalysis();
    }
}
