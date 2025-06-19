public class ExcelDocumentFactory : DocumentFactory
{
    public override Document CreateDocument(string name)
    {
        return new ExcelDocument(name);
    }
}
