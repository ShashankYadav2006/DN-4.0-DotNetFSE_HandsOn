public class WordDocumentFactory : DocumentFactory
{
    public override Document CreateDocument(string name)
    {
        return new WordDocument(name);
    }
}
