public class WordDocument : Document
{
    public WordDocument(string name) : base(name) {}

    public override void Open()
    {
        Console.WriteLine("Opening Word document: " + name);
    }
    public override void Save()
    {
        Console.WriteLine("Saving docs " + name);
    }
}
