public class PdfDocumentFactory : DocumentFactory
{
    public override Document CreateDocument(string name)
    {
        return new PdfDocument(name);
    }
}
