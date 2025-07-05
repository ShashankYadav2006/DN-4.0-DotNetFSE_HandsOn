using RetailInventory.Data;
using RetailInventory.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();
        var products = await context.Products.ToListAsync();
        Console.WriteLine(" All Products:");
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - ₹{p.Price}");

        var product = await context.Products.FindAsync(1);
        Console.WriteLine($"\n Found by ID 1: {product?.Name}");
        var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
        Console.WriteLine($"\n First Expensive Product (> ₹50,000): {expensive?.Name}");
    }
}
