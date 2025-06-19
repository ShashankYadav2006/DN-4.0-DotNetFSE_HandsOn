public class ExcelDocument : Document
{
    public ExcelDocument(string name) : base(name) {}
    public override void Open()
    {
        Console.WriteLine("Launching Excel sheet: " + name);
    }
    public override void Save()
    {
        Console.WriteLine("Saving spreadsheet " + name);
    }
}
