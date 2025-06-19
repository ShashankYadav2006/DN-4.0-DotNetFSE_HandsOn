import java.util.*;
//Exercise - 2
class Item {
    private int id;
    private String name;
    private String type;
    public Item(int id, String name, String type) {
        this.id = id;
        this.name = name;
        this.type = type;
    }
    public int getId() { return id; }
    public String getName() { return name; }
    public String getType() { return type; }
    @Override
    public String toString() {
        return "[ID: " + id + ", Name: " + name + ", Type: " + type + "]";
    }
}
class SearchEngine {
    private Item[] unsortedItems;
    private Item[] sortedItems;
    private int itemCount;
    public SearchEngine() {
        System.out.println("Initializing search functionality for platform...");
        loadItems();
    }
    private void loadItems() {
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
        sortedItems = Arrays.copyOf(unsortedItems, itemCount);
        Arrays.sort(sortedItems, Comparator.comparingInt(Item::getId));
        System.out.println("Items database loaded successfully.");
    }
    public Item linearFind(int targetId) {
        System.out.println("Performing linear search for item ID: " + targetId);
        for (int i = 0; i < itemCount; i++) {
            if (unsortedItems[i].getId() == targetId) {
                System.out.println("Item located at index " + i);
                return unsortedItems[i];
            }
        }
        System.out.println("No item found with ID " + targetId);
        return null;
    }
    public Item binaryFind(int targetId) {
        System.out.println("Performing binary search for item ID: " + targetId);
        int start = 0;
        int end = itemCount - 1;
        while (start <= end) {
            int mid = (start + end) / 2;
            int midId = sortedItems[mid].getId();
            if (midId == targetId) {
                System.out.println("Item located at index " + mid + " in sorted array.");
                return sortedItems[mid];
            }
            if (targetId > midId) {
                start = mid + 1;
            } else {
                end = mid - 1;
            }
        }
        System.out.println("No item found with ID " + targetId);
        return null;
    }
    public void showComplexityAnalysis() {
        System.out.println("\nUnderstanding Algorithm Efficiency");
        System.out.println("Big O notation indicates how runtime grows with input size.");
        System.out.println("\nLinear Search->");
        System.out.println("Best Case: O(1)");
        System.out.println("Average Case: O(n/2)");
        System.out.println("Worst Case: O(n)");
        System.out.println("\nBinary Search->");
        System.out.println("Best Case: O(1)");
        System.out.println("Average/Worst Case: O(log n)");
        System.out.println("Note: Binary search requires data to be sorted.");
        System.out.println("\nPractical Advice->");
        System.out.println("Use linear search for small or unsorted lists.");
        System.out.println("Use binary search for performance in large sorted datasets.");
    }
}

public class EcommerceSearchMain {
    public static void main(String[] args) {
        System.out.println("Welcome to E-commerce Product Search");
        SearchEngine engine = new SearchEngine();
        System.out.println("\nLinear Search Execution");
        Item found1 = engine.linearFind(190);
        if (found1 != null) System.out.println("Result: " + found1);
        System.out.println("\nBinary Search Execution");
        Item found2 = engine.binaryFind(190);
        if (found2 != null) System.out.println("Result: " + found2);
        System.out.println("\n Search for Non-Existent Item ");
        engine.linearFind(999);
        engine.binaryFind(999);
        engine.showComplexityAnalysis();
    }
}
