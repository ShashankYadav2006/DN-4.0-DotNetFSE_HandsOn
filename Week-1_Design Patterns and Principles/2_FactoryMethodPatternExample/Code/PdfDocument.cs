public class PdfDocument : Document
{
    public PdfDocument(string name) : base(name) {}
    public override void Open()
    {
        Console.WriteLine("Opening PDF document: " + name);
    }
    public override void Save()
    {
        Console.WriteLine("Saving PDF " + name);
    }
}
